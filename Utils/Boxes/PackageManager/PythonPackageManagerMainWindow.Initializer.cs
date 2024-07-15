using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE.Utils;

partial class PythonPackageManagerMain
{
    protected internal static IniFile _I18nFile = new(Program.STARTUP_PATH + $"\\Languages\\{GlobalSettings.language}\\ppmm.relang", Encoding.UTF8);

    private void InitializeLocalization()
    {
        this.Text = _I18nFile.Localize(this.Text);
        this.uiTextBox1.Watermark = _I18nFile.Localize(this.uiTextBox1.Watermark);
        this.label6.Text = _I18nFile.Localize(this.label6.Text);
        this.label1.Text = _I18nFile.Localize(this.label1.Text);
        this.label2.Text = _I18nFile.Localize(this.label2.Text);
        this.label7.Text = _I18nFile.Localize(this.label7.Text);
        this.label8.Text = _I18nFile.Localize(this.label8.Text);
        this.label3.Text = _I18nFile.Localize(this.label3.Text);
        this.label9.Text = _I18nFile.Localize(this.label9.Text);
        this.label10.Text = _I18nFile.Localize(this.label10.Text);
        this.label11.Text = _I18nFile.Localize(this.label11.Text);
        this.label5.Text = _I18nFile.Localize(this.label5.Text);
        foreach (var item in GetAllToolStripItems(uiContextMenuStrip1.Items))
        {
            item.Text = _I18nFile.Localize(item.Text);
        }
    }

    private List<ToolStripMenuItem> GetAllToolStripItems(ToolStripItemCollection items)
    {
        var toolStripItems = new List<ToolStripMenuItem>();
        foreach (ToolStripMenuItem item in items)
        {
            toolStripItems.Add(item);
            if (item is ToolStripDropDownItem dropDownItem)
            {
                toolStripItems.AddRange(GetAllToolStripItems(dropDownItem.DropDownItems));
            }
        }
        return toolStripItems;
    }
}
