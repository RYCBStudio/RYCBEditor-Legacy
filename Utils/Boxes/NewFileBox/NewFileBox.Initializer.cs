using System.Windows.Forms;
using Sunny.UI;

namespace IDE
{
    partial class NewFileBox
    {
        IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSettings.language}\\newfile.relang", System.Text.Encoding.UTF8);

        private void InitializeLocalizate()
        {
            uiLabel1.Text = _I18nFile.ReadString("I18n", uiLabel1.Text, uiLabel1.Text);
            uiLabel2.Text = _I18nFile.ReadString("I18n", uiLabel2.Text, uiLabel2.Text);
            uiButton1.Text = _I18nFile.ReadString("I18n", uiButton1.Text, uiButton1.Text);
            uiButton2.Text = _I18nFile.ReadString("I18n", uiButton2.Text, uiButton2.Text);
        }
    }
}

