namespace Merrto
{
    partial class BarCodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
       
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarCodeForm));
            this.OFDReports = new System.Windows.Forms.OpenFileDialog();
            this.SFDReports = new System.Windows.Forms.SaveFileDialog();
            this.AGRDReports = new AxgrdesLib.AxGRDesigner();
            ((System.ComponentModel.ISupportInitialize)(this.AGRDReports)).BeginInit();
            this.SuspendLayout();
            // 
            // OFDReports
            // 
            this.OFDReports.FileName = "OFDReports";
            // 
            // AGRDReports
            // 
            this.AGRDReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AGRDReports.Enabled = true;
            this.AGRDReports.Location = new System.Drawing.Point(0, 0);
            this.AGRDReports.Name = "AGRDReports";
            this.AGRDReports.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AGRDReports.OcxState")));
            this.AGRDReports.Size = new System.Drawing.Size(577, 494);
            this.AGRDReports.TabIndex = 0;
            // 
            // BarCodeForm
            // 
            this.ClientSize = new System.Drawing.Size(577, 494);
            this.Controls.Add(this.AGRDReports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BarCodeForm";
            ((System.ComponentModel.ISupportInitialize)(this.AGRDReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxgrdesLib.AxGRDesigner AGRDReports;
        private System.Windows.Forms.OpenFileDialog OFDReports;
        private System.Windows.Forms.SaveFileDialog SFDReports;

        //private AxgrdesLib.AxGRDesigner AGRDReports;
        //private System.Windows.Forms.OpenFileDialog OFDReports;
        //private System.Windows.Forms.SaveFileDialog SFDReports;


    }
}