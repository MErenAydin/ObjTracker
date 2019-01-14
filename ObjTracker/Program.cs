using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using OpenCvSharp;

namespace ObjTracker
{

	internal static class Program
	{
		static readonly Scalar greenLower = new Scalar(29, 86, 6);
		static readonly Scalar greenUpper = new Scalar(64, 255, 255);

		const string serialDevice = "Arduino Uno";
		const int baudRate = 115200;

		public static int Main(string[] args)
		{
			SerialPort serial;
			try
			{
				IEnumerable<PortInfo> ports = PortInfo.GetPorts();
				string port = ports.FirstOrDefault((pi) => pi.Description == serialDevice)?.DeviceID;
				if (port != null)
					serial = new SerialPort(port, baudRate);
				else
					throw new IOException("Could not connect to serial port.");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return 1;
			}

			Console.WriteLine();
			TcpListener listener = new TcpListener(IPAddress.Any, 5050);
			re:
			try
			{
				listener.Start();
				Console.WriteLine("Listening " + listener.LocalEndpoint);
				using (var client = listener.AcceptTcpClient())
				{
					listener.Stop();
					Console.WriteLine("Connection established " + client.Client.RemoteEndPoint);
					using (NetworkStream stream = client.GetStream())
					{
						int width, height, fps, quality;
						using (var reader = new BinaryReader(stream, System.Text.Encoding.ASCII, true))
						{
							using (var writer = new BinaryWriter(stream, System.Text.Encoding.ASCII, true))
							{
								width = reader.ReadInt32();
								height = reader.ReadInt32();
								fps = reader.ReadInt32();
								quality = reader.ReadInt32();

								Console.WriteLine("Parameters received:");
								Console.WriteLine($"    Width:   {width}");
								Console.WriteLine($"    Height:  {height}");
								Console.WriteLine($"    Fps:     {fps}");
								Console.WriteLine($"    Quality: {quality}");

								var encoderParam = new ImageEncodingParam(ImwriteFlags.JpegQuality, quality);
								using (var cap = new VideoCapture(0) { FrameWidth = width, FrameHeight = height, Fps = fps })
								{
									Console.WriteLine("Started video capturing...");
									Mat imgMatrix = new Mat();
									Mat mask = new Mat();
									Mat tresh = new Mat();
                                    

									try
									{
										Scalar lastSeen = default(Scalar);
                                        bool autoPilot = false,
                                             camAuto = false,
                                             moveAuto = false,
                                             none;

                                        while (client.Connected && stream.CanWrite)
										{
                                            Command commandTaken = (Command)reader.ReadByte();

                                            autoPilot = commandTaken.HasFlag(Command.AutoPilot);
                                            camAuto = commandTaken.HasFlag(Command.CamAuto);
                                            moveAuto = commandTaken.HasFlag(Command.MoveAuto);
                                            none = commandTaken == Command.None;

                                           
                                            if (cap.Read(imgMatrix))
											{
												Cv2.CvtColor(imgMatrix, mask, ColorConversionCodes.BGR2HSV);
												Cv2.InRange(mask, greenLower, greenUpper, tresh);
												Cv2.Erode(tresh, tresh, null, iterations: 2);
												Cv2.Dilate(tresh, tresh, null, iterations: 2);

												Cv2.FindContours(
													tresh,
													out Point[][] contours,
													out HierarchyIndex[] hierarchyIndexes,
													RetrievalModes.External,
													ContourApproximationModes.ApproxSimple
													);

												if (contours.Length > 0)
												{
													contours.OrderBy(element => Cv2.ContourArea(element));
													Point[] max = contours[contours.Length - 1];

													Cv2.MinEnclosingCircle(max, out Point2f xy, out float radius);

													//Moments M = Cv2.Moments(max);
													//Point center = new Point((M.M10 / M.M00), (M.M01 / M.M00));

													Point center = new Point(xy.X, xy.Y);

													if (radius > 10.0f)
													{
														Cv2.Circle(imgMatrix, center, (int)radius, new Scalar(0, 255, 255), thickness: 2);
														Cv2.Circle(imgMatrix, center, 5, new Scalar(0, 0, 255), thickness: -1);

														//find the ball which region on the screen horizontally [0-5]
														int xRegion = center.X.Map(0, width, 0, 3);
														//find the ball which region on the screen vertically [0-5]
														int yRegion = center.Y.Map(0, height, 0, 3);
														//find the ball is too far from camera or too close
														int zRegion = ((int)radius).Map(10, 400, 0, 3);

														lastSeen = FindBallCoordinates((int)radius, center, new Point(width / 2, height / 2));

                                                        #region Automatic Decisions

                                                        Command command = 0;

                                                        if (autoPilot)
                                                        {
                                                            

														    if (xRegion < 1 && yRegion < 1)
															    command |= Command.CamLeft | Command.CamUp;
														    else if (xRegion < 1 && yRegion > 1)
															    command |= Command.CamLeft | Command.CamDown;
														    else if (xRegion > 1 && yRegion < 1)
															    command |= Command.CamRight | Command.CamUp;
														    else if (xRegion > 1 && yRegion > 1)
															    command |= Command.CamRight | Command.CamDown;
														    else if (xRegion < 1)
															    command |= Command.CamLeft;
														    else if (xRegion > 1)
															    command |= Command.CamRight;
														    else if (yRegion < 1)
															    command |= Command.CamUp;
														    else if (yRegion > 1)
															    command |= Command.CamDown;
														    if (zRegion > 1)
															    command |= Command.MoveBackward;
														    else if (zRegion < 1)
															    command |= Command.MoveForward;

														    byte[] message = { (byte)command };
														    serial.Write(message, 0, 1);

                                                        }

                                                        else if (camAuto)
                                                        {

                                                            if (xRegion < 1 && yRegion < 1)
                                                                command |= Command.CamLeft | Command.CamUp;
                                                            else if (xRegion < 1 && yRegion > 1)
                                                                command |= Command.CamLeft | Command.CamDown;
                                                            else if (xRegion > 1 && yRegion < 1)
                                                                command |= Command.CamRight | Command.CamUp;
                                                            else if (xRegion > 1 && yRegion > 1)
                                                                command |= Command.CamRight | Command.CamDown;
                                                            else if (xRegion < 1)
                                                                command |= Command.CamLeft;
                                                            else if (xRegion > 1)
                                                                command |= Command.CamRight;
                                                            else if (yRegion < 1)
                                                                command |= Command.CamUp;
                                                            else if (yRegion > 1)
                                                                command |= Command.CamDown;

                                                            byte[] message = { (byte)(command | (commandTaken & Command.MoveAuto))};
														    serial.Write(message, 0, 1);
                                                        }
                                                        else if (moveAuto)
                                                        {
                                                            if (zRegion > 1 && xRegion < 1)
                                                                command |= Command.MoveForward | Command.MoveLeft;
                                                            else if (zRegion > 1 && xRegion > 1)
                                                                command |= Command.MoveForward | Command.MoveRight;
                                                            else if (zRegion < 1 && xRegion < 1)
                                                                command |= Command.MoveBackward | Command.MoveRight;
                                                            else if (zRegion <1 && xRegion >1)
                                                                command |= Command.MoveBackward | Command.MoveLeft;
                                                            else if (zRegion > 1)
                                                                command |= Command.MoveBackward;
                                                            else if (zRegion < 1)
                                                                command |= Command.MoveForward;
                                                            else if (xRegion < 1)
                                                                command |= Command.MoveLeft;
                                                            else if (xRegion > 1)
                                                                command |= Command.MoveRight;

                                                            byte[] message = { (byte)(command | (commandTaken & Command.CamAuto)) };
                                                            serial.Write(message, 0, 1);
                                                        }

                                                        else if (none)
                                                        {
                                                            byte[] message = { (byte)(commandTaken) };
                                                            serial.Write(message, 0, 1);
                                                        }

                                                        
														#endregion
													}
													else
													{
														Console.WriteLine($"{lastSeen.ToString()}");
													}
												}

												Cv2.ImEncode(".jpg", imgMatrix, out byte[] result, encoderParam);
												writer.Write(result.Length);
												stream.Write(result, 0, result.Length);
											}
										}
									}
									finally
									{
										Console.WriteLine();
									}
								}
							}
						}
					}
				}
				Console.WriteLine("Done\n");
			}
			catch (EndOfStreamException ex)
			{
				Console.WriteLine(ex.Message);
				goto re;
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
				goto re;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return 1;
			}
			finally
			{
				listener.Stop();
				Console.WriteLine("\n");
			}
			//goto re;
			return 0;
		}

		static int Map(this int x, int in_min, int in_max, int out_min, int out_max)
		{
			return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
		}

		static Scalar FindBallCoordinates(int ballRadiusInPixel, Point centerOfBall, Point centerOfScreen, float ballDiameter = 6.5f)
		{
			//finding ball distance in centimeters from camera with precalculated constants
			double ballDist = 60 * 20 / (ballRadiusInPixel - 1);
			//relative coordinates according to camera
			double x = (centerOfBall.X - centerOfScreen.X) * ballDiameter / (ballRadiusInPixel - 1) / 2;
			double y = (centerOfBall.Y - centerOfScreen.Y) * ballDiameter / (ballRadiusInPixel - 1) / 2;
			double z = Math.Sqrt((Math.Pow(ballDist, 2) - Math.Pow(x, 2))) * 2;
			return new Scalar(x, y, z);
		}
	}
}
