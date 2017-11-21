namespace Merrto.TheShopReports
{
    partial class STR_ProductWeight
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
            this.ProductDGV = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.SizeDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TXtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBrow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductDGV
            // 
            this.ProductDGV.AllowUserToAddRows = false;
            this.ProductDGV.AllowUserToDeleteRows = false;
            this.ProductDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ProductDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDGV.Location = new System.Drawing.Point(6, 46);
            this.ProductDGV.Name = "ProductDGV";
            this.ProductDGV.ReadOnly = true;
            this.ProductDGV.RowTemplate.Height = 23;
            this.ProductDGV.Size = new System.Drawing.Size(285, 331);
            this.ProductDGV.TabIndex = 14;
            this.ProductDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductDGV_CellClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(198, 383);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "产品重量定义";
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
            this.SizeDGV.Location = new System.Drawing.Point(297, 46);
            this.SizeDGV.Name = "SizeDGV";
            this.SizeDGV.ReadOnly = true;
            this.SizeDGV.RowTemplate.Height = 23;
            this.SizeDGV.Size = new System.Drawing.Size(279, 331);
            this.SizeDGV.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TXtCade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnBrow);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 48);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // TXtCade
            // 
            this.TXtCade.Location = new System.Drawing.Point(53, 16);
            this.TXtCade.Name = "TXtCade";
            this.TXtCade.Size = new System.Drawing.Size(139, 21);
            this.TXtCade.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "款号：";
            // 
            // BtnBrow
            // 
            this.BtnBrow.Location = new System.Drawing.Point(198, 14);
            this.BtnBrow.Name = "BtnBrow";
            this.BtnBrow.Size = new System.Drawing.Size(75, 26);
            this.BtnBrow.TabIndex = 0;
            this.BtnBrow.Text = "查询";
            this.BtnBrow.UseVisualStyleBackColor = true;
            this.BtnBrow.Click += new System.EventHandler(this.BtnBrow_Click);
            // 
            // STR_ProductWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 415);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ProductDGV);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.SizeDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "STR_ProductWeight";
            this.Text = "STR_ProductWeight";
            this.Load += new System.EventHandler(this.STR_ProductWeight_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProductDGV;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView SizeDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TXtCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBrow;
    }
}