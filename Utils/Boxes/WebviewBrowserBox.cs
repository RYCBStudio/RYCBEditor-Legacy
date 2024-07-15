using System;

namespace IDE
{
    public partial class WebviewBrowserBox : Sunny.UI.UIForm
    {
        private string path;
        public WebviewBrowserBox(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private async void LicenseAndCopyrights_Load(object sender, EventArgs e)
        {
            TS_L_Copyright.Text = $"Copyright © {DateTime.Now.Year} RYCB Studio, All rights reserved.";
            await webView21.EnsureCoreWebView2Async();
            this.webView21.NavigateToString(System.IO.File.ReadAllText(this.path));
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
            this.webView21.NavigateToString(System.IO.File.ReadAllText(this.path));
        }
    }
}
