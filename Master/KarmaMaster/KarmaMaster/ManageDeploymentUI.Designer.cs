namespace KarmaMaster
{
    partial class ManageDeploymentUI
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
            this.txt_Jenkins_Build_Number = new System.Windows.Forms.TextBox();
            this.txt_Deployment_Number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_DBChanges = new System.Windows.Forms.CheckBox();
            this.chk_WinServices = new System.Windows.Forms.CheckBox();
            this.chk_CP = new System.Windows.Forms.CheckBox();
            this.chk_API = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk_env_LON = new System.Windows.Forms.CheckBox();
            this.chk_env_ORD = new System.Windows.Forms.CheckBox();
            this.chk_env_SYD = new System.Windows.Forms.CheckBox();
            this.chk_env_TEST = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_deploy = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Logger = new System.Windows.Forms.RichTextBox();
            this.btn_Clear_logs = new System.Windows.Forms.Button();
            this.btn_Poll_Q = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Jenkins_Build_Number);
            this.groupBox1.Controls.Add(this.txt_Deployment_Number);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Build Properties";
            // 
            // txt_Jenkins_Build_Number
            // 
            this.txt_Jenkins_Build_Number.Location = new System.Drawing.Point(82, 61);
            this.txt_Jenkins_Build_Number.Name = "txt_Jenkins_Build_Number";
            this.txt_Jenkins_Build_Number.Size = new System.Drawing.Size(182, 22);
            this.txt_Jenkins_Build_Number.TabIndex = 4;
            this.txt_Jenkins_Build_Number.Text = "133";
            // 
            // txt_Deployment_Number
            // 
            this.txt_Deployment_Number.Location = new System.Drawing.Point(82, 31);
            this.txt_Deployment_Number.Name = "txt_Deployment_Number";
            this.txt_Deployment_Number.Size = new System.Drawing.Size(182, 22);
            this.txt_Deployment_Number.TabIndex = 4;
            this.txt_Deployment_Number.Text = "v1.9.03-Hack";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Build #:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Version:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk_DBChanges);
            this.groupBox2.Controls.Add(this.chk_WinServices);
            this.groupBox2.Controls.Add(this.chk_CP);
            this.groupBox2.Controls.Add(this.chk_API);
            this.groupBox2.Location = new System.Drawing.Point(353, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 146);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modules to Deploy";
            // 
            // chk_DBChanges
            // 
            this.chk_DBChanges.AutoSize = true;
            this.chk_DBChanges.Location = new System.Drawing.Point(33, 119);
            this.chk_DBChanges.Name = "chk_DBChanges";
            this.chk_DBChanges.Size = new System.Drawing.Size(159, 21);
            this.chk_DBChanges.TabIndex = 3;
            this.chk_DBChanges.Text = "Database Changes?";
            this.chk_DBChanges.UseVisualStyleBackColor = true;
            // 
            // chk_WinServices
            // 
            this.chk_WinServices.AutoSize = true;
            this.chk_WinServices.Checked = true;
            this.chk_WinServices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_WinServices.Location = new System.Drawing.Point(33, 89);
            this.chk_WinServices.Name = "chk_WinServices";
            this.chk_WinServices.Size = new System.Drawing.Size(144, 21);
            this.chk_WinServices.TabIndex = 2;
            this.chk_WinServices.Text = "Windows Services";
            this.chk_WinServices.UseVisualStyleBackColor = true;
            // 
            // chk_CP
            // 
            this.chk_CP.AutoSize = true;
            this.chk_CP.Checked = true;
            this.chk_CP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_CP.Location = new System.Drawing.Point(33, 62);
            this.chk_CP.Name = "chk_CP";
            this.chk_CP.Size = new System.Drawing.Size(48, 21);
            this.chk_CP.TabIndex = 1;
            this.chk_CP.Text = "CP";
            this.chk_CP.UseVisualStyleBackColor = true;
            // 
            // chk_API
            // 
            this.chk_API.AutoSize = true;
            this.chk_API.Checked = true;
            this.chk_API.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_API.Location = new System.Drawing.Point(33, 37);
            this.chk_API.Name = "chk_API";
            this.chk_API.Size = new System.Drawing.Size(51, 21);
            this.chk_API.TabIndex = 0;
            this.chk_API.Text = "API";
            this.chk_API.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chk_env_LON);
            this.groupBox3.Controls.Add(this.chk_env_ORD);
            this.groupBox3.Controls.Add(this.chk_env_SYD);
            this.groupBox3.Controls.Add(this.chk_env_TEST);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(24, 217);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 161);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Deployment Settings";
            // 
            // chk_env_LON
            // 
            this.chk_env_LON.AutoSize = true;
            this.chk_env_LON.Location = new System.Drawing.Point(39, 128);
            this.chk_env_LON.Name = "chk_env_LON";
            this.chk_env_LON.Size = new System.Drawing.Size(59, 21);
            this.chk_env_LON.TabIndex = 4;
            this.chk_env_LON.Text = "LON";
            this.chk_env_LON.UseVisualStyleBackColor = true;
            // 
            // chk_env_ORD
            // 
            this.chk_env_ORD.AutoSize = true;
            this.chk_env_ORD.Location = new System.Drawing.Point(39, 106);
            this.chk_env_ORD.Name = "chk_env_ORD";
            this.chk_env_ORD.Size = new System.Drawing.Size(61, 21);
            this.chk_env_ORD.TabIndex = 4;
            this.chk_env_ORD.Text = "ORD";
            this.chk_env_ORD.UseVisualStyleBackColor = true;
            // 
            // chk_env_SYD
            // 
            this.chk_env_SYD.AutoSize = true;
            this.chk_env_SYD.Checked = true;
            this.chk_env_SYD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_env_SYD.Location = new System.Drawing.Point(39, 79);
            this.chk_env_SYD.Name = "chk_env_SYD";
            this.chk_env_SYD.Size = new System.Drawing.Size(58, 21);
            this.chk_env_SYD.TabIndex = 4;
            this.chk_env_SYD.Text = "SYD";
            this.chk_env_SYD.UseVisualStyleBackColor = true;
            // 
            // chk_env_TEST
            // 
            this.chk_env_TEST.AutoSize = true;
            this.chk_env_TEST.Location = new System.Drawing.Point(39, 52);
            this.chk_env_TEST.Name = "chk_env_TEST";
            this.chk_env_TEST.Size = new System.Drawing.Size(66, 21);
            this.chk_env_TEST.TabIndex = 4;
            this.chk_env_TEST.Text = "TEST";
            this.chk_env_TEST.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Deploy To:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_Email);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(353, 217);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(317, 161);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Notifications";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(18, 65);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(282, 22);
            this.txt_Email.TabIndex = 1;
            this.txt_Email.Text = "balaji.iyer@rackspace.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Send Email To:";
            // 
            // btn_deploy
            // 
            this.btn_deploy.Location = new System.Drawing.Point(711, 97);
            this.btn_deploy.Name = "btn_deploy";
            this.btn_deploy.Size = new System.Drawing.Size(75, 29);
            this.btn_deploy.TabIndex = 4;
            this.btn_deploy.Text = "Deploy";
            this.btn_deploy.UseVisualStyleBackColor = true;
            this.btn_deploy.Click += new System.EventHandler(this.btn_deploy_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(711, 132);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 28);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Logger);
            this.groupBox5.Location = new System.Drawing.Point(24, 420);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(646, 275);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Logs";
            // 
            // Logger
            // 
            this.Logger.Location = new System.Drawing.Point(6, 21);
            this.Logger.Name = "Logger";
            this.Logger.Size = new System.Drawing.Size(634, 248);
            this.Logger.TabIndex = 0;
            this.Logger.Text = "";
            // 
            // btn_Clear_logs
            // 
            this.btn_Clear_logs.Location = new System.Drawing.Point(711, 441);
            this.btn_Clear_logs.Name = "btn_Clear_logs";
            this.btn_Clear_logs.Size = new System.Drawing.Size(75, 26);
            this.btn_Clear_logs.TabIndex = 7;
            this.btn_Clear_logs.Text = "Clear";
            this.btn_Clear_logs.UseVisualStyleBackColor = true;
            this.btn_Clear_logs.Click += new System.EventHandler(this.btn_Clear_logs_Click);
            // 
            // btn_Poll_Q
            // 
            this.btn_Poll_Q.Location = new System.Drawing.Point(711, 41);
            this.btn_Poll_Q.Name = "btn_Poll_Q";
            this.btn_Poll_Q.Size = new System.Drawing.Size(75, 23);
            this.btn_Poll_Q.TabIndex = 8;
            this.btn_Poll_Q.Text = "Poll Q";
            this.btn_Poll_Q.UseVisualStyleBackColor = true;
            this.btn_Poll_Q.Click += new System.EventHandler(this.btn_Poll_Q_Click);
            // 
            // ManageDeploymentUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 707);
            this.Controls.Add(this.btn_Poll_Q);
            this.Controls.Add(this.btn_Clear_logs);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_deploy);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageDeploymentUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Karma MASTER";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Jenkins_Build_Number;
        private System.Windows.Forms.TextBox txt_Deployment_Number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_DBChanges;
        private System.Windows.Forms.CheckBox chk_WinServices;
        private System.Windows.Forms.CheckBox chk_CP;
        private System.Windows.Forms.CheckBox chk_API;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chk_env_LON;
        private System.Windows.Forms.CheckBox chk_env_ORD;
        private System.Windows.Forms.CheckBox chk_env_SYD;
        private System.Windows.Forms.CheckBox chk_env_TEST;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_deploy;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox Logger;
        private System.Windows.Forms.Button btn_Clear_logs;
        private System.Windows.Forms.Button btn_Poll_Q;
    }
}

