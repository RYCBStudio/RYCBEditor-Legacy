using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
public partial class FrmCustomSettings
{
    private void ChangeLanguage(object sender, EventArgs e)
    {
        if (isInitialized)
        {
            var selectedLanguage = CBoxLanguage.Text;
            if (selectedLanguage != GlobalSettings.language & !selectedLanguage.IsNullOrEmpty())
            {
                GlobalSettings.language = GlobalSettings.language_set[selectedLanguage];
                Program.reConf.Write("General", "Language", GlobalSettings.language_set[selectedLanguage]);
                errorProvider1.SetError(CBoxLanguage, tip_1);
            }
        }
    }

    private void ChangeTheme(object sender, EventArgs e)
    {
        if (isInitialized)
        {
            var selectedTheme = CBoxTheme.Text;
            if (selectedTheme != GlobalSettings.theme.Item1)
            {
                GlobalSettings.theme = Themes.GetTheme(GlobalSettings.theme_set[GlobalSettings.language][selectedTheme]);
                Program.reConf.Write("General", "Theme", GlobalSettings.theme_set[GlobalSettings.language][selectedTheme]);
                errorProvider1.SetError(CBoxTheme, tip_1);
            }
        }
    }

    private void Tip(object sender, EventArgs e)
    {
        errorProvider1.SetError((Control)sender, tip_1);
    }

    private void ChangeCachePath(object sender, EventArgs e)
    {
        if (!(folderBrowserDialog1.ShowDialog() == DialogResult.OK))
        {
            return;
        }

        settings.Write("Editor", "XshdFilePath", folderBrowserDialog1.SelectedPath);
        TBoxXshdCache.Text = folderBrowserDialog1.SelectedPath;
    }

    private void uiTrackBar1_ValueChanged(object sender, EventArgs e)
    {
        NUDDPC.Value = TBPC.Value;
    }

    private void UpdateDownloadSettings(object sender, EventArgs e)
    {
        settings.Write("Downloading", "ParallelDownload", SwtchParallelDownload.Active);
        settings.Write("Downloading", "AutoParallelCount", SwtchAutoParallelDownloadCount.Active);
        settings.Write("Downloading", "ParallelCount", NUDDPC.Value);
    }

    private void NUDDPC_ValueChanged(object sender, int value)
    {
        TBPC.Value = NUDDPC.Value;
    }

}
