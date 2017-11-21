namespace Merrto.BarCodes
{
    partial class ProductExpress
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
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnEXCEL = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DTdatetime = new System.Windows.Forms.DateTimePicker();
            this.CmdShop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ListDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DataDGV
            // 
            this.DataDGV.AllowUserToAddRows = false;
            this.DataDGV.AllowUserToDeleteRows = false;
            this.DataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataDGV.Dock = System.Windows.Forms.DockStyle.Left;
            this.DataDGV.Location = new System.Drawing.Point(0, 33);
            this.DataDGV.Name = "DataDGV";
            this.DataDGV.ReadOnly = true;
            this.DataDGV.RowTemplate.Height = 23;
            this.DataDGV.Size = new System.Drawing.Size(423, 567);
            this.DataDGV.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.BtnEXCEL);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DTdatetime);
            this.groupBox1.Controls.Add(this.CmdShop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 33);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnSave.Location = new System.Drawing.Point(427, 5);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnEXCEL
            // 
            this.BtnEXCEL.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnEXCEL.Location = new System.Drawing.Point(348, 5);
            this.BtnEXCEL.Name = "BtnEXCEL";
            this.BtnEXCEL.Size = new System.Drawing.Size(75, 23);
            this.BtnEXCEL.TabIndex = 5;
            this.BtnEXCEL.Text = "导入EXCEL";
            this.BtnEXCEL.UseVisualStyleBackColor = true;
            this.BtnEXCEL.Click += new System.EventHandler(this.BtnEXCEL_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(176, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "日期";
            // 
            // DTdatetime
            // 
            this.DTdatetime.Font = new System.Drawing.Font("宋体", 10F);
            this.DTdatetime.Location = new System.Drawing.Point(210, 6);
            this.DTdatetime.Name = "DTdatetime";
            this.DTdatetime.Size = new System.Drawing.Size(122, 23);
            this.DTdatetime.TabIndex = 3;
            // 
            // CmdShop
            // 
            this.CmdShop.Font = new System.Drawing.Font("宋体", 10F);
            this.CmdShop.FormattingEnabled = true;
            this.CmdShop.Location = new System.Drawing.Point(48, 6);
            this.CmdShop.Name = "CmdShop";
            this.CmdShop.Size = new System.Drawing.Size(121, 21);
            this.CmdShop.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "店铺：";
            // 
            // ListDGV
            // 
            this.ListDGV.AllowUserToAddRows = false;
            this.ListDGV.AllowUserToDeleteRows = false;
            this.ListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListDGV.Location = new System.Drawing.Point(423, 33);
            this.ListDGV.Name = "ListDGV";
            this.ListDGV.ReadOnly = true;
            this.ListDGV.RowTemplate.Height = 23;
            this.ListDGV.Size = new System.Drawing.Size(377, 567);
            this.ListDGV.TabIndex = 10;
            // 
            // ProductExpress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ListDGV);
            this.Controls.Add(this.DataDGV);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductExpress";
            this.Text = "ProductExpress";
            this.Load += new System.EventHandler(this.ProductExpress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnEXCEL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTdatetime;
        private System.Windows.Forms.ComboBox CmdShop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ListDGV;
    }
}