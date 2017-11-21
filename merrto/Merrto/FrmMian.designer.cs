namespace Merrto
{
    partial class FrmMian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMian));
            this.TSPUser = new System.Windows.Forms.ToolStrip();
            this.TSPsoftUPDAte = new System.Windows.Forms.ToolStripButton();
            this.TspEditpassword = new System.Windows.Forms.ToolStripButton();
            this.tspcancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TSSsoftname = new System.Windows.Forms.ToolStripStatusLabel();
            this.PMEUN = new System.Windows.Forms.Panel();
            this.tv_meun = new System.Windows.Forms.TreeView();
            this.SPTLEFT = new System.Windows.Forms.Splitter();
            this.tclMian = new System.Windows.Forms.TabControl();
            this.LblTime = new System.Windows.Forms.Label();
            this.MianTime = new System.Windows.Forms.Timer(this.components);
            this.LblName = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.TSPUser.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.PMEUN.SuspendLayout();
            this.SuspendLayout();
            // 
            // TSPUser
            // 
            this.TSPUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(217)))));
            this.TSPUser.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.TSPUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSPsoftUPDAte,
            this.TspEditpassword,
            this.tspcancel,
            this.toolStripLabel1,
            this.btnExit});
            this.TSPUser.Location = new System.Drawing.Point(0, 0);
            this.TSPUser.Name = "TSPUser";
            this.TSPUser.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TSPUser.Size = new System.Drawing.Size(984, 37);
            this.TSPUser.TabIndex = 0;
            this.TSPUser.Text = "toolStrip1";
            // 
            // TSPsoftUPDAte
            // 
            this.TSPsoftUPDAte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSPsoftUPDAte.Image = ((System.Drawing.Image)(resources.GetObject("TSPsoftUPDAte.Image")));
            this.TSPsoftUPDAte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSPsoftUPDAte.Name = "TSPsoftUPDAte";
            this.TSPsoftUPDAte.Size = new System.Drawing.Size(34, 34);
            this.TSPsoftUPDAte.Text = "检查软件版本";
            this.TSPsoftUPDAte.Click += new System.EventHandler(this.TSPsoftUPDAte_Click);
            // 
            // TspEditpassword
            // 
            this.TspEditpassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TspEditpassword.Image = ((System.Drawing.Image)(resources.GetObject("TspEditpassword.Image")));
            this.TspEditpassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TspEditpassword.Name = "TspEditpassword";
            this.TspEditpassword.Size = new System.Drawing.Size(34, 34);
            this.TspEditpassword.Text = "修改密码";
            this.TspEditpassword.Click += new System.EventHandler(this.TspEditpassword_Click);
            // 
            // tspcancel
            // 
            this.tspcancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspcancel.Image = ((System.Drawing.Image)(resources.GetObject("tspcancel.Image")));
            this.tspcancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspcancel.Name = "tspcancel";
            this.tspcancel.Size = new System.Drawing.Size(34, 34);
            this.tspcancel.Text = "重新登录";
            this.tspcancel.Click += new System.EventHandler(this.tspcancel_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 34);
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(34, 34);
            this.btnExit.Text = "退出软件";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSsoftname});
            this.statusStrip1.Location = new System.Drawing.Point(0, 437);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TSSsoftname
            // 
            this.TSSsoftname.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TSSsoftname.Name = "TSSsoftname";
            this.TSSsoftname.Size = new System.Drawing.Size(193, 20);
            this.TSSsoftname.Text = "||欢迎使用迈途信息管理系统||";
            // 
            // PMEUN
            // 
            this.PMEUN.Controls.Add(this.tv_meun);
            this.PMEUN.Dock = System.Windows.Forms.DockStyle.Left;
            this.PMEUN.Location = new System.Drawing.Point(0, 37);
            this.PMEUN.Name = "PMEUN";
            this.PMEUN.Size = new System.Drawing.Size(183, 400);
            this.PMEUN.TabIndex = 2;
            // 
            // tv_meun
            // 
            this.tv_meun.BackColor = System.Drawing.Color.White;
            this.tv_meun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_meun.Font = new System.Drawing.Font("宋体", 12F);
            this.tv_meun.Location = new System.Drawing.Point(0, 0);
            this.tv_meun.Name = "tv_meun";
            this.tv_meun.Size = new System.Drawing.Size(183, 400);
            this.tv_meun.TabIndex = 0;
            this.tv_meun.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_meun_NodeMouseClick);
            // 
            // SPTLEFT
            // 
            this.SPTLEFT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(217)))));
            this.SPTLEFT.CausesValidation = false;
            this.SPTLEFT.Location = new System.Drawing.Point(183, 37);
            this.SPTLEFT.MaximumSize = new System.Drawing.Size(5, 0);
            this.SPTLEFT.Name = "SPTLEFT";
            this.SPTLEFT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SPTLEFT.Size = new System.Drawing.Size(5, 400);
            this.SPTLEFT.TabIndex = 3;
            this.SPTLEFT.TabStop = false;
            this.SPTLEFT.Tag = "";
            this.SPTLEFT.UseWaitCursor = true;
            this.SPTLEFT.Click += new System.EventHandler(this.SPTLEFT_Click);
            // 
            // tclMian
            // 
            this.tclMian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tclMian.Location = new System.Drawing.Point(188, 37);
            this.tclMian.Name = "tclMian";
            this.tclMian.Padding = new System.Drawing.Point(7, 2);
            this.tclMian.SelectedIndex = 0;
            this.tclMian.Size = new System.Drawing.Size(796, 400);
            this.tclMian.TabIndex = 7;
            // 
            // LblTime
            // 
            this.LblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("宋体", 10F);
            this.LblTime.Location = new System.Drawing.Point(751, 443);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(49, 14);
            this.LblTime.TabIndex = 9;
            this.LblTime.Text = "label1";
            // 
            // MianTime
            // 
            this.MianTime.Tick += new System.EventHandler(this.MianTime_Tick);
            // 
            // LblName
            // 
            this.LblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("宋体", 10F);
            this.LblName.Location = new System.Drawing.Point(404, 442);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(49, 14);
            this.LblName.TabIndex = 10;
            this.LblName.Text = "label1";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(188, 37);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 400);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // FrmMian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.LblTime);
            this.Controls.Add(this.tclMian);
            this.Controls.Add(this.SPTLEFT);
            this.Controls.Add(this.PMEUN);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TSPUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "迈途信息管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMian_FormClosing);
            this.Load += new System.EventHandler(this.FrmMian_Load);
            this.TSPUser.ResumeLayout(false);
            this.TSPUser.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.PMEUN.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TSPUser;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TSSsoftname;
        private System.Windows.Forms.Panel PMEUN;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton tspcancel;
        private System.Windows.Forms.TabControl tclMian;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Timer MianTime;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TreeView tv_meun;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton TspEditpassword;
        private System.Windows.Forms.ToolStripButton TSPsoftUPDAte;
        private System.Windows.Forms.Splitter SPTLEFT;

    }
}