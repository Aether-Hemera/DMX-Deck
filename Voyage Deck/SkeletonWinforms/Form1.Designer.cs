﻿namespace SkeletonWinforms
{
    partial class Form1
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
            this.checkBoxSeatedMode = new System.Windows.Forms.CheckBox();
            this.largeText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblSerial = new System.Windows.Forms.Label();
            this.chkSerialStart = new System.Windows.Forms.CheckBox();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Z = new System.Windows.Forms.Label();
            this.nudZ = new System.Windows.Forms.NumericUpDown();
            this.SetCenter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblShutDown = new System.Windows.Forms.Label();
            this.chkShutBirds = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.kLaunch = new System.Windows.Forms.Button();
            this.kCount = new System.Windows.Forms.Button();
            this.kState = new System.Windows.Forms.Button();
            this.voyageCommunicationControl1 = new SerialDmxDeck.VoyageCommunicationControl();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxSeatedMode
            // 
            this.checkBoxSeatedMode.AutoSize = true;
            this.checkBoxSeatedMode.Location = new System.Drawing.Point(194, 91);
            this.checkBoxSeatedMode.Name = "checkBoxSeatedMode";
            this.checkBoxSeatedMode.Size = new System.Drawing.Size(170, 21);
            this.checkBoxSeatedMode.TabIndex = 1;
            this.checkBoxSeatedMode.Text = "Kinect in seated mode";
            this.checkBoxSeatedMode.UseVisualStyleBackColor = true;
            this.checkBoxSeatedMode.CheckedChanged += new System.EventHandler(this.checkBoxSeatedMode_CheckedChanged);
            // 
            // largeText
            // 
            this.largeText.AutoSize = true;
            this.largeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.largeText.Location = new System.Drawing.Point(180, 9);
            this.largeText.Name = "largeText";
            this.largeText.Size = new System.Drawing.Size(798, 79);
            this.largeText.TabIndex = 3;
            this.largeText.Text = "Kinect not  yet contacted";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblSerial
            // 
            this.lblSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSerial.AutoSize = true;
            this.lblSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.Location = new System.Drawing.Point(12, 9);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(162, 46);
            this.lblSerial.TabIndex = 5;
            this.lblSerial.Text = "lblSerial";
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkSerialStart
            // 
            this.chkSerialStart.AutoSize = true;
            this.chkSerialStart.Location = new System.Drawing.Point(20, 58);
            this.chkSerialStart.Name = "chkSerialStart";
            this.chkSerialStart.Size = new System.Drawing.Size(133, 21);
            this.chkSerialStart.TabIndex = 6;
            this.chkSerialStart.Text = "Serial Auto Start";
            this.chkSerialStart.UseVisualStyleBackColor = true;
            // 
            // nudX
            // 
            this.nudX.DecimalPlaces = 3;
            this.nudX.Location = new System.Drawing.Point(226, 121);
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(74, 22);
            this.nudX.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "X";
            // 
            // Z
            // 
            this.Z.AutoSize = true;
            this.Z.Location = new System.Drawing.Point(191, 151);
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(17, 17);
            this.Z.TabIndex = 10;
            this.Z.Text = "Z";
            // 
            // nudZ
            // 
            this.nudZ.DecimalPlaces = 3;
            this.nudZ.Location = new System.Drawing.Point(226, 149);
            this.nudZ.Name = "nudZ";
            this.nudZ.Size = new System.Drawing.Size(74, 22);
            this.nudZ.TabIndex = 9;
            // 
            // SetCenter
            // 
            this.SetCenter.Location = new System.Drawing.Point(306, 120);
            this.SetCenter.Name = "SetCenter";
            this.SetCenter.Size = new System.Drawing.Size(58, 51);
            this.SetCenter.TabIndex = 11;
            this.SetCenter.Text = "Set";
            this.SetCenter.UseVisualStyleBackColor = true;
            this.SetCenter.Click += new System.EventHandler(this.SetCenter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblShutDown);
            this.groupBox1.Controls.Add(this.chkShutBirds);
            this.groupBox1.Location = new System.Drawing.Point(20, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shutdown";
            // 
            // lblShutDown
            // 
            this.lblShutDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShutDown.AutoSize = true;
            this.lblShutDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShutDown.Location = new System.Drawing.Point(3, 45);
            this.lblShutDown.Name = "lblShutDown";
            this.lblShutDown.Size = new System.Drawing.Size(162, 46);
            this.lblShutDown.TabIndex = 8;
            this.lblShutDown.Text = "lblSerial";
            this.lblShutDown.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkShutBirds
            // 
            this.chkShutBirds.AutoSize = true;
            this.chkShutBirds.Checked = true;
            this.chkShutBirds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShutBirds.Location = new System.Drawing.Point(6, 21);
            this.chkShutBirds.Name = "chkShutBirds";
            this.chkShutBirds.Size = new System.Drawing.Size(118, 21);
            this.chkShutBirds.TabIndex = 7;
            this.chkShutBirds.Text = "Birds shutdow";
            this.chkShutBirds.UseVisualStyleBackColor = true;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // kLaunch
            // 
            this.kLaunch.Location = new System.Drawing.Point(604, 121);
            this.kLaunch.Name = "kLaunch";
            this.kLaunch.Size = new System.Drawing.Size(72, 51);
            this.kLaunch.TabIndex = 13;
            this.kLaunch.Text = "K Start";
            this.kLaunch.UseVisualStyleBackColor = true;
            this.kLaunch.Click += new System.EventHandler(this.kLaunch_Click);
            // 
            // kCount
            // 
            this.kCount.Location = new System.Drawing.Point(448, 121);
            this.kCount.Name = "kCount";
            this.kCount.Size = new System.Drawing.Size(72, 51);
            this.kCount.TabIndex = 14;
            this.kCount.Text = "K Count";
            this.kCount.UseVisualStyleBackColor = true;
            this.kCount.Click += new System.EventHandler(this.kCount_Click);
            // 
            // kState
            // 
            this.kState.Location = new System.Drawing.Point(526, 121);
            this.kState.Name = "kState";
            this.kState.Size = new System.Drawing.Size(72, 51);
            this.kState.TabIndex = 15;
            this.kState.Text = "K State";
            this.kState.UseVisualStyleBackColor = true;
            this.kState.Click += new System.EventHandler(this.kState_Click);
            // 
            // voyageCommunicationControl1
            // 
            this.voyageCommunicationControl1.Location = new System.Drawing.Point(12, 261);
            this.voyageCommunicationControl1.Name = "voyageCommunicationControl1";
            this.voyageCommunicationControl1.Size = new System.Drawing.Size(1297, 490);
            this.voyageCommunicationControl1.TabIndex = 4;
            this.voyageCommunicationControl1.Load += new System.EventHandler(this.voyageCommunicationControl1_Load);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1158, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(151, 51);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close (Safe birds)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 763);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.kState);
            this.Controls.Add(this.kCount);
            this.Controls.Add(this.kLaunch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SetCenter);
            this.Controls.Add(this.Z);
            this.Controls.Add(this.nudZ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudX);
            this.Controls.Add(this.chkSerialStart);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.voyageCommunicationControl1);
            this.Controls.Add(this.largeText);
            this.Controls.Add(this.checkBoxSeatedMode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSeatedMode;
        private System.Windows.Forms.Label largeText;
        private SerialDmxDeck.VoyageCommunicationControl voyageCommunicationControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.CheckBox chkSerialStart;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Z;
        private System.Windows.Forms.NumericUpDown nudZ;
        private System.Windows.Forms.Button SetCenter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkShutBirds;
        private System.Windows.Forms.Label lblShutDown;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button kLaunch;
        private System.Windows.Forms.Button kCount;
        private System.Windows.Forms.Button kState;
        private System.Windows.Forms.Button btnClose;
    }
}

