namespace IDE
{
    partial class LicenseAndCopyrights
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseAndCopyrights));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TS_L_Copyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.uiStyleManager1 = new Sunny.UI.UIStyleManager(this.components);
            this.htmlLabel1 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_L_Copyright});
            this.statusStrip1.Location = new System.Drawing.Point(0, 348);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(875, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TS_L_Copyright
            // 
            this.TS_L_Copyright.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.TS_L_Copyright.Name = "TS_L_Copyright";
            this.TS_L_Copyright.Size = new System.Drawing.Size(379, 20);
            this.TS_L_Copyright.Text = "Copyright © 2023 RYCB Studio, All rights reserved.";
            // 
            // htmlLabel1
            // 
            this.htmlLabel1.AutoScroll = true;
            this.htmlLabel1.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.htmlLabel1.AutoSize = false;
            this.htmlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.htmlLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.htmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.htmlLabel1.Location = new System.Drawing.Point(0, 35);
            this.htmlLabel1.Name = "htmlLabel1";
            this.htmlLabel1.Size = new System.Drawing.Size(875, 313);
            this.htmlLabel1.TabIndex = 2;
            // 
            // LicenseAndCopyrights
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(875, 374);
            this.Controls.Add(this.htmlLabel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseAndCopyrights";
            this.StyleCustomMode = true;
            this.Text = "text.LAC.title";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 875, 374);
            this.Load += new System.EventHandler(this.LicenseAndCopyrights_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TS_L_Copyright;
        private Sunny.UI.UIStyleManager uiStyleManager1;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel1;
    }
}