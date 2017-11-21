namespace Merrto.BarCodes
{
    partial class PassToStockEdit
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
            this.DtpCadeDate = new System.Windows.Forms.DateTimePicker();
            this.CboFID = new System.Windows.Forms.ComboBox();
            this.TxtNo = new System.Windows.Forms.TextBox();
            this.TxtCade = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtItem_no = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.TxtOrderCade = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtBarCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtSize = new System.Windows.Forms.TextBox();
            this.Txtcolour = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DtpCadeDate
            // 
            this.DtpCadeDate.Checked = false;
            this.DtpCadeDate.Font = new System.Drawing.Font("宋体", 9F);
            this.DtpCadeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpCadeDate.Location = new System.Drawing.Point(51, 86);
            this.DtpCadeDate.Name = "DtpCadeDate";
            this.DtpCadeDate.Size = new System.Drawing.Size(168, 21);
            this.DtpCadeDate.TabIndex = 125;
            // 
            // CboFID
            // 
            this.CboFID.FormattingEnabled = true;
            this.CboFID.Items.AddRange(new object[] {
            "未按约定时间发货",
            "我试了不合适 ",
            "七天无理由退换货",
            "未收到货",
            "商品质量问题",
            "收到商品与描述不符",
            "退运费 ",
            "发票问题",
            "收到假货",
            "商品错发/漏发 ",
            "收到商品破损",
            "商品需要维修"});
            this.CboFID.Location = new System.Drawing.Point(51, 124);
            this.CboFID.Name = "CboFID";
            this.CboFID.Size = new System.Drawing.Size(168, 20);
            this.CboFID.TabIndex = 123;
            // 
            // TxtNo
            // 
            this.TxtNo.Location = new System.Drawing.Point(51, 163);
            this.TxtNo.Name = "TxtNo";
            this.TxtNo.Size = new System.Drawing.Size(168, 21);
            this.TxtNo.TabIndex = 121;
            // 
            // TxtCade
            // 
            this.TxtCade.Location = new System.Drawing.Point(51, 12);
            this.TxtCade.Name = "TxtCade";
            this.TxtCade.Size = new System.Drawing.Size(168, 21);
            this.TxtCade.TabIndex = 113;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.Location = new System.Drawing.Point(8, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 126;
            this.label8.Text = "日期：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 118;
            this.label6.Text = "数量：";
            // 
            // TxtItem_no
            // 
            this.TxtItem_no.Enabled = false;
            this.TxtItem_no.Location = new System.Drawing.Point(283, 86);
            this.TxtItem_no.Name = "TxtItem_no";
            this.TxtItem_no.Size = new System.Drawing.Size(168, 21);
            this.TxtItem_no.TabIndex = 117;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 115;
            this.label7.Text = "颜色：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 114;
            this.label4.Text = "款号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 112;
            this.label2.Text = "批次：";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(240, 16);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 12);
            this.lblID.TabIndex = 111;
            this.lblID.Visible = false;
            // 
            // TxtOrderCade
            // 
            this.TxtOrderCade.Location = new System.Drawing.Point(50, 50);
            this.TxtOrderCade.Name = "TxtOrderCade";
            this.TxtOrderCade.Size = new System.Drawing.Size(168, 21);
            this.TxtOrderCade.TabIndex = 109;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(245, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 108;
            this.label10.Text = "条码：";
            // 
            // TxtBarCode
            // 
            this.TxtBarCode.Location = new System.Drawing.Point(282, 12);
            this.TxtBarCode.Name = "TxtBarCode";
            this.TxtBarCode.Size = new System.Drawing.Size(168, 21);
            this.TxtBarCode.TabIndex = 107;
            this.TxtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarCode_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 106;
            this.label9.Text = "单据：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 105;
            this.label5.Text = "供方：";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(334, 163);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(117, 23);
            this.BtnSave.TabIndex = 103;
            this.BtnSave.Text = "确定(&S)";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(245, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 116;
            this.label11.Text = "尺码：";
            // 
            // TxtSize
            // 
            this.TxtSize.Enabled = false;
            this.TxtSize.Location = new System.Drawing.Point(282, 50);
            this.TxtSize.Name = "TxtSize";
            this.TxtSize.Size = new System.Drawing.Size(168, 21);
            this.TxtSize.TabIndex = 127;
            // 
            // Txtcolour
            // 
            this.Txtcolour.Enabled = false;
            this.Txtcolour.Location = new System.Drawing.Point(282, 123);
            this.Txtcolour.Name = "Txtcolour";
            this.Txtcolour.Size = new System.Drawing.Size(168, 21);
            this.Txtcolour.TabIndex = 128;
            // 
            // PassToStockEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 201);
            this.Controls.Add(this.Txtcolour);
            this.Controls.Add(this.TxtSize);
            this.Controls.Add(this.TxtBarCode);
            this.Controls.Add(this.DtpCadeDate);
            this.Controls.Add(this.CboFID);
            this.Controls.Add(this.TxtNo);
            this.Controls.Add(this.TxtCade);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtItem_no);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.TxtOrderCade);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label11);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PassToStockEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改扫描数据";
            this.Load += new System.EventHandler(this.PassToStockEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtpCadeDate;
        private System.Windows.Forms.ComboBox CboFID;
        private System.Windows.Forms.TextBox TxtNo;
        private System.Windows.Forms.TextBox TxtCade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtItem_no;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox TxtOrderCade;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtBarCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtSize;
        private System.Windows.Forms.TextBox Txtcolour;
    }
}