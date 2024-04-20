using System;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE
{
    public partial class Help : Form
    {
        IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSettings.language}\\main.relang", System.Text.Encoding.UTF8);

        public Help(Uri uri)
        {
            this.TopMost = true;
            InitializeComponent();
            this.Text = _I18nFile.ReadString("I18n", "text.help.window.title.help", "text.help.window.title.help");
            this.webBrowser1.Url = uri;
            this.Owner = new Main();
            this.Show();
            this.Focus();
            this.TopMost = false;
        }

        private void Help_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.webBrowser1.Dispose();
            this.Owner.Show();
        }

        private void Help_Resize(object sender, EventArgs e)
        {
            this.webBrowser1.Size = new System.Drawing.Size(this.Width-(765-747), this.Height-(481-434));
        }
    }
}
