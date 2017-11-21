namespace Merrto.TheShopReports
{
    partial class ZFBDateFrm
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
            this.DTPstop = new System.Windows.Forms.DateTimePicker();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnEXCEL = new System.Windows.Forms.Button();
            this.DTdatetime = new System.Windows.Forms.DateTimePicker();
            this.CmdShop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BTNDelete = new System.Windows.Forms.Button();
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
            this.DataDGV.Size = new System.Drawing.Size(814, 572);
            this.DataDGV.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTNDelete);
            this.groupBox1.Controls.Add(this.DTPstop);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.BtnEXCEL);
            this.groupBox1.Controls.Add(this.DTdatetime);
            this.groupBox1.Controls.Add(this.CmdShop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 41);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // DTPstop
            // 
            this.DTPstop.Location = new System.Drawing.Point(421, 13);
            this.DTPstop.Name = "DTPstop";
            this.DTPstop.Size = new System.Drawing.Size(122, 21);
            this.DTPstop.TabIndex = 7;
            this.DTPstop.Value = new System.DateTime(2014, 6, 14, 23, 59, 0, 0);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(642, 12);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnEXCEL
            // 
            this.BtnEXCEL.Location = new System.Drawing.Point(563, 12);
            this.BtnEXCEL.Name = "BtnEXCEL";
            this.BtnEXCEL.Size = new System.Drawing.Size(75, 23);
            this.BtnEXCEL.TabIndex = 5;
            this.BtnEXCEL.Text = "导入EXCEL";
            this.BtnEXCEL.UseVisualStyleBackColor = true;
            this.BtnEXCEL.Click += new System.EventHandler(this.BtnEXCEL_Click);
            // 
            // DTdatetime
            // 
            this.DTdatetime.Location = new System.Drawing.Point(236, 13);
            this.DTdatetime.Name = "DTdatetime";
            this.DTdatetime.Size = new System.Drawing.Size(122, 21);
            this.DTdatetime.TabIndex = 3;
            this.DTdatetime.Value = new System.DateTime(2014, 6, 14, 0, 0, 0, 0);
            // 
            // CmdShop
            // 
            this.CmdShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdShop.FormattingEnabled = true;
            this.CmdShop.Location = new System.Drawing.Point(48, 13);
            this.CmdShop.Name = "CmdShop";
            this.CmdShop.Size = new System.Drawing.Size(121, 20);
            this.CmdShop.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "店铺：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "起始日期：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "终止日期：";
            // 
            // BTNDelete
            // 
            this.BTNDelete.Location = new System.Drawing.Point(720, 12);
            this.BTNDelete.Name = "BTNDelete";
            this.BTNDelete.Size = new System.Drawing.Size(75, 23);
            this.BTNDelete.TabIndex = 9;
            this.BTNDelete.Text = "删除";
            this.BTNDelete.UseVisualStyleBackColor = true;
            this.BTNDelete.Click += new System.EventHandler(this.BTNDelete_Click);
            // 
            // ZFBDateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 613);
            this.Controls.Add(this.DataDGV);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ZFBDateFrm";
            this.Text = "ZFBDateFrm";
            this.Load += new System.EventHandler(this.ZFBDateFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.DateTimePicker DTPstop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTNDelete;
    }
}