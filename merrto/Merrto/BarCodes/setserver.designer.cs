namespace Merrto
{
    partial class SetServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnout = new System.Windows.Forms.Button();
            this.txtserverIP = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.cmbdbo = new System.Windows.Forms.ComboBox();
            this.btnquit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "数据库：";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(16, 225);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 4;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnout
            // 
            this.btnout.Location = new System.Drawing.Point(109, 225);
            this.btnout.Name = "btnout";
            this.btnout.Size = new System.Drawing.Size(75, 23);
            this.btnout.TabIndex = 5;
            this.btnout.Text = "测试连接";
            this.btnout.UseVisualStyleBackColor = true;
            this.btnout.Click += new System.EventHandler(this.btnout_Click);
            // 
            // txtserverIP
            // 
            this.txtserverIP.Location = new System.Drawing.Point(93, 30);
            this.txtserverIP.Name = "txtserverIP";
            this.txtserverIP.Size = new System.Drawing.Size(180, 21);
            this.txtserverIP.TabIndex = 7;
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(93, 74);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(180, 21);
            this.txtuser.TabIndex = 8;
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(93, 117);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(180, 21);
            this.txtpwd.TabIndex = 9;
            // 
            // cmbdbo
            // 
            this.cmbdbo.FormattingEnabled = true;
            this.cmbdbo.Location = new System.Drawing.Point(93, 169);
            this.cmbdbo.Name = "cmbdbo";
            this.cmbdbo.Size = new System.Drawing.Size(180, 20);
            this.cmbdbo.TabIndex = 10;
            this.cmbdbo.Enter += new System.EventHandler(this.cmbdbo_Enter);
            // 
            // btnquit
            // 
            this.btnquit.Location = new System.Drawing.Point(205, 225);
            this.btnquit.Name = "btnquit";
            this.btnquit.Size = new System.Drawing.Size(75, 23);
            this.btnquit.TabIndex = 11;
            this.btnquit.Text = "退出";
            this.btnquit.UseVisualStyleBackColor = true;
            this.btnquit.Click += new System.EventHandler(this.btnquit_Click);
            // 
            // SetServer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnquit);
            this.Controls.Add(this.cmbdbo);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.txtserverIP);
            this.Controls.Add(this.btnout);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetServer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetServer";
            this.Load += new System.EventHandler(this.SetServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnout;
        private System.Windows.Forms.TextBox txtserverIP;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.ComboBox cmbdbo;
        private System.Windows.Forms.Button btnquit;
    }
}