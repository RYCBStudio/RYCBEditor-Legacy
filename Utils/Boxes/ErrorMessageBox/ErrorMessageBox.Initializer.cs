using System.Collections.Generic;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
internal partial class ErrorMessageBox
{
    private IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSettings.language}\\errMsgBox.relang", System.Text.Encoding.UTF8);

    private void InitializeTranslation()
    {
        var controls = GetAllControls(this);
        foreach (var control in controls)
        {
            control.Text = _I18nFile.ReadString("I18n", control.Text, control.Text);
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
}
