namespace Merrto
{
    partial class ZXBarCode
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Cmbprint = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnprints = new System.Windows.Forms.Button();
            this.chkprint = new System.Windows.Forms.CheckBox();
            this.chkPrompt = new System.Windows.Forms.CheckBox();
            this.btnBARCode = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TXTBarCode = new System.Windows.Forms.TextBox();
            this.LBBarCode = new System.Windows.Forms.ListBox();
            this.TXTROEER = new System.Windows.Forms.TextBox();
            this.TXTNomber = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Cmbprint);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnprint);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnprints);
            this.groupBox2.Controls.Add(this.chkprint);
            this.groupBox2.Controls.Add(this.chkPrompt);
            this.groupBox2.Controls.Add(this.btnBARCode);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(921, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // Cmbprint
            // 
            this.Cmbprint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmbprint.FormattingEnabled = true;
            this.Cmbprint.Location = new System.Drawing.Point(300, 12);
            this.Cmbprint.Name = "Cmbprint";
            this.Cmbprint.Size = new System.Drawing.Size(94, 20);
            this.Cmbprint.TabIndex = 15;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(320, 38);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(74, 45);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(224, 38);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(96, 45);
            this.btnprint.TabIndex = 19;
            this.btnprint.Text = "直接打印";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "打印方式：";
            // 
            // btnprints
            // 
            this.btnprints.Location = new System.Drawing.Point(125, 38);
            this.btnprints.Name = "btnprints";
            this.btnprints.Size = new System.Drawing.Size(99, 45);
            this.btnprints.TabIndex = 16;
            this.btnprints.Text = "打印预览";
            this.btnprints.UseVisualStyleBackColor = true;
            this.btnprints.Click += new System.EventHandler(this.btnprints_Click);
            // 
            // chkprint
            // 
            this.chkprint.AutoSize = true;
            this.chkprint.Checked = true;
            this.chkprint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkprint.Location = new System.Drawing.Point(63, 16);
            this.chkprint.Name = "chkprint";
            this.chkprint.Size = new System.Drawing.Size(72, 16);
            this.chkprint.TabIndex = 14;
            this.chkprint.Text = "直接打印";
            this.chkprint.UseVisualStyleBackColor = true;
            // 
            // chkPrompt
            // 
            this.chkPrompt.AutoSize = true;
            this.chkPrompt.Checked = true;
            this.chkPrompt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrompt.Location = new System.Drawing.Point(6, 16);
            this.chkPrompt.Name = "chkPrompt";
            this.chkPrompt.Size = new System.Drawing.Size(60, 16);
            this.chkPrompt.TabIndex = 13;
            this.chkPrompt.Text = "提示音";
            this.chkPrompt.UseVisualStyleBackColor = true;
            // 
            // btnBARCode
            // 
            this.btnBARCode.Location = new System.Drawing.Point(4, 38);
            this.btnBARCode.Name = "btnBARCode";
            this.btnBARCode.Size = new System.Drawing.Size(121, 45);
            this.btnBARCode.TabIndex = 10;
            this.btnBARCode.Text = "打印模版设设置";
            this.btnBARCode.UseVisualStyleBackColor = true;
            this.btnBARCode.Click += new System.EventHandler(this.btnBARCode_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TXTBarCode);
            this.groupBox3.Controls.Add(this.LBBarCode);
            this.groupBox3.Controls.Add(this.TXTROEER);
            this.groupBox3.Controls.Add(this.TXTNomber);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(0, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(921, 457);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // TXTBarCode
            // 
            this.TXTBarCode.BackColor = System.Drawing.SystemColors.MenuText;
            this.TXTBarCode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TXTBarCode.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TXTBarCode.ForeColor = System.Drawing.SystemColors.Window;
            this.TXTBarCode.Location = new System.Drawing.Point(3, 416);
            this.TXTBarCode.Name = "TXTBarCode";
            this.TXTBarCode.Size = new System.Drawing.Size(915, 38);
            this.TXTBarCode.TabIndex = 6;
            this.TXTBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXTBarCode_KeyDown);
            // 
            // LBBarCode
            // 
            this.LBBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LBBarCode.BackColor = System.Drawing.SystemColors.WindowText;
            this.LBBarCode.Font = new System.Drawing.Font("宋体", 20F);
            this.LBBarCode.ForeColor = System.Drawing.Color.White;
            this.LBBarCode.FormattingEnabled = true;
            this.LBBarCode.IntegralHeight = false;
            this.LBBarCode.ItemHeight = 27;
            this.LBBarCode.Location = new System.Drawing.Point(3, 12);
            this.LBBarCode.Name = "LBBarCode";
            this.LBBarCode.Size = new System.Drawing.Size(434, 402);
            this.LBBarCode.TabIndex = 4;
            // 
            // TXTROEER
            // 
            this.TXTROEER.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TXTROEER.BackColor = System.Drawing.SystemColors.MenuText;
            this.TXTROEER.ForeColor = System.Drawing.SystemColors.Window;
            this.TXTROEER.Location = new System.Drawing.Point(640, 11);
            this.TXTROEER.Multiline = true;
            this.TXTROEER.Name = "TXTROEER";
            this.TXTROEER.Size = new System.Drawing.Size(277, 401);
            this.TXTROEER.TabIndex = 2;
            // 
            // TXTNomber
            // 
            this.TXTNomber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TXTNomber.BackColor = System.Drawing.SystemColors.MenuText;
            this.TXTNomber.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TXTNomber.ForeColor = System.Drawing.SystemColors.Window;
            this.TXTNomber.Location = new System.Drawing.Point(439, 12);
            this.TXTNomber.Multiline = true;
            this.TXTNomber.Name = "TXTNomber";
            this.TXTNomber.Size = new System.Drawing.Size(199, 401);
            this.TXTNomber.TabIndex = 1;
            this.TXTNomber.Text = "扫描次数：  0";
            this.TXTNomber.TextChanged += new System.EventHandler(this.TXTNomber_TextChanged);
            // 
            // ZXBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 543);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ZXBarCode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "条码扫描";
            this.Load += new System.EventHandler(this.BarCode_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TXTROEER;
        private System.Windows.Forms.TextBox TXTNomber;
        private System.Windows.Forms.ListBox LBBarCode;
        private System.Windows.Forms.Button btnBARCode;
        private System.Windows.Forms.CheckBox chkprint;
        private System.Windows.Forms.CheckBox chkPrompt;
        private System.Windows.Forms.ComboBox Cmbprint;
        private System.Windows.Forms.Button btnprints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox TXTBarCode;
    }
}

