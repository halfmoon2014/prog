namespace Merrto.M_System
{
    partial class waiServer
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
            this.cmbdbo = new System.Windows.Forms.ComboBox();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtserverIP = new System.Windows.Forms.TextBox();
            this.btnout = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbdbo
            // 
            this.cmbdbo.FormattingEnabled = true;
            this.cmbdbo.Location = new System.Drawing.Point(106, 158);
            this.cmbdbo.Name = "cmbdbo";
            this.cmbdbo.Size = new System.Drawing.Size(180, 20);
            this.cmbdbo.TabIndex = 21;
            this.cmbdbo.Enter += new System.EventHandler(this.cmbdbo_Enter);
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(106, 106);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(180, 21);
            this.txtpwd.TabIndex = 20;
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(106, 63);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(180, 21);
            this.txtuser.TabIndex = 19;
            // 
            // txtserverIP
            // 
            this.txtserverIP.Location = new System.Drawing.Point(106, 19);
            this.txtserverIP.Name = "txtserverIP";
            this.txtserverIP.Size = new System.Drawing.Size(180, 21);
            this.txtserverIP.TabIndex = 18;
            // 
            // btnout
            // 
            this.btnout.Location = new System.Drawing.Point(211, 214);
            this.btnout.Name = "btnout";
            this.btnout.Size = new System.Drawing.Size(75, 23);
            this.btnout.TabIndex = 17;
            this.btnout.Text = "测试连接";
            this.btnout.UseVisualStyleBackColor = true;
            this.btnout.Click += new System.EventHandler(this.btnout_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(29, 214);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 16;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "数据库：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "用户名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "服务器地址：";
            // 
            // waiServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 268);
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
            this.Name = "waiServer";
            this.Text = "waiServer";
            this.Load += new System.EventHandler(this.waiServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbdbo;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtserverIP;
        private System.Windows.Forms.Button btnout;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}