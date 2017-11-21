namespace Merrto.M_Data
{
    partial class FiledType
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
            this.DATADGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DATADGV)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEdit
            // 
            this.BtnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnEdit.Location = new System.Drawing.Point(241, 398);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(54, 23);
            this.BtnEdit.TabIndex = 9;
            this.BtnEdit.Text = "修改";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnadd.Location = new System.Drawing.Point(4, 398);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(54, 23);
            this.btnadd.TabIndex = 8;
            this.btnadd.Text = "新增";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // DATADGV
            // 
            this.DATADGV.AllowUserToAddRows = false;
            this.DATADGV.AllowUserToDeleteRows = false;
            this.DATADGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.DATADGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATADGV.Location = new System.Drawing.Point(4, 4);
            this.DATADGV.Name = "DATADGV";
            this.DATADGV.ReadOnly = true;
            this.DATADGV.RowTemplate.Height = 23;
            this.DATADGV.Size = new System.Drawing.Size(291, 388);
            this.DATADGV.TabIndex = 7;
            // 
            // FiledType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 433);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.DATADGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FiledType";
            this.Text = "FiledType";
            this.Load += new System.EventHandler(this.FiledType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DATADGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.DataGridView DATADGV;
    }
}