namespace Merrto.M_System
{
    partial class M_ShortMessage
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
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtserverIP = new System.Windows.Forms.TextBox();
            this.btnout = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.chktype = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(62, 103);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(220, 21);
            this.txtpwd.TabIndex = 30;
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(62, 60);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(220, 21);
            this.txtuser.TabIndex = 29;
            // 
            // txtserverIP
            // 
            this.txtserverIP.Location = new System.Drawing.Point(62, 16);
            this.txtserverIP.Name = "txtserverIP";
            this.txtserverIP.Size = new System.Drawing.Size(220, 21);
            this.txtserverIP.TabIndex = 28;
            // 
            // btnout
            // 
            this.btnout.Location = new System.Drawing.Point(207, 156);
            this.btnout.Name = "btnout";
            this.btnout.Size = new System.Drawing.Size(75, 23);
            this.btnout.TabIndex = 27;
            this.btnout.Text = "测试连接";
            this.btnout.UseVisualStyleBackColor = true;
            this.btnout.Click += new System.EventHandler(this.btnout_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(50, 156);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 26;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "用户名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "地址：";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(12, 192);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(41, 12);
            this.lblname.TabIndex = 31;
            this.lblname.Text = "密码：";
            // 
            // chktype
            // 
            this.chktype.AutoSize = true;
            this.chktype.Location = new System.Drawing.Point(62, 134);
            this.chktype.Name = "chktype";
            this.chktype.Size = new System.Drawing.Size(48, 16);
            this.chktype.TabIndex = 32;
            this.chktype.Text = "启用";
            this.chktype.UseVisualStyleBackColor = true;
            // 
            // M_ShortMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 349);
            this.Controls.Add(this.chktype);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.txtserverIP);
            this.Controls.Add(this.btnout);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "M_ShortMessage";
            this.Text = "M_ShortMessage";
            this.Load += new System.EventHandler(this.M_ShortMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtserverIP;
        private System.Windows.Forms.Button btnout;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.CheckBox chktype;
    }
}