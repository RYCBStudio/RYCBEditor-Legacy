using System;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE
{
    public partial class About : UIForm
    {
        IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSuppressions.language}\\main.relang", System.Text.Encoding.UTF8);
        public About()
        {
            InitializeComponent();
            this.Text = _I18nFile.ReadString("I18n", "text.help.window.title.about", "text.help.window.title.about");
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            label3.Text = "Version " + Main.FRIENDLY_VER;
            label4.Text = $"Copyright © RYCBStudio {DateTime.Now.Year}. All Rights Reserved.";
        }
    }
}
