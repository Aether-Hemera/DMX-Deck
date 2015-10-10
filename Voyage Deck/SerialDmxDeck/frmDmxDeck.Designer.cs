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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmxDeck));
            Bonghi.Modeling.Camera camera1 = new Bonghi.Modeling.Camera();
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
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button15 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkAutoColor = new System.Windows.Forms.CheckBox();
            this.btnDefaultColor = new System.Windows.Forms.Button();
            this.chkSendBack = new System.Windows.Forms.CheckBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.optionDefault = new System.Windows.Forms.RadioButton();
            this.optionCell = new System.Windows.Forms.RadioButton();
            this.optionAll = new System.Windows.Forms.RadioButton();
            this.optionRow = new System.Windows.Forms.RadioButton();
            this.optionCol = new System.Windows.Forms.RadioButton();
            this.cmdSendColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudCol = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudRow = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.nudMode = new System.Windows.Forms.NumericUpDown();
            this.txtModeInfo = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.voyageControl1 = new SerialDmxDeck.VoyageControl();
            this.button7 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bControl = new WinFormsGraphicsDevice.BonghiControl();
            this.button5 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkDate2 = new System.Windows.Forms.CheckBox();
            this.dateParameter2 = new System.Windows.Forms.DateTimePicker();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.button14 = new System.Windows.Forms.Button();
            this.chkDate1 = new System.Windows.Forms.CheckBox();
            this.dateParameter1 = new System.Windows.Forms.DateTimePicker();
            this.button13 = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.txtLogReport = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDirInfo = new System.Windows.Forms.TextBox();
            this.txtCustomCommand = new System.Windows.Forms.TextBox();
            this.cmdSendCustom = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chkSerialShowText = new System.Windows.Forms.CheckBox();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMode)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1317, 299);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // cmbSerialSelect
            // 
            this.cmbSerialSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialSelect.FormattingEnabled = true;
            this.cmbSerialSelect.Location = new System.Drawing.Point(7, 22);
            this.cmbSerialSelect.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSerialSelect.Name = "cmbSerialSelect";
            this.cmbSerialSelect.Size = new System.Drawing.Size(87, 24);
            this.cmbSerialSelect.TabIndex = 7;
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
            this.txtReport.Size = new System.Drawing.Size(1093, 231);
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
            this.chkAsColor.Location = new System.Drawing.Point(1110, 58);
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
            this.cmdSetCustomChannels.Location = new System.Drawing.Point(1110, 22);
            this.cmdSetCustomChannels.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSetCustomChannels.Name = "cmdSetCustomChannels";
            this.cmdSetCustomChannels.Size = new System.Drawing.Size(203, 28);
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
            this.button2.Location = new System.Drawing.Point(7, 110);
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
            this.cmdSetAll.Location = new System.Drawing.Point(13, 14);
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
            this.cmdEchoOn.Size = new System.Drawing.Size(85, 28);
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
            this.cmdEchoOff.Size = new System.Drawing.Size(85, 28);
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
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(4, 2);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1339, 344);
            this.tabControl2.TabIndex = 11;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(1331, 315);
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
            this.groupBox2.Location = new System.Drawing.Point(5, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1319, 244);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channels";
            // 
            // txtCustomChannels
            // 
            this.txtCustomChannels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomChannels.Location = new System.Drawing.Point(11, 22);
            this.txtCustomChannels.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomChannels.Multiline = true;
            this.txtCustomChannels.Name = "txtCustomChannels";
            this.txtCustomChannels.Size = new System.Drawing.Size(1091, 136);
            this.txtCustomChannels.TabIndex = 6;
            this.txtCustomChannels.Text = "1-9;10;11;12";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.flowLayoutPanel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Size = new System.Drawing.Size(1331, 315);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Controls";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox3);
            this.tabPage6.Controls.Add(this.cmdSetAll);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1331, 315);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Commands";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtValues);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(13, 48);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(307, 145);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pattern values";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button15);
            this.tabPage1.Controls.Add(this.button12);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.nudMode);
            this.tabPage1.Controls.Add(this.txtModeInfo);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.voyageControl1);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1331, 315);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Voyage";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(769, 196);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(138, 48);
            this.button15.TabIndex = 9;
            this.button15.Text = "Graphics recover";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(13, 153);
            this.button12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(128, 27);
            this.button12.TabIndex = 8;
            this.button12.Text = "stay on scheme";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkAutoColor);
            this.groupBox5.Controls.Add(this.btnDefaultColor);
            this.groupBox5.Controls.Add(this.chkSendBack);
            this.groupBox5.Controls.Add(this.button11);
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Controls.Add(this.button10);
            this.groupBox5.Controls.Add(this.button8);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.cmdSendColor);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.nudCol);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.nudRow);
            this.groupBox5.Location = new System.Drawing.Point(151, 187);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(612, 108);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Interactive";
            // 
            // chkAutoColor
            // 
            this.chkAutoColor.AutoSize = true;
            this.chkAutoColor.Location = new System.Drawing.Point(268, 72);
            this.chkAutoColor.Name = "chkAutoColor";
            this.chkAutoColor.Size = new System.Drawing.Size(59, 21);
            this.chkAutoColor.TabIndex = 17;
            this.chkAutoColor.Text = "Auto";
            this.chkAutoColor.UseVisualStyleBackColor = true;
            // 
            // btnDefaultColor
            // 
            this.btnDefaultColor.BackColor = System.Drawing.Color.White;
            this.btnDefaultColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefaultColor.Location = new System.Drawing.Point(440, 70);
            this.btnDefaultColor.Name = "btnDefaultColor";
            this.btnDefaultColor.Size = new System.Drawing.Size(123, 27);
            this.btnDefaultColor.TabIndex = 16;
            this.btnDefaultColor.UseVisualStyleBackColor = false;
            // 
            // chkSendBack
            // 
            this.chkSendBack.AutoSize = true;
            this.chkSendBack.Location = new System.Drawing.Point(324, 72);
            this.chkSendBack.Name = "chkSendBack";
            this.chkSendBack.Size = new System.Drawing.Size(110, 21);
            this.chkSendBack.TabIndex = 15;
            this.chkSendBack.Text = "Send default";
            this.chkSendBack.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.White;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(520, 23);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(43, 41);
            this.button11.TabIndex = 14;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.cmdSendColor_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Black;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(471, 23);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(43, 41);
            this.button9.TabIndex = 13;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.cmdSendColor_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Blue;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(422, 23);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(43, 41);
            this.button10.TabIndex = 12;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.cmdSendColor_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Lime;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(373, 23);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(43, 41);
            this.button8.TabIndex = 11;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.cmdSendColor_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.optionDefault);
            this.groupBox6.Controls.Add(this.optionCell);
            this.groupBox6.Controls.Add(this.optionAll);
            this.groupBox6.Controls.Add(this.optionRow);
            this.groupBox6.Controls.Add(this.optionCol);
            this.groupBox6.Location = new System.Drawing.Point(6, 21);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(215, 80);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Paint scope";
            // 
            // optionDefault
            // 
            this.optionDefault.AutoSize = true;
            this.optionDefault.Location = new System.Drawing.Point(61, 48);
            this.optionDefault.Name = "optionDefault";
            this.optionDefault.Size = new System.Drawing.Size(74, 21);
            this.optionDefault.TabIndex = 4;
            this.optionDefault.Text = "Default";
            this.optionDefault.UseVisualStyleBackColor = true;
            // 
            // optionCell
            // 
            this.optionCell.AutoSize = true;
            this.optionCell.Location = new System.Drawing.Point(6, 48);
            this.optionCell.Name = "optionCell";
            this.optionCell.Size = new System.Drawing.Size(52, 21);
            this.optionCell.TabIndex = 3;
            this.optionCell.Text = "Cell";
            this.optionCell.UseVisualStyleBackColor = true;
            // 
            // optionAll
            // 
            this.optionAll.AutoSize = true;
            this.optionAll.Checked = true;
            this.optionAll.Location = new System.Drawing.Point(123, 21);
            this.optionAll.Name = "optionAll";
            this.optionAll.Size = new System.Drawing.Size(44, 21);
            this.optionAll.TabIndex = 2;
            this.optionAll.TabStop = true;
            this.optionAll.Text = "All";
            this.optionAll.UseVisualStyleBackColor = true;
            // 
            // optionRow
            // 
            this.optionRow.AutoSize = true;
            this.optionRow.Location = new System.Drawing.Point(61, 21);
            this.optionRow.Name = "optionRow";
            this.optionRow.Size = new System.Drawing.Size(56, 21);
            this.optionRow.TabIndex = 1;
            this.optionRow.Text = "Row";
            this.optionRow.UseVisualStyleBackColor = true;
            // 
            // optionCol
            // 
            this.optionCol.AutoSize = true;
            this.optionCol.Location = new System.Drawing.Point(6, 21);
            this.optionCol.Name = "optionCol";
            this.optionCol.Size = new System.Drawing.Size(49, 21);
            this.optionCol.TabIndex = 0;
            this.optionCol.Text = "Col";
            this.optionCol.UseVisualStyleBackColor = true;
            // 
            // cmdSendColor
            // 
            this.cmdSendColor.BackColor = System.Drawing.Color.Red;
            this.cmdSendColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSendColor.Location = new System.Drawing.Point(324, 23);
            this.cmdSendColor.Name = "cmdSendColor";
            this.cmdSendColor.Size = new System.Drawing.Size(43, 41);
            this.cmdSendColor.TabIndex = 9;
            this.cmdSendColor.UseVisualStyleBackColor = false;
            this.cmdSendColor.Click += new System.EventHandler(this.cmdSendColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Col";
            // 
            // nudCol
            // 
            this.nudCol.Location = new System.Drawing.Point(268, 49);
            this.nudCol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudCol.Name = "nudCol";
            this.nudCol.Size = new System.Drawing.Size(50, 22);
            this.nudCol.TabIndex = 7;
            this.nudCol.ValueChanged += new System.EventHandler(this.nudCol_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Row";
            // 
            // nudRow
            // 
            this.nudRow.Location = new System.Drawing.Point(268, 23);
            this.nudRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudRow.Name = "nudRow";
            this.nudRow.Size = new System.Drawing.Size(50, 22);
            this.nudRow.TabIndex = 5;
            this.nudRow.ValueChanged += new System.EventHandler(this.nudRow_ValueChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 208);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 30);
            this.button4.TabIndex = 5;
            this.button4.Text = "Image";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // nudMode
            // 
            this.nudMode.Location = new System.Drawing.Point(13, 96);
            this.nudMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudMode.Name = "nudMode";
            this.nudMode.Size = new System.Drawing.Size(128, 22);
            this.nudMode.TabIndex = 4;
            // 
            // txtModeInfo
            // 
            this.txtModeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModeInfo.Location = new System.Drawing.Point(1045, 11);
            this.txtModeInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtModeInfo.Multiline = true;
            this.txtModeInfo.Name = "txtModeInfo";
            this.txtModeInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtModeInfo.Size = new System.Drawing.Size(281, 296);
            this.txtModeInfo.TabIndex = 3;
            this.txtModeInfo.Text = resources.GetString("txtModeInfo.Text");
            this.txtModeInfo.TextChanged += new System.EventHandler(this.txtModeInfo_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 63);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 27);
            this.button3.TabIndex = 2;
            this.button3.Text = "Send mode";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open Serial";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // voyageControl1
            // 
            this.voyageControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voyageControl1.Location = new System.Drawing.Point(151, 10);
            this.voyageControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.voyageControl1.Name = "voyageControl1";
            this.voyageControl1.RowOrder = SerialDmxDeck.VoyageControl.Order.Normal;
            this.voyageControl1.Size = new System.Drawing.Size(851, 170);
            this.voyageControl1.TabIndex = 1;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(13, 122);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(128, 27);
            this.button7.TabIndex = 3;
            this.button7.Text = "Stop animation";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bControl);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1331, 315);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Butterflies";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bControl
            // 
            this.bControl.AllowMotdelMatrixChange = false;
            this.bControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            camera1.EyeDistance = 10F;
            camera1.EyePoint = new Microsoft.Xna.Framework.Vector3(-3.535534F, -3.535534F, 8.660254F);
            camera1.FarNearClippingBox = null;
            camera1.ProjType = Bonghi.Modeling.Camera.ProjTypeEnum.Orthogonal;
            camera1.TargetPoint = new Microsoft.Xna.Framework.Vector3(0F, 0F, 0F);
            camera1.UpVector = new Microsoft.Xna.Framework.Vector3(0.6123724F, 0.6123724F, 0.5F);
            this.bControl.Camera = camera1;
            this.bControl.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.bControl.ExtendedContextMenus = null;
            this.bControl.Location = new System.Drawing.Point(107, 6);
            this.bControl.Margin = new System.Windows.Forms.Padding(4);
            this.bControl.MouseMode = WinFormsGraphicsDevice.BonghiControl.MouseModeValue.Orbit;
            this.bControl.Name = "bControl";
            this.bControl.Size = new System.Drawing.Size(1214, 294);
            this.bControl.TabIndex = 2;
            this.bControl.Text = "bControl";
            this.bControl.TextMessage = null;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 6);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 27);
            this.button5.TabIndex = 1;
            this.button5.Text = "Open Serial";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkDate2);
            this.tabPage3.Controls.Add(this.dateParameter2);
            this.tabPage3.Controls.Add(this.cmbFilterType);
            this.tabPage3.Controls.Add(this.button14);
            this.tabPage3.Controls.Add(this.chkDate1);
            this.tabPage3.Controls.Add(this.dateParameter1);
            this.tabPage3.Controls.Add(this.button13);
            this.tabPage3.Controls.Add(this.zedGraphControl1);
            this.tabPage3.Controls.Add(this.txtLogReport);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.txtDirInfo);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1331, 315);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "Apache log report";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkDate2
            // 
            this.chkDate2.AutoSize = true;
            this.chkDate2.Location = new System.Drawing.Point(170, 119);
            this.chkDate2.Name = "chkDate2";
            this.chkDate2.Size = new System.Drawing.Size(74, 21);
            this.chkDate2.TabIndex = 11;
            this.chkDate2.Text = "Enable";
            this.chkDate2.UseVisualStyleBackColor = true;
            // 
            // dateParameter2
            // 
            this.dateParameter2.Location = new System.Drawing.Point(9, 115);
            this.dateParameter2.Name = "dateParameter2";
            this.dateParameter2.Size = new System.Drawing.Size(155, 22);
            this.dateParameter2.TabIndex = 10;
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Location = new System.Drawing.Point(6, 143);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(155, 24);
            this.cmbFilterType.TabIndex = 9;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(104, 173);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(184, 37);
            this.button14.TabIndex = 8;
            this.button14.Text = "Report Days";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // chkDate1
            // 
            this.chkDate1.AutoSize = true;
            this.chkDate1.Location = new System.Drawing.Point(170, 88);
            this.chkDate1.Name = "chkDate1";
            this.chkDate1.Size = new System.Drawing.Size(74, 21);
            this.chkDate1.TabIndex = 7;
            this.chkDate1.Text = "Enable";
            this.chkDate1.UseVisualStyleBackColor = true;
            // 
            // dateParameter1
            // 
            this.dateParameter1.Location = new System.Drawing.Point(9, 87);
            this.dateParameter1.Name = "dateParameter1";
            this.dateParameter1.Size = new System.Drawing.Size(155, 22);
            this.dateParameter1.TabIndex = 6;
            this.dateParameter1.Value = new System.DateTime(2014, 11, 1, 0, 0, 0, 0);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(104, 214);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(184, 37);
            this.button13.TabIndex = 5;
            this.button13.Text = "Report hours";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.IsAutoScrollRange = false;
            this.zedGraphControl1.IsEnableHPan = true;
            this.zedGraphControl1.IsEnableHZoom = true;
            this.zedGraphControl1.IsEnableVPan = true;
            this.zedGraphControl1.IsEnableVZoom = true;
            this.zedGraphControl1.IsScrollY2 = false;
            this.zedGraphControl1.IsShowContextMenu = true;
            this.zedGraphControl1.IsShowCursorValues = false;
            this.zedGraphControl1.IsShowHScrollBar = false;
            this.zedGraphControl1.IsShowPointValues = false;
            this.zedGraphControl1.IsShowVScrollBar = false;
            this.zedGraphControl1.IsZoomOnMouseCenter = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(619, 6);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.zedGraphControl1.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.PointDateFormat = "g";
            this.zedGraphControl1.PointValueFormat = "G";
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(709, 303);
            this.zedGraphControl1.TabIndex = 4;
            this.zedGraphControl1.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.zedGraphControl1.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.ZoomStepFraction = 0.1D;
            // 
            // txtLogReport
            // 
            this.txtLogReport.Location = new System.Drawing.Point(320, 34);
            this.txtLogReport.Multiline = true;
            this.txtLogReport.Name = "txtLogReport";
            this.txtLogReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogReport.Size = new System.Drawing.Size(293, 217);
            this.txtLogReport.TabIndex = 3;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(68, 34);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 37);
            this.button6.TabIndex = 2;
            this.button6.Text = "Load";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Folder";
            // 
            // txtDirInfo
            // 
            this.txtDirInfo.Location = new System.Drawing.Point(68, 6);
            this.txtDirInfo.Name = "txtDirInfo";
            this.txtDirInfo.Size = new System.Drawing.Size(545, 22);
            this.txtDirInfo.TabIndex = 0;
            this.txtDirInfo.Text = "C:\\Users\\Bonghi\\Desktop\\amsterdam";
            // 
            // txtCustomCommand
            // 
            this.txtCustomCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomCommand.Location = new System.Drawing.Point(4, 7);
            this.txtCustomCommand.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomCommand.Multiline = true;
            this.txtCustomCommand.Name = "txtCustomCommand";
            this.txtCustomCommand.Size = new System.Drawing.Size(981, 35);
            this.txtCustomCommand.TabIndex = 6;
            // 
            // cmdSendCustom
            // 
            this.cmdSendCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSendCustom.Location = new System.Drawing.Point(993, 4);
            this.cmdSendCustom.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSendCustom.Name = "cmdSendCustom";
            this.cmdSendCustom.Size = new System.Drawing.Size(96, 28);
            this.cmdSendCustom.TabIndex = 5;
            this.cmdSendCustom.Text = "Send";
            this.cmdSendCustom.UseVisualStyleBackColor = true;
            this.cmdSendCustom.Click += new System.EventHandler(this.cmdSendCustom_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSerialSelect);
            this.groupBox1.Controls.Add(this.cmdEchoOn);
            this.groupBox1.Controls.Add(this.cmdEchoOff);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(100, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.chkSerialShowText);
            this.splitContainer1.Panel2.Controls.Add(this.cmdClear);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1347, 703);
            this.splitContainer1.SplitterDistance = 348;
            this.splitContainer1.TabIndex = 12;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(112, 4);
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
            this.splitContainer2.Size = new System.Drawing.Size(1093, 281);
            this.splitContainer2.SplitterDistance = 46;
            this.splitContainer2.TabIndex = 8;
            // 
            // chkSerialShowText
            // 
            this.chkSerialShowText.AutoSize = true;
            this.chkSerialShowText.Location = new System.Drawing.Point(5, 175);
            this.chkSerialShowText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkSerialShowText.Name = "chkSerialShowText";
            this.chkSerialShowText.Size = new System.Drawing.Size(84, 21);
            this.chkSerialShowText.TabIndex = 7;
            this.chkSerialShowText.Text = "Show Rx";
            this.chkSerialShowText.UseVisualStyleBackColor = true;
            // 
            // frmDmxDeck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 727);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDmxDeck";
            this.Text = "DMX Deck";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMode)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtCustomCommand;
        private System.Windows.Forms.Button cmdSendCustom;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private VoyageControl voyageControl1;
        private System.Windows.Forms.CheckBox chkSerialShowText;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtModeInfo;
        private System.Windows.Forms.NumericUpDown nudMode;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button5;
        private WinFormsGraphicsDevice.BonghiControl bControl;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudRow;
        private System.Windows.Forms.Button cmdSendColor;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton optionAll;
        private System.Windows.Forms.RadioButton optionRow;
        private System.Windows.Forms.RadioButton optionCol;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnDefaultColor;
        private System.Windows.Forms.CheckBox chkSendBack;
        private System.Windows.Forms.RadioButton optionDefault;
        private System.Windows.Forms.RadioButton optionCell;
        private System.Windows.Forms.CheckBox chkAutoColor;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDirInfo;
        private System.Windows.Forms.TextBox txtLogReport;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.DateTimePicker dateParameter1;
        private System.Windows.Forms.CheckBox chkDate1;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.CheckBox chkDate2;
        private System.Windows.Forms.DateTimePicker dateParameter2;
        private System.Windows.Forms.Button button15;
    }
}

