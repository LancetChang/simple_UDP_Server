namespace UdpServer
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
            this.button1 = new System.Windows.Forms.Button();
            this.server_log = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ListeningIP = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.ListeningPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // server_log
            // 
            this.server_log.FormattingEnabled = true;
            this.server_log.ItemHeight = 12;
            this.server_log.Location = new System.Drawing.Point(12, 89);
            this.server_log.Name = "server_log";
            this.server_log.Size = new System.Drawing.Size(260, 148);
            this.server_log.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Listening IP";
            // 
            // ListeningIP
            // 
            this.ListeningIP.Location = new System.Drawing.Point(75, 17);
            this.ListeningIP.Name = "ListeningIP";
            this.ListeningIP.Size = new System.Drawing.Size(95, 22);
            this.ListeningIP.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(8, 47);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(70, 12);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Listening Port";
            // 
            // ListeningPort
            // 
            this.ListeningPort.Location = new System.Drawing.Point(84, 44);
            this.ListeningPort.Name = "ListeningPort";
            this.ListeningPort.Size = new System.Drawing.Size(95, 22);
            this.ListeningPort.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ListeningPort);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.ListeningIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.server_log);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox server_log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ListeningIP;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox ListeningPort;
    }
}

