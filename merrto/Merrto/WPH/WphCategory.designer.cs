namespace Merrto
{
    partial class WphCategory
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
            this.CategoryDGV = new System.Windows.Forms.DataGridView();
            this.btnadd = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // CategoryDGV
            // 
            this.CategoryDGV.AllowUserToAddRows = false;
            this.CategoryDGV.AllowUserToDeleteRows = false;
            this.CategoryDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.CategoryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CategoryDGV.Location = new System.Drawing.Point(5, 4);
            this.CategoryDGV.Name = "CategoryDGV";
            this.CategoryDGV.ReadOnly = true;
            this.CategoryDGV.RowTemplate.Height = 23;
            this.CategoryDGV.Size = new System.Drawing.Size(186, 229);
            this.CategoryDGV.TabIndex = 1;
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnadd.Location = new System.Drawing.Point(5, 239);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(54, 23);
            this.btnadd.TabIndex = 2;
            this.btnadd.Text = "新增";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnEdit.Location = new System.Drawing.Point(137, 239);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(54, 23);
            this.BtnEdit.TabIndex = 3;
            this.BtnEdit.Text = "修改";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // WphCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 266);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.CategoryDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WphCategory";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "类别新增";
            this.Load += new System.EventHandler(this.WphCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CategoryDGV;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button BtnEdit;
    }
}