using System;
using System.Windows.Forms;

namespace IDE
{
    public partial class Help : Form
    {
        public Help(Uri uri)
        {
            this.TopMost = true;
            InitializeComponent();
            this.webBrowser1.Url = uri;
            this.Owner = new Main();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Show();
            this.Focus();
            this.TopMost = false;
        }

        private void Help_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.webBrowser1.Dispose();
            this.Owner.Show();
        }
    }
}
