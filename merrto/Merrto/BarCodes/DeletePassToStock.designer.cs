namespace Merrto.BarCodes
{
    partial class DeletePassToStock
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
            this.CboBatch = new System.Windows.Forms.ComboBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCade = new System.Windows.Forms.Button();
            this.CboCade = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CboBatch
            // 
            this.CboBatch.FormattingEnabled = true;
            this.CboBatch.Location = new System.Drawing.Point(68, 37);
            this.CboBatch.Name = "CboBatch";
            this.CboBatch.Size = new System.Drawing.Size(243, 20);
            this.CboBatch.TabIndex = 0;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(317, 31);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 31);
            this.BtnDelete.TabIndex = 1;
            this.BtnDelete.Text = "重置";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "入库批次：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "装箱箱号：";
            // 
            // BtnCade
            // 
            this.BtnCade.Location = new System.Drawing.Point(317, 95);
            this.BtnCade.Name = "BtnCade";
            this.BtnCade.Size = new System.Drawing.Size(75, 31);
            this.BtnCade.TabIndex = 30;
            this.BtnCade.Text = "重置";
            this.BtnCade.UseVisualStyleBackColor = true;
            this.BtnCade.Click += new System.EventHandler(this.BtnCade_Click);
            // 
            // CboCade
            // 
            this.CboCade.FormattingEnabled = true;
            this.CboCade.Location = new System.Drawing.Point(68, 101);
            this.CboCade.Name = "CboCade";
            this.CboCade.Size = new System.Drawing.Size(243, 20);
            this.CboCade.TabIndex = 29;
            // 
            // DeletePassToStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 353);
            this.Controls.Add(this.CboCade);
            this.Controls.Add(this.CboBatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeletePassToStock";
            this.Text = "DeletePassToStock";
            this.Load += new System.EventHandler(this.DeletePassToStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboBatch;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCade;
        private System.Windows.Forms.ComboBox CboCade;
    }
}