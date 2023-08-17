using Sunny.UI;
using System.Linq;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Windows.Media;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using System.Xml;
using System.Reflection;
using System.Xml.Linq;

namespace IDE
{
    public partial class CustomSettings : UIForm
    {
        private static string _path, _path_oringin, tip_1;
        private bool isInitialized = false;
        private static readonly IniFile settings = Program.reConf;
        private static TextEditor edit;

        public CustomSettings(string path)
        {
            InitializeComponent();
            _path = path + "\\Xshd";
            _path_oringin = path + "\\Xshd";
            //SettingsHandler.SetSettings(path, 0);
            var language = GlobalSettings.language_set.FirstOrDefault(q => q.Value == GlobalSettings.language).Key;
            CBoxLanguage.SelectedItem = language;
            CBoxLanguage.Text = language;
            isInitialized = true;
            errorProvider1.SetError(CBoxLanguage, "");
        }

        private void ChooseXshdFile(object sender, System.EventArgs e)
        {
            if (XshdFileFinder.ShowDialog() == DialogResult.OK)
            {
                CBoxXshdFile.Items.Add(XshdFileFinder.FileName);
                File.Copy(XshdFileFinder.FileName, _path + XshdFileFinder.FileName.SplitLast("\\"), true);
            }
        }

        private void PickDiretory(object sender, System.EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ChangeCachePath(sender, e);
            }
        }

        private void CustomSettings_Load(object sender, EventArgs e)
        {
            isInitialized = true;
            edit = new TextEditor()
            {
                Width = EHostForEditor.Width,
                Height = EHostForEditor.Height,
                FontFamily = new FontFamily(settings.ReadString("Editor", "Font", "Consolas")),
                Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x2B, 0x2D, 0x30)),
                Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xA9, 0xB7, 0xC6)),
                FontSize = settings.ReadInt("Editor", "Size", 12),
                ShowLineNumbers = CkBoxShowLN.Checked,
                HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Visible,
                VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Visible,
                Text =
                """
                abcdefghijklmnopqrstuvwxyz
                ABCDEFGHIJKLMNOPQRSTUVWXYZ
                0123456789
                ~!@$%^&*()_+{}|:<>?`-=[]\;,./
                "
                '
                #
                你好 中国

                keyword
                method()
                "string"
                __specialdef__
                #comment
                """,
            };
            EHostForEditor.Child = edit;
            System.Reflection.Assembly assembly = Assembly.GetExecutingAssembly();
            //设置语法规则
            string name = assembly.GetName().Name + ".Settings.xshd";
            using (Stream s = assembly.GetManifestResourceStream(name))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                edit.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
            using (Stream s = assembly.GetManifestResourceStream(name))
            {
                XmlDocument xDoc = new();
                xDoc.Load(s);
                XmlElement rootElem = xDoc.DocumentElement;

                foreach (XmlNode item in rootElem.ChildNodes)
                {
                    if (item.Name != "Color")
                    {
                        continue;
                    }
                    string attrName = item.Attributes["name"]?.Value;
                    string attrForeground = item.Attributes["foreground"]?.Value;
                    

                    if (attrName == "Keywords")
                    {
                        attrForeground.Replace("ff", "");
                        BtnColor_Keyword.BackColor = System.Drawing.ColorTranslator.FromHtml(attrForeground);
                    }
                    else if (attrName == "MethodCall")
                    {
                        attrForeground.Replace("ff", "");
                        BtnColor_Method.BackColor = System.Drawing.ColorTranslator.FromHtml(attrForeground);
                    }
                    else if (attrName == "Comment")
                    {
                        attrForeground.Replace("ff", "");
                        BtnColor_Com.BackColor = System.Drawing.ColorTranslator.FromHtml(attrForeground);
                    }
                    else if (attrName == "NumberLiteral")
                    {
                        attrForeground.Replace("ff", "");
                        BtnColor_Num.BackColor = System.Drawing.ColorTranslator.FromHtml(attrForeground);
                    }
                }
            }

        }

        private void FormUpdate(object sender, EventArgs e)
        {
            SetSunnyCobBoxItems(CBoxEditorFont, new InstalledFontCollection().Families);
            CBoxEditorFont.SelectedItem = settings.ReadString("Editor", "Font", "Consolas");
            NUDFontSize.Value = 12;
            CkBoxShowLN.Checked = settings.ReadBool("Editor", "ShowLineNum", true);
            edit.FontFamily = new FontFamily(CBoxEditorFont.SelectedText);
            edit.FontSize = NUDFontSize.Value;
        }

        private void Update(object sender, EventArgs e)
        {
            settings.Write("Editor", "Font", CBoxEditorFont.SelectedText);
            settings.Write("Editor", "Size", NUDFontSize.Value);
            edit.FontFamily = new FontFamily(CBoxEditorFont.SelectedText);
            edit.FontSize = NUDFontSize.Value;
            edit.ShowLineNumbers = CkBoxShowLN.Checked;

        }

        private void ChangeLanguage(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                string selectedLanguage = CBoxLanguage.Text;
                if (selectedLanguage != GlobalSettings.language)
                {
                    GlobalSettings.language = GlobalSettings.language_set[selectedLanguage];
                    Program.reConf.Write("General", "Language", GlobalSettings.language_set[selectedLanguage]);
                    errorProvider1.SetError(CBoxLanguage, tip_1);
                }
            }
        }

        private void Update(object sender, int value)
        {
            settings.Write("Editor", "Size", NUDFontSize.Value);
            settings.Write("Editor", "Font", CBoxEditorFont.SelectedText);
            edit.FontFamily = new FontFamily(CBoxEditorFont.SelectedText);
            edit.FontSize = NUDFontSize.Value;
        }

        private void UpdateSettings(object sender, EventArgs e)
        {
            settings.Write("Editor", "ShowLineNum", CkBoxShowLN.Checked.ToString().ToLower());
            edit.ShowLineNumbers = CkBoxShowLN.Checked;
        }

        private void ChooseColor(object sender, EventArgs e)
        {
            RYCBColorPicker picker = new()
            {
                Color = ((Button)sender).BackColor
            };
            picker.ShowDialog(this);
            ((Button)sender).BackColor = picker.Color;
        }

        private void ChangeCachePath(object sender, System.EventArgs e)
        {
            try
            {
                foreach (var item in Directory.EnumerateFiles(_path_oringin))
                {
                    File.Copy(item,
                        folderBrowserDialog1.SelectedPath + '\\' + item.Split('\\')[item.Split('\\').Length - 1],
                        true);
                }
            }
            catch (Exception ex)
            {
                Main.LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                return;
            }
            txtBoxXshdCache.Text = folderBrowserDialog1.SelectedPath;
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
        public static void SetSunnyCobBoxItems(UIComboBox CobBox, string ItemsValue)
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
        public static void SetSunnyCobBoxItems(UIComboBox CobBox, List<string> ItemsList)
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
        /// <param name="families">List</param>
        private void SetSunnyCobBoxItems(UIComboBox CobBox, System.Drawing.FontFamily[] families)
        {
            CobBox.Items.Clear();
            CobBox.Text = "";
            if (families.Length == 0) { return; }
            for (int i = 0; i <= families.Length - 1; i++)
            {
                CobBox.Items.Add(families[i].Name);
            }
        }

        #endregion 
    }
}
