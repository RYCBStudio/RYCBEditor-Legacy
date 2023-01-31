using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            label3.Text = "Version " + Main.VERSION;
            label4.Text = $"Copyright © RYCBStudio {DateTime.Now.Year}. All Rights Reserved.";
        }
    }
}
