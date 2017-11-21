namespace Merrto
{
    partial class ProductSize
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
            this.btnSave = new System.Windows.Forms.Button();
            this.SizeDGV = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSize = new System.Windows.Forms.CheckBox();
            this.chkproduct = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.SizeDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(502, 364);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SizeDGV
            // 
            this.SizeDGV.AllowUserToAddRows = false;
            this.SizeDGV.AllowUserToDeleteRows = false;
            this.SizeDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.SizeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SizeDGV.Location = new System.Drawing.Point(7, 31);
            this.SizeDGV.Name = "SizeDGV";
            this.SizeDGV.ReadOnly = true;
            this.SizeDGV.RowTemplate.Height = 23;
            this.SizeDGV.Size = new System.Drawing.Size(266, 327);
            this.SizeDGV.TabIndex = 7;
            this.SizeDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SizeDGV_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "产品货号";
            // 
            // ProductDGV
            // 
            this.ProductDGV.AllowUserToAddRows = false;
            this.ProductDGV.AllowUserToDeleteRows = false;
            this.ProductDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ProductDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDGV.Location = new System.Drawing.Point(279, 31);
            this.ProductDGV.Name = "ProductDGV";
            this.ProductDGV.ReadOnly = true;
            this.ProductDGV.RowTemplate.Height = 23;
            this.ProductDGV.Size = new System.Drawing.Size(298, 327);
            this.ProductDGV.TabIndex = 11;
            this.ProductDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductDGV_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "尺码名称";
            // 
            // chkSize
            // 
            this.chkSize.AutoSize = true;
            this.chkSize.Checked = true;
            this.chkSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSize.Location = new System.Drawing.Point(357, 7);
            this.chkSize.Name = "chkSize";
            this.chkSize.Size = new System.Drawing.Size(108, 16);
            this.chkSize.TabIndex = 14;
            this.chkSize.Text = "只显示没有设置";
            this.chkSize.UseVisualStyleBackColor = true;
            // 
            // chkproduct
            // 
            this.chkproduct.AutoSize = true;
            this.chkproduct.Location = new System.Drawing.Point(491, 7);
            this.chkproduct.Name = "chkproduct";
            this.chkproduct.Size = new System.Drawing.Size(84, 16);
            this.chkproduct.TabIndex = 15;
            this.chkproduct.Text = "只显示设置";
            this.chkproduct.UseVisualStyleBackColor = true;
            // 
            // ProductSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 398);
            this.Controls.Add(this.chkproduct);
            this.Controls.Add(this.chkSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProductDGV);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.SizeDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductSize";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品与尺码";
            this.Load += new System.EventHandler(this.ProductSize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SizeDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView SizeDGV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ProductDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSize;
        private System.Windows.Forms.CheckBox chkproduct;
    }
}