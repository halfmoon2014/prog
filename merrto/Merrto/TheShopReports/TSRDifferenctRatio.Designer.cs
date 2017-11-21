namespace Merrto.TheShopReports
{
    partial class TSRDifferenctRatio
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
            this.WPHbROWDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RbtnOtlay = new System.Windows.Forms.RadioButton();
            this.RbtnDetailOtlay = new System.Windows.Forms.RadioButton();
            this.DTPStop = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnupEXcel = new System.Windows.Forms.Button();
            this.CmdShop = new System.Windows.Forms.ComboBox();
            this.BTNbROW = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WPHbROWDGV
            // 
            this.WPHbROWDGV.AllowUserToAddRows = false;
            this.WPHbROWDGV.AllowUserToDeleteRows = false;
            this.WPHbROWDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WPHbROWDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WPHbROWDGV.Location = new System.Drawing.Point(0, 42);
            this.WPHbROWDGV.Name = "WPHbROWDGV";
            this.WPHbROWDGV.ReadOnly = true;
            this.WPHbROWDGV.RowTemplate.Height = 23;
            this.WPHbROWDGV.Size = new System.Drawing.Size(843, 496);
            this.WPHbROWDGV.TabIndex = 14;
            this.WPHbROWDGV.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.WPHbROWDGV_RowPostPaint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RbtnOtlay);
            this.groupBox1.Controls.Add(this.RbtnDetailOtlay);
            this.groupBox1.Controls.Add(this.DTPStop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DTPStart);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnupEXcel);
            this.groupBox1.Controls.Add(this.CmdShop);
            this.groupBox1.Controls.Add(this.BTNbROW);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 42);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // RbtnOtlay
            // 
            this.RbtnOtlay.AutoSize = true;
            this.RbtnOtlay.Location = new System.Drawing.Point(552, 17);
            this.RbtnOtlay.Name = "RbtnOtlay";
            this.RbtnOtlay.Size = new System.Drawing.Size(71, 16);
            this.RbtnOtlay.TabIndex = 26;
            this.RbtnOtlay.Text = "比例费用";
            this.RbtnOtlay.UseVisualStyleBackColor = true;
            // 
            // RbtnDetailOtlay
            // 
            this.RbtnDetailOtlay.AutoSize = true;
            this.RbtnDetailOtlay.Checked = true;
            this.RbtnDetailOtlay.Location = new System.Drawing.Point(475, 17);
            this.RbtnDetailOtlay.Name = "RbtnDetailOtlay";
            this.RbtnDetailOtlay.Size = new System.Drawing.Size(71, 16);
            this.RbtnDetailOtlay.TabIndex = 25;
            this.RbtnDetailOtlay.TabStop = true;
            this.RbtnDetailOtlay.Text = "明细费用";
            this.RbtnDetailOtlay.UseVisualStyleBackColor = true;
            // 
            // DTPStop
            // 
            this.DTPStop.Checked = false;
            this.DTPStop.Location = new System.Drawing.Point(357, 14);
            this.DTPStop.Name = "DTPStop";
            this.DTPStop.Size = new System.Drawing.Size(112, 21);
            this.DTPStop.TabIndex = 23;
            this.DTPStop.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "月份：";
            // 
            // DTPStart
            // 
            this.DTPStart.Checked = false;
            this.DTPStart.Location = new System.Drawing.Point(202, 14);
            this.DTPStart.Name = "DTPStart";
            this.DTPStart.Size = new System.Drawing.Size(112, 21);
            this.DTPStart.TabIndex = 21;
            this.DTPStart.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "月份：";
            // 
            // btnupEXcel
            // 
            this.btnupEXcel.Location = new System.Drawing.Point(702, 13);
            this.btnupEXcel.Name = "btnupEXcel";
            this.btnupEXcel.Size = new System.Drawing.Size(88, 23);
            this.btnupEXcel.TabIndex = 16;
            this.btnupEXcel.Text = "导出EXCEL";
            this.btnupEXcel.UseVisualStyleBackColor = true;
            this.btnupEXcel.Click += new System.EventHandler(this.btnupEXcel_Click);
            // 
            // CmdShop
            // 
            this.CmdShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdShop.FormattingEnabled = true;
            this.CmdShop.Location = new System.Drawing.Point(47, 14);
            this.CmdShop.Name = "CmdShop";
            this.CmdShop.Size = new System.Drawing.Size(111, 20);
            this.CmdShop.TabIndex = 8;
            // 
            // BTNbROW
            // 
            this.BTNbROW.Location = new System.Drawing.Point(626, 13);
            this.BTNbROW.Name = "BTNbROW";
            this.BTNbROW.Size = new System.Drawing.Size(75, 23);
            this.BTNbROW.TabIndex = 12;
            this.BTNbROW.Text = "查询";
            this.BTNbROW.UseVisualStyleBackColor = true;
            this.BTNbROW.Click += new System.EventHandler(this.BTNbROW_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "店铺：";
            // 
            // TSRDifferenctRatio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 538);
            this.Controls.Add(this.WPHbROWDGV);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TSRDifferenctRatio";
            this.Text = "TSRDifferenctRatio";
            this.Load += new System.EventHandler(this.TSRDifferenctRatio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WPHbROWDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DTPStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnupEXcel;
        private System.Windows.Forms.ComboBox CmdShop;
        private System.Windows.Forms.Button BTNbROW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTPStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RbtnOtlay;
        private System.Windows.Forms.RadioButton RbtnDetailOtlay;

    }
}