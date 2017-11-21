namespace Merrto
{
    partial class WphStorage
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
            this.BtnEdit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.StorageDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.StorageDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(186, 237);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(54, 23);
            this.BtnEdit.TabIndex = 7;
            this.BtnEdit.Text = "修改";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(4, 237);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(54, 23);
            this.btnadd.TabIndex = 6;
            this.btnadd.Text = "新增";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // StorageDGV
            // 
            this.StorageDGV.AllowUserToAddRows = false;
            this.StorageDGV.AllowUserToDeleteRows = false;
            this.StorageDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StorageDGV.Location = new System.Drawing.Point(4, 2);
            this.StorageDGV.Name = "StorageDGV";
            this.StorageDGV.ReadOnly = true;
            this.StorageDGV.RowTemplate.Height = 23;
            this.StorageDGV.Size = new System.Drawing.Size(236, 229);
            this.StorageDGV.TabIndex = 5;
            // 
            // WphStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 272);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.StorageDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WphStorage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "唯品汇仓库";
            this.Load += new System.EventHandler(this.WphStorage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StorageDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.DataGridView StorageDGV;
    }
}