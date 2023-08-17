using System.Collections.Generic;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE
{
    partial class Main
    {
        private IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSettings.language}\\main.relang", System.Text.Encoding.UTF8);

        private void InitializeTranslation()
        {
            var theme = GlobalSettings.theme.Item1;
            var Fore = GlobalSettings.theme.Item2;
            var Back = GlobalSettings.theme.Item3;
            var controls = GetAllControls(this);
            var toolStripItems = GetAllToolStripItems(this.statusStrip1.Items);
            toolStripItems.AddRange(GetAllToolStripItems(this.statusStrip2.Items));
            toolStripItems.AddRange(GetAllToolStripItems(this.menuStrip1.Items));
            toolStripItems.AddRange(GetAllToolStripItems(this.contextMenuStrip1.Items));
            toolStripItems.AddRange(GetAllToolStripItems(this.menuStrip1.Items));
            toolStripItems.AddRange(GetAllToolStripItems(this.文件FToolStripMenuItem.DropDownItems));
            toolStripItems.AddRange(GetAllToolStripItems(this.编辑EToolStripMenuItem.DropDownItems));
            toolStripItems.AddRange(GetAllToolStripItems(this.运行RToolStripMenuItem.DropDownItems));
            toolStripItems.AddRange(GetAllToolStripItems(this.工具TToolStripMenuItem.DropDownItems));
            toolStripItems.AddRange(GetAllToolStripItems(this.帮助HToolStripMenuItem.DropDownItems));
            toolStripItems.AddRange(GetAllToolStripItems(this.开发者选项DToolStripMenuItem.DropDownItems));

            foreach (Control control in controls)
            {
                control.Text = _I18nFile.ReadString("I18n", control.Text, control.Text);
                control.BackColor = Back;
                control.ForeColor = Fore;
            }

            foreach (ToolStripItem item in toolStripItems)
            {
                item.Text = _I18nFile.ReadString("I18n", item.Text, item.Text);
                item.BackColor = Back;
                item.ForeColor = Fore;
            }
            this.tabControl1.FillColor = Fore;
            this.tabControl1.TabBackColor = Back;
            if (theme == "Light")
            {
                this.tabControl1.MenuStyle = UIMenuStyle.White;
                this.tabControl1.StyleCustomMode = false;
            }
            this.tabPage1.ForeColor = Fore;
            this.tabPage1.BackColor = Back;
            this.openFileDialog1.Title = _I18nFile.ReadString("I18n", "this.openFileDialog1.Title", "this.openFileDialog1.Title");
            this.文件ToolStripMenuItem.Text = _I18nFile.ReadString("I18n", this.文件ToolStripMenuItem.Text, this.文件ToolStripMenuItem.Text);
            this.文件ToolStripMenuItem.ForeColor = Fore;
            this.文件ToolStripMenuItem.BackColor = Back;
            this.项目ToolStripMenuItem.BackColor = Back;
            this.项目ToolStripMenuItem.ForeColor = Fore;
            this.项目ToolStripMenuItem.Text = _I18nFile.ReadString("I18n", this.项目ToolStripMenuItem.Text, this.项目ToolStripMenuItem.Text);
            this.崩溃测试ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;

            title = _I18nFile.ReadString("I18n", "text.main.selectfile.title", "text.main.selectfile.title");
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

        private List<ToolStripItem> GetAllToolStripItems(ToolStripItemCollection items)
        {
            List<ToolStripItem> toolStripItems = new List<ToolStripItem>();
            foreach (ToolStripItem item in items)
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
}