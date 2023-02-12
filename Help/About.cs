using System;
using System.Windows.Forms;

namespace IDE
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            label3.Text = "Version " + Main.FRIENDLY_VER;
            label4.Text = $"Copyright © RYCBStudio {DateTime.Now.Year}. All Rights Reserved.";
        }
    }
}
