namespace Merrto.SingleSupplement
{
    partial class SSItemSize
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
            this.TXTCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TXTCade
            // 
            this.TXTCade.Location = new System.Drawing.Point(39, 12);
            this.TXTCade.Name = "TXTCade";
            this.TXTCade.Size = new System.Drawing.Size(239, 21);
            this.TXTCade.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "款号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "配码:";
            // 
            // cmbSize
            // 
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(39, 61);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(239, 20);
            this.cmbSize.TabIndex = 5;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(197, 96);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(81, 26);
            this.btnclose.TabIndex = 7;
            this.btnclose.Text = "退出";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(12, 96);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(81, 26);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // SSItemSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 134);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.cmbSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TXTCade);
            this.Controls.Add(this.label1);
            this.Name = "SSItemSize";
            this.Text = "SSItemSize";
            this.Load += new System.EventHandler(this.SSItemSize_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button BtnSave;
    }
}