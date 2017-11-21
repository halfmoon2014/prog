namespace Merrto.TheShopReports
{
    partial class STR_itemDBO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STR_itemDBO));
            this.DTPdatedt = new System.Windows.Forms.DateTimePicker();
            this.TXtRemarks = new System.Windows.Forms.TextBox();
            this.TxtSumMoney = new System.Windows.Forms.TextBox();
            this.CboItem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.CmdShop = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DTPdatedt
            // 
            resources.ApplyResources(this.DTPdatedt, "DTPdatedt");
            this.DTPdatedt.Name = "DTPdatedt";
            // 
            // TXtRemarks
            // 
            resources.ApplyResources(this.TXtRemarks, "TXtRemarks");
            this.TXtRemarks.Name = "TXtRemarks";
            // 
            // TxtSumMoney
            // 
            resources.ApplyResources(this.TxtSumMoney, "TxtSumMoney");
            this.TxtSumMoney.Name = "TxtSumMoney";
            // 
            // CboItem
            // 
            resources.ApplyResources(this.CboItem, "CboItem");
            this.CboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboItem.FormattingEnabled = true;
            this.CboItem.Name = "CboItem";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // BtnSave
            // 
            resources.ApplyResources(this.BtnSave, "BtnSave");
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // CmdShop
            // 
            resources.ApplyResources(this.CmdShop, "CmdShop");
            this.CmdShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdShop.FormattingEnabled = true;
            this.CmdShop.Name = "CmdShop";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // BtnQuit
            // 
            resources.ApplyResources(this.BtnQuit, "BtnQuit");
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.UseVisualStyleBackColor = true;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // STR_itemDBO
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.CmdShop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CboItem);
            this.Controls.Add(this.TXtRemarks);
            this.Controls.Add(this.TxtSumMoney);
            this.Controls.Add(this.DTPdatedt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "STR_itemDBO";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.STR_itemDBO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPdatedt;
        private System.Windows.Forms.TextBox TXtRemarks;
        private System.Windows.Forms.TextBox TxtSumMoney;
        private System.Windows.Forms.ComboBox CboItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ComboBox CmdShop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnQuit;

    }
}