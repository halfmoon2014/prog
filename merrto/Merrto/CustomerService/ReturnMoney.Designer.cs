namespace Merrto.CustomerService
{
    partial class ReturnMoney
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnReturnCanle = new System.Windows.Forms.Button();
            this.BtnOperate = new System.Windows.Forms.Button();
            this.BtnCanle = new System.Windows.Forms.Button();
            this.BtnReturnHandle = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.BtnEmploy = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CboUserName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CboType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DTStop = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DTPOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtVIPname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnupEXcel = new System.Windows.Forms.Button();
            this.BTNbROW = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LblNomber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // WPHbROWDGV
            // 
            this.WPHbROWDGV.AllowUserToAddRows = false;
            this.WPHbROWDGV.AllowUserToDeleteRows = false;
            this.WPHbROWDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WPHbROWDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WPHbROWDGV.Location = new System.Drawing.Point(0, 94);
            this.WPHbROWDGV.Name = "WPHbROWDGV";
            this.WPHbROWDGV.ReadOnly = true;
            this.WPHbROWDGV.RowTemplate.Height = 23;
            this.WPHbROWDGV.Size = new System.Drawing.Size(954, 371);
            this.WPHbROWDGV.TabIndex = 27;
            this.WPHbROWDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.WPHbROWDGV_DataBindingComplete);
            this.WPHbROWDGV.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.WPHbROWDGV_RowPostPaint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnReturnCanle);
            this.groupBox2.Controls.Add(this.BtnOperate);
            this.groupBox2.Controls.Add(this.BtnCanle);
            this.groupBox2.Controls.Add(this.BtnReturnHandle);
            this.groupBox2.Controls.Add(this.BtnNew);
            this.groupBox2.Controls.Add(this.BtnEmploy);
            this.groupBox2.Controls.Add(this.BtnEdit);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox2.Location = new System.Drawing.Point(0, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(954, 39);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // BtnReturnCanle
            // 
            this.BtnReturnCanle.Enabled = false;
            this.BtnReturnCanle.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnReturnCanle.Location = new System.Drawing.Point(396, 3);
            this.BtnReturnCanle.Name = "BtnReturnCanle";
            this.BtnReturnCanle.Size = new System.Drawing.Size(75, 32);
            this.BtnReturnCanle.TabIndex = 31;
            this.BtnReturnCanle.Text = "取消作废";
            this.BtnReturnCanle.UseVisualStyleBackColor = true;
            this.BtnReturnCanle.Click += new System.EventHandler(this.BtnReturnCanle_Click);
            // 
            // BtnOperate
            // 
            this.BtnOperate.Enabled = false;
            this.BtnOperate.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnOperate.Location = new System.Drawing.Point(475, 3);
            this.BtnOperate.Name = "BtnOperate";
            this.BtnOperate.Size = new System.Drawing.Size(75, 32);
            this.BtnOperate.TabIndex = 30;
            this.BtnOperate.Text = "日志";
            this.BtnOperate.UseVisualStyleBackColor = true;
            this.BtnOperate.Click += new System.EventHandler(this.BtnOperate_Click);
            // 
            // BtnCanle
            // 
            this.BtnCanle.Enabled = false;
            this.BtnCanle.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnCanle.Location = new System.Drawing.Point(318, 3);
            this.BtnCanle.Name = "BtnCanle";
            this.BtnCanle.Size = new System.Drawing.Size(75, 32);
            this.BtnCanle.TabIndex = 29;
            this.BtnCanle.Text = "作废";
            this.BtnCanle.UseVisualStyleBackColor = true;
            this.BtnCanle.Click += new System.EventHandler(this.BtnCanle_Click);
            // 
            // BtnReturnHandle
            // 
            this.BtnReturnHandle.Enabled = false;
            this.BtnReturnHandle.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnReturnHandle.Location = new System.Drawing.Point(240, 3);
            this.BtnReturnHandle.Name = "BtnReturnHandle";
            this.BtnReturnHandle.Size = new System.Drawing.Size(75, 32);
            this.BtnReturnHandle.TabIndex = 28;
            this.BtnReturnHandle.Text = "反审";
            this.BtnReturnHandle.UseVisualStyleBackColor = true;
            this.BtnReturnHandle.Click += new System.EventHandler(this.BtnReturnHandle_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Enabled = false;
            this.BtnNew.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnNew.Location = new System.Drawing.Point(6, 3);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 32);
            this.BtnNew.TabIndex = 27;
            this.BtnNew.Text = "新增(&N)";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnEmploy
            // 
            this.BtnEmploy.Enabled = false;
            this.BtnEmploy.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnEmploy.Location = new System.Drawing.Point(162, 3);
            this.BtnEmploy.Name = "BtnEmploy";
            this.BtnEmploy.Size = new System.Drawing.Size(75, 32);
            this.BtnEmploy.TabIndex = 25;
            this.BtnEmploy.Text = "审核";
            this.BtnEmploy.UseVisualStyleBackColor = true;
            this.BtnEmploy.Click += new System.EventHandler(this.BtnEmploy_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Enabled = false;
            this.BtnEdit.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnEdit.Location = new System.Drawing.Point(83, 3);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 32);
            this.BtnEdit.TabIndex = 19;
            this.BtnEdit.Text = "修改(&U)";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CboUserName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CboType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DTStop);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DTPOrderDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtVIPname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtCade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnupEXcel);
            this.groupBox1.Controls.Add(this.BTNbROW);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(954, 55);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
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
            this.CboUserName.Location = new System.Drawing.Point(473, 31);
            this.CboUserName.Name = "CboUserName";
            this.CboUserName.Size = new System.Drawing.Size(123, 20);
            this.CboUserName.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(424, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 49;
            this.label7.Text = "操作员：";
            // 
            // CboType
            // 
            this.CboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CboType.FormattingEnabled = true;
            this.CboType.Items.AddRange(new object[] {
            "待处理",
            "已审核",
            "关闭",
            " "});
            this.CboType.Location = new System.Drawing.Point(474, 7);
            this.CboType.Name = "CboType";
            this.CboType.Size = new System.Drawing.Size(122, 20);
            this.CboType.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(435, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "状态：";
            // 
            // DTStop
            // 
            this.DTStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTStop.Location = new System.Drawing.Point(273, 6);
            this.DTStop.Name = "DTStop";
            this.DTStop.Size = new System.Drawing.Size(144, 21);
            this.DTStop.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(215, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "终止时间：";
            // 
            // DTPOrderDate
            // 
            this.DTPOrderDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DTPOrderDate.Location = new System.Drawing.Point(72, 5);
            this.DTPOrderDate.Name = "DTPOrderDate";
            this.DTPOrderDate.Size = new System.Drawing.Size(134, 21);
            this.DTPOrderDate.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "起始时间：";
            // 
            // TxtVIPname
            // 
            this.TxtVIPname.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtVIPname.Location = new System.Drawing.Point(71, 31);
            this.TxtVIPname.Name = "TxtVIPname";
            this.TxtVIPname.Size = new System.Drawing.Size(135, 21);
            this.TxtVIPname.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "买家ID：";
            // 
            // TxtCade
            // 
            this.TxtCade.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtCade.Location = new System.Drawing.Point(273, 31);
            this.TxtCade.Name = "TxtCade";
            this.TxtCade.Size = new System.Drawing.Size(144, 21);
            this.TxtCade.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(234, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "订单：";
            // 
            // btnupEXcel
            // 
            this.btnupEXcel.Enabled = false;
            this.btnupEXcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnupEXcel.Location = new System.Drawing.Point(692, 4);
            this.btnupEXcel.Name = "btnupEXcel";
            this.btnupEXcel.Size = new System.Drawing.Size(88, 44);
            this.btnupEXcel.TabIndex = 32;
            this.btnupEXcel.Text = "导出EXCEL";
            this.btnupEXcel.UseVisualStyleBackColor = true;
            this.btnupEXcel.Click += new System.EventHandler(this.btnupEXcel_Click);
            // 
            // BTNbROW
            // 
            this.BTNbROW.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTNbROW.Location = new System.Drawing.Point(613, 4);
            this.BTNbROW.Name = "BTNbROW";
            this.BTNbROW.Size = new System.Drawing.Size(75, 44);
            this.BTNbROW.TabIndex = 31;
            this.BTNbROW.Text = "查询";
            this.BTNbROW.UseVisualStyleBackColor = true;
            this.BTNbROW.Click += new System.EventHandler(this.BTNbROW_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LblNomber);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox3.Location = new System.Drawing.Point(0, 465);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(954, 25);
            this.groupBox3.TabIndex = 28;
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
            // ReturnMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 490);
            this.Controls.Add(this.WPHbROWDGV);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReturnMoney";
            this.Text = "ReturnMoney";
            this.Load += new System.EventHandler(this.ReturnMoney_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WPHbROWDGV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnCanle;
        private System.Windows.Forms.Button BtnReturnHandle;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Button BtnEmploy;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CboType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DTStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTPOrderDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtVIPname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnupEXcel;
        private System.Windows.Forms.Button BTNbROW;
        private System.Windows.Forms.Button BtnOperate;
        private System.Windows.Forms.Button BtnReturnCanle;
        private System.Windows.Forms.ComboBox CboUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label LblNomber;
    }
}