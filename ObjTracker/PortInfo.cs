using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;

namespace ObjTracker
{
	public class PortInfo
	{
		public string DeviceID { get; private set; }
		public string Name { get; private set; }
		public string Caption { get; private set; }
		public string Description { get; private set; }

		public PortInfo(string deviceID, string name, string caption, string description)
		{
			DeviceID = deviceID;
			Name = name;
			Caption = caption;
			Description = description;
		}

		public static IEnumerable<PortInfo> GetPorts()
		{
			using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort"))
			{
				ManagementObjectCollection ports = searcher.Get();
				return ports.Cast<ManagementObject>().Select(
					(port) => new PortInfo(
						port["DeviceID"].ToString(),
						port["Name"].ToString(),
						port["Caption"].ToString(),
						port["Description"].ToString()
					)
				);
			}
		}
	}
}
