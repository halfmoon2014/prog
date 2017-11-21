namespace Merrto.WPH
{
    partial class WphtrBarCode
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
            this.ProudctDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPrompt = new System.Windows.Forms.CheckBox();
            this.TxtBarCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LBLPAsking = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProudctDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.ProudctDGV.Size = new System.Drawing.Size(790, 524);
            this.ProudctDGV.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPrompt);
            this.groupBox1.Controls.Add(this.TxtBarCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LBLPAsking);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // chkPrompt
            // 
            this.chkPrompt.AutoSize = true;
            this.chkPrompt.Checked = true;
            this.chkPrompt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrompt.Location = new System.Drawing.Point(452, 14);
            this.chkPrompt.Name = "chkPrompt";
            this.chkPrompt.Size = new System.Drawing.Size(72, 16);
            this.chkPrompt.TabIndex = 6;
            this.chkPrompt.Text = "声音提示";
            this.chkPrompt.UseVisualStyleBackColor = true;
            // 
            // TxtBarCode
            // 
            this.TxtBarCode.Font = new System.Drawing.Font("宋体", 23F);
            this.TxtBarCode.Location = new System.Drawing.Point(87, 12);
            this.TxtBarCode.Name = "TxtBarCode";
            this.TxtBarCode.Size = new System.Drawing.Size(359, 42);
            this.TxtBarCode.TabIndex = 1;
            this.TxtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarCode_KeyDown);
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
            // LBLPAsking
            // 
            this.LBLPAsking.AutoSize = true;
            this.LBLPAsking.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBLPAsking.Location = new System.Drawing.Point(96, 69);
            this.LBLPAsking.Name = "LBLPAsking";
            this.LBLPAsking.Size = new System.Drawing.Size(0, 16);
            this.LBLPAsking.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前箱号:";
            // 
            // WphtrBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 624);
            this.Controls.Add(this.ProudctDGV);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WphtrBarCode";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "退货检验";
            ((System.ComponentModel.ISupportInitialize)(this.ProudctDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProudctDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPrompt;
        private System.Windows.Forms.TextBox TxtBarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBLPAsking;
        private System.Windows.Forms.Label label2;
    }
}