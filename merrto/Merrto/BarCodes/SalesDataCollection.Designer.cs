namespace Merrto.BarCodes
{
    partial class SalesDataCollection
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
            this.BtnEXCEL = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DGVdata = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVdata)).BeginInit();
            this.SuspendLayout();
            // 
            // DataDGV
            // 
            this.DataDGV.AllowUserToAddRows = false;
            this.DataDGV.AllowUserToDeleteRows = false;
            this.DataDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataDGV.Dock = System.Windows.Forms.DockStyle.Left;
            this.DataDGV.Location = new System.Drawing.Point(0, 41);
            this.DataDGV.Name = "DataDGV";
            this.DataDGV.ReadOnly = true;
            this.DataDGV.RowTemplate.Height = 23;
            this.DataDGV.Size = new System.Drawing.Size(430, 471);
            this.DataDGV.TabIndex = 11;
            // 
            // BtnEXCEL
            // 
            this.BtnEXCEL.Location = new System.Drawing.Point(12, 10);
            this.BtnEXCEL.Name = "BtnEXCEL";
            this.BtnEXCEL.Size = new System.Drawing.Size(75, 29);
            this.BtnEXCEL.TabIndex = 5;
            this.BtnEXCEL.Text = "导入EXCEL";
            this.BtnEXCEL.UseVisualStyleBackColor = true;
            this.BtnEXCEL.Click += new System.EventHandler(this.BtnEXCEL_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(430, 10);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 29);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "转换";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.BtnEXCEL);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 41);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // DGVdata
            // 
            this.DGVdata.AllowUserToAddRows = false;
            this.DGVdata.AllowUserToDeleteRows = false;
            this.DGVdata.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVdata.Location = new System.Drawing.Point(430, 41);
            this.DGVdata.Name = "DGVdata";
            this.DGVdata.ReadOnly = true;
            this.DGVdata.RowTemplate.Height = 23;
            this.DGVdata.Size = new System.Drawing.Size(554, 471);
            this.DGVdata.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(514, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 25;
            this.button1.Text = "导出Excel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SalesDataCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 512);
            this.Controls.Add(this.DGVdata);
            this.Controls.Add(this.DataDGV);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalesDataCollection";
            this.Text = "SalesDataCollection";
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataDGV;
        private System.Windows.Forms.Button BtnEXCEL;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGVdata;
        private System.Windows.Forms.Button button1;
    }
}