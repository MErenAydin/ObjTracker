using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using OpenCvSharp;

namespace ObjTracker
{
    internal static class Program
    {
        



        public static int Main(string[] args)
		{
            Scalar greenLower = new Scalar(29, 86, 6);
            Scalar greenUpper = new Scalar(64, 255, 255);
            const string PORT = "COM5";
            const int BAUD_RATE = 115200;
            Console.WriteLine("Connecting Serial Port");
            SerialPort serial = new SerialPort(PORT, BAUD_RATE);
            serial.Open();
            Console.WriteLine("Connected " + PORT + " with " + BAUD_RATE + " baud rate");
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
										while (client.Connected && stream.CanWrite)
										{
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
                                                        
                                                    }

                                                }

                                                Cv2.ImEncode(".jpg", imgMatrix, out byte[] result, encoderParam);
												writer.Write(result.Length);
												stream.Write(result, 0, result.Length);
												Console.Write($"\r{result.Length}        ");
											}
										}
									}
									finally
									{
										Console.Error.WriteLine();
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
				Console.Error.WriteLine(ex.Message);
				goto re;
			}
			catch (IOException ex)
			{
				Console.Error.WriteLine(ex.Message);
				goto re;
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex);
				return 1;
			}
			finally
			{
				listener.Stop();
				Console.Error.WriteLine("\n");
			}
			//goto re;
			return 0;
		}
	}
}
