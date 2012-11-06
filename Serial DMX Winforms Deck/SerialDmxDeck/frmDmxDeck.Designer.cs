namespace SerialDmxDeck
{
    partial class frmDmxDeck
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbSerialSelect = new System.Windows.Forms.ComboBox();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmdClear = new System.Windows.Forms.Button();
            this.chkAsColor = new System.Windows.Forms.CheckBox();
            this.cmdSetCustomChannels = new System.Windows.Forms.Button();
            this.txtValues = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cmdSetAll = new System.Windows.Forms.Button();
            this.cmdEchoOn = new System.Windows.Forms.Button();
            this.cmdEchoOff = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCustomChannels = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 7);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1179, 242);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // cmbSerialSelect
            // 
            this.cmbSerialSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialSelect.FormattingEnabled = true;
            this.cmbSerialSelect.Location = new System.Drawing.Point(7, 22);
            this.cmbSerialSelect.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSerialSelect.Name = "cmbSerialSelect";
            this.cmbSerialSelect.Size = new System.Drawing.Size(86, 24);
            this.cmbSerialSelect.TabIndex = 7;
            // 
            // txtReport
            // 
            this.txtReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReport.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReport.Location = new System.Drawing.Point(108, 4);
            this.txtReport.Margin = new System.Windows.Forms.Padding(4);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReport.Size = new System.Drawing.Size(1097, 280);
            this.txtReport.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(4, 140);
            this.cmdClear.Margin = new System.Windows.Forms.Padding(4);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(100, 28);
            this.cmdClear.TabIndex = 6;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // chkAsColor
            // 
            this.chkAsColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAsColor.AutoSize = true;
            this.chkAsColor.Location = new System.Drawing.Point(972, 58);
            this.chkAsColor.Margin = new System.Windows.Forms.Padding(4);
            this.chkAsColor.Name = "chkAsColor";
            this.chkAsColor.Size = new System.Drawing.Size(88, 21);
            this.chkAsColor.TabIndex = 5;
            this.chkAsColor.Text = "As colors";
            this.chkAsColor.UseVisualStyleBackColor = true;
            // 
            // cmdSetCustomChannels
            // 
            this.cmdSetCustomChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSetCustomChannels.Location = new System.Drawing.Point(972, 22);
            this.cmdSetCustomChannels.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSetCustomChannels.Name = "cmdSetCustomChannels";
            this.cmdSetCustomChannels.Size = new System.Drawing.Size(202, 28);
            this.cmdSetCustomChannels.TabIndex = 3;
            this.cmdSetCustomChannels.Text = "Set channels";
            this.cmdSetCustomChannels.UseVisualStyleBackColor = true;
            this.cmdSetCustomChannels.Click += new System.EventHandler(this.cmdSetCustomChannels_Click);
            // 
            // txtValues
            // 
            this.txtValues.Location = new System.Drawing.Point(7, 22);
            this.txtValues.Margin = new System.Windows.Forms.Padding(4);
            this.txtValues.Multiline = true;
            this.txtValues.Name = "txtValues";
            this.txtValues.Size = new System.Drawing.Size(293, 79);
            this.txtValues.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 109);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(293, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Set";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmdSetAll
            // 
            this.cmdSetAll.Location = new System.Drawing.Point(13, 13);
            this.cmdSetAll.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSetAll.Name = "cmdSetAll";
            this.cmdSetAll.Size = new System.Drawing.Size(307, 28);
            this.cmdSetAll.TabIndex = 8;
            this.cmdSetAll.Text = "All values 0";
            this.cmdSetAll.UseVisualStyleBackColor = true;
            this.cmdSetAll.Click += new System.EventHandler(this.cmdSetAll_Click);
            // 
            // cmdEchoOn
            // 
            this.cmdEchoOn.Location = new System.Drawing.Point(7, 54);
            this.cmdEchoOn.Margin = new System.Windows.Forms.Padding(4);
            this.cmdEchoOn.Name = "cmdEchoOn";
            this.cmdEchoOn.Size = new System.Drawing.Size(86, 28);
            this.cmdEchoOn.TabIndex = 9;
            this.cmdEchoOn.Text = "Echo On";
            this.cmdEchoOn.UseVisualStyleBackColor = true;
            this.cmdEchoOn.Click += new System.EventHandler(this.cmdEchoOn_Click);
            // 
            // cmdEchoOff
            // 
            this.cmdEchoOff.Location = new System.Drawing.Point(7, 90);
            this.cmdEchoOff.Margin = new System.Windows.Forms.Padding(4);
            this.cmdEchoOff.Name = "cmdEchoOff";
            this.cmdEchoOff.Size = new System.Drawing.Size(86, 28);
            this.cmdEchoOff.TabIndex = 10;
            this.cmdEchoOff.Text = "Echo Off";
            this.cmdEchoOff.UseVisualStyleBackColor = true;
            this.cmdEchoOff.Click += new System.EventHandler(this.cmdEchoOff_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(4, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1201, 285);
            this.tabControl2.TabIndex = 11;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1193, 256);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Setup";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmdSetCustomChannels);
            this.groupBox2.Controls.Add(this.chkAsColor);
            this.groupBox2.Controls.Add(this.txtCustomChannels);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1181, 244);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channels";
            // 
            // txtCustomChannels
            // 
            this.txtCustomChannels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomChannels.Location = new System.Drawing.Point(10, 22);
            this.txtCustomChannels.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomChannels.Multiline = true;
            this.txtCustomChannels.Name = "txtCustomChannels";
            this.txtCustomChannels.Size = new System.Drawing.Size(954, 136);
            this.txtCustomChannels.TabIndex = 6;
            this.txtCustomChannels.Text = "1-9;10;11;12";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSerialSelect);
            this.groupBox1.Controls.Add(this.cmdEchoOn);
            this.groupBox1.Controls.Add(this.cmdEchoOff);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.flowLayoutPanel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1193, 256);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Controls";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox3);
            this.tabPage6.Controls.Add(this.cmdSetAll);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1193, 256);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Commands";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cmdClear);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.txtReport);
            this.splitContainer1.Size = new System.Drawing.Size(1209, 583);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtValues);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(13, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 145);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pattern values";
            // 
            // frmDmxDeck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 607);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDmxDeck";
            this.Text = "DMX Deck";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbSerialSelect;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdSetCustomChannels;
        private System.Windows.Forms.Button cmdSetAll;
        private System.Windows.Forms.CheckBox chkAsColor;
        private System.Windows.Forms.Button cmdEchoOn;
        private System.Windows.Forms.Button cmdEchoOff;
        private System.Windows.Forms.TextBox txtValues;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCustomChannels;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

