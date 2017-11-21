namespace Merrto.TheShopReports
{
    partial class CustomerUnitSet
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTName = new System.Windows.Forms.TextBox();
            this.TXTCade = new System.Windows.Forms.TextBox();
            this.BtnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(14, 201);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(81, 32);
            this.BtnSave.TabIndex = 13;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "编号：";
            // 
            // TXTName
            // 
            this.TXTName.Location = new System.Drawing.Point(53, 68);
            this.TXTName.Multiline = true;
            this.TXTName.Name = "TXTName";
            this.TXTName.Size = new System.Drawing.Size(203, 102);
            this.TXTName.TabIndex = 10;
            // 
            // TXTCade
            // 
            this.TXTCade.Location = new System.Drawing.Point(51, 24);
            this.TXTCade.Name = "TXTCade";
            this.TXTCade.Size = new System.Drawing.Size(204, 21);
            this.TXTCade.TabIndex = 9;
            // 
            // BtnQuit
            // 
            this.BtnQuit.Location = new System.Drawing.Point(175, 201);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(81, 32);
            this.BtnQuit.TabIndex = 14;
            this.BtnQuit.Text = "退出";
            this.BtnQuit.UseVisualStyleBackColor = true;
            this.BtnQuit.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // CustomerUnitSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 259);
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.TXTCade);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXTName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerUnitSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerUnitSet";
            this.Load += new System.EventHandler(this.CustomerUnitSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXTName;
        private System.Windows.Forms.TextBox TXTCade;
        private System.Windows.Forms.Button BtnQuit;
    }
}