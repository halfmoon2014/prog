namespace Merrto.CustomerService
{
    partial class QuestionOrderCadeEdit
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
            this.lblID = new System.Windows.Forms.Label();
            this.TXTReason = new System.Windows.Forms.TextBox();
            this.CboShopName = new System.Windows.Forms.ComboBox();
            this.TxtOrderCade = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtExpressBarCode = new System.Windows.Forms.TextBox();
            this.CboExpressName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TxtVipID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(248, 10);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 12);
            this.lblID.TabIndex = 71;
            this.lblID.Visible = false;
            // 
            // TXTReason
            // 
            this.TXTReason.Location = new System.Drawing.Point(329, 67);
            this.TXTReason.Name = "TXTReason";
            this.TXTReason.Size = new System.Drawing.Size(228, 21);
            this.TXTReason.TabIndex = 69;
            // 
            // CboShopName
            // 
            this.CboShopName.FormattingEnabled = true;
            this.CboShopName.Items.AddRange(new object[] {
            "迈途旗舰店",
            "森途户外专营店",
            "海龟船1980",
            "思遥鞋类专营店",
            "迈途户外专营店",
            "迈途本路专卖店",
            "迈途深圳专卖店",
            "拍拍"});
            this.CboShopName.Location = new System.Drawing.Point(67, 27);
            this.CboShopName.Name = "CboShopName";
            this.CboShopName.Size = new System.Drawing.Size(171, 20);
            this.CboShopName.TabIndex = 67;
            // 
            // TxtOrderCade
            // 
            this.TxtOrderCade.Location = new System.Drawing.Point(329, 27);
            this.TxtOrderCade.Name = "TxtOrderCade";
            this.TxtOrderCade.Size = new System.Drawing.Size(228, 21);
            this.TxtOrderCade.TabIndex = 66;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(257, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 65;
            this.label10.Text = "网络订单号：";
            // 
            // TxtExpressBarCode
            // 
            this.TxtExpressBarCode.Location = new System.Drawing.Point(329, 108);
            this.TxtExpressBarCode.Name = "TxtExpressBarCode";
            this.TxtExpressBarCode.Size = new System.Drawing.Size(228, 21);
            this.TxtExpressBarCode.TabIndex = 63;
            // 
            // CboExpressName
            // 
            this.CboExpressName.FormattingEnabled = true;
            this.CboExpressName.Items.AddRange(new object[] {
            "韵达",
            "圆通",
            "中通",
            "申通",
            "顺丰",
            "EMS",
            "天天",
            "全峰",
            "百世",
            "国通",
            "快捷",
            "优速",
            "速尔",
            "宅急送"});
            this.CboExpressName.Location = new System.Drawing.Point(67, 113);
            this.CboExpressName.Name = "CboExpressName";
            this.CboExpressName.Size = new System.Drawing.Size(171, 20);
            this.CboExpressName.TabIndex = 62;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(278, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 61;
            this.label9.Text = "快递单：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 60;
            this.label8.Text = "快递公司：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 58;
            this.label5.Text = "问题：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 56;
            this.label1.Text = "店铺：";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(436, 152);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(117, 23);
            this.BtnSave.TabIndex = 55;
            this.BtnSave.Text = "确定(&S)";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtVipID
            // 
            this.TxtVipID.Location = new System.Drawing.Point(67, 71);
            this.TxtVipID.Name = "TxtVipID";
            this.TxtVipID.Size = new System.Drawing.Size(171, 21);
            this.TxtVipID.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 72;
            this.label2.Text = "买家ID：";
            // 
            // QuestionOrderCadeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 185);
            this.Controls.Add(this.TxtVipID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.TXTReason);
            this.Controls.Add(this.CboShopName);
            this.Controls.Add(this.TxtOrderCade);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtExpressBarCode);
            this.Controls.Add(this.CboExpressName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionOrderCadeEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuestionOrderCadeEdit";
            this.Load += new System.EventHandler(this.QuestionOrderCadeEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox TXTReason;
        private System.Windows.Forms.ComboBox CboShopName;
        private System.Windows.Forms.TextBox TxtOrderCade;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtExpressBarCode;
        private System.Windows.Forms.ComboBox CboExpressName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TxtVipID;
        private System.Windows.Forms.Label label2;
    }
}