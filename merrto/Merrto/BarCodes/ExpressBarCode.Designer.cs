namespace Merrto.BarCodes
{
    partial class ExpressBarCode
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
            this.StrageDgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ProudctDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StrageDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // ProudctDGV
            // 
            this.ProudctDGV.AllowUserToAddRows = false;
            this.ProudctDGV.AllowUserToDeleteRows = false;
            this.ProudctDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProudctDGV.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProudctDGV.Location = new System.Drawing.Point(0, 100);
            this.ProudctDGV.Name = "ProudctDGV";
            this.ProudctDGV.ReadOnly = true;
            this.ProudctDGV.RowTemplate.Height = 23;
            this.ProudctDGV.Size = new System.Drawing.Size(306, 394);
            this.ProudctDGV.TabIndex = 9;
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
            this.groupBox1.Size = new System.Drawing.Size(593, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // chkPrompt
            // 
            this.chkPrompt.AutoSize = true;
            this.chkPrompt.Checked = true;
            this.chkPrompt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrompt.Location = new System.Drawing.Point(509, 72);
            this.chkPrompt.Name = "chkPrompt";
            this.chkPrompt.Size = new System.Drawing.Size(72, 16);
            this.chkPrompt.TabIndex = 6;
            this.chkPrompt.Text = "声音提示";
            this.chkPrompt.UseVisualStyleBackColor = true;
            // 
            // TxtBarCode
            // 
            this.TxtBarCode.Font = new System.Drawing.Font("宋体", 23F);
            this.TxtBarCode.Location = new System.Drawing.Point(171, 12);
            this.TxtBarCode.Name = "TxtBarCode";
            this.TxtBarCode.Size = new System.Drawing.Size(410, 42);
            this.TxtBarCode.TabIndex = 1;
            this.TxtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 23F);
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "快递单号：";
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
            this.label2.Text = "快递单号:";
            // 
            // StrageDgv
            // 
            this.StrageDgv.AllowUserToAddRows = false;
            this.StrageDgv.AllowUserToDeleteRows = false;
            this.StrageDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StrageDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StrageDgv.Location = new System.Drawing.Point(306, 100);
            this.StrageDgv.Name = "StrageDgv";
            this.StrageDgv.ReadOnly = true;
            this.StrageDgv.RowTemplate.Height = 23;
            this.StrageDgv.Size = new System.Drawing.Size(287, 394);
            this.StrageDgv.TabIndex = 10;
            // 
            // ExpressBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 494);
            this.Controls.Add(this.StrageDgv);
            this.Controls.Add(this.ProudctDGV);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExpressBarCode";
            this.Text = "ExpressBarCode";
            this.Load += new System.EventHandler(this.ExpressBarCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProudctDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StrageDgv)).EndInit();
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
        private System.Windows.Forms.DataGridView StrageDgv;
    }
}