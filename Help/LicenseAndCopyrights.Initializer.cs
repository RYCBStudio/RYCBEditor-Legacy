using System.Collections.Generic;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
public partial class LicenseAndCopyrights
{
    private void InitializeTranslation()
    {
        var theme = GlobalSettings.theme.Item1;
        var Fore = GlobalSettings.theme.Item2;
        var Back = GlobalSettings.theme.Item3;
        IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSettings.language}\\LAC.relang", System.Text.Encoding.UTF8);
        this.Text = _I18nFile.ReadString("I18n", this.Text, this.Text);
        this.BackColor = Back;
        this.ForeColor = Fore;
        var controls = GetAllControls(this);
        foreach (Control control in controls)
        {
            control.Text = _I18nFile.ReadString("I18n", control.Text, control.Text);
            control.BackColor = Back;
            control.ForeColor = Fore;
        }
    }

    private List<Control> GetAllControls(Control control)
    {
        List<Control> controls = new List<Control>();
        foreach (Control c in control.Controls)
        {
            controls.Add(c);
            controls.AddRange(GetAllControls(c));
        }
        return controls;
    }

}
