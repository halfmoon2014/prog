namespace Merrto
{
    partial class WphBarCode
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
            this.TxtBarCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LBLPAsking = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPrompt = new System.Windows.Forms.CheckBox();
            this.ProudctDGV = new System.Windows.Forms.DataGridView();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProudctDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 23F);
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "条码：";
            // 
            // TxtBarCode
            // 
            this.TxtBarCode.Font = new System.Drawing.Font("宋体", 23F);
            this.TxtBarCode.Location = new System.Drawing.Point(87, 12);
            this.TxtBarCode.Name = "TxtBarCode";
            this.TxtBarCode.Size = new System.Drawing.Size(346, 42);
            this.TxtBarCode.TabIndex = 1;
            this.TxtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前箱号:";
            // 
            // LBLPAsking
            // 
            this.LBLPAsking.AutoSize = true;
            this.LBLPAsking.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBLPAsking.Location = new System.Drawing.Point(96, 62);
            this.LBLPAsking.Name = "LBLPAsking";
            this.LBLPAsking.Size = new System.Drawing.Size(128, 16);
            this.LBLPAsking.TabIndex = 3;
            this.LBLPAsking.Text = "GZ2010070400001";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelPreview);
            this.groupBox1.Controls.Add(this.chkPrompt);
            this.groupBox1.Controls.Add(this.TxtBarCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LBLPAsking);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // chkPrompt
            // 
            this.chkPrompt.AutoSize = true;
            this.chkPrompt.Checked = true;
            this.chkPrompt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrompt.Font = new System.Drawing.Font("宋体", 9F);
            this.chkPrompt.Location = new System.Drawing.Point(445, 12);
            this.chkPrompt.Name = "chkPrompt";
            this.chkPrompt.Size = new System.Drawing.Size(72, 16);
            this.chkPrompt.TabIndex = 6;
            this.chkPrompt.Text = "声音提示";
            this.chkPrompt.UseVisualStyleBackColor = true;
            // 
            // ProudctDGV
            // 
            this.ProudctDGV.AllowUserToAddRows = false;
            this.ProudctDGV.AllowUserToDeleteRows = false;
            this.ProudctDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProudctDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProudctDGV.Location = new System.Drawing.Point(0, 100);
            this.ProudctDGV.Name = "ProudctDGV";
            this.ProudctDGV.ReadOnly = true;
            this.ProudctDGV.RowTemplate.Height = 23;
            this.ProudctDGV.Size = new System.Drawing.Size(720, 402);
            this.ProudctDGV.TabIndex = 7;
            // 
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.Location = new System.Drawing.Point(526, 3);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(189, 93);
            this.panelPreview.TabIndex = 8;
            // 
            // WphBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 502);
            this.Controls.Add(this.ProudctDGV);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WphBarCode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "唯品汇条码扫描";
            this.Load += new System.EventHandler(this.WphBarCode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProudctDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBarCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBLPAsking;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView ProudctDGV;
        private System.Windows.Forms.CheckBox chkPrompt;
        private System.Windows.Forms.Panel panelPreview;
    }
}