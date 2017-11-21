namespace Merrto.TheShopReports
{
    partial class productCostNew
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
            this.TXTCost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TxtProduect = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblpid = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TXTCost
            // 
            this.TXTCost.Location = new System.Drawing.Point(73, 46);
            this.TXTCost.Name = "TXTCost";
            this.TXTCost.Size = new System.Drawing.Size(212, 21);
            this.TXTCost.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "成  本：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(210, 87);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(8, 87);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 28;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtProduect
            // 
            this.TxtProduect.Enabled = false;
            this.TxtProduect.Location = new System.Drawing.Point(74, 12);
            this.TxtProduect.Name = "TxtProduect";
            this.TxtProduect.Size = new System.Drawing.Size(212, 21);
            this.TxtProduect.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "款  号：";
            // 
            // lblpid
            // 
            this.lblpid.AutoSize = true;
            this.lblpid.Location = new System.Drawing.Point(103, 92);
            this.lblpid.Name = "lblpid";
            this.lblpid.Size = new System.Drawing.Size(23, 12);
            this.lblpid.TabIndex = 32;
            this.lblpid.Text = "PID";
            this.lblpid.Visible = false;
            // 
            // productCostNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 123);
            this.Controls.Add(this.lblpid);
            this.Controls.Add(this.TXTCost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtProduect);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "productCostNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "productCostNew";
            this.Load += new System.EventHandler(this.productCostNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TxtProduect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblpid;
    }
}