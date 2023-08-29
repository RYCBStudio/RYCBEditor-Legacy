using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Media;
using Sunny.UI;

namespace IDE
{
    partial class Main
    {
        private struct Editor
        {
            public static Color Fore;
            public static Color Back;
        }

        private IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSettings.language}\\main.relang", System.Text.Encoding.UTF8);

        private void InitializeTranslation()
        {
            var fontName = reConf.ReadString("Display", "DisplayFont", "Microsoft YaHei UI");
            var theme = GlobalSettings.theme.Item1;
            var _theme = theme;
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
            if (fontName.FontExists())
            {
                this.Font = new(fontName, this.Font.Size, this.Font.Style);
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
            }

            foreach (var item in toolStripItems)
            {
                item.Text = _I18nFile.ReadString("I18n", item.Text, item.Text);
                if (fontName.FontExists())
                {
                    item.Font = new(fontName, item.Font.Size, item.Font.Style);
                }
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
            if (_theme != "Dark" && _theme != "Light")
            {
                _theme = "Dark";
            }
            Editor.Fore = GlobalSettings.editor_color_set[_theme][0];
            Editor.Back = GlobalSettings.editor_color_set[_theme][1];
            this.tabPage1.ForeColor = Fore;
            this.tabPage1.BackColor = Back;
            this.崩溃测试ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;

            title = _I18nFile.ReadString("I18n", "text.main.selectfile.title", "text.main.selectfile.title");
            filter = _I18nFile.ReadString("I18n", "text.main.selectfile.filter", "text.main.selectfile.filter");
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

        private List<ToolStripItem> GetAllToolStripItems(ToolStripItemCollection items)
        {
            var toolStripItems = new List<ToolStripItem>();
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