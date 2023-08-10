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
            }

            foreach (ToolStripItem item in toolStripItems)
            {
                item.Text = _I18nFile.ReadString("I18n", item.Text, item.Text);
            }

            this.openFileDialog1.Title = _I18nFile.ReadString("I18n", "this.openFileDialog1.Title", "this.openFileDialog1.Title");
            this.文件ToolStripMenuItem.Text = _I18nFile.ReadString("I18n", this.文件ToolStripMenuItem.Text, this.文件ToolStripMenuItem.Text);
            this.项目ToolStripMenuItem.Text = _I18nFile.ReadString("I18n", this.项目ToolStripMenuItem.Text, this.项目ToolStripMenuItem.Text);
            this.tabPage1.Text = _I18nFile.ReadString("I18n", tabPage1.Text, tabPage1.Text);

            string[] keys = _I18nFile.GetKeys("List_lang");
            List<string> items = new List<string>();
            foreach (var item in keys)
            {
                items.Add(_I18nFile.ReadString("List_lang", item, item));
            }
            SetCobBoxItems(this.toolStripComboBox1, items);
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

        #region ComboBox Items设定
        /// <summary>
        /// ComboBox Items设定
        /// </summary>
        /// <param name="CobBox">ComboBox 名称</param>
        /// <param name="ItemsValue">要添加的Items(各项目之间用;隔开)</param>
        public static void SetCobBoxItems(ComboBox CobBox, string ItemsValue)
        {
            CobBox.Items.Clear();
            CobBox.Text = "";
            if (ItemsValue == null) { return; }
            string[] s = ItemsValue.Split(new char[] { ';' });
            for (int i = 0; i <= s.Length - 1; i++)
            {
                CobBox.Items.Add(s[i].ToString());
            }
        }

        /// <summary>
        /// ComboBox Items设定
        /// </summary>
        /// <param name="CobBox">ComboBox 名称</param>
        /// <param name="ItemsList">List</param>
        public static void SetCobBoxItems(ComboBox CobBox, List<string> ItemsList)
        {
            CobBox.Items.Clear();
            CobBox.Text = "";
            if (ItemsList.Count == 0) { return; }
            for (int i = 0; i <= ItemsList.Count - 1; i++)
            {
                CobBox.Items.Add(ItemsList[i].ToString());
            }
        }

        /// <summary>
        /// ComboBox Items设定
        /// </summary>
        /// <param name="CobBox">ComboBox 名称</param>
        /// <param name="ItemsValue">要添加的Items(各项目之间用;隔开)</param>
        public static void SetCobBoxItems(ToolStripComboBox CobBox, string ItemsValue)
        {
            CobBox.Items.Clear();
            CobBox.Text = "";
            if (ItemsValue == null) { return; }
            string[] s = ItemsValue.Split(new char[] { ';' });
            for (int i = 0; i <= s.Length - 1; i++)
            {
                CobBox.Items.Add(s[i].ToString());
            }
        }

        /// <summary>
        /// ComboBox Items设定
        /// </summary>
        /// <param name="CobBox">ComboBox 名称</param>
        /// <param name="ItemsList">List</param>
        public static void SetCobBoxItems(ToolStripComboBox CobBox, List<string> ItemsList)
        {
            CobBox.Items.Clear();
            CobBox.Text = "";
            if (ItemsList.Count == 0) { return; }
            for (int i = 0; i <= ItemsList.Count - 1; i++)
            {
                CobBox.Items.Add(ItemsList[i].ToString());
            }
        }
        #endregion 
    }
}