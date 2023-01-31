using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace IDE
{
    public partial class LicenseAndCopyrights : Form
    {
        public LicenseAndCopyrights()
        {
            InitializeComponent();
        }

        private void startAvalonGithub(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/icsharpcode/AvalonEdit/blob/master/LICENSE");
        }

        private void startAvalonOfficalWebsite(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://avalonedit.net/");
        }

        private void LicenseAndCopyrights_Load(object sender, System.EventArgs e)
        {
            TS_L_Copyright.Text = $"Copyright © {DateTime.Now.Year} RYCB Studio, All rights reserved.";
        }
    }
}
