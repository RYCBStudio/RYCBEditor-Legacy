using ICSharpCode.AvalonEdit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Xml;

namespace IDE
{
    delegate string GetKey(string TagName);

    public partial class XshdVisualEditor : Form
    {
        private enum FileSituation
        {
            Visual,
            Code
        }

        private FileSituation fileSituation = FileSituation.Visual;
        private int i = 0;
        internal string path;
        internal TreeNode main;
        private static XmlDocument doc = new();
        private readonly TextEditor editor;
        private LogUtil LOGGER = Main.LOGGER;

        public XshdVisualEditor(string path)
        {
            editor = new TextEditor()
            {
                FontFamily = new System.Windows.Media.FontFamily("Consolas"),
                Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x2B, 0x2D, 0x30)),
                Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xA9, 0xB7, 0xC6)),
                ShowLineNumbers = true,
            };

            doc.Load(path);
            InitializeComponent();
            CodeEditingPanel.Hide();
            this.path = path;
            FileTxtBox.Text = path;
            main = new(path.Split('\\')
                [path.Split('\\').Length - 1]
                .Split('.')[0]);
            Tv_File.Nodes.Add(main);
            FileSizeTxtBox.Text = Math.Round((double)(new FileInfo(path).Length / 1024), 2).ToString();
            Save.Enabled = false;
            Cancel.Enabled = false;
            main.Nodes.Add("颜色类型");
        }

        private void GetXshdKeys(string path, string TagName, int treeNodeIndex)
        {
            FileNameTxtBox.Text = path.Split('\\')[path.Split('\\').Length - 1];
            SyntaxHighlightingTypeNameTxtBox.Text = doc.DocumentElement.Attributes["name"].Value;
            FileExtensionTypeTxtBox.Text = doc.DocumentElement.Attributes["extensions"].Value;
            foreach (XmlNode item in doc.DocumentElement.ChildNodes)
            {
                if (item.Name == TagName)
                {
                    main.Nodes[treeNodeIndex].Nodes.Add(item.Attributes["name"].Value);
                }
            }
        }

        private List<XmlNode> GetXshdKeys(string path, string TagName, bool hasExAttribute)
        {
            List<XmlNode> list = new();
            FileNameTxtBox.Text = path.Split('\\')[path.Split('\\').Length - 1];
            SyntaxHighlightingTypeNameTxtBox.Text = doc.DocumentElement.Attributes["name"].Value;
            FileExtensionTypeTxtBox.Text = doc.DocumentElement.Attributes["extensions"].Value;
            foreach (XmlNode item in doc.DocumentElement.ChildNodes)
            {
                if (hasExAttribute)
                {
                    if (item.Name == TagName && item.Attributes.Count >= 1)
                    {
                        foreach (XmlNode i in item.ChildNodes)
                        {
                            list.Add(i);
                        }
                    }
                }
                else
                {
                    if (item.Name == TagName && item.Attributes.Count == 0)
                    {
                        foreach (XmlNode i in item.ChildNodes)
                        {
                            list.Add(i);
                        }
                    }
                }
            }
            return list;
        }

        private string GetXmlKey(string TagName)
        {
            foreach (XmlNode item in doc.DocumentElement.ChildNodes)
            {
                if (item.Name == TagName)
                {
                    if (item.Attributes == null)
                    {
                        goto End;
                    }
                    if (item.Attributes.Count == 0)
                    {
                        goto End;
                    }
                    return item.Attributes["name"].Value;
                }
                else continue;
            }
        End:
            return "null";
        }

        private string GetXmlKey(string TagName, List<XmlNode> childNodes, string attributeName)
        {
            foreach (XmlNode item in childNodes)
            {
                if (item.Name == TagName)
                {
                    if (item.Attributes == null)
                    {
                        goto End;
                    }
                    if (item.Attributes.Count == 0)
                    {
                        goto End;
                    }
                    return item.Attributes[attributeName].Value;
                }
                else continue;
            }
        End:
            return "null";
        }

        private void XshdVisualEditor_Load(object sender, EventArgs e)
        {
            elementHost1.Child = editor;
            GetXshdKeys(path, "Color", 0);
            main.Nodes.Add(GetXmlKey("RuleSet"))/*.Nodes.Add(get(""))*/;
            TreeNode mainRuleSet = new TreeNode("主设置");
            main.Nodes.Add(mainRuleSet);
            List<XmlNode> keys = GetXshdKeys(path, "RuleSet", false);
            foreach (XmlNode item in keys)
            {
                mainRuleSet.Nodes.Add(GetXmlKey(item.Name, keys, "color")); ;
            }
            //GetXshdKeys(path, "RuleSet", Tv_File.Nodes.Add(""));
        }

        private void EnableButtons(object sender, EventArgs e)
        {
            Save.Enabled = true;
            Cancel.Enabled = true;
        }

        private void GetInfo(object sender, TreeViewEventArgs e)
        {
            foreach (XmlNode item in doc.DocumentElement.ChildNodes)
            {
                if (item.Name == "Color")
                {
                    TxtBox_Edit_keyname.Text = e.Node.Text;
                    if (item.Attributes["name"].Value == e.Node.Text)
                    {
                        XmlAttribute tmpAttribute;
                        tmpAttribute = item.Attributes["foreground"];
                        if (tmpAttribute != null)
                        {
                            if (!tmpAttribute.Value.StartsWith("#ff"))
                                TxtBox_Edit_Foreground.Text = tmpAttribute.Value.Insert(1, "ff");
                            else
                                TxtBox_Edit_Foreground.Text = tmpAttribute.Value;
                            colorDialog1.Color = ColorTranslator.FromHtml(tmpAttribute.Value);
                        }
                        tmpAttribute = item.Attributes["background"];
                        if (tmpAttribute != null)
                        {
                            if (!tmpAttribute.Value.StartsWith("#ff"))
                                TxtBox_Edit_Background.Text = tmpAttribute.Value.Insert(1, "ff");
                            else
                                TxtBox_Edit_Foreground.Text = tmpAttribute.Value;
                        }
                        tmpAttribute = item.Attributes["fontWeight"];
                        if (tmpAttribute != null) { CBBox_Edit_FontProperties.Text = tmpAttribute.Value; }
                        else { CBBox_Edit_FontProperties.Text = ""; }
                    }
                }
            }
        }

        private void PickForegroundColors(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                var tmp = ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(colorDialog1.Color.A, colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B));
                TxtBox_Edit_Foreground.Text = tmp.Insert(1, (tmp.Contains("ff") ? "" : "ff"));
            }
        }

        private void PickBackgroundColors(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TxtBox_Edit_Background.Text = ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(colorDialog1.Color.A, colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B));
            }
        }

        private void Coding(object sender, EventArgs e)
        {
            i++;
            if (i % 2 != 0)
            {
                EditingModeSwitch.Text = "切换到代码编辑模式(Alt+&C)";
                fileSituation = FileSituation.Visual;
                CodeEditingPanel.Hide();
            }
            else
            {
                EditingModeSwitch.Text = "切换到可视化编辑模式(Alt+&V)";
                fileSituation = FileSituation.Code;
                CodeEditingPanel.Show();
                editor.Text = File.ReadAllText(path);
            }
        }

        private void Event_Save(object sender, EventArgs e)
        {
            try
            {
                if (fileSituation == FileSituation.Code)
                {
                    Cancel.Enabled = false;
                    File.WriteAllText(path, editor.Document.Text, Encoding.UTF8);
                }
                LOGGER.WriteLog("保存成功", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.IO);
            }
            catch (Exception ex)
            {
                LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            }
        }
    }
}
