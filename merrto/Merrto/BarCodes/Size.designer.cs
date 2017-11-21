namespace Merrto
{
    partial class Size
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
            this.SizeDetailsDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SizeDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeDetailsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // SizeDGV
            // 
            this.SizeDGV.AllowUserToAddRows = false;
            this.SizeDGV.AllowUserToDeleteRows = false;
            this.SizeDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.SizeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SizeDGV.Location = new System.Drawing.Point(12, 35);
            this.SizeDGV.Name = "SizeDGV";
            this.SizeDGV.ReadOnly = true;
            this.SizeDGV.RowTemplate.Height = 23;
            this.SizeDGV.Size = new System.Drawing.Size(266, 327);
            this.SizeDGV.TabIndex = 0;
            this.SizeDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SizeDGV_CellClick);
            // 
            // SizeDetailsDGV
            // 
            this.SizeDetailsDGV.AllowUserToAddRows = false;
            this.SizeDetailsDGV.AllowUserToDeleteRows = false;
            this.SizeDetailsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.SizeDetailsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SizeDetailsDGV.Location = new System.Drawing.Point(281, 35);
            this.SizeDetailsDGV.Name = "SizeDetailsDGV";
            this.SizeDetailsDGV.ReadOnly = true;
            this.SizeDetailsDGV.RowTemplate.Height = 23;
            this.SizeDetailsDGV.Size = new System.Drawing.Size(337, 327);
            this.SizeDetailsDGV.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "尺码名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "尺码规格";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(12, 380);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnupdate.Location = new System.Drawing.Point(203, 380);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(75, 23);
            this.btnupdate.TabIndex = 5;
            this.btnupdate.Text = "修改";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // Size
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 416);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SizeDetailsDGV);
            this.Controls.Add(this.SizeDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Size";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "尺码定义";
            this.Load += new System.EventHandler(this.ProductSize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SizeDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeDetailsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SizeDGV;
        private System.Windows.Forms.DataGridView SizeDetailsDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnupdate;
    }
}