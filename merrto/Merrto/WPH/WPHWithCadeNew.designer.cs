namespace Merrto.WPH
{
    partial class WPHWithCadeNew
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
            this.TxtItem = new System.Windows.Forms.TextBox();
            this.WithCodeDGV = new System.Windows.Forms.DataGridView();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnQuit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WithCodeDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "款    号：";
            // 
            // TxtItem
            // 
            this.TxtItem.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TxtItem.Enabled = false;
            this.TxtItem.Location = new System.Drawing.Point(72, 12);
            this.TxtItem.Name = "TxtItem";
            this.TxtItem.Size = new System.Drawing.Size(204, 21);
            this.TxtItem.TabIndex = 1;
            // 
            // WithCodeDGV
            // 
            this.WithCodeDGV.AllowUserToAddRows = false;
            this.WithCodeDGV.AllowUserToDeleteRows = false;
            this.WithCodeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WithCodeDGV.Location = new System.Drawing.Point(4, 66);
            this.WithCodeDGV.Name = "WithCodeDGV";
            this.WithCodeDGV.RowTemplate.Height = 23;
            this.WithCodeDGV.Size = new System.Drawing.Size(279, 387);
            this.WithCodeDGV.TabIndex = 2;
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(72, 39);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(204, 21);
            this.TxtName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "配比名称：";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(13, 471);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(82, 27);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnQuit
            // 
            this.BtnQuit.Location = new System.Drawing.Point(184, 471);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(82, 27);
            this.BtnQuit.TabIndex = 6;
            this.BtnQuit.Text = "退出";
            this.BtnQuit.UseVisualStyleBackColor = true;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // WPHWithCadeNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 522);
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WithCodeDGV);
            this.Controls.Add(this.TxtItem);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WPHWithCadeNew";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WPHWithCadeNew";
            this.Load += new System.EventHandler(this.WPHWithCadeNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WithCodeDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtItem;
        private System.Windows.Forms.DataGridView WithCodeDGV;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnQuit;
    }
}