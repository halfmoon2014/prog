namespace Merrto.CustomerService
{
    partial class OutRuturnStorage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtOrderCade = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtExpress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CboUserName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CboType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CboShopName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.DTStop = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmdCadeType = new System.Windows.Forms.ComboBox();
            this.BTNbROW = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.WPHbROWDGV = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LblNomber = new System.Windows.Forms.Label();
            this.GpbBtn = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtOrderCade);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TxtExpress);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.CboUserName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CboType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CboShopName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.DTStop);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DTPOrderDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtCade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CmdCadeType);
            this.groupBox1.Controls.Add(this.BTNbROW);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TxtOrderCade
            // 
            this.TxtOrderCade.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtOrderCade.Location = new System.Drawing.Point(642, 5);
            this.TxtOrderCade.Name = "TxtOrderCade";
            this.TxtOrderCade.Size = new System.Drawing.Size(119, 21);
            this.TxtOrderCade.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(607, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 52;
            this.label9.Text = "订单：";
            // 
            // TxtExpress
            // 
            this.TxtExpress.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtExpress.Location = new System.Drawing.Point(642, 30);
            this.TxtExpress.Name = "TxtExpress";
            this.TxtExpress.Size = new System.Drawing.Size(119, 21);
            this.TxtExpress.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(596, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 50;
            this.label8.Text = "快递单：";
            // 
            // CboUserName
            // 
            this.CboUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboUserName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CboUserName.FormattingEnabled = true;
            this.CboUserName.Items.AddRange(new object[] {
            "等待寄回",
            "等待收货",
            "确认收货",
            "换货完毕",
            "退款完毕",
            "ERP已核",
            "订单完成",
            "订单关闭",
            "            "});
            this.CboUserName.Location = new System.Drawing.Point(486, 6);
            this.CboUserName.Name = "CboUserName";
            this.CboUserName.Size = new System.Drawing.Size(109, 20);
            this.CboUserName.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(439, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 45;
            this.label7.Text = "操作员：";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // CboType
            // 
            this.CboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CboType.FormattingEnabled = true;
            this.CboType.Items.AddRange(new object[] {
            "等待寄回",
            "等待收货",
            "确认收货",
            "换货完毕",
            "退款完毕",
            "ERP已核",
            "订单完成",
            "订单关闭",
            "            "});
            this.CboType.Location = new System.Drawing.Point(352, 30);
            this.CboType.Name = "CboType";
            this.CboType.Size = new System.Drawing.Size(86, 20);
            this.CboType.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(317, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 43;
            this.label6.Text = "状态：";
            // 
            // CboShopName
            // 
            this.CboShopName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboShopName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CboShopName.FormattingEnabled = true;
            this.CboShopName.Location = new System.Drawing.Point(486, 32);
            this.CboShopName.Name = "CboShopName";
            this.CboShopName.Size = new System.Drawing.Size(109, 20);
            this.CboShopName.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(451, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 41;
            this.label5.Text = "店铺：";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblType.ForeColor = System.Drawing.Color.Red;
            this.lblType.Location = new System.Drawing.Point(417, 15);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 12);
            this.lblType.TabIndex = 39;
            // 
            // DTStop
            // 
            this.DTStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTStop.Location = new System.Drawing.Point(272, 6);
            this.DTStop.Name = "DTStop";
            this.DTStop.Size = new System.Drawing.Size(166, 21);
            this.DTStop.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(211, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "终止时间：";
            // 
            // DTPOrderDate
            // 
            this.DTPOrderDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTPOrderDate.Location = new System.Drawing.Point(70, 6);
            this.DTPOrderDate.Name = "DTPOrderDate";
            this.DTPOrderDate.Size = new System.Drawing.Size(134, 21);
            this.DTPOrderDate.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(9, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 35;
            this.label4.Text = "起始时间：";
            // 
            // TxtCade
            // 
            this.TxtCade.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtCade.Location = new System.Drawing.Point(59, 30);
            this.TxtCade.Name = "TxtCade";
            this.TxtCade.Size = new System.Drawing.Size(146, 21);
            this.TxtCade.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "会员号：";
            // 
            // CmdCadeType
            // 
            this.CmdCadeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdCadeType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmdCadeType.FormattingEnabled = true;
            this.CmdCadeType.Location = new System.Drawing.Point(249, 31);
            this.CmdCadeType.Name = "CmdCadeType";
            this.CmdCadeType.Size = new System.Drawing.Size(64, 20);
            this.CmdCadeType.TabIndex = 29;
            // 
            // BTNbROW
            // 
            this.BTNbROW.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTNbROW.Location = new System.Drawing.Point(764, 3);
            this.BTNbROW.Name = "BTNbROW";
            this.BTNbROW.Size = new System.Drawing.Size(75, 50);
            this.BTNbROW.TabIndex = 31;
            this.BTNbROW.Text = "查询";
            this.BTNbROW.UseVisualStyleBackColor = true;
            this.BTNbROW.Click += new System.EventHandler(this.BTNbROW_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(212, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "类型：";
            // 
            // WPHbROWDGV
            // 
            this.WPHbROWDGV.AllowUserToAddRows = false;
            this.WPHbROWDGV.AllowUserToDeleteRows = false;
            this.WPHbROWDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WPHbROWDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WPHbROWDGV.Location = new System.Drawing.Point(0, 87);
            this.WPHbROWDGV.Name = "WPHbROWDGV";
            this.WPHbROWDGV.ReadOnly = true;
            this.WPHbROWDGV.RowTemplate.Height = 23;
            this.WPHbROWDGV.Size = new System.Drawing.Size(900, 488);
            this.WPHbROWDGV.TabIndex = 18;
            this.WPHbROWDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.WPHbROWDGV_DataBindingComplete);
            this.WPHbROWDGV.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.WPHbROWDGV_RowPostPaint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LblNomber);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox3.Location = new System.Drawing.Point(0, 575);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(900, 25);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // LblNomber
            // 
            this.LblNomber.AutoSize = true;
            this.LblNomber.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblNomber.Location = new System.Drawing.Point(5, 6);
            this.LblNomber.Name = "LblNomber";
            this.LblNomber.Size = new System.Drawing.Size(53, 12);
            this.LblNomber.TabIndex = 34;
            this.LblNomber.Text = "会员号：";
            // 
            // GpbBtn
            // 
            this.GpbBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.GpbBtn.Font = new System.Drawing.Font("宋体", 1F);
            this.GpbBtn.Location = new System.Drawing.Point(0, 57);
            this.GpbBtn.Name = "GpbBtn";
            this.GpbBtn.Size = new System.Drawing.Size(900, 30);
            this.GpbBtn.TabIndex = 20;
            this.GpbBtn.TabStop = false;
            // 
            // OutRuturnStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.WPHbROWDGV);
            this.Controls.Add(this.GpbBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OutRuturnStorage";
            this.Text = "OutRuturnStorage";
            this.Load += new System.EventHandler(this.OutRuturnStorage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.DateTimePicker DTStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPOrderDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmdCadeType;
        private System.Windows.Forms.Button BTNbROW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CboShopName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView WPHbROWDGV;
        private System.Windows.Forms.ComboBox CboType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CboUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtOrderCade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtExpress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label LblNomber;
        private System.Windows.Forms.GroupBox GpbBtn;
    }
}