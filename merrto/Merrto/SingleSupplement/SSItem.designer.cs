namespace Merrto.SingleSupplement
{
    partial class SSItem
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
            this.TCItems = new System.Windows.Forms.TabControl();
            this.TPX = new System.Windows.Forms.TabPage();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SizeDGV = new System.Windows.Forms.DataGridView();
            this.TPItem = new System.Windows.Forms.TabPage();
            this.M_ProductDGV = new System.Windows.Forms.DataGridView();
            this.btnEDITItem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ColourSizeDGV = new System.Windows.Forms.DataGridView();
            this.TCItems.SuspendLayout();
            this.TPX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeDGV)).BeginInit();
            this.TPItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M_ProductDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColourSizeDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // TCItems
            // 
            this.TCItems.Controls.Add(this.TPX);
            this.TCItems.Controls.Add(this.TPItem);
            this.TCItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCItems.Location = new System.Drawing.Point(0, 0);
            this.TCItems.Name = "TCItems";
            this.TCItems.SelectedIndex = 0;
            this.TCItems.Size = new System.Drawing.Size(595, 430);
            this.TCItems.TabIndex = 1;
            // 
            // TPX
            // 
            this.TPX.Controls.Add(this.btnNew);
            this.TPX.Controls.Add(this.label1);
            this.TPX.Controls.Add(this.SizeDGV);
            this.TPX.Location = new System.Drawing.Point(4, 21);
            this.TPX.Name = "TPX";
            this.TPX.Padding = new System.Windows.Forms.Padding(3);
            this.TPX.Size = new System.Drawing.Size(587, 405);
            this.TPX.TabIndex = 0;
            this.TPX.Text = "配码比率";
            this.TPX.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(9, 369);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 18;
            this.btnNew.Text = "关联";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "款号名称";
            // 
            // SizeDGV
            // 
            this.SizeDGV.AllowUserToAddRows = false;
            this.SizeDGV.AllowUserToDeleteRows = false;
            this.SizeDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.SizeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SizeDGV.Location = new System.Drawing.Point(4, 25);
            this.SizeDGV.Name = "SizeDGV";
            this.SizeDGV.ReadOnly = true;
            this.SizeDGV.RowTemplate.Height = 23;
            this.SizeDGV.Size = new System.Drawing.Size(575, 327);
            this.SizeDGV.TabIndex = 14;
            // 
            // TPItem
            // 
            this.TPItem.Controls.Add(this.M_ProductDGV);
            this.TPItem.Controls.Add(this.btnEDITItem);
            this.TPItem.Controls.Add(this.label3);
            this.TPItem.Controls.Add(this.label4);
            this.TPItem.Controls.Add(this.ColourSizeDGV);
            this.TPItem.Location = new System.Drawing.Point(4, 21);
            this.TPItem.Name = "TPItem";
            this.TPItem.Padding = new System.Windows.Forms.Padding(3);
            this.TPItem.Size = new System.Drawing.Size(587, 405);
            this.TPItem.TabIndex = 1;
            this.TPItem.Text = "款号比率";
            this.TPItem.UseVisualStyleBackColor = true;
            // 
            // M_ProductDGV
            // 
            this.M_ProductDGV.AllowUserToAddRows = false;
            this.M_ProductDGV.AllowUserToDeleteRows = false;
            this.M_ProductDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.M_ProductDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.M_ProductDGV.Location = new System.Drawing.Point(5, 26);
            this.M_ProductDGV.Name = "M_ProductDGV";
            this.M_ProductDGV.ReadOnly = true;
            this.M_ProductDGV.RowTemplate.Height = 23;
            this.M_ProductDGV.Size = new System.Drawing.Size(266, 327);
            this.M_ProductDGV.TabIndex = 20;
            this.M_ProductDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.M_ProductDGV_CellClick);
            // 
            // btnEDITItem
            // 
            this.btnEDITItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEDITItem.Location = new System.Drawing.Point(10, 366);
            this.btnEDITItem.Name = "btnEDITItem";
            this.btnEDITItem.Size = new System.Drawing.Size(75, 23);
            this.btnEDITItem.TabIndex = 19;
            this.btnEDITItem.Text = "补充比率";
            this.btnEDITItem.UseVisualStyleBackColor = true;
            this.btnEDITItem.Click += new System.EventHandler(this.btnEDITItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "尺码规格";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "产品名称";
            // 
            // ColourSizeDGV
            // 
            this.ColourSizeDGV.AllowUserToAddRows = false;
            this.ColourSizeDGV.AllowUserToDeleteRows = false;
            this.ColourSizeDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ColourSizeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColourSizeDGV.Location = new System.Drawing.Point(279, 26);
            this.ColourSizeDGV.Name = "ColourSizeDGV";
            this.ColourSizeDGV.ReadOnly = true;
            this.ColourSizeDGV.RowTemplate.Height = 23;
            this.ColourSizeDGV.Size = new System.Drawing.Size(298, 327);
            this.ColourSizeDGV.TabIndex = 15;
            // 
            // SSItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 430);
            this.Controls.Add(this.TCItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SSItem";
            this.Text = "SSItem";
            this.Load += new System.EventHandler(this.SSItem_Load);
            this.TCItems.ResumeLayout(false);
            this.TPX.ResumeLayout(false);
            this.TPX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeDGV)).EndInit();
            this.TPItem.ResumeLayout(false);
            this.TPItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.M_ProductDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColourSizeDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TCItems;
        private System.Windows.Forms.TabPage TPX;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView SizeDGV;
        private System.Windows.Forms.TabPage TPItem;
        private System.Windows.Forms.DataGridView M_ProductDGV;
        private System.Windows.Forms.Button btnEDITItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView ColourSizeDGV;
    }
}