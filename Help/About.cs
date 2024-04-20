using System;
using System.Diagnostics;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE
{
    public partial class About : UIForm
    {
        IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSettings.language}\\main.relang", System.Text.Encoding.UTF8);
        public About()
        {
            this.TitleFont = new(GlobalSettings.MainFontName, this.TitleFont.Size, this.TitleFont.Style);
            InitializeComponent();
            this.Text = _I18nFile.ReadString("I18n", "text.help.window.title.about", "text.help.window.title.about");
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Tag is not null)
                {
                    if (ctrl.Tag.ToString() == "NoModify") { continue; }
                }
                ctrl.Font = new(GlobalSettings.MainFontName, ctrl.Font.Size, ctrl.Font.Style);
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            label3.Text = "Version " + Main.FRIENDLY_VER;
            label4.Text = $"Copyright © RYCBStudio {DateTime.Now.Year}. All Rights Reserved.";
        }

        private void GoToGithub(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/RYCBStudio/RYCB-Editor");
        }
    }
}
