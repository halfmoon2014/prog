namespace Merrto.SingleSupplement
{
    partial class SS_WithCade
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
            this.SizeDGV = new System.Windows.Forms.DataGridView();
            this.ProductDGV = new System.Windows.Forms.DataGridView();
            this.BTNSizeADD = new System.Windows.Forms.Button();
            this.GBSelect = new System.Windows.Forms.GroupBox();
            this.TXtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBrow = new System.Windows.Forms.Button();
            this.GBBtn = new System.Windows.Forms.GroupBox();
            this.ColourDgv = new System.Windows.Forms.DataGridView();
            this.BtnColourAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SizeDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDGV)).BeginInit();
            this.GBSelect.SuspendLayout();
            this.GBBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColourDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // SizeDGV
            // 
            this.SizeDGV.AllowUserToAddRows = false;
            this.SizeDGV.AllowUserToDeleteRows = false;
            this.SizeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SizeDGV.Dock = System.Windows.Forms.DockStyle.Left;
            this.SizeDGV.Location = new System.Drawing.Point(262, 37);
            this.SizeDGV.Name = "SizeDGV";
            this.SizeDGV.ReadOnly = true;
            this.SizeDGV.RowTemplate.Height = 23;
            this.SizeDGV.Size = new System.Drawing.Size(273, 442);
            this.SizeDGV.TabIndex = 16;
            // 
            // ProductDGV
            // 
            this.ProductDGV.AllowUserToAddRows = false;
            this.ProductDGV.AllowUserToDeleteRows = false;
            this.ProductDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDGV.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProductDGV.Location = new System.Drawing.Point(0, 37);
            this.ProductDGV.Name = "ProductDGV";
            this.ProductDGV.ReadOnly = true;
            this.ProductDGV.RowTemplate.Height = 23;
            this.ProductDGV.Size = new System.Drawing.Size(262, 442);
            this.ProductDGV.TabIndex = 15;
            this.ProductDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductDGV_CellClick);
            // 
            // BTNSizeADD
            // 
            this.BTNSizeADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNSizeADD.Font = new System.Drawing.Font("宋体", 10F);
            this.BTNSizeADD.Location = new System.Drawing.Point(7, 4);
            this.BTNSizeADD.Name = "BTNSizeADD";
            this.BTNSizeADD.Size = new System.Drawing.Size(83, 29);
            this.BTNSizeADD.TabIndex = 0;
            this.BTNSizeADD.Text = "配码配比";
            this.BTNSizeADD.UseVisualStyleBackColor = true;
            this.BTNSizeADD.Click += new System.EventHandler(this.BTNSizeADD_Click);
            // 
            // GBSelect
            // 
            this.GBSelect.Controls.Add(this.TXtCade);
            this.GBSelect.Controls.Add(this.label1);
            this.GBSelect.Controls.Add(this.BtnBrow);
            this.GBSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.GBSelect.Font = new System.Drawing.Font("宋体", 1F);
            this.GBSelect.Location = new System.Drawing.Point(0, 0);
            this.GBSelect.Name = "GBSelect";
            this.GBSelect.Size = new System.Drawing.Size(823, 37);
            this.GBSelect.TabIndex = 13;
            this.GBSelect.TabStop = false;
            // 
            // TXtCade
            // 
            this.TXtCade.Font = new System.Drawing.Font("宋体", 10F);
            this.TXtCade.Location = new System.Drawing.Point(53, 8);
            this.TXtCade.Name = "TXtCade";
            this.TXtCade.Size = new System.Drawing.Size(177, 23);
            this.TXtCade.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "款号：";
            // 
            // BtnBrow
            // 
            this.BtnBrow.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnBrow.Location = new System.Drawing.Point(236, 8);
            this.BtnBrow.Name = "BtnBrow";
            this.BtnBrow.Size = new System.Drawing.Size(75, 23);
            this.BtnBrow.TabIndex = 0;
            this.BtnBrow.Text = "查询";
            this.BtnBrow.UseVisualStyleBackColor = true;
            this.BtnBrow.Click += new System.EventHandler(this.BtnBrow_Click);
            // 
            // GBBtn
            // 
            this.GBBtn.Controls.Add(this.BtnColourAdd);
            this.GBBtn.Controls.Add(this.BTNSizeADD);
            this.GBBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GBBtn.Font = new System.Drawing.Font("宋体", 1F);
            this.GBBtn.Location = new System.Drawing.Point(0, 479);
            this.GBBtn.Name = "GBBtn";
            this.GBBtn.Size = new System.Drawing.Size(823, 36);
            this.GBBtn.TabIndex = 14;
            this.GBBtn.TabStop = false;
            // 
            // ColourDgv
            // 
            this.ColourDgv.AllowUserToAddRows = false;
            this.ColourDgv.AllowUserToDeleteRows = false;
            this.ColourDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColourDgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.ColourDgv.Location = new System.Drawing.Point(535, 37);
            this.ColourDgv.Name = "ColourDgv";
            this.ColourDgv.ReadOnly = true;
            this.ColourDgv.RowTemplate.Height = 23;
            this.ColourDgv.Size = new System.Drawing.Size(273, 442);
            this.ColourDgv.TabIndex = 17;
            // 
            // BtnColourAdd
            // 
            this.BtnColourAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnColourAdd.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnColourAdd.Location = new System.Drawing.Point(98, 4);
            this.BtnColourAdd.Name = "BtnColourAdd";
            this.BtnColourAdd.Size = new System.Drawing.Size(83, 29);
            this.BtnColourAdd.TabIndex = 1;
            this.BtnColourAdd.Text = "颜色配比";
            this.BtnColourAdd.UseVisualStyleBackColor = true;
            this.BtnColourAdd.Click += new System.EventHandler(this.BtnColourAdd_Click);
            // 
            // SS_WithCade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 515);
            this.Controls.Add(this.ColourDgv);
            this.Controls.Add(this.SizeDGV);
            this.Controls.Add(this.ProductDGV);
            this.Controls.Add(this.GBSelect);
            this.Controls.Add(this.GBBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SS_WithCade";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SS_WithCade";
            ((System.ComponentModel.ISupportInitialize)(this.SizeDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDGV)).EndInit();
            this.GBSelect.ResumeLayout(false);
            this.GBSelect.PerformLayout();
            this.GBBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ColourDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SizeDGV;
        private System.Windows.Forms.DataGridView ProductDGV;
        private System.Windows.Forms.Button BTNSizeADD;
        private System.Windows.Forms.GroupBox GBSelect;
        private System.Windows.Forms.TextBox TXtCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBrow;
        private System.Windows.Forms.GroupBox GBBtn;
        private System.Windows.Forms.Button BtnColourAdd;
        private System.Windows.Forms.DataGridView ColourDgv;
    }
}