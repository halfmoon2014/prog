namespace Merrto.CustomerService
{
    partial class OutReturnSoragebarcodeEdit
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
            this.BtnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CboReason = new System.Windows.Forms.ComboBox();
            this.CboCadeType = new System.Windows.Forms.ComboBox();
            this.CboNExpressName = new System.Windows.Forms.ComboBox();
            this.CboExpressName = new System.Windows.Forms.ComboBox();
            this.TxtExpressBarCode = new System.Windows.Forms.TextBox();
            this.TxtRemarks = new System.Windows.Forms.TextBox();
            this.TxtVipName = new System.Windows.Forms.TextBox();
            this.TxtMobile = new System.Windows.Forms.TextBox();
            this.TxtOrderCade = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CboShopName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(485, 218);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "确定";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "店铺：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "会员号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "电话：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "原因：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "问题处理：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "换出快递公司：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(248, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "寄回快递公司：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(260, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "寄回快递单：";
            // 
            // CboReason
            // 
            this.CboReason.FormattingEnabled = true;
            this.CboReason.Items.AddRange(new object[] {
            "七天无理由（买家不喜欢）",
            "尺码问题偏小",
            "尺码问题偏大",
            "质量问题（承担邮费）",
            "发错货（承担邮费）",
            "退货重拍（尺码偏大）",
            "退货重拍（尺码偏小）",
            "描述不符（色差）",
            "拒签退回"});
            this.CboReason.Location = new System.Drawing.Point(61, 177);
            this.CboReason.Name = "CboReason";
            this.CboReason.Size = new System.Drawing.Size(171, 20);
            this.CboReason.TabIndex = 11;
            // 
            // CboCadeType
            // 
            this.CboCadeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboCadeType.FormattingEnabled = true;
            this.CboCadeType.Items.AddRange(new object[] {
            "退货",
            "换货",
            "维修"});
            this.CboCadeType.Location = new System.Drawing.Point(61, 63);
            this.CboCadeType.Name = "CboCadeType";
            this.CboCadeType.Size = new System.Drawing.Size(171, 20);
            this.CboCadeType.TabIndex = 12;
            // 
            // CboNExpressName
            // 
            this.CboNExpressName.FormattingEnabled = true;
            this.CboNExpressName.Items.AddRange(new object[] {
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
            "宅急送",
            "信丰"});
            this.CboNExpressName.Location = new System.Drawing.Point(332, 20);
            this.CboNExpressName.Name = "CboNExpressName";
            this.CboNExpressName.Size = new System.Drawing.Size(228, 20);
            this.CboNExpressName.TabIndex = 13;
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
            "宅急送",
            "信丰"});
            this.CboExpressName.Location = new System.Drawing.Point(332, 63);
            this.CboExpressName.Name = "CboExpressName";
            this.CboExpressName.Size = new System.Drawing.Size(228, 20);
            this.CboExpressName.TabIndex = 14;
            // 
            // TxtExpressBarCode
            // 
            this.TxtExpressBarCode.Location = new System.Drawing.Point(332, 101);
            this.TxtExpressBarCode.Name = "TxtExpressBarCode";
            this.TxtExpressBarCode.Size = new System.Drawing.Size(228, 21);
            this.TxtExpressBarCode.TabIndex = 15;
            // 
            // TxtRemarks
            // 
            this.TxtRemarks.Location = new System.Drawing.Point(332, 177);
            this.TxtRemarks.Name = "TxtRemarks";
            this.TxtRemarks.Size = new System.Drawing.Size(228, 21);
            this.TxtRemarks.TabIndex = 16;
            // 
            // TxtVipName
            // 
            this.TxtVipName.Location = new System.Drawing.Point(61, 101);
            this.TxtVipName.Name = "TxtVipName";
            this.TxtVipName.Size = new System.Drawing.Size(171, 21);
            this.TxtVipName.TabIndex = 17;
            // 
            // TxtMobile
            // 
            this.TxtMobile.Location = new System.Drawing.Point(61, 139);
            this.TxtMobile.Name = "TxtMobile";
            this.TxtMobile.Size = new System.Drawing.Size(171, 21);
            this.TxtMobile.TabIndex = 18;
            // 
            // TxtOrderCade
            // 
            this.TxtOrderCade.Location = new System.Drawing.Point(332, 134);
            this.TxtOrderCade.Name = "TxtOrderCade";
            this.TxtOrderCade.Size = new System.Drawing.Size(228, 21);
            this.TxtOrderCade.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(260, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "网络订单号：";
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
            "淘宝分销后台",
            "迈途本路专卖店",
            "迈途深圳专卖店",
            "拍拍",
            "aben",
            "缤纷服饰专营店",
            "策驰",
            "分销小杨",
            "互动分销",
            "尚之彩",
            "拓野回回给",
            "千里狼户外专营店",
            "迈途君德专卖店",
            "深圳迈途专卖店",
            "本路户外专营店",
            "君德户外专营店 ",
            "步步升电商",
            "虎牙运动户外专营店 ",
            "恒发户外专营店",
            "博库户外专营店",
            "君德户外专营店",
            "京东思远户外",
            "京东迈途户外SOP",
            "迈途分销阿里巴巴",
            "MERRTO迈途当当旗舰店",
            "MERRTO迈途一号店旗舰店",
            "深圳市迈乐途电子商务有限公司",
            "京东户外旗舰店LBP",
            "京东户外旗舰店SOPL",
            "凡客迈途-顺丰",
            "拍鞋网迈途旗舰店",
            "迈途邮乐旗舰店",
            "库巴旗舰店",
            "驴友商城旗舰店",
            "迈途户外专营店",
            "迈途本路专卖店"});
            this.CboShopName.Location = new System.Drawing.Point(61, 21);
            this.CboShopName.Name = "CboShopName";
            this.CboShopName.Size = new System.Drawing.Size(171, 20);
            this.CboShopName.TabIndex = 21;
            // 
            // OutReturnSoragebarcodeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 256);
            this.Controls.Add(this.CboShopName);
            this.Controls.Add(this.TxtOrderCade);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtMobile);
            this.Controls.Add(this.TxtVipName);
            this.Controls.Add(this.TxtRemarks);
            this.Controls.Add(this.TxtExpressBarCode);
            this.Controls.Add(this.CboExpressName);
            this.Controls.Add(this.CboNExpressName);
            this.Controls.Add(this.CboCadeType);
            this.Controls.Add(this.CboReason);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutReturnSoragebarcodeEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "领用";
            this.Load += new System.EventHandler(this.OutReturnSoragebarcodeEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CboReason;
        private System.Windows.Forms.ComboBox CboCadeType;
        private System.Windows.Forms.ComboBox CboNExpressName;
        private System.Windows.Forms.ComboBox CboExpressName;
        private System.Windows.Forms.TextBox TxtExpressBarCode;
        private System.Windows.Forms.TextBox TxtRemarks;
        private System.Windows.Forms.TextBox TxtVipName;
        private System.Windows.Forms.TextBox TxtMobile;
        private System.Windows.Forms.TextBox TxtOrderCade;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CboShopName;
    }
}