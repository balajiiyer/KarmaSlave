namespace KarmaSlave
{
    partial class KarmaSlaveUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Logger = new System.Windows.Forms.RichTextBox();
            this.btn_PollQ = new System.Windows.Forms.Button();
            this.btn_Clear_Log = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Logger);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1323, 334);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logs";
            // 
            // Logger
            // 
            this.Logger.Location = new System.Drawing.Point(6, 21);
            this.Logger.Name = "Logger";
            this.Logger.Size = new System.Drawing.Size(1311, 307);
            this.Logger.TabIndex = 0;
            this.Logger.Text = "";
            // 
            // btn_PollQ
            // 
            this.btn_PollQ.Location = new System.Drawing.Point(1254, 49);
            this.btn_PollQ.Name = "btn_PollQ";
            this.btn_PollQ.Size = new System.Drawing.Size(75, 28);
            this.btn_PollQ.TabIndex = 1;
            this.btn_PollQ.Text = "Poll Q";
            this.btn_PollQ.UseVisualStyleBackColor = true;
            this.btn_PollQ.Click += new System.EventHandler(this.btn_PollQ_Click);
            // 
            // btn_Clear_Log
            // 
            this.btn_Clear_Log.Location = new System.Drawing.Point(1115, 54);
            this.btn_Clear_Log.Name = "btn_Clear_Log";
            this.btn_Clear_Log.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear_Log.TabIndex = 2;
            this.btn_Clear_Log.Text = "Clear";
            this.btn_Clear_Log.UseVisualStyleBackColor = true;
            this.btn_Clear_Log.Click += new System.EventHandler(this.btn_Clear_Log_Click);
            // 
            // KarmaSlaveUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1347, 429);
            this.Controls.Add(this.btn_Clear_Log);
            this.Controls.Add(this.btn_PollQ);
            this.Controls.Add(this.groupBox1);
            this.Name = "KarmaSlaveUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Karma SLAVE";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox Logger;
        private System.Windows.Forms.Button btn_PollQ;
        private System.Windows.Forms.Button btn_Clear_Log;
    }
}

