namespace Merrto
{
    partial class frmlogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmlogin));
            this.LblSetServer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChkPWD = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblSetServer
            // 
            this.LblSetServer.AutoSize = true;
            this.LblSetServer.BackColor = System.Drawing.Color.Transparent;
            this.LblSetServer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblSetServer.Location = new System.Drawing.Point(37, 38);
            this.LblSetServer.Name = "LblSetServer";
            this.LblSetServer.Size = new System.Drawing.Size(56, 16);
            this.LblSetServer.TabIndex = 0;
            this.LblSetServer.Text = "帐号：";
            this.LblSetServer.Click += new System.EventHandler(this.LblSetServer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(39, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserID.Location = new System.Drawing.Point(82, 33);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(362, 26);
            this.txtUserID.TabIndex = 2;
            this.txtUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserID_KeyDown);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassWord.Location = new System.Drawing.Point(82, 104);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(362, 26);
            this.txtPassWord.TabIndex = 3;
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassWord_KeyDown);
            // 
            // btnlogin
            // 
            this.btnlogin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnlogin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnlogin.Location = new System.Drawing.Point(83, 165);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(361, 49);
            this.btnlogin.TabIndex = 4;
            this.btnlogin.Text = "登 录(&S)";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnlogin);
            this.panel1.Controls.Add(this.ChkPWD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 248);
            this.panel1.TabIndex = 6;
            // 
            // ChkPWD
            // 
            this.ChkPWD.AutoSize = true;
            this.ChkPWD.Location = new System.Drawing.Point(15, 194);
            this.ChkPWD.Name = "ChkPWD";
            this.ChkPWD.Size = new System.Drawing.Size(72, 16);
            this.ChkPWD.TabIndex = 6;
            this.ChkPWD.Text = "记住密码";
            this.ChkPWD.UseVisualStyleBackColor = true;
            // 
            // frmlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(489, 248);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblSetServer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmlogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmlogin_FormClosing);
            this.Load += new System.EventHandler(this.frmlogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSetServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ChkPWD;
    }
}

