namespace Merrto.M_System
{
    partial class Soft_FormBution
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.formdg = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gbbutton = new System.Windows.Forms.GroupBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.buttiondg = new System.Windows.Forms.DataGridView();
            this.BtnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formdg)).BeginInit();
            this.gbbutton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttiondg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.formdg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 524);
            this.panel1.TabIndex = 2;
            // 
            // formdg
            // 
            this.formdg.AllowUserToAddRows = false;
            this.formdg.AllowUserToDeleteRows = false;
            this.formdg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.formdg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formdg.Location = new System.Drawing.Point(0, 0);
            this.formdg.Name = "formdg";
            this.formdg.ReadOnly = true;
            this.formdg.RowTemplate.Height = 23;
            this.formdg.Size = new System.Drawing.Size(220, 524);
            this.formdg.TabIndex = 1;
            this.formdg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.formdg_CellClick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(220, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 524);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // gbbutton
            // 
            this.gbbutton.Controls.Add(this.BtnClose);
            this.gbbutton.Controls.Add(this.btnsave);
            this.gbbutton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbbutton.Location = new System.Drawing.Point(223, 483);
            this.gbbutton.Name = "gbbutton";
            this.gbbutton.Size = new System.Drawing.Size(291, 41);
            this.gbbutton.TabIndex = 5;
            this.gbbutton.TabStop = false;
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnsave.Location = new System.Drawing.Point(15, 14);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 2;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // buttiondg
            // 
            this.buttiondg.AllowUserToAddRows = false;
            this.buttiondg.AllowUserToDeleteRows = false;
            this.buttiondg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttiondg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.buttiondg.Location = new System.Drawing.Point(226, 0);
            this.buttiondg.Name = "buttiondg";
            this.buttiondg.RowTemplate.Height = 23;
            this.buttiondg.Size = new System.Drawing.Size(287, 489);
            this.buttiondg.TabIndex = 6;
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnClose.Location = new System.Drawing.Point(204, 14);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 3;
            this.BtnClose.Text = "退出";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // Soft_FormBution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 524);
            this.Controls.Add(this.buttiondg);
            this.Controls.Add(this.gbbutton);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Soft_FormBution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soft_FormBution";
            this.Load += new System.EventHandler(this.Soft_FormBution_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formdg)).EndInit();
            this.gbbutton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttiondg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView formdg;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox gbbutton;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridView buttiondg;
        private System.Windows.Forms.Button BtnClose;
    }
}