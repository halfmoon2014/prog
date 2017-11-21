namespace Merrto.BarCodes
{
    partial class excelStorage
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
            this.DataDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnStorage = new System.Windows.Forms.Button();
            this.BtnInExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataDGV
            // 
            this.DataDGV.AllowUserToAddRows = false;
            this.DataDGV.AllowUserToDeleteRows = false;
            this.DataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataDGV.Location = new System.Drawing.Point(0, 41);
            this.DataDGV.Name = "DataDGV";
            this.DataDGV.ReadOnly = true;
            this.DataDGV.RowTemplate.Height = 23;
            this.DataDGV.Size = new System.Drawing.Size(959, 491);
            this.DataDGV.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnStorage);
            this.groupBox1.Controls.Add(this.BtnInExcel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 41);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // BtnStorage
            // 
            this.BtnStorage.Location = new System.Drawing.Point(86, 13);
            this.BtnStorage.Name = "BtnStorage";
            this.BtnStorage.Size = new System.Drawing.Size(75, 23);
            this.BtnStorage.TabIndex = 8;
            this.BtnStorage.Text = "保存";
            this.BtnStorage.UseVisualStyleBackColor = true;
            // 
            // BtnInExcel
            // 
            this.BtnInExcel.Location = new System.Drawing.Point(6, 13);
            this.BtnInExcel.Name = "BtnInExcel";
            this.BtnInExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnInExcel.TabIndex = 7;
            this.BtnInExcel.Text = "导入EXCEL";
            this.BtnInExcel.UseVisualStyleBackColor = true;
            this.BtnInExcel.Click += new System.EventHandler(this.BtnInExcel_Click);
            // 
            // excelStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 532);
            this.Controls.Add(this.DataDGV);
            this.Controls.Add(this.groupBox1);
            this.Name = "excelStorage";
            this.Text = "excelStorage";
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnStorage;
        private System.Windows.Forms.Button BtnInExcel;
    }
}