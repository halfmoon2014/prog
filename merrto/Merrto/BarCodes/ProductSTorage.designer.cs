namespace Merrto
{
    partial class ProductSTorage
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
            this.cmbitem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductStorageDGV = new System.Windows.Forms.DataGridView();
            this.BTNSave = new System.Windows.Forms.Button();
            this.cboStock = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnread = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProductStorageDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbitem
            // 
            this.cmbitem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbitem.FormattingEnabled = true;
            this.cmbitem.Location = new System.Drawing.Point(51, 49);
            this.cmbitem.Name = "cmbitem";
            this.cmbitem.Size = new System.Drawing.Size(349, 20);
            this.cmbitem.TabIndex = 0;
            this.cmbitem.SelectedValueChanged += new System.EventHandler(this.cmbitem_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "货号：";
            // 
            // ProductStorageDGV
            // 
            this.ProductStorageDGV.AllowUserToAddRows = false;
            this.ProductStorageDGV.AllowUserToDeleteRows = false;
            this.ProductStorageDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ProductStorageDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductStorageDGV.Location = new System.Drawing.Point(13, 75);
            this.ProductStorageDGV.Name = "ProductStorageDGV";
            this.ProductStorageDGV.RowTemplate.Height = 23;
            this.ProductStorageDGV.Size = new System.Drawing.Size(387, 390);
            this.ProductStorageDGV.TabIndex = 2;
            // 
            // BTNSave
            // 
            this.BTNSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNSave.Location = new System.Drawing.Point(294, 473);
            this.BTNSave.Name = "BTNSave";
            this.BTNSave.Size = new System.Drawing.Size(90, 26);
            this.BTNSave.TabIndex = 5;
            this.BTNSave.Text = "保存";
            this.BTNSave.UseVisualStyleBackColor = true;
            this.BTNSave.Click += new System.EventHandler(this.BTNSave_Click);
            // 
            // cboStock
            // 
            this.cboStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStock.FormattingEnabled = true;
            this.cboStock.Location = new System.Drawing.Point(51, 12);
            this.cboStock.Name = "cboStock";
            this.cboStock.Size = new System.Drawing.Size(349, 20);
            this.cboStock.TabIndex = 7;
            this.cboStock.SelectedValueChanged += new System.EventHandler(this.cboStock_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "仓库：";
            // 
            // btnread
            // 
            this.btnread.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnread.Location = new System.Drawing.Point(32, 473);
            this.btnread.Name = "btnread";
            this.btnread.Size = new System.Drawing.Size(90, 26);
            this.btnread.TabIndex = 9;
            this.btnread.Text = "读取";
            this.btnread.UseVisualStyleBackColor = true;
            this.btnread.Click += new System.EventHandler(this.btnread_Click);
            // 
            // ProductSTorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 511);
            this.Controls.Add(this.btnread);
            this.Controls.Add(this.cboStock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTNSave);
            this.Controls.Add(this.cmbitem);
            this.Controls.Add(this.ProductStorageDGV);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductSTorage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "库位定义";
            this.Load += new System.EventHandler(this.ProductSTorage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductStorageDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbitem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ProductStorageDGV;
        private System.Windows.Forms.Button BTNSave;
        private System.Windows.Forms.ComboBox cboStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnread;
    }
}