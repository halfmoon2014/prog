namespace Merrto
{
    partial class WphPeport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ProudctDGV = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DTTDATE = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnOPExcel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.txtSpecial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BTNPacking = new System.Windows.Forms.Button();
            this.btnINExcel = new System.Windows.Forms.Button();
            this.ExcelDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ProudctDGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ProudctDGV
            // 
            this.ProudctDGV.AllowUserToAddRows = false;
            this.ProudctDGV.AllowUserToDeleteRows = false;
            this.ProudctDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProudctDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProudctDGV.Location = new System.Drawing.Point(238, 0);
            this.ProudctDGV.Name = "ProudctDGV";
            this.ProudctDGV.ReadOnly = true;
            this.ProudctDGV.RowTemplate.Height = 23;
            this.ProudctDGV.Size = new System.Drawing.Size(759, 585);
            this.ProudctDGV.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ExcelDGV);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 585);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DTTDATE);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnOPExcel);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.txtSpecial);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.BTNPacking);
            this.groupBox1.Controls.Add(this.btnINExcel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 150);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // DTTDATE
            // 
            this.DTTDATE.Font = new System.Drawing.Font("宋体", 10F);
            this.DTTDATE.Location = new System.Drawing.Point(68, 29);
            this.DTTDATE.Name = "DTTDATE";
            this.DTTDATE.Size = new System.Drawing.Size(158, 23);
            this.DTTDATE.TabIndex = 24;
            this.DTTDATE.Value = new System.DateTime(2014, 4, 25, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(4, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 22;
            this.label1.Text = "日    期:";
            // 
            // BtnOPExcel
            // 
            this.BtnOPExcel.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnOPExcel.Location = new System.Drawing.Point(5, 56);
            this.BtnOPExcel.Name = "BtnOPExcel";
            this.BtnOPExcel.Size = new System.Drawing.Size(97, 41);
            this.BtnOPExcel.TabIndex = 21;
            this.BtnOPExcel.Text = "导出EXCEL数据";
            this.BtnOPExcel.UseVisualStyleBackColor = true;
            this.BtnOPExcel.Click += new System.EventHandler(this.BtnOPExcel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnSave.Location = new System.Drawing.Point(105, 56);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(121, 41);
            this.BtnSave.TabIndex = 20;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtSpecial
            // 
            this.txtSpecial.Font = new System.Drawing.Font("宋体", 10F);
            this.txtSpecial.Location = new System.Drawing.Point(68, 3);
            this.txtSpecial.Name = "txtSpecial";
            this.txtSpecial.Size = new System.Drawing.Size(158, 23);
            this.txtSpecial.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10F);
            this.label8.Location = new System.Drawing.Point(4, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "专场名称:";
            // 
            // BTNPacking
            // 
            this.BTNPacking.Font = new System.Drawing.Font("宋体", 9F);
            this.BTNPacking.Location = new System.Drawing.Point(105, 100);
            this.BTNPacking.Name = "BTNPacking";
            this.BTNPacking.Size = new System.Drawing.Size(121, 41);
            this.BTNPacking.TabIndex = 17;
            this.BTNPacking.Text = "转换为唯品汇报表";
            this.BTNPacking.UseVisualStyleBackColor = true;
            this.BTNPacking.Click += new System.EventHandler(this.BTNPacking_Click);
            // 
            // btnINExcel
            // 
            this.btnINExcel.Font = new System.Drawing.Font("宋体", 9F);
            this.btnINExcel.Location = new System.Drawing.Point(5, 100);
            this.btnINExcel.Name = "btnINExcel";
            this.btnINExcel.Size = new System.Drawing.Size(97, 41);
            this.btnINExcel.TabIndex = 16;
            this.btnINExcel.Text = "导入EXCEL数据";
            this.btnINExcel.UseVisualStyleBackColor = true;
            this.btnINExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // ExcelDGV
            // 
            this.ExcelDGV.AllowUserToAddRows = false;
            this.ExcelDGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcelDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ExcelDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ExcelDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExcelDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExcelDGV.Location = new System.Drawing.Point(3, 155);
            this.ExcelDGV.Name = "ExcelDGV";
            this.ExcelDGV.ReadOnly = true;
            this.ExcelDGV.RowTemplate.Height = 23;
            this.ExcelDGV.Size = new System.Drawing.Size(232, 427);
            this.ExcelDGV.TabIndex = 13;
            // 
            // WphPeport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 585);
            this.Controls.Add(this.ProudctDGV);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WphPeport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "唯品汇报表";
            this.Load += new System.EventHandler(this.WphPeport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProudctDGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProudctDGV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSpecial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BTNPacking;
        private System.Windows.Forms.Button btnINExcel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnOPExcel;
        private System.Windows.Forms.DateTimePicker DTTDATE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ExcelDGV;
    }
}