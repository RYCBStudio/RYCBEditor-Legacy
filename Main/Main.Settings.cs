using System.Windows.Forms;
using Sunny.UI;

namespace IDE
{
    partial class Main
    {
        private void InitializeTranslation()
        {
            IniFile _I18nFile = new(Application.StartupPath + ".\\zh-CN.relang", System.Text.Encoding.UTF8);
            foreach (Control item in this.Controls)
            {
                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.statusStrip1.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.statusStrip2.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.toolStrip1.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.menuStrip1.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.contextMenuStrip1.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.contextMenuStrip2.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.menuStrip1.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.文件FToolStripMenuItem.DropDownItems)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.编辑EToolStripMenuItem.DropDownItems)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.运行RToolStripMenuItem.DropDownItems)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.工具TToolStripMenuItem.DropDownItems)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.帮助HToolStripMenuItem.DropDownItems)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            this.openFileDialog1.Title = _I18nFile.ReadString("I18n", "this.openFileDialog1.Title", "this.openFileDialog1.Title").Split('\t', ' ')[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="langType">语言类型</param>
        private void InitializeTranslation(string langType)
        {
            IniFile _I18nFile = new(Application.StartupPath + $".\\{langType}.relang", System.Text.Encoding.UTF8);
            foreach (Control item in this.Controls)
            {
                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.statusStrip1.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.statusStrip2.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.toolStrip1.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.menuStrip1.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.contextMenuStrip1.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.contextMenuStrip2.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.menuStrip1.Items)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.文件FToolStripMenuItem.DropDownItems)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.编辑EToolStripMenuItem.DropDownItems)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.运行RToolStripMenuItem.DropDownItems)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.工具TToolStripMenuItem.DropDownItems)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            foreach (ToolStripItem item in this.帮助HToolStripMenuItem.DropDownItems)
            {

                item.Text = _I18nFile.ReadString("I18n", item.Name, item.Name).Split('\t', ' ')[0];
            }
            this.openFileDialog1.Title = _I18nFile.ReadString("I18n", "this.openFileDialog1.Title", "this.openFileDialog1.Title").Split('\t', ' ')[0];
        }
        private enum LangType
        {
            zh_CN,
            en_US,
        }
        private string GetLangType(LangType langType)
        {
            string[] langs = { "zh-CN", "en-US" };
            return langs[(int)langType];
        }
    }
}