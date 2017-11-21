namespace Merrto.M_System
{
    partial class Soft_Buttion
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
            this.btndelete = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtcade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.buttondg = new System.Windows.Forms.DataGridView();
            this.TxtSort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.buttondg)).BeginInit();
            this.SuspendLayout();
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(523, 279);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 15;
            this.btndelete.Text = "删除";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(390, 193);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(208, 21);
            this.txtname.TabIndex = 14;
            // 
            // txtcade
            // 
            this.txtcade.Location = new System.Drawing.Point(390, 140);
            this.txtcade.Name = "txtcade";
            this.txtcade.Size = new System.Drawing.Size(208, 21);
            this.txtcade.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "编码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "名称";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(355, 279);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 9;
            this.btnsave.Text = "应用";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // buttondg
            // 
            this.buttondg.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.buttondg.AllowUserToAddRows = false;
            this.buttondg.AllowUserToDeleteRows = false;
            this.buttondg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.buttondg.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttondg.Location = new System.Drawing.Point(0, 0);
            this.buttondg.Name = "buttondg";
            this.buttondg.ReadOnly = true;
            this.buttondg.RowTemplate.Height = 23;
            this.buttondg.Size = new System.Drawing.Size(325, 464);
            this.buttondg.TabIndex = 8;
            this.buttondg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.buttondg_CellClick);
            // 
            // TxtSort
            // 
            this.TxtSort.Location = new System.Drawing.Point(390, 239);
            this.TxtSort.Name = "TxtSort";
            this.TxtSort.Size = new System.Drawing.Size(208, 21);
            this.TxtSort.TabIndex = 17;
            this.TxtSort.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "排序";
            // 
            // Soft_Buttion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 464);
            this.Controls.Add(this.TxtSort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtcade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.buttondg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Soft_Buttion";
            this.Text = "Soft_Buttion";
            this.Load += new System.EventHandler(this.Soft_Buttion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.buttondg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtcade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridView buttondg;
        private System.Windows.Forms.TextBox TxtSort;
        private System.Windows.Forms.Label label3;
    }
}