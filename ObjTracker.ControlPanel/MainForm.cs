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
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			Settings.Reload();
			this.WindowState = Settings.Current.windowState;
			textBox_Address.Text = Settings.Current.address;
			textBox_Fps.Text = Settings.Current.fps.ToString();
			textBox_FrameWidth.Text = Settings.Current.frameWidth.ToString();
			textBox_FrameHeight.Text = Settings.Current.frameHeight.ToString();
		}

		private const string connectStr = "Connect",
			disconnectStr = "Disconnect",
			connectedStr = "Connected",
			disconnectedStr = "Disconnected";

		Thread videoThread;

		long running = 0, cancelled = 0;

		Command command = Command.None;

		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		private void ReceiveVideoAsync(object arg)
		{
			var client = (TcpClient)arg;
			var stream = client.GetStream();
			try
			{
				Interlocked.Exchange(ref running, 1);
				MethodInvoker uiConnected = () =>
				{
					groupBox_Settings.Enabled = false;
					button_Connect.Text = disconnectStr;
					toolStripStatusLabel_Status.Text = connectedStr;
				};
				this.Invoke(uiConnected);

				using (var reader = new BinaryReader(stream, System.Text.Encoding.ASCII, true))
				{
					using (var writer = new BinaryWriter(stream, System.Text.Encoding.ASCII, true))
					{
						var img = new Mat();

						int fps = 0, lastFps = 0, lastWidth = 0, lastHeight = 0;

						MethodInvoker invoker = () =>
							{
								var tmp = frameBox.Image;
								frameBox.Image = BitmapConverter.ToBitmap(img);
								//frameBox.Refresh();
								if (img.Width != lastWidth)
								{
									toolStripStatusLabel_Width.Text = img.Width.ToString();
									lastWidth = img.Width;
								}
								if (img.Height != lastHeight)
								{
									toolStripStatusLabel_Height.Text = img.Height.ToString();
									lastHeight = img.Height;
								}
								if (fps != lastFps)
								{
									toolStripStatusLabel_Fps.Text = fps.ToString();
									lastFps = fps;
								}
								tmp?.Dispose();
							};

						int fpsCounter = 0;
						Stopwatch sw = Stopwatch.StartNew();
						try
						{
							while (Interlocked.Read(ref cancelled) == 0 && client.Connected && stream.CanRead)
							{
                                writer.Write((byte)command);
                                int size = reader.ReadInt32();
                                if (size < 0)
									throw new ApplicationException(size.ToString());
								{
									byte[] imgBuffer = stream.ReadAll(size);
									img = Cv2.ImDecode(imgBuffer, ImreadModes.Color);
                                    
                                    if (img.Size() != OpenCvSharp.Size.Zero)
									{
										frameBox.Invoke(invoker); //Execute in UI thread
										fpsCounter++;
									}
									if (sw.ElapsedMilliseconds >= 1000)
									{
										sw.Restart();
										fps = fpsCounter;
										fpsCounter = 0;
									}

                                    
                                }
								GC.Collect(0, GCCollectionMode.Forced, false, true);
							}
						}
						finally
						{
							sw.Stop();
						}
					}
				}
			}
			catch (EndOfStreamException ex)
			{
				this.Invoke((MethodInvoker)(() => 
				MessageBox.Show(this, ex.ToString(), "Stream Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
			}
			catch (IOException ex)
			{
				this.Invoke((MethodInvoker)(() =>
				MessageBox.Show(this, ex.ToString(), "Stream Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
			}
			finally
			{
				Interlocked.Exchange(ref running, 0);
				stream.Close();
				client.Close();
				MethodInvoker uiDisconnected = () =>
				{
					groupBox_Settings.Enabled = true;
					button_Connect.Text = connectStr;
					toolStripStatusLabel_Status.Text = disconnectedStr;
				};
				this.Invoke(uiDisconnected);
				GC.Collect();
			}
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			textBox_Address.Select();
		}

		private void button_Connect_Click(object sender, EventArgs e)
		{
			if (Interlocked.Read(ref running) == 0)
			{
				if (!(Extensions.TryCreateIPEndPoint(textBox_Address.Text, out IPEndPoint endPoint) &&
					int.TryParse(textBox_FrameWidth.Text, out int w) &&
					int.TryParse(textBox_FrameHeight.Text, out int h) &&
					int.TryParse(textBox_Fps.Text, out int fps) &&
					int.TryParse(textBox_Quality.Text, out int quality)))
					return;

				TcpClient conn = new TcpClient();
				try
				{
					conn.Connect(endPoint);
					toolStripStatusLabel_Address.Text = endPoint.ToString();
				}
				catch (SocketException ex)
				{
					MessageBox.Show(this, ex.ToString(), "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					conn.Dispose();
					return;
				}
				using (var writer = new BinaryWriter(conn.GetStream(), System.Text.Encoding.ASCII, true))
				{
					writer.Write(w);
					writer.Write(h);
					writer.Write(fps);
					writer.Write(quality);
				}
				Interlocked.Exchange(ref cancelled, 0);
				videoThread = new Thread(ReceiveVideoAsync) { IsBackground = true };
				videoThread.Start(conn);
			}
			else
			{
				Interlocked.Exchange(ref cancelled, 1);
				while (Interlocked.Read(ref running) == 1)
					Application.DoEvents();
			}
		}

		private void PassSettings()
		{
			if (int.TryParse(textBox_FrameWidth.Text, out int w))
				Settings.Current.frameWidth = w;

			if (int.TryParse(textBox_FrameHeight.Text, out int h))
				Settings.Current.frameHeight = h;

			if (int.TryParse(textBox_Fps.Text, out int fps))
				Settings.Current.fps = fps;

			if (Extensions.TryCreateIPEndPoint(textBox_Address.Text, out IPEndPoint result))
				Settings.Current.address = textBox_Address.Text;

			Settings.Current.windowState = this.WindowState;
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			PassSettings();
			Settings.Save();
			Interlocked.Exchange(ref cancelled, 1);
			while (Interlocked.Read(ref running) == 1)
				Application.DoEvents();
		}

		#region Validators
		Color errorColor = Color.FromArgb(255, 128, 128);

		private void textBox_FrameWidth_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(textBox_FrameWidth.Text, out int w))
				textBox_FrameWidth.BackColor = SystemColors.Window;
			else
				textBox_FrameWidth.BackColor = errorColor;
		}

		private void textBox_FrameHeight_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(textBox_FrameHeight.Text, out int h))
				textBox_FrameHeight.BackColor = SystemColors.Window;
			else
				textBox_FrameHeight.BackColor = errorColor;
		}

		private void textBox_Fps_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(textBox_Fps.Text, out int fps))
				textBox_Fps.BackColor = SystemColors.Window;
			else
				textBox_Fps.BackColor = errorColor;
		}

		private void textBox_Address_TextChanged(object sender, EventArgs e)
		{
			if (Extensions.TryCreateIPEndPoint(textBox_Address.Text, out IPEndPoint result))
				textBox_Address.BackColor = SystemColors.Window;
			else
				textBox_Address.BackColor = errorColor;
		}
		#endregion

		#region Mouse Commands
		//Movement
		private void button_MoveForward_MouseDown(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.MoveAuto) ? command : (command | Command.MoveForward);

		private void button_MoveBackward_MouseDown(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.MoveAuto) ? command : (command | Command.MoveBackward);

		private void button_MoveRight_MouseDown(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.MoveAuto) ? command : (command | Command.MoveRight);

		private void button_MoveLeft_MouseDown(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.MoveAuto) ? command : (command | Command.MoveLeft);

		private void button_MoveForward_MouseUp(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.MoveAuto) ? command : (command & ~Command.MoveForward);

		private void button_MoveBackward_MouseUp(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.MoveAuto) ? command : (command & ~Command.MoveBackward);

		private void button_MoveRight_MouseUp(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.MoveAuto) ? command : (command & ~Command.MoveRight);

		private void button_MoveLeft_MouseUp(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.MoveAuto) ? command : (command & ~Command.MoveLeft);

		private void checkBox_AutoMove_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_AutoMove.Checked)
				command |= Command.MoveAuto;
			else
				command &= ~Command.MoveAuto;
		}

		//Camera
		private void button_CamUp_MouseDown(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.CamAuto) ? command : (command | Command.CamUp);

		private void button_CamDown_MouseDown(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.CamAuto) ? command : (command | Command.CamDown);

		private void button_CamRight_MouseDown(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.CamAuto) ? command : (command | Command.CamRight);

		private void button_CamLeft_MouseDown(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.CamAuto) ? command : (command | Command.CamLeft);

		private void button_CamUp_MouseUp(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.CamAuto) ? command : (command & ~Command.CamUp);

		private void button_CamDown_MouseUp(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.CamAuto) ? command : (command & ~Command.CamDown);

		private void button_CamRight_MouseUp(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.CamAuto) ? command : (command & ~Command.CamRight);

		private void button_CamLeft_MouseUp(object sender, MouseEventArgs e) =>
			command = command.HasFlag(Command.CamAuto) ? command : (command & ~Command.CamLeft);

		private void checkBox_AutoCam_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_AutoCam.Checked)
				command |= Command.CamAuto;
			else
				command &= ~Command.CamAuto;
		}
		#endregion

		#region Keyboard Commands
		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (Interlocked.Read(ref running) == 0)
				return;
			e.Handled = true;
			switch (e.KeyCode)
			{
				case Keys.W:
					command |= Command.MoveForward;
					break;
				case Keys.S:
					command |= Command.MoveBackward;
					break;
				case Keys.D:
					command |= Command.MoveRight;
					break;
				case Keys.A:
					command |= Command.MoveLeft;
					break;
				case Keys.Up:
					command |= Command.CamUp;
					break;
				case Keys.Down:
					command |= Command.CamDown;
					break;
				case Keys.Right:
					command |= Command.CamRight;
					break;
				case Keys.Left:
					command |= Command.CamLeft;
					break;
				default:
					e.Handled = false;
					break;
			}
		}

		private void MainForm_KeyUp(object sender, KeyEventArgs e)
		{
			if (Interlocked.Read(ref running) == 0)
				return;
			e.Handled = true;
			switch (e.KeyCode)
			{
				case Keys.W:
					command |= Command.MoveForward;
					break;
				case Keys.S:
					command |= Command.MoveBackward;
					break;
				case Keys.D:
					command |= Command.MoveRight;
					break;
				case Keys.A:
					command |= Command.MoveLeft;
					break;
				case Keys.Up:
					command |= Command.CamUp;
					break;
				case Keys.Down:
					command |= Command.CamDown;
					break;
				case Keys.Right:
					command |= Command.CamRight;
					break;
				case Keys.Left:
					command |= Command.CamLeft;
					break;
				default:
					e.Handled = false;
					break;
			}
		}
		#endregion
	}
}
