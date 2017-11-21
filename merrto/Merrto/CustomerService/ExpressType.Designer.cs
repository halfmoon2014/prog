namespace Merrto.CustomerService
{
    partial class ExpressType
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
            this.CboType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CboRemarks = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DTStop = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DTPOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtVIPname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNbROW = new System.Windows.Forms.Button();
            this.GpbBtn = new System.Windows.Forms.GroupBox();
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
            this.WPHbROWDGV.Location = new System.Drawing.Point(0, 84);
            this.WPHbROWDGV.Name = "WPHbROWDGV";
            this.WPHbROWDGV.ReadOnly = true;
            this.WPHbROWDGV.RowTemplate.Height = 23;
            this.WPHbROWDGV.Size = new System.Drawing.Size(982, 430);
            this.WPHbROWDGV.TabIndex = 24;
            this.WPHbROWDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.WPHbROWDGV_DataBindingComplete);
            this.WPHbROWDGV.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.WPHbROWDGV_RowPostPaint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CboType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CboRemarks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DTStop);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DTPOrderDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtVIPname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtCade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BTNbROW);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(982, 51);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // CboType
            // 
            this.CboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CboType.FormattingEnabled = true;
            this.CboType.Items.AddRange(new object[] {
            "待处理",
            "处理中",
            "完结",
            "关闭",
            " "});
            this.CboType.Location = new System.Drawing.Point(473, 4);
            this.CboType.Name = "CboType";
            this.CboType.Size = new System.Drawing.Size(136, 20);
            this.CboType.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(436, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "状态：";
            // 
            // CboRemarks
            // 
            this.CboRemarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboRemarks.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CboRemarks.FormattingEnabled = true;
            this.CboRemarks.Items.AddRange(new object[] {
            "退回",
            "丢件",
            "转单",
            "签收",
            " "});
            this.CboRemarks.Location = new System.Drawing.Point(474, 27);
            this.CboRemarks.Name = "CboRemarks";
            this.CboRemarks.Size = new System.Drawing.Size(134, 20);
            this.CboRemarks.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(413, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 45;
            this.label6.Text = "处理结果：";
            // 
            // DTStop
            // 
            this.DTStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTStop.Location = new System.Drawing.Point(270, 4);
            this.DTStop.Name = "DTStop";
            this.DTStop.Size = new System.Drawing.Size(134, 21);
            this.DTStop.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(209, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "终止时间：";
            // 
            // DTPOrderDate
            // 
            this.DTPOrderDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTPOrderDate.Location = new System.Drawing.Point(68, 4);
            this.DTPOrderDate.Name = "DTPOrderDate";
            this.DTPOrderDate.Size = new System.Drawing.Size(134, 21);
            this.DTPOrderDate.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(7, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "起始时间：";
            // 
            // TxtVIPname
            // 
            this.TxtVIPname.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtVIPname.Location = new System.Drawing.Point(269, 27);
            this.TxtVIPname.Name = "TxtVIPname";
            this.TxtVIPname.Size = new System.Drawing.Size(135, 21);
            this.TxtVIPname.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(220, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "买家ID：";
            // 
            // TxtCade
            // 
            this.TxtCade.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtCade.Location = new System.Drawing.Point(57, 27);
            this.TxtCade.Name = "TxtCade";
            this.TxtCade.Size = new System.Drawing.Size(146, 21);
            this.TxtCade.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "快递单：";
            // 
            // BTNbROW
            // 
            this.BTNbROW.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTNbROW.Location = new System.Drawing.Point(614, 3);
            this.BTNbROW.Name = "BTNbROW";
            this.BTNbROW.Size = new System.Drawing.Size(75, 46);
            this.BTNbROW.TabIndex = 31;
            this.BTNbROW.Text = "查询";
            this.BTNbROW.UseVisualStyleBackColor = true;
            this.BTNbROW.Click += new System.EventHandler(this.BTNbROW_Click);
            // 
            // GpbBtn
            // 
            this.GpbBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.GpbBtn.Font = new System.Drawing.Font("宋体", 1F);
            this.GpbBtn.Location = new System.Drawing.Point(0, 51);
            this.GpbBtn.Name = "GpbBtn";
            this.GpbBtn.Size = new System.Drawing.Size(982, 33);
            this.GpbBtn.TabIndex = 25;
            this.GpbBtn.TabStop = false;
            // 
            // ExpressType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 514);
            this.Controls.Add(this.WPHbROWDGV);
            this.Controls.Add(this.GpbBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExpressType";
            this.Text = "ExpressType";
            this.Load += new System.EventHandler(this.ExpressType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }



        private System.Windows.Forms.DataGridView WPHbROWDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DTStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTPOrderDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtVIPname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNbROW;
        private System.Windows.Forms.ComboBox CboRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CboType;
        private System.Windows.Forms.Label label5;

        #endregion
        private System.Windows.Forms.GroupBox GpbBtn;
    }
}