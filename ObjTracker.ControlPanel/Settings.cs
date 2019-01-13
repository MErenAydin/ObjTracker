using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;
using System.Windows.Forms;

namespace ObjTracker.ControlPanel
{
	public sealed class Settings : ICloneable
	{
		public static Settings Current = new Settings();

		public static readonly string SettingsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ObjTracker.ControlPanel",
			SettingsPath = SettingsDir + "\\settings.xml";

		public int frameWidth = 640, frameHeight = 480, fps = 30;
		public string address = "127.0.0.1:5050";
		public FormWindowState windowState = FormWindowState.Normal;
		
		public static void Reload()
		{
			if (File.Exists(SettingsPath))
			{
				try
				{
					using (FileStream settings = new FileStream(SettingsPath, FileMode.Open, FileAccess.Read))
					{
						XmlSerializer xs = new XmlSerializer(typeof(Settings));
						Current = (Settings)xs.Deserialize(settings);
					}
				}
				catch
				{
					try
					{
						File.Delete(SettingsPath);
					}
					catch { }
				}
			}
		}

		public static void Save()
		{
			if (!Directory.Exists(SettingsDir))
				Directory.CreateDirectory(SettingsDir);
			using (FileStream settings = new FileStream(SettingsPath, FileMode.Create, FileAccess.Write))
			{
				XmlSerializer xs = new XmlSerializer(typeof(Settings));
				xs.Serialize(settings, Current);
			}
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
