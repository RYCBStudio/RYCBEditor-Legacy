using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
public partial class FrmThanks
{
    IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSettings.language}\\thanks.relang", System.Text.Encoding.UTF8);

    private void InitializeLocalization()
    {
        this.Text = _I18nFile.ReadString("I18n", "text.thanks.window.title", "text.thanks.window.title");
        this.uiTextBox1.Text = _I18nFile.ReadString("I18n", uiTextBox1.Text, uiTextBox1.Text);
        this.uiTextBox2.Text = _I18nFile.ReadString("I18n", uiTextBox2.Text, uiTextBox2.Text);
        this.uiTitlePanel1.Text = _I18nFile.ReadString("I18n", uiTitlePanel1.Text, uiTitlePanel1.Text);
        this.uiTitlePanel2.Text = _I18nFile.ReadString("I18n", uiTitlePanel2.Text, uiTitlePanel2.Text);
    }
}
