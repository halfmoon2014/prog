namespace Merrto.M_System
{
    partial class EditPassWord
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
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPassWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfiredPassWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnlogin = new System.Windows.Forms.Button();
            this.BtnCand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("宋体", 12F);
            this.txtPassWord.Location = new System.Drawing.Point(99, 27);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(247, 26);
            this.txtPassWord.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(36, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "原密码：";
            // 
            // txtNewPassWord
            // 
            this.txtNewPassWord.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNewPassWord.Location = new System.Drawing.Point(99, 77);
            this.txtNewPassWord.Name = "txtNewPassWord";
            this.txtNewPassWord.PasswordChar = '*';
            this.txtNewPassWord.Size = new System.Drawing.Size(247, 26);
            this.txtNewPassWord.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(36, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "新密码：";
            // 
            // txtfiredPassWord
            // 
            this.txtfiredPassWord.Font = new System.Drawing.Font("宋体", 12F);
            this.txtfiredPassWord.Location = new System.Drawing.Point(99, 121);
            this.txtfiredPassWord.Name = "txtfiredPassWord";
            this.txtfiredPassWord.PasswordChar = '*';
            this.txtfiredPassWord.Size = new System.Drawing.Size(247, 26);
            this.txtfiredPassWord.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(20, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "确认密码：";
            // 
            // btnlogin
            // 
            this.btnlogin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnlogin.Location = new System.Drawing.Point(99, 169);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(75, 28);
            this.btnlogin.TabIndex = 10;
            this.btnlogin.Text = "确认(&S)";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // BtnCand
            // 
            this.BtnCand.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCand.Location = new System.Drawing.Point(266, 170);
            this.BtnCand.Name = "BtnCand";
            this.BtnCand.Size = new System.Drawing.Size(75, 28);
            this.BtnCand.TabIndex = 11;
            this.BtnCand.Text = "取消(&S)";
            this.BtnCand.UseVisualStyleBackColor = true;
            this.BtnCand.Click += new System.EventHandler(this.BtnCand_Click);
            // 
            // EditPassWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 217);
            this.Controls.Add(this.BtnCand);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtfiredPassWord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNewPassWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPassWord";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.EditPassWord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPassWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtfiredPassWord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button BtnCand;
    }
}