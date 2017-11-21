namespace Merrto
{
    partial class WphProportionEdit
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
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.CmdCategory = new System.Windows.Forms.ComboBox();
            this.CmbStorage = new System.Windows.Forms.ComboBox();
            this.TxtProportion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(351, 124);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(80, 23);
            this.BtnClose.TabIndex = 11;
            this.BtnClose.Text = "退出";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(12, 124);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // CmdCategory
            // 
            this.CmdCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdCategory.FormattingEnabled = true;
            this.CmdCategory.Location = new System.Drawing.Point(74, 12);
            this.CmdCategory.Name = "CmdCategory";
            this.CmdCategory.Size = new System.Drawing.Size(357, 20);
            this.CmdCategory.TabIndex = 12;
            // 
            // CmbStorage
            // 
            this.CmbStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStorage.FormattingEnabled = true;
            this.CmbStorage.Location = new System.Drawing.Point(74, 49);
            this.CmbStorage.Name = "CmbStorage";
            this.CmbStorage.Size = new System.Drawing.Size(357, 20);
            this.CmbStorage.TabIndex = 13;
            // 
            // TxtProportion
            // 
            this.TxtProportion.Location = new System.Drawing.Point(74, 87);
            this.TxtProportion.Name = "TxtProportion";
            this.TxtProportion.Size = new System.Drawing.Size(357, 21);
            this.TxtProportion.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "类别：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "仓库：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "比率：";
            // 
            // WphProportionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 162);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtProportion);
            this.Controls.Add(this.CmbStorage);
            this.Controls.Add(this.CmdCategory);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WphProportionEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WphProportionEdit";
            this.Load += new System.EventHandler(this.WphProportionEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ComboBox CmdCategory;
        private System.Windows.Forms.ComboBox CmbStorage;
        private System.Windows.Forms.TextBox TxtProportion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}