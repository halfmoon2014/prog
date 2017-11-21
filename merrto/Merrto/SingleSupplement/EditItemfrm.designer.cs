namespace Merrto.SingleSupplement
{
    partial class EditItemfrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TXTCade = new System.Windows.Forms.TextBox();
            this.ColourSizeDGV = new System.Windows.Forms.DataGridView();
            this.BtnSave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ColourSizeDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "款号";
            // 
            // TXTCade
            // 
            this.TXTCade.Location = new System.Drawing.Point(44, 4);
            this.TXTCade.Name = "TXTCade";
            this.TXTCade.Size = new System.Drawing.Size(290, 21);
            this.TXTCade.TabIndex = 1;
            // 
            // ColourSizeDGV
            // 
            this.ColourSizeDGV.AllowUserToAddRows = false;
            this.ColourSizeDGV.AllowUserToDeleteRows = false;
            this.ColourSizeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColourSizeDGV.Location = new System.Drawing.Point(3, 31);
            this.ColourSizeDGV.Name = "ColourSizeDGV";
            this.ColourSizeDGV.RowTemplate.Height = 23;
            this.ColourSizeDGV.Size = new System.Drawing.Size(331, 326);
            this.ColourSizeDGV.TabIndex = 2;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(14, 374);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(81, 26);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(236, 374);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(81, 26);
            this.btnclose.TabIndex = 4;
            this.btnclose.Text = "退出";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // EditItemfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 412);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.ColourSizeDGV);
            this.Controls.Add(this.TXTCade);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditItemfrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditItemfrm";
            this.Load += new System.EventHandler(this.EditItemfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ColourSizeDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTCade;
        private System.Windows.Forms.DataGridView ColourSizeDGV;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button btnclose;
    }
}