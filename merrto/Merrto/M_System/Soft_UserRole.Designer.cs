namespace Merrto.M_System
{
    partial class Soft_UserRole
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
            this.RoleDG = new System.Windows.Forms.DataGridView();
            this.btnquit = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RoleDG)).BeginInit();
            this.SuspendLayout();
            // 
            // RoleDG
            // 
            this.RoleDG.AllowUserToAddRows = false;
            this.RoleDG.AllowUserToDeleteRows = false;
            this.RoleDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleDG.Dock = System.Windows.Forms.DockStyle.Top;
            this.RoleDG.Location = new System.Drawing.Point(0, 0);
            this.RoleDG.Name = "RoleDG";
            this.RoleDG.RowTemplate.Height = 23;
            this.RoleDG.Size = new System.Drawing.Size(216, 277);
            this.RoleDG.TabIndex = 1;
            // 
            // btnquit
            // 
            this.btnquit.Location = new System.Drawing.Point(129, 295);
            this.btnquit.Name = "btnquit";
            this.btnquit.Size = new System.Drawing.Size(75, 23);
            this.btnquit.TabIndex = 19;
            this.btnquit.Text = "退 出";
            this.btnquit.UseVisualStyleBackColor = true;
            this.btnquit.Click += new System.EventHandler(this.btnquit_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(16, 295);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 18;
            this.btnsave.Text = "保 存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // Soft_UserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 328);
            this.Controls.Add(this.btnquit);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.RoleDG);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Soft_UserRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户";
            this.Load += new System.EventHandler(this.Soft_UserRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RoleDG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView RoleDG;
        private System.Windows.Forms.Button btnquit;
        private System.Windows.Forms.Button btnsave;
    }
}