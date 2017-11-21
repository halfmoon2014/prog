namespace BarCode
{
    partial class BarCodeRoute
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
            this.cmbForm = new System.Windows.Forms.ComboBox();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.btnquit = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbForm
            // 
            this.cmbForm.FormattingEnabled = true;
            this.cmbForm.Items.AddRange(new object[] {
            "装箱条码",
            "鞋盒条码",
            "服装条码"});
            this.cmbForm.Location = new System.Drawing.Point(118, 28);
            this.cmbForm.Name = "cmbForm";
            this.cmbForm.Size = new System.Drawing.Size(253, 20);
            this.cmbForm.TabIndex = 21;
            this.cmbForm.Text = "装箱条码";
            // 
            // txtRoute
            // 
            this.txtRoute.Location = new System.Drawing.Point(118, 71);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(253, 21);
            this.txtRoute.TabIndex = 19;
            this.txtRoute.DoubleClick += new System.EventHandler(this.txtRoute_DoubleClick);
            // 
            // btnquit
            // 
            this.btnquit.Location = new System.Drawing.Point(296, 112);
            this.btnquit.Name = "btnquit";
            this.btnquit.Size = new System.Drawing.Size(75, 23);
            this.btnquit.TabIndex = 17;
            this.btnquit.Text = "退出";
            this.btnquit.UseVisualStyleBackColor = true;
            this.btnquit.Click += new System.EventHandler(this.btnquit_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(41, 112);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 15;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "文件路径：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "打印模式：";
            // 
            // BarCodeRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 167);
            this.Controls.Add(this.cmbForm);
            this.Controls.Add(this.txtRoute);
            this.Controls.Add(this.btnquit);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarCodeRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BarCodeRoute";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbForm;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Button btnquit;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}