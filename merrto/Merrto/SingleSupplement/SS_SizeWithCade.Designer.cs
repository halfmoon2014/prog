namespace Merrto.SingleSupplement
{
    partial class SS_SizeWithCade
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
            this.BtnQuit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.WithCodeDGV = new System.Windows.Forms.DataGridView();
            this.TxtItem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WithCodeDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnQuit
            // 
            this.BtnQuit.Location = new System.Drawing.Point(196, 323);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(82, 27);
            this.BtnQuit.TabIndex = 11;
            this.BtnQuit.Text = "退出";
            this.BtnQuit.UseVisualStyleBackColor = true;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(25, 323);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(82, 27);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // WithCodeDGV
            // 
            this.WithCodeDGV.AllowUserToAddRows = false;
            this.WithCodeDGV.AllowUserToDeleteRows = false;
            this.WithCodeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WithCodeDGV.Location = new System.Drawing.Point(12, 37);
            this.WithCodeDGV.Name = "WithCodeDGV";
            this.WithCodeDGV.RowTemplate.Height = 23;
            this.WithCodeDGV.Size = new System.Drawing.Size(266, 280);
            this.WithCodeDGV.TabIndex = 9;
            // 
            // TxtItem
            // 
            this.TxtItem.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TxtItem.Enabled = false;
            this.TxtItem.Location = new System.Drawing.Point(74, 12);
            this.TxtItem.Name = "TxtItem";
            this.TxtItem.Size = new System.Drawing.Size(204, 21);
            this.TxtItem.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "款    号：";
            // 
            // SS_SizeWithCade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 358);
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.WithCodeDGV);
            this.Controls.Add(this.TxtItem);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SS_SizeWithCade";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SS_SizeWithCade";
            this.Load += new System.EventHandler(this.SS_SizeWithCade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WithCodeDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnQuit;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.DataGridView WithCodeDGV;
        private System.Windows.Forms.TextBox TxtItem;
        private System.Windows.Forms.Label label1;
    }
}