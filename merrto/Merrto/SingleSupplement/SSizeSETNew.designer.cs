namespace Merrto.SingleSupplement
{
    partial class SSizeSETNew
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
            this.btnclose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.txtCade = new System.Windows.Forms.TextBox();
            this.SizeDetailsDGV = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CMBSize = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.SizeDetailsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(182, 376);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 13;
            this.btnclose.Text = "退出";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(8, 376);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 12;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(74, 46);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(183, 21);
            this.TxtName.TabIndex = 11;
            // 
            // txtCade
            // 
            this.txtCade.Location = new System.Drawing.Point(74, 8);
            this.txtCade.Name = "txtCade";
            this.txtCade.Size = new System.Drawing.Size(183, 21);
            this.txtCade.TabIndex = 10;
            // 
            // SizeDetailsDGV
            // 
            this.SizeDetailsDGV.AllowUserToAddRows = false;
            this.SizeDetailsDGV.AllowUserToDeleteRows = false;
            this.SizeDetailsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SizeDetailsDGV.Location = new System.Drawing.Point(8, 109);
            this.SizeDetailsDGV.Name = "SizeDetailsDGV";
            this.SizeDetailsDGV.RowTemplate.Height = 23;
            this.SizeDetailsDGV.Size = new System.Drawing.Size(249, 257);
            this.SizeDetailsDGV.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "配码名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "配码代码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "尺码名称：";
            // 
            // CMBSize
            // 
            this.CMBSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBSize.FormattingEnabled = true;
            this.CMBSize.Location = new System.Drawing.Point(74, 76);
            this.CMBSize.Name = "CMBSize";
            this.CMBSize.Size = new System.Drawing.Size(183, 20);
            this.CMBSize.TabIndex = 15;
            this.CMBSize.SelectedValueChanged += new System.EventHandler(this.CMBSize_SelectedValueChanged);
            // 
            // SSizeSETNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 407);
            this.Controls.Add(this.CMBSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.txtCade);
            this.Controls.Add(this.SizeDetailsDGV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SSizeSETNew";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配码新增";
            this.Load += new System.EventHandler(this.SSizeSETNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SizeDetailsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox txtCade;
        private System.Windows.Forms.DataGridView SizeDetailsDGV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CMBSize;
    }
}