namespace Merrto.BarCodes
{
    partial class rStorage
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
            this.BTNbROW = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.DTStop = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnupEXcel = new System.Windows.Forms.Button();
            this.CmdShop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.WPHbROWDGV.Size = new System.Drawing.Size(840, 371);
            this.WPHbROWDGV.TabIndex = 17;
            this.WPHbROWDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WPHbROWDGV_CellClick);
            this.WPHbROWDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.WPHbROWDGV_DataBindingComplete);
            this.WPHbROWDGV.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.WPHbROWDGV_RowPostPaint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTNbROW);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.DTStop);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DTPOrderDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtCade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnupEXcel);
            this.groupBox1.Controls.Add(this.CmdShop);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(840, 54);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // BTNbROW
            // 
            this.BTNbROW.Font = new System.Drawing.Font("宋体", 9F);
            this.BTNbROW.Location = new System.Drawing.Point(491, 4);
            this.BTNbROW.Name = "BTNbROW";
            this.BTNbROW.Size = new System.Drawing.Size(75, 46);
            this.BTNbROW.TabIndex = 12;
            this.BTNbROW.Text = "查询";
            this.BTNbROW.UseVisualStyleBackColor = true;
            this.BTNbROW.Click += new System.EventHandler(this.BTNbROW_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("华文新魏", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblType.ForeColor = System.Drawing.Color.Red;
            this.lblType.Location = new System.Drawing.Point(420, 14);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 30);
            this.lblType.TabIndex = 28;
            // 
            // DTStop
            // 
            this.DTStop.Font = new System.Drawing.Font("宋体", 9F);
            this.DTStop.Location = new System.Drawing.Point(275, 29);
            this.DTStop.Name = "DTStop";
            this.DTStop.Size = new System.Drawing.Size(134, 21);
            this.DTStop.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(214, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "终止时间：";
            // 
            // DTPOrderDate
            // 
            this.DTPOrderDate.Font = new System.Drawing.Font("宋体", 9F);
            this.DTPOrderDate.Location = new System.Drawing.Point(73, 29);
            this.DTPOrderDate.Name = "DTPOrderDate";
            this.DTPOrderDate.Size = new System.Drawing.Size(134, 21);
            this.DTPOrderDate.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.Location = new System.Drawing.Point(12, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "起始时间：";
            // 
            // TxtCade
            // 
            this.TxtCade.Font = new System.Drawing.Font("宋体", 9F);
            this.TxtCade.Location = new System.Drawing.Point(61, 5);
            this.TxtCade.Name = "TxtCade";
            this.TxtCade.Size = new System.Drawing.Size(146, 21);
            this.TxtCade.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "单据号：";
            // 
            // btnupEXcel
            // 
            this.btnupEXcel.Font = new System.Drawing.Font("宋体", 9F);
            this.btnupEXcel.Location = new System.Drawing.Point(646, 5);
            this.btnupEXcel.Name = "btnupEXcel";
            this.btnupEXcel.Size = new System.Drawing.Size(88, 45);
            this.btnupEXcel.TabIndex = 16;
            this.btnupEXcel.Text = "导出EXCEL";
            this.btnupEXcel.UseVisualStyleBackColor = true;
            this.btnupEXcel.Visible = false;
            // 
            // CmdShop
            // 
            this.CmdShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdShop.Font = new System.Drawing.Font("宋体", 9F);
            this.CmdShop.FormattingEnabled = true;
            this.CmdShop.Location = new System.Drawing.Point(275, 5);
            this.CmdShop.Name = "CmdShop";
            this.CmdShop.Size = new System.Drawing.Size(134, 20);
            this.CmdShop.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(238, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "仓库：";
            // 
            // GpbBtn
            // 
            this.GpbBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.GpbBtn.Font = new System.Drawing.Font("宋体", 1F);
            this.GpbBtn.Location = new System.Drawing.Point(0, 54);
            this.GpbBtn.Name = "GpbBtn";
            this.GpbBtn.Size = new System.Drawing.Size(840, 30);
            this.GpbBtn.TabIndex = 21;
            this.GpbBtn.TabStop = false;
            // 
            // rStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 455);
            this.Controls.Add(this.WPHbROWDGV);
            this.Controls.Add(this.GpbBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "rStorage";
            this.Text = "rStorage";
            this.Load += new System.EventHandler(this.rStorage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WPHbROWDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DTStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPOrderDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnupEXcel;
        private System.Windows.Forms.ComboBox CmdShop;
        private System.Windows.Forms.Button BTNbROW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.GroupBox GpbBtn;
    }
}