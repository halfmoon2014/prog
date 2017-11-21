namespace Merrto.Common
{
    partial class CommonForm
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
            this.DateDgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DateDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // DateDgv
            // 
            this.DateDgv.AllowUserToAddRows = false;
            this.DateDgv.AllowUserToDeleteRows = false;
            this.DateDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DateDgv.Location = new System.Drawing.Point(3, 1);
            this.DateDgv.Name = "DateDgv";
            this.DateDgv.ReadOnly = true;
            this.DateDgv.RowTemplate.Height = 23;
            this.DateDgv.Size = new System.Drawing.Size(469, 374);
            this.DateDgv.TabIndex = 0;
            // 
            // CommonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 376);
            this.Controls.Add(this.DateDgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommonForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日志";
            this.Load += new System.EventHandler(this.CommonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DateDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DateDgv;
    }
}