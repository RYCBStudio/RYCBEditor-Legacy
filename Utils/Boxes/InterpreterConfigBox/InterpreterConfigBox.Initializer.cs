using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
partial class FrmInterpreterConfigBox
{
    private readonly IniFile _I18nFile = new(Program.STARTUP_PATH + $"\\Languages\\{GlobalSettings.language}\\icb.relang");

    private void InitializeLocalization()
    {
        this.Text = _I18nFile.Localize(this.Text);
        foreach (Control item in tableLayoutPanel1.Controls)
        {
            item.Text = _I18nFile.Localize(item.Text);
        }
        foreach (Control item in tableLayoutPanel2.Controls)
        {
            item.Text = _I18nFile.Localize(item.Text);
        }
    }
}
