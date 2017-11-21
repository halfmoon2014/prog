namespace Merrto.M_System
{
    partial class Soft_Menu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.data = new System.Windows.Forms.SplitContainer();
            this.RoleDG = new System.Windows.Forms.DataGridView();
            this.MenuDG = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnUser = new System.Windows.Forms.Button();
            this.BtnFormButton = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            this.data.Panel1.SuspendLayout();
            this.data.Panel2.SuspendLayout();
            this.data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuDG)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // data
            // 
            this.data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data.Location = new System.Drawing.Point(0, 0);
            this.data.Name = "data";
            // 
            // data.Panel1
            // 
            this.data.Panel1.Controls.Add(this.RoleDG);
            this.data.Panel1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            // 
            // data.Panel2
            // 
            this.data.Panel2.Controls.Add(this.MenuDG);
            this.data.Size = new System.Drawing.Size(989, 453);
            this.data.SplitterDistance = 174;
            this.data.TabIndex = 3;
            // 
            // RoleDG
            // 
            this.RoleDG.AllowUserToAddRows = false;
            this.RoleDG.AllowUserToDeleteRows = false;
            this.RoleDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleDG.Location = new System.Drawing.Point(0, 0);
            this.RoleDG.Name = "RoleDG";
            this.RoleDG.ReadOnly = true;
            this.RoleDG.RowTemplate.Height = 23;
            this.RoleDG.Size = new System.Drawing.Size(174, 453);
            this.RoleDG.TabIndex = 0;
            this.RoleDG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleDG_CellClick);
            // 
            // MenuDG
            // 
            this.MenuDG.AllowUserToAddRows = false;
            this.MenuDG.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MenuDG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.MenuDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MenuDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuDG.Location = new System.Drawing.Point(0, 0);
            this.MenuDG.Name = "MenuDG";
            this.MenuDG.ReadOnly = true;
            this.MenuDG.RowTemplate.Height = 23;
            this.MenuDG.Size = new System.Drawing.Size(811, 453);
            this.MenuDG.TabIndex = 0;
            this.MenuDG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MenuDG_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnUser);
            this.groupBox1.Controls.Add(this.BtnFormButton);
            this.groupBox1.Controls.Add(this.btnupdate);
            this.groupBox1.Controls.Add(this.btnadd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnsave);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 453);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(989, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // BtnUser
            // 
            this.BtnUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUser.Location = new System.Drawing.Point(723, 18);
            this.BtnUser.Name = "BtnUser";
            this.BtnUser.Size = new System.Drawing.Size(64, 23);
            this.BtnUser.TabIndex = 12;
            this.BtnUser.Text = "用户";
            this.BtnUser.UseVisualStyleBackColor = true;
            this.BtnUser.Click += new System.EventHandler(this.BtnUser_Click);
            // 
            // BtnFormButton
            // 
            this.BtnFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFormButton.Location = new System.Drawing.Point(638, 18);
            this.BtnFormButton.Name = "BtnFormButton";
            this.BtnFormButton.Size = new System.Drawing.Size(80, 23);
            this.BtnFormButton.TabIndex = 11;
            this.BtnFormButton.Text = "表单权限";
            this.BtnFormButton.UseVisualStyleBackColor = true;
            this.BtnFormButton.Click += new System.EventHandler(this.BtnFormButton_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnupdate.Location = new System.Drawing.Point(857, 18);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(60, 23);
            this.btnupdate.TabIndex = 10;
            this.btnupdate.Text = "修改";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.Location = new System.Drawing.Point(792, 18);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(60, 23);
            this.btnadd.TabIndex = 9;
            this.btnadd.Text = "新增";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(616, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "注：权限：“√”的权限是可用，“×”权限不可用，为空的表示表单没有对应的权限";
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.Location = new System.Drawing.Point(922, 18);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(60, 23);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // Soft_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 506);
            this.Controls.Add(this.data);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Soft_Menu";
            this.Text = "Soft_Menu";
            this.Load += new System.EventHandler(this.Soft_Menu_Load);
            this.data.Panel1.ResumeLayout(false);
            this.data.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            this.data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuDG)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer data;
        private System.Windows.Forms.DataGridView RoleDG;
        private System.Windows.Forms.DataGridView MenuDG;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button BtnFormButton;
        private System.Windows.Forms.Button BtnUser;
    }
}