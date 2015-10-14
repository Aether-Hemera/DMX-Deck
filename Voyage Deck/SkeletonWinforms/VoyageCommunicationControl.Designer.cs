namespace SerialDmxDeck
{
    partial class VoyageCommunicationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbSerialSelect = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cmdSendCustom = new System.Windows.Forms.Button();
            this.txtCustomCommand = new System.Windows.Forms.TextBox();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.chkSerialShowText = new System.Windows.Forms.CheckBox();
            this.voyageControl1 = new SerialDmxDeck.VoyageControl();
            this.nudMode = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMode)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSerialSelect
            // 
            this.cmbSerialSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialSelect.FormattingEnabled = true;
            this.cmbSerialSelect.Location = new System.Drawing.Point(13, 224);
            this.cmbSerialSelect.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSerialSelect.Name = "cmbSerialSelect";
            this.cmbSerialSelect.Size = new System.Drawing.Size(128, 24);
            this.cmbSerialSelect.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 186);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Open Serial";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(148, 186);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cmdSendCustom);
            this.splitContainer2.Panel1.Controls.Add(this.txtCustomCommand);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtReport);
            this.splitContainer2.Size = new System.Drawing.Size(480, 302);
            this.splitContainer2.SplitterDistance = 49;
            this.splitContainer2.TabIndex = 11;
            // 
            // cmdSendCustom
            // 
            this.cmdSendCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSendCustom.Location = new System.Drawing.Point(380, 2);
            this.cmdSendCustom.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSendCustom.Name = "cmdSendCustom";
            this.cmdSendCustom.Size = new System.Drawing.Size(96, 40);
            this.cmdSendCustom.TabIndex = 5;
            this.cmdSendCustom.Text = "Send";
            this.cmdSendCustom.UseVisualStyleBackColor = true;
            this.cmdSendCustom.Click += new System.EventHandler(this.cmdSendCustom_Click);
            // 
            // txtCustomCommand
            // 
            this.txtCustomCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomCommand.Location = new System.Drawing.Point(4, 5);
            this.txtCustomCommand.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomCommand.Multiline = true;
            this.txtCustomCommand.Name = "txtCustomCommand";
            this.txtCustomCommand.Size = new System.Drawing.Size(368, 40);
            this.txtCustomCommand.TabIndex = 6;
            // 
            // txtReport
            // 
            this.txtReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReport.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReport.Location = new System.Drawing.Point(0, 0);
            this.txtReport.Margin = new System.Windows.Forms.Padding(4);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReport.Size = new System.Drawing.Size(480, 249);
            this.txtReport.TabIndex = 5;
            // 
            // chkSerialShowText
            // 
            this.chkSerialShowText.AutoSize = true;
            this.chkSerialShowText.Location = new System.Drawing.Point(13, 254);
            this.chkSerialShowText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkSerialShowText.Name = "chkSerialShowText";
            this.chkSerialShowText.Size = new System.Drawing.Size(84, 21);
            this.chkSerialShowText.TabIndex = 12;
            this.chkSerialShowText.Text = "Show Rx";
            this.chkSerialShowText.UseVisualStyleBackColor = true;
            // 
            // voyageControl1
            // 
            this.voyageControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voyageControl1.Location = new System.Drawing.Point(13, 12);
            this.voyageControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.voyageControl1.Name = "voyageControl1";
            this.voyageControl1.RowOrder = SerialDmxDeck.VoyageControl.Order.Normal;
            this.voyageControl1.Size = new System.Drawing.Size(615, 170);
            this.voyageControl1.TabIndex = 5;
            // 
            // nudMode
            // 
            this.nudMode.Location = new System.Drawing.Point(13, 312);
            this.nudMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudMode.Name = "nudMode";
            this.nudMode.Size = new System.Drawing.Size(128, 22);
            this.nudMode.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 279);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 27);
            this.button3.TabIndex = 13;
            this.button3.Text = "Send mode";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Received mode:";
            // 
            // VoyageCommunicationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMode);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.chkSerialShowText);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.cmbSerialSelect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.voyageControl1);
            this.Name = "VoyageCommunicationControl";
            this.Size = new System.Drawing.Size(638, 490);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VoyageControl voyageControl1;
        private System.Windows.Forms.ComboBox cmbSerialSelect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button cmdSendCustom;
        private System.Windows.Forms.TextBox txtCustomCommand;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.CheckBox chkSerialShowText;
        private System.Windows.Forms.NumericUpDown nudMode;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;

    }
}
