namespace ObjTracker.ControlPanel
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.button_MoveBackward = new System.Windows.Forms.Button();
            this.button_MoveRight = new System.Windows.Forms.Button();
            this.button_MoveForward = new System.Windows.Forms.Button();
            this.button_MoveLeft = new System.Windows.Forms.Button();
            this.checkBox_AutoMove = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Address = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Width = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Height = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Fps = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox_Movement = new System.Windows.Forms.GroupBox();
            this.groupBox_Camera = new System.Windows.Forms.GroupBox();
            this.checkBox_AutoCam = new System.Windows.Forms.CheckBox();
            this.button_CamDown = new System.Windows.Forms.Button();
            this.button_CamRight = new System.Windows.Forms.Button();
            this.button_CamUp = new System.Windows.Forms.Button();
            this.button_CamLeft = new System.Windows.Forms.Button();
            this.textBox_FrameWidth = new System.Windows.Forms.TextBox();
            this.label_FrameSize = new System.Windows.Forms.Label();
            this.textBox_FrameHeight = new System.Windows.Forms.TextBox();
            this.textBox_Fps = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.frameBox = new System.Windows.Forms.PictureBox();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label_Address = new System.Windows.Forms.Label();
            this.groupBox_Settings = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Quality = new System.Windows.Forms.TextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip.SuspendLayout();
            this.groupBox_Movement.SuspendLayout();
            this.groupBox_Camera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameBox)).BeginInit();
            this.groupBox_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_MoveBackward
            // 
            this.button_MoveBackward.Location = new System.Drawing.Point(42, 93);
            this.button_MoveBackward.Name = "button_MoveBackward";
            this.button_MoveBackward.Size = new System.Drawing.Size(30, 30);
            this.button_MoveBackward.TabIndex = 0;
            this.button_MoveBackward.TabStop = false;
            this.button_MoveBackward.Text = "⯆";
            this.button_MoveBackward.UseVisualStyleBackColor = true;
            this.button_MoveBackward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MoveBackward_MouseDown);
            this.button_MoveBackward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MoveBackward_MouseUp);
            // 
            // button_MoveRight
            // 
            this.button_MoveRight.Location = new System.Drawing.Point(78, 57);
            this.button_MoveRight.Name = "button_MoveRight";
            this.button_MoveRight.Size = new System.Drawing.Size(30, 30);
            this.button_MoveRight.TabIndex = 0;
            this.button_MoveRight.TabStop = false;
            this.button_MoveRight.Text = "⯈";
            this.button_MoveRight.UseVisualStyleBackColor = true;
            this.button_MoveRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MoveRight_MouseDown);
            this.button_MoveRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MoveRight_MouseUp);
            // 
            // button_MoveForward
            // 
            this.button_MoveForward.Location = new System.Drawing.Point(42, 21);
            this.button_MoveForward.Name = "button_MoveForward";
            this.button_MoveForward.Size = new System.Drawing.Size(30, 30);
            this.button_MoveForward.TabIndex = 0;
            this.button_MoveForward.TabStop = false;
            this.button_MoveForward.Text = "⯅";
            this.button_MoveForward.UseVisualStyleBackColor = true;
            this.button_MoveForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MoveForward_MouseDown);
            this.button_MoveForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MoveForward_MouseUp);
            // 
            // button_MoveLeft
            // 
            this.button_MoveLeft.Location = new System.Drawing.Point(6, 57);
            this.button_MoveLeft.Name = "button_MoveLeft";
            this.button_MoveLeft.Size = new System.Drawing.Size(30, 30);
            this.button_MoveLeft.TabIndex = 0;
            this.button_MoveLeft.TabStop = false;
            this.button_MoveLeft.Text = "⯇";
            this.button_MoveLeft.UseVisualStyleBackColor = true;
            this.button_MoveLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MoveLeft_MouseDown);
            this.button_MoveLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MoveLeft_MouseUp);
            // 
            // checkBox_AutoMove
            // 
            this.checkBox_AutoMove.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_AutoMove.Location = new System.Drawing.Point(42, 57);
            this.checkBox_AutoMove.Name = "checkBox_AutoMove";
            this.checkBox_AutoMove.Size = new System.Drawing.Size(30, 30);
            this.checkBox_AutoMove.TabIndex = 0;
            this.checkBox_AutoMove.TabStop = false;
            this.checkBox_AutoMove.Text = "⬤";
            this.checkBox_AutoMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_AutoMove.UseVisualStyleBackColor = true;
            this.checkBox_AutoMove.CheckedChanged += new System.EventHandler(this.checkBox_AutoMove_CheckedChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Status,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel_Address,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel_Width,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel_Height,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_Fps});
            this.statusStrip.Location = new System.Drawing.Point(0, 586);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(790, 29);
            this.statusStrip.TabIndex = 3;
            // 
            // toolStripStatusLabel_Status
            // 
            this.toolStripStatusLabel_Status.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel_Status.Name = "toolStripStatusLabel_Status";
            this.toolStripStatusLabel_Status.Size = new System.Drawing.Size(103, 24);
            this.toolStripStatusLabel_Status.Text = "Disconnected";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(257, 24);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = "Address:";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel_Address
            // 
            this.toolStripStatusLabel_Address.Name = "toolStripStatusLabel_Address";
            this.toolStripStatusLabel_Address.Size = new System.Drawing.Size(16, 24);
            this.toolStripStatusLabel_Address.Text = "?";
            this.toolStripStatusLabel_Address.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(257, 24);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Width:";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel_Width
            // 
            this.toolStripStatusLabel_Width.Name = "toolStripStatusLabel_Width";
            this.toolStripStatusLabel_Width.Size = new System.Drawing.Size(16, 24);
            this.toolStripStatusLabel_Width.Text = "?";
            this.toolStripStatusLabel_Width.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(57, 24);
            this.toolStripStatusLabel4.Text = "Height:";
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel_Height
            // 
            this.toolStripStatusLabel_Height.Name = "toolStripStatusLabel_Height";
            this.toolStripStatusLabel_Height.Size = new System.Drawing.Size(16, 24);
            this.toolStripStatusLabel_Height.Text = "?";
            this.toolStripStatusLabel_Height.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 24);
            this.toolStripStatusLabel1.Text = "FPS:";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel_Fps
            // 
            this.toolStripStatusLabel_Fps.Name = "toolStripStatusLabel_Fps";
            this.toolStripStatusLabel_Fps.Size = new System.Drawing.Size(17, 24);
            this.toolStripStatusLabel_Fps.Text = "0";
            this.toolStripStatusLabel_Fps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox_Movement
            // 
            this.groupBox_Movement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Movement.AutoSize = true;
            this.groupBox_Movement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox_Movement.Controls.Add(this.checkBox_AutoMove);
            this.groupBox_Movement.Controls.Add(this.button_MoveBackward);
            this.groupBox_Movement.Controls.Add(this.button_MoveRight);
            this.groupBox_Movement.Controls.Add(this.button_MoveForward);
            this.groupBox_Movement.Controls.Add(this.button_MoveLeft);
            this.groupBox_Movement.Location = new System.Drawing.Point(664, 12);
            this.groupBox_Movement.Name = "groupBox_Movement";
            this.groupBox_Movement.Size = new System.Drawing.Size(114, 149);
            this.groupBox_Movement.TabIndex = 5;
            this.groupBox_Movement.TabStop = false;
            this.groupBox_Movement.Text = "Movement";
            // 
            // groupBox_Camera
            // 
            this.groupBox_Camera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Camera.AutoSize = true;
            this.groupBox_Camera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox_Camera.Controls.Add(this.checkBox_AutoCam);
            this.groupBox_Camera.Controls.Add(this.button_CamDown);
            this.groupBox_Camera.Controls.Add(this.button_CamRight);
            this.groupBox_Camera.Controls.Add(this.button_CamUp);
            this.groupBox_Camera.Controls.Add(this.button_CamLeft);
            this.groupBox_Camera.Location = new System.Drawing.Point(664, 167);
            this.groupBox_Camera.Name = "groupBox_Camera";
            this.groupBox_Camera.Size = new System.Drawing.Size(114, 149);
            this.groupBox_Camera.TabIndex = 5;
            this.groupBox_Camera.TabStop = false;
            this.groupBox_Camera.Text = "Camera";
            // 
            // checkBox_AutoCam
            // 
            this.checkBox_AutoCam.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_AutoCam.Location = new System.Drawing.Point(42, 57);
            this.checkBox_AutoCam.Name = "checkBox_AutoCam";
            this.checkBox_AutoCam.Size = new System.Drawing.Size(30, 30);
            this.checkBox_AutoCam.TabIndex = 0;
            this.checkBox_AutoCam.TabStop = false;
            this.checkBox_AutoCam.Text = "⬤";
            this.checkBox_AutoCam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_AutoCam.UseVisualStyleBackColor = true;
            this.checkBox_AutoCam.CheckedChanged += new System.EventHandler(this.checkBox_AutoCam_CheckedChanged);
            // 
            // button_CamDown
            // 
            this.button_CamDown.Location = new System.Drawing.Point(42, 93);
            this.button_CamDown.Name = "button_CamDown";
            this.button_CamDown.Size = new System.Drawing.Size(30, 30);
            this.button_CamDown.TabIndex = 0;
            this.button_CamDown.TabStop = false;
            this.button_CamDown.Text = "⯆";
            this.button_CamDown.UseVisualStyleBackColor = true;
            this.button_CamDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_CamDown_MouseDown);
            this.button_CamDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_CamDown_MouseUp);
            // 
            // button_CamRight
            // 
            this.button_CamRight.Location = new System.Drawing.Point(78, 57);
            this.button_CamRight.Name = "button_CamRight";
            this.button_CamRight.Size = new System.Drawing.Size(30, 30);
            this.button_CamRight.TabIndex = 0;
            this.button_CamRight.TabStop = false;
            this.button_CamRight.Text = "⯈";
            this.button_CamRight.UseVisualStyleBackColor = true;
            this.button_CamRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_CamRight_MouseDown);
            this.button_CamRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_CamRight_MouseUp);
            // 
            // button_CamUp
            // 
            this.button_CamUp.Location = new System.Drawing.Point(42, 21);
            this.button_CamUp.Name = "button_CamUp";
            this.button_CamUp.Size = new System.Drawing.Size(30, 30);
            this.button_CamUp.TabIndex = 0;
            this.button_CamUp.TabStop = false;
            this.button_CamUp.Text = "⯅";
            this.button_CamUp.UseVisualStyleBackColor = true;
            this.button_CamUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_CamUp_MouseDown);
            this.button_CamUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_CamUp_MouseUp);
            // 
            // button_CamLeft
            // 
            this.button_CamLeft.Location = new System.Drawing.Point(6, 57);
            this.button_CamLeft.Name = "button_CamLeft";
            this.button_CamLeft.Size = new System.Drawing.Size(30, 30);
            this.button_CamLeft.TabIndex = 0;
            this.button_CamLeft.TabStop = false;
            this.button_CamLeft.Text = "⯇";
            this.button_CamLeft.UseVisualStyleBackColor = true;
            this.button_CamLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_CamLeft_MouseDown);
            this.button_CamLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_CamLeft_MouseUp);
            // 
            // textBox_FrameWidth
            // 
            this.textBox_FrameWidth.Location = new System.Drawing.Point(293, 26);
            this.textBox_FrameWidth.Name = "textBox_FrameWidth";
            this.textBox_FrameWidth.Size = new System.Drawing.Size(54, 27);
            this.textBox_FrameWidth.TabIndex = 2;
            this.textBox_FrameWidth.Text = "640";
            this.textBox_FrameWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_FrameWidth.TextChanged += new System.EventHandler(this.textBox_FrameWidth_TextChanged);
            // 
            // label_FrameSize
            // 
            this.label_FrameSize.AutoSize = true;
            this.label_FrameSize.Location = new System.Drawing.Point(203, 29);
            this.label_FrameSize.Name = "label_FrameSize";
            this.label_FrameSize.Size = new System.Drawing.Size(84, 20);
            this.label_FrameSize.TabIndex = 0;
            this.label_FrameSize.Text = "Frame Size:";
            // 
            // textBox_FrameHeight
            // 
            this.textBox_FrameHeight.Location = new System.Drawing.Point(353, 26);
            this.textBox_FrameHeight.Name = "textBox_FrameHeight";
            this.textBox_FrameHeight.Size = new System.Drawing.Size(54, 27);
            this.textBox_FrameHeight.TabIndex = 3;
            this.textBox_FrameHeight.Text = "480";
            this.textBox_FrameHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_FrameHeight.TextChanged += new System.EventHandler(this.textBox_FrameHeight_TextChanged);
            // 
            // textBox_Fps
            // 
            this.textBox_Fps.Location = new System.Drawing.Point(454, 26);
            this.textBox_Fps.Name = "textBox_Fps";
            this.textBox_Fps.Size = new System.Drawing.Size(73, 27);
            this.textBox_Fps.TabIndex = 4;
            this.textBox_Fps.Text = "30";
            this.textBox_Fps.TextChanged += new System.EventHandler(this.textBox_Fps_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(413, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "FPS:";
            // 
            // frameBox
            // 
            this.frameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frameBox.BackColor = System.Drawing.Color.Black;
            this.frameBox.Location = new System.Drawing.Point(12, 12);
            this.frameBox.Name = "frameBox";
            this.frameBox.Size = new System.Drawing.Size(640, 480);
            this.frameBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.frameBox.TabIndex = 6;
            this.frameBox.TabStop = false;
            // 
            // textBox_Address
            // 
            this.textBox_Address.Location = new System.Drawing.Point(77, 26);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(120, 27);
            this.textBox_Address.TabIndex = 1;
            this.textBox_Address.Text = "127.0.0.1:5050";
            this.textBox_Address.TextChanged += new System.EventHandler(this.textBox_Address_TextChanged);
            // 
            // label_Address
            // 
            this.label_Address.AutoSize = true;
            this.label_Address.Location = new System.Drawing.Point(6, 29);
            this.label_Address.Name = "label_Address";
            this.label_Address.Size = new System.Drawing.Size(65, 20);
            this.label_Address.TabIndex = 0;
            this.label_Address.Text = "Address:";
            // 
            // groupBox_Settings
            // 
            this.groupBox_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_Settings.AutoSize = true;
            this.groupBox_Settings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox_Settings.Controls.Add(this.label_FrameSize);
            this.groupBox_Settings.Controls.Add(this.textBox_Address);
            this.groupBox_Settings.Controls.Add(this.textBox_FrameWidth);
            this.groupBox_Settings.Controls.Add(this.textBox_FrameHeight);
            this.groupBox_Settings.Controls.Add(this.label_Address);
            this.groupBox_Settings.Controls.Add(this.label1);
            this.groupBox_Settings.Controls.Add(this.textBox_Quality);
            this.groupBox_Settings.Controls.Add(this.label3);
            this.groupBox_Settings.Controls.Add(this.textBox_Fps);
            this.groupBox_Settings.Location = new System.Drawing.Point(12, 498);
            this.groupBox_Settings.Name = "groupBox_Settings";
            this.groupBox_Settings.Size = new System.Drawing.Size(677, 79);
            this.groupBox_Settings.TabIndex = 7;
            this.groupBox_Settings.TabStop = false;
            this.groupBox_Settings.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quality:";
            // 
            // textBox_Quality
            // 
            this.textBox_Quality.Location = new System.Drawing.Point(598, 26);
            this.textBox_Quality.Name = "textBox_Quality";
            this.textBox_Quality.Size = new System.Drawing.Size(73, 27);
            this.textBox_Quality.TabIndex = 4;
            this.textBox_Quality.Text = "50";
            this.textBox_Quality.TextChanged += new System.EventHandler(this.textBox_Fps_TextChanged);
            // 
            // button_Connect
            // 
            this.button_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Connect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_Connect.Location = new System.Drawing.Point(664, 322);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(114, 50);
            this.button_Connect.TabIndex = 5;
            this.button_Connect.Text = "Connect";
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(790, 615);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.groupBox_Settings);
            this.Controls.Add(this.frameBox);
            this.Controls.Add(this.groupBox_Camera);
            this.Controls.Add(this.groupBox_Movement);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Object Tracking Control Panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox_Movement.ResumeLayout(false);
            this.groupBox_Camera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.frameBox)).EndInit();
            this.groupBox_Settings.ResumeLayout(false);
            this.groupBox_Settings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button_MoveBackward;
		private System.Windows.Forms.Button button_MoveRight;
		private System.Windows.Forms.Button button_MoveForward;
		private System.Windows.Forms.Button button_MoveLeft;
		private System.Windows.Forms.CheckBox checkBox_AutoMove;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.GroupBox groupBox_Movement;
		private System.Windows.Forms.GroupBox groupBox_Camera;
		private System.Windows.Forms.CheckBox checkBox_AutoCam;
		private System.Windows.Forms.Button button_CamDown;
		private System.Windows.Forms.Button button_CamRight;
		private System.Windows.Forms.Button button_CamUp;
		private System.Windows.Forms.Button button_CamLeft;
		private System.Windows.Forms.TextBox textBox_FrameWidth;
		private System.Windows.Forms.Label label_FrameSize;
		private System.Windows.Forms.TextBox textBox_FrameHeight;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Status;
		private System.Windows.Forms.TextBox textBox_Fps;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox frameBox;
		private System.Windows.Forms.TextBox textBox_Address;
		private System.Windows.Forms.Label label_Address;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Fps;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Width;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Height;
		private System.Windows.Forms.GroupBox groupBox_Settings;
		private System.Windows.Forms.Button button_Connect;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Address;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_Quality;
	}
}

