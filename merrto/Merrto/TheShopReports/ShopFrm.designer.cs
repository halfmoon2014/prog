namespace Merrto.TheShopReports
{
    partial class ShopFrm
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
            this.ShopDGV = new System.Windows.Forms.DataGridView();
            this.BTNNew = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ShopDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ShopDGV
            // 
            this.ShopDGV.AllowUserToAddRows = false;
            this.ShopDGV.AllowUserToDeleteRows = false;
            this.ShopDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ShopDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShopDGV.Location = new System.Drawing.Point(3, 1);
            this.ShopDGV.Name = "ShopDGV";
            this.ShopDGV.ReadOnly = true;
            this.ShopDGV.RowTemplate.Height = 23;
            this.ShopDGV.Size = new System.Drawing.Size(316, 393);
            this.ShopDGV.TabIndex = 0;
            // 
            // BTNNew
            // 
            this.BTNNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNNew.Location = new System.Drawing.Point(22, 401);
            this.BTNNew.Name = "BTNNew";
            this.BTNNew.Size = new System.Drawing.Size(75, 23);
            this.BTNNew.TabIndex = 1;
            this.BTNNew.Text = "新增";
            this.BTNNew.UseVisualStyleBackColor = true;
            this.BTNNew.Click += new System.EventHandler(this.BTNNew_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnEdit.Location = new System.Drawing.Point(235, 401);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 2;
            this.BtnEdit.Text = "修改";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // ShopFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 437);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BTNNew);
            this.Controls.Add(this.ShopDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShopFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "店铺定义";
            this.Load += new System.EventHandler(this.ShopFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShopDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ShopDGV;
        private System.Windows.Forms.Button BTNNew;
        private System.Windows.Forms.Button BtnEdit;
    }
}