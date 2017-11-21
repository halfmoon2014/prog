namespace Merrto.M_System
{
    partial class Soft_RoleEdit
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
            this.btnquit = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtcade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TXTRemark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnquit
            // 
            this.btnquit.Location = new System.Drawing.Point(221, 112);
            this.btnquit.Name = "btnquit";
            this.btnquit.Size = new System.Drawing.Size(75, 23);
            this.btnquit.TabIndex = 17;
            this.btnquit.Text = "退 出";
            this.btnquit.UseVisualStyleBackColor = true;
            this.btnquit.Click += new System.EventHandler(this.btnquit_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(45, 112);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 16;
            this.btnsave.Text = "保 存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(74, 48);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(256, 21);
            this.txtname.TabIndex = 15;
            // 
            // txtcade
            // 
            this.txtcade.Location = new System.Drawing.Point(74, 14);
            this.txtcade.Name = "txtcade";
            this.txtcade.Size = new System.Drawing.Size(256, 21);
            this.txtcade.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "角色名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "角色代码";
            // 
            // TXTRemark
            // 
            this.TXTRemark.Location = new System.Drawing.Point(74, 82);
            this.TXTRemark.Name = "TXTRemark";
            this.TXTRemark.Size = new System.Drawing.Size(256, 21);
            this.TXTRemark.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "备    注";
            // 
            // Soft_RoleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 151);
            this.Controls.Add(this.TXTRemark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnquit);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtcade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Soft_RoleEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色新增";
            this.Load += new System.EventHandler(this.Soft_RoleEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnquit;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtcade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTRemark;
        private System.Windows.Forms.Label label3;
    }
}