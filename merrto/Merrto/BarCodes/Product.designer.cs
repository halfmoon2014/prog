namespace Merrto
{
    partial class Product
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
            this.ProductDG = new System.Windows.Forms.DataGridView();
            this.TXTItem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.chkcolour = new System.Windows.Forms.CheckBox();
            this.chkSize = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDG)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductDG
            // 
            this.ProductDG.AllowUserToAddRows = false;
            this.ProductDG.AllowUserToDeleteRows = false;
            this.ProductDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ProductDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDG.Location = new System.Drawing.Point(5, 36);
            this.ProductDG.Name = "ProductDG";
            this.ProductDG.ReadOnly = true;
            this.ProductDG.RowTemplate.Height = 23;
            this.ProductDG.Size = new System.Drawing.Size(540, 551);
            this.ProductDG.TabIndex = 0;
            // 
            // TXTItem
            // 
            this.TXTItem.Location = new System.Drawing.Point(39, 7);
            this.TXTItem.Name = "TXTItem";
            this.TXTItem.Size = new System.Drawing.Size(207, 21);
            this.TXTItem.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "款号";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(466, 6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(76, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // chkcolour
            // 
            this.chkcolour.AutoSize = true;
            this.chkcolour.Location = new System.Drawing.Point(257, 9);
            this.chkcolour.Name = "chkcolour";
            this.chkcolour.Size = new System.Drawing.Size(96, 16);
            this.chkcolour.TabIndex = 4;
            this.chkcolour.Text = "显示没有颜色";
            this.chkcolour.UseVisualStyleBackColor = true;
            // 
            // chkSize
            // 
            this.chkSize.AutoSize = true;
            this.chkSize.Location = new System.Drawing.Point(361, 9);
            this.chkSize.Name = "chkSize";
            this.chkSize.Size = new System.Drawing.Size(96, 16);
            this.chkSize.TabIndex = 5;
            this.chkSize.Text = "显示没有尺码";
            this.chkSize.UseVisualStyleBackColor = true;
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 591);
            this.Controls.Add(this.chkSize);
            this.Controls.Add(this.chkcolour);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTItem);
            this.Controls.Add(this.ProductDG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Product";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品档案";
            this.Load += new System.EventHandler(this.Product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductDG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ProductDG;
        private System.Windows.Forms.TextBox TXTItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.CheckBox chkcolour;
        private System.Windows.Forms.CheckBox chkSize;
    }
}