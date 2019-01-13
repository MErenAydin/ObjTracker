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

using OpenCvSharp;

namespace ObjTracker
{
	internal static class Program
	{
		public static int Main(string[] args)
		{
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
									try
									{
										while (client.Connected && stream.CanWrite)
										{
											if (cap.Read(imgMatrix))
											{
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
