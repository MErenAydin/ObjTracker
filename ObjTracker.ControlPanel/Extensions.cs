using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ObjTracker.ControlPanel
{
	public static class Extensions
	{
		public static byte[] ReadAll(this NetworkStream stream, int size)
		{
			byte[] buffer = new byte[size];
			for (int i = 0; i < size; )
			{
				int read = stream.Read(buffer, i, size - i);
				if (read == 0)
					return null;
				i += read;
			}
			return buffer;
		}

		public static bool TryCreateIPEndPoint(string endPoint, out IPEndPoint result)
		{
			string[] ep = endPoint.Split(':');
			if (ep.Length < 2)
			{
				result = null;
				return false;
			}
			IPAddress ip;
			if (ep.Length > 2)
			{
				if (!IPAddress.TryParse(string.Join(":", ep, 0, ep.Length - 1), out ip))
				{
					result = null;
					return false;
				}
			}
			else
			{
				if (!IPAddress.TryParse(ep[0], out ip))
				{
					result = null;
					return false;
				}
			}
			if (!int.TryParse(ep[ep.Length - 1], out int port) || port < IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
			{
				result = null;
				return false;
			}
			result = new IPEndPoint(ip, port);
			return true;
		}
	}
}
