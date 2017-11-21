namespace Merrto
{
    partial class SizeNew
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
            this.label2 = new System.Windows.Forms.Label();
            this.SizeDetailsDGV = new System.Windows.Forms.DataGridView();
            this.txtCade = new System.Windows.Forms.TextBox();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SizeDetailsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "尺码代码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "尺码名称：";
            // 
            // SizeDetailsDGV
            // 
            this.SizeDetailsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SizeDetailsDGV.Location = new System.Drawing.Point(3, 71);
            this.SizeDetailsDGV.Name = "SizeDetailsDGV";
            this.SizeDetailsDGV.RowTemplate.Height = 23;
            this.SizeDetailsDGV.Size = new System.Drawing.Size(320, 297);
            this.SizeDetailsDGV.TabIndex = 2;
            // 
            // txtCade
            // 
            this.txtCade.Location = new System.Drawing.Point(83, 6);
            this.txtCade.Name = "txtCade";
            this.txtCade.Size = new System.Drawing.Size(228, 21);
            this.txtCade.TabIndex = 3;
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(83, 44);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(228, 21);
            this.TxtName.TabIndex = 4;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(17, 373);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 5;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(236, 373);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 6;
            this.btnclose.Text = "退出";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // SizeNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 405);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.txtCade);
            this.Controls.Add(this.SizeDetailsDGV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SizeNew";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SizeNew";
            this.Load += new System.EventHandler(this.SizeNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SizeDetailsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView SizeDetailsDGV;
        private System.Windows.Forms.TextBox txtCade;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnclose;
    }
}