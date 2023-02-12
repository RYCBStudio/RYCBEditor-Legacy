using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace IDE
{
    public partial class LicenseAndCopyrights : MetroFramework.Forms.MetroForm
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

        private void LicenseAndCopyrights_Load(object sender, EventArgs e)
        {
            TS_L_Copyright.Text = $"Copyright © {DateTime.Now.Year} RYCB Studio, All rights reserved.";
        }

        private void StartMetroUIOnGithub(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/dennismagno/metroframework-modern-ui");
        }

        private void StartMetroLicense(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/dennismagno/metroframework-modern-ui/blob/master/LICENSE.md");
        }

        private void StartSunnyOffical(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://gitee.com/yhuse/SunnyUI");
        }

        private void StartSunnyLicense(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://gitee.com/yhuse/SunnyUI/blob/master/LICENSE");
        }

        private void StartMsgPackOnGithub(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/neuecc/MessagePack-CSharp");
        }

        private void StartMsgPackLicense(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/neuecc/MessagePack-CSharp/blob/master/LICENSE");
        }
    }
}
