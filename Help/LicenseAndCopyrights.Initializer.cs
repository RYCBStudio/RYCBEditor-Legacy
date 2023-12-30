using System.IO;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
public partial class LicenseAndCopyrights
{
    StreamReader _I18nContentFile = new(Program.STARTUP_PATH + $"\\Languages\\{GlobalSettings.language}\\LAC.html", System.Text.Encoding.UTF8);

    private void InitializeTranslation()
    {
        var fontName = Program.reConf.ReadString("Display", "DisplayFont", "Microsoft YaHei UI");
        if (fontName.FontExists())
        {
            this.Font = new(fontName, this.Font.Size, this.Font.Style);
            this.TitleFont = new(fontName, this.TitleFont.Size, this.TitleFont.Style);
            this.toolStrip1.Font = new(fontName, this.toolStrip1.Font.Size, this.toolStrip1.Font.Style);
            this.statusStrip1.Font = new(fontName, this.statusStrip1.Font.Size, this.statusStrip1.Font.Style);
        }
        var theme = GlobalSettings.theme.Item1;
        var Fore = GlobalSettings.theme.Item2;
        var Back = GlobalSettings.theme.Item3;
        IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSettings.language}\\LAC.relang", System.Text.Encoding.UTF8);
        this.Text = _I18nFile.Localize("text.LAC.title");
        this.BackColor = Back;
        this.ForeColor = Fore;
    }

}
