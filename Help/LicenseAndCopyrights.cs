using System;

namespace IDE
{
    public partial class LicenseAndCopyrights : Sunny.UI.UIForm
    {
        private string Text;
        public LicenseAndCopyrights()
        {
            InitializeComponent();
            InitializeTranslation();
        }

        private async void LicenseAndCopyrights_Load(object sender, EventArgs e)
        {
            TS_L_Copyright.Text = $"Copyright © {DateTime.Now.Year} RYCB Studio, All rights reserved.";
            await webView21.EnsureCoreWebView2Async();
            Text = _I18nContentFile.ReadToEnd();
            this.webView21.NavigateToString(Text);
            _I18nContentFile.Close();
        }

        private void Back(object sender, EventArgs e)
        {
            this.webView21.GoBack();
        }

        private void Previous(object sender, EventArgs e)
        {
            this.webView21.GoForward();
        }

        private void Refresh(object sender, EventArgs e)
        {
            this.webView21.Reload();
        }

        private void Home(object sender, EventArgs e)
        {
            this.webView21.NavigateToString(Text);
        }
    }
}
