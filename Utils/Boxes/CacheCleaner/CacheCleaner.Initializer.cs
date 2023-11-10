using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
public partial class CacheCleaner
{
    private IniFile _I18nFile = new(Program.STARTUP_PATH + $"\\Languages\\{GlobalSettings.language}\\cc.relang", System.Text.Encoding.UTF8);

    private void InitializeTranslation()
    {
        var fontName = Program.reConf.ReadString("Display", "DisplayFont", "Microsoft YaHei UI");
        var Fore = GlobalSettings.theme.Item2;
        var Back = GlobalSettings.theme.Item3;
        var controls = GetAllControls(this);
        this.BackColor = Back;
        this.ForeColor = Fore;
        if (fontName.FontExists())
        {
            this.Font = new(fontName, this.Font.Size, this.Font.Style);
            this.TitleFont = new(fontName, this.Font.Size, this.Font.Style);
        }

        foreach (var control in controls)
        {
            control.Text = _I18nFile.ReadString("I18n", control.Text, control.Text);

            if (fontName.FontExists())
            {
                control.Font = new(fontName, control.Font.Size, control.Font.Style);
            }
            control.BackColor = Back;
            control.ForeColor = Fore; 
            if (control is UIButton button) { button.FillColor = Back; button.ForeColor = Fore; }
            if (control is UILine line) { line.FillColor = Back; line.ForeColor = Fore; }
            if (control is UIUserControl _control) { _control.FillColor = Back; _control.ForeColor = Fore; }

        }
    }

    private List<Control> GetAllControls(Control control)
    {
        var controls = new List<Control>();
        foreach (Control c in control.Controls)
        {
            controls.Add(c);
            controls.AddRange(GetAllControls(c));
        }
        return controls;
    }

    private void InitializeTranslationWrite()
    {
#if DEBUG
        try
        {
            _I18nFile.Write("I18n", this.Text, "");
            foreach (Control ctrls in this.Controls)
            {
                if (_I18nFile.KeyExists("I18n", ctrls.Text))
                {
                    continue;
                }

                _I18nFile.Write("I18n", ctrls.Text, "");

            }
        }
        catch { }
#else
return;
#endif
    }
}
