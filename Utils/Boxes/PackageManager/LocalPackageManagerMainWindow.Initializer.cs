using System.Text;
using Sunny.UI;

namespace IDE.Utils;

partial class PackageManagerMain
{
    IniFile _I18nFile = new(Program.STARTUP_PATH + $"\\Languages\\{GlobalSettings.language}\\lpmm.relang", Encoding.UTF8);

    private void InitializeLocalization()
    {
        this.Text = _I18nFile.Localize(this.Text);
        this.uiTextBox1.Watermark = _I18nFile.Localize(this.uiTextBox1.Watermark);
    }
}
