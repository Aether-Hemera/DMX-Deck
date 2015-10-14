namespace SkeletonWinforms
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
            this.statusBarText = new System.Windows.Forms.Label();
            this.checkBoxSeatedMode = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.voyageCommunicationControl1 = new SerialDmxDeck.VoyageCommunicationControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statusBarText
            // 
            this.statusBarText.AutoSize = true;
            this.statusBarText.Location = new System.Drawing.Point(219, 148);
            this.statusBarText.Name = "statusBarText";
            this.statusBarText.Size = new System.Drawing.Size(46, 17);
            this.statusBarText.TabIndex = 0;
            this.statusBarText.Text = "label1";
            // 
            // checkBoxSeatedMode
            // 
            this.checkBoxSeatedMode.AutoSize = true;
            this.checkBoxSeatedMode.Location = new System.Drawing.Point(35, 147);
            this.checkBoxSeatedMode.Name = "checkBoxSeatedMode";
            this.checkBoxSeatedMode.Size = new System.Drawing.Size(98, 21);
            this.checkBoxSeatedMode.TabIndex = 1;
            this.checkBoxSeatedMode.Text = "checkBox1";
            this.checkBoxSeatedMode.UseVisualStyleBackColor = true;
            this.checkBoxSeatedMode.CheckedChanged += new System.EventHandler(this.checkBoxSeatedMode_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 135);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // voyageCommunicationControl1
            // 
            this.voyageCommunicationControl1.Location = new System.Drawing.Point(35, 185);
            this.voyageCommunicationControl1.Name = "voyageCommunicationControl1";
            this.voyageCommunicationControl1.Size = new System.Drawing.Size(961, 490);
            this.voyageCommunicationControl1.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(823, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(486, 135);
            this.label2.TabIndex = 5;
            this.label2.Text = "lblSerial";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 726);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.voyageCommunicationControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxSeatedMode);
            this.Controls.Add(this.statusBarText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusBarText;
        private System.Windows.Forms.CheckBox checkBoxSeatedMode;
        private System.Windows.Forms.Label label1;
        private SerialDmxDeck.VoyageCommunicationControl voyageCommunicationControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
    }
}

