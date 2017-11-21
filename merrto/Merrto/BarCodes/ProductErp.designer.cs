namespace Merrto
{
    partial class ProductERP
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
            this.BtnRead = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBarCode = new System.Windows.Forms.TextBox();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApiSerect = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApiUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.ddlApiResultType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnRead
            // 
            this.BtnRead.Location = new System.Drawing.Point(397, 79);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(97, 29);
            this.BtnRead.TabIndex = 0;
            this.BtnRead.Text = "读取";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(513, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "快递单号";
            // 
            // TxtBarCode
            // 
            this.TxtBarCode.Location = new System.Drawing.Point(67, 84);
            this.TxtBarCode.Name = "TxtBarCode";
            this.TxtBarCode.Size = new System.Drawing.Size(315, 21);
            this.TxtBarCode.TabIndex = 11;
            this.TxtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarCode_KeyDown);
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(67, 6);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(271, 21);
            this.txtApiKey.TabIndex = 13;
            this.txtApiKey.Text = "U1CITYFXSTEST";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "Api_Key:";
            // 
            // txtApiSerect
            // 
            this.txtApiSerect.Location = new System.Drawing.Point(413, 6);
            this.txtApiSerect.Name = "txtApiSerect";
            this.txtApiSerect.Size = new System.Drawing.Size(242, 21);
            this.txtApiSerect.TabIndex = 15;
            this.txtApiSerect.Text = "U1CITYFXSTESTBBIOFKD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "Api_Serect：";
            // 
            // txtApiUrl
            // 
            this.txtApiUrl.Location = new System.Drawing.Point(67, 46);
            this.txtApiUrl.Name = "txtApiUrl";
            this.txtApiUrl.Size = new System.Drawing.Size(271, 21);
            this.txtApiUrl.TabIndex = 17;
            this.txtApiUrl.Text = "http://wqbopenapi.ushopn6.com/wqbnew/api.rest";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "Api_Url：";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(3, 558);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 18;
            this.lblMsg.Text = "label5";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(14, 114);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(385, 441);
            this.txtMsg.TabIndex = 19;
            // 
            // ddlApiResultType
            // 
            this.ddlApiResultType.AutoCompleteCustomSource.AddRange(new string[] {
            "xml",
            "json"});
            this.ddlApiResultType.FormattingEnabled = true;
            this.ddlApiResultType.Items.AddRange(new object[] {
            "xml",
            "json"});
            this.ddlApiResultType.Location = new System.Drawing.Point(379, 46);
            this.ddlApiResultType.Name = "ddlApiResultType";
            this.ddlApiResultType.Size = new System.Drawing.Size(130, 20);
            this.ddlApiResultType.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(405, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProductERP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 579);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ddlApiResultType);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtApiUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApiSerect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBarCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnRead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductERP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快递单输入";
            this.Load += new System.EventHandler(this.ProductExpress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBarCode;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApiSerect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApiUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.ComboBox ddlApiResultType;
        private System.Windows.Forms.Button button1;
    }
}