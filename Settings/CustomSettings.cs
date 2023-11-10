<<<<<<< Updated upstream
﻿using Sunny.UI;
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
using static IronPython.Modules._ast;
using static IronPython.Modules.PythonCsvModule;

namespace IDE
{
    public partial class CustomSettings : UIForm
    {
        private static string _path, _path_oringin, tip_1 = "重启应用程序后生效";
        private bool isInitialized = false;
        private static readonly IniFile settings = Program.reConf;
        private static TextEditor edit;
        private static readonly System.Drawing.Size SHOW_SIZE = new(879, 468);
        private List<string> xshd_files = new();

        public CustomSettings(string path)
        {
            InitializeComponent();
            //InitializeTranslationWrite();
            InitializeTranslation();
            _path = path + "\\Xshd";
            _path_oringin = path + "\\Xshd";
            //SettingsHandler.SetSettings(path, 0);
            var language = GlobalSettings.language_set.FirstOrDefault(q => q.Value == GlobalSettings.language).Key;
            CBoxLanguage.SelectedItem = language;
            CBoxLanguage.Text = language;
            List<string> items = new();
            foreach (string item in CBoxTheme.Items)
            {
                items.Add(_I18nFile.ReadString("I18n", item, item));
            }
            SetSunnyCobBoxItems(CBoxTheme, items);
            var theme = GlobalSettings.theme_set[GlobalSettings.language_set[language]].FirstOrDefault(q => q.Value == GlobalSettings.theme.Item1).Key;
            CBoxTheme.SelectedItem = theme;
            CBoxTheme.Text = theme;
            isInitialized = true;
            errorProvider1.SetError(CBoxLanguage, "");
        }

        private void PickDiretory(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ChangeCachePath(sender, e);
            }
        }

        private void CustomSettings_Load(object sender, EventArgs e)
        {
            this.Size = SHOW_SIZE;
            isInitialized = true;
            edit = new TextEditor()
            {
                Width = EHostForEditor.Width,
                Height = EHostForEditor.Height,
                FontFamily = new FontFamily(settings.ReadString("Editor", "Font", "Consolas")),
                Background = new SolidColorBrush(Color.FromRgb(0x1E, 0x1F, 0x22)),
                Foreground = new SolidColorBrush(Color.FromRgb(0xA9, 0xB7, 0xC6)),
                FontSize = settings.ReadInt("Editor", "Size", 12),
                ShowLineNumbers = CkBoxShowLN.Checked,
                HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
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
            var assembly = Assembly.GetExecutingAssembly();
            //设置语法规则
            var name = assembly.GetName().Name + ".Settings.xshd";
            using (var s = assembly.GetManifestResourceStream(name))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                edit.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
            using (var s = assembly.GetManifestResourceStream(name))
            {
                XmlDocument xDoc = new();
                xDoc.Load(s);
                var rootElem = xDoc.DocumentElement;

                foreach (XmlNode item in rootElem.ChildNodes)
                {
                    if (item.Name != "Color")
                    {
                        continue;
                    }
                    var attrName = item.Attributes["name"]?.Value;
                    var attrForeground = item.Attributes["foreground"]?.Value;
                    

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
            TBoxXshdCache.Text = settings.ReadString("Editor", "XshdFilePath", Application.StartupPath + "\\Config\\Highlightings\\");

        }

        private void FormUpdate(object sender, EventArgs e)
        {
            var font_list = new List<System.Drawing.FontFamily>();
            var xshd_list = new List<string>();
            foreach (var item in new InstalledFontCollection().Families)
            {
                if (!item.Name.ToLower().Contains("Bold"))
                {
                    font_list.Add(item);
                }
            }
            foreach (var item in Directory.EnumerateFiles(Program.STARTUP_PATH+"\\Config\\Highlighting\\"))
            {
                xshd_list.Add(Main.GetFileName(item));
                xshd_files.Add(item);
            }
            SetSunnyCobBoxItems(CBoxEditorXshd, xshd_list);
            SetSunnyCobBoxItems(CBoxEditorFont, font_list.ToArray());
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

        private void GetColors(string path)
        {
            if (path.Contains("PlainText"))
            {
                BtnColor_Com.Disabled();
                BtnColor_Com.BackColor = System.Drawing.Color.Transparent;
                BtnColor_Com.ForeColor = System.Drawing.Color.White;
                BtnColor_Keyword.Disabled();
                BtnColor_Keyword.BackColor = System.Drawing.Color.Transparent;
                BtnColor_Keyword.ForeColor = System.Drawing.Color.White;
                BtnColor_Method.Disabled();
                BtnColor_Method.BackColor = System.Drawing.Color.Transparent;
                BtnColor_Method.ForeColor = System.Drawing.Color.White;
                BtnColor_Normal.Disabled();
                BtnColor_Normal.BackColor = System.Drawing.Color.Transparent;
                BtnColor_Normal.ForeColor = System.Drawing.Color.White;
                BtnColor_Num.Disabled();
                BtnColor_Num.BackColor = System.Drawing.Color.Transparent;
                BtnColor_Num.ForeColor = System.Drawing.Color.White;
                return;
            }
            BtnColor_Com.Enable();
            BtnColor_Keyword.Enable();
            BtnColor_Method.Enable();
            BtnColor_Normal.Enable();
            BtnColor_Num.Enable();
            var stream = new XmlTextReader(path);
            using (var s = new XmlTextReader(path))
            {
                XmlDocument xDoc = new();
                xDoc.Load(s);
                var rootElem = xDoc.DocumentElement;
                var xshd = HighlightingLoader.LoadXshd(stream);
                edit.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                edit.UpdateLayout();
                foreach (XmlNode item in rootElem.ChildNodes)
                {
                    if (item.Name != "Color")
                    {
                        continue;
                    }
                    var attrName = item.Attributes["name"]?.Value;
                    var attrForeground = item.Attributes["foreground"]?.Value;


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

        private void ChangeLanguage(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                var selectedLanguage = CBoxLanguage.Text;
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

        private void ChangeTheme(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                var selectedTheme = CBoxTheme.Text;
                if (selectedTheme != GlobalSettings.theme.Item1)
                {
                    GlobalSettings.theme = Themes.GetTheme(GlobalSettings.theme_set[GlobalSettings.language][selectedTheme]);
                    Program.reConf.Write("General", "Theme", GlobalSettings.theme_set[GlobalSettings.language][selectedTheme]);
                    errorProvider1.SetError(CBoxTheme, tip_1);
                }
            }
        }

        private void Tip(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, tip_1);
        }

        private void ChangeCachePath(object sender, EventArgs e)
        {
            if (!(folderBrowserDialog1.ShowDialog() == DialogResult.OK))
            {
                return;
            }

            settings.Write("Editor", "XshdFilePath", folderBrowserDialog1.SelectedPath);
            TBoxXshdCache.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeXshdColor(object sender, EventArgs e)
        {
            var path = "";
            foreach (var item in xshd_files)
            {
                if (item.EndsWith(CBoxEditorXshd.Text))
                {
                    path = item;
                    break;
                }
            }
            GetColors(path);
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
            var s = ItemsValue.Split(new char[] { ';' });
            for (var i = 0; i <= s.Length - 1; i++)
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
            for (var i = 0; i <= ItemsList.Count - 1; i++)
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
            var s = ItemsValue.Split(new char[] { ';' });
            for (var i = 0; i <= s.Length - 1; i++)
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
            for (var i = 0; i <= ItemsList.Count - 1; i++)
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
            for (var i = 0; i <= families.Length - 1; i++)
            {
                CobBox.Items.Add(families[i].Name);
            }
        }

        #endregion 
    }
}
=======
﻿using Sunny.UI;
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
using static IronPython.Modules._ast;
using static IronPython.Modules.PythonCsvModule;

namespace IDE
{
    public partial class CustomSettings : UIForm
    {
        private static string _path, _path_oringin, tip_1 = "重启应用程序后生效";
        private bool isInitialized = false;
        private static readonly IniFile settings = Program.reConf;
        private static TextEditor edit;
        private static readonly System.Drawing.Size SHOW_SIZE = new(879, 468);
        private List<string> xshd_files = new();

        public CustomSettings(string path)
        {
            InitializeComponent();
            //InitializeTranslationWrite();
            InitializeTranslation();
            _path = path + "\\Xshd";
            _path_oringin = path + "\\Xshd";
            //SettingsHandler.SetSettings(path, 0);
            var language = GlobalSettings.language_set.FirstOrDefault(q => q.Value == GlobalSettings.language).Key;
            CBoxLanguage.SelectedItem = language;
            CBoxLanguage.Text = language;
            List<string> items = new();
            foreach (string item in CBoxTheme.Items)
            {
                items.Add(_I18nFile.ReadString("I18n", item, item));
            }
            SetSunnyCobBoxItems(CBoxTheme, items);
            var theme = GlobalSettings.theme_set[GlobalSettings.language_set[language]].FirstOrDefault(q => q.Value == GlobalSettings.theme.Item1).Key;
            CBoxTheme.SelectedItem = theme;
            CBoxTheme.Text = theme;
            isInitialized = true;
            errorProvider1.SetError(CBoxLanguage, "");
        }

        private void PickDiretory(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ChangeCachePath(sender, e);
            }
        }

        private void CustomSettings_Load(object sender, EventArgs e)
        {
            this.Size = SHOW_SIZE;
            isInitialized = true;
            edit = new TextEditor()
            {
                Width = EHostForEditor.Width,
                Height = EHostForEditor.Height,
                FontFamily = new FontFamily(settings.ReadString("Editor", "Font", "Consolas")),
                Background = new SolidColorBrush(Color.FromRgb(0x1E, 0x1F, 0x22)),
                Foreground = new SolidColorBrush(Color.FromRgb(0xA9, 0xB7, 0xC6)),
                FontSize = settings.ReadInt("Editor", "Size", 12),
                ShowLineNumbers = CkBoxShowLN.Checked,
                HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
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
            var assembly = Assembly.GetExecutingAssembly();
            //设置语法规则
            var name = assembly.GetName().Name + ".Settings.xshd";
            using (var s = assembly.GetManifestResourceStream(name))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                edit.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
            using (var s = assembly.GetManifestResourceStream(name))
            {
                XmlDocument xDoc = new();
                xDoc.Load(s);
                var rootElem = xDoc.DocumentElement;

                foreach (XmlNode item in rootElem.ChildNodes)
                {
                    if (item.Name != "Color")
                    {
                        continue;
                    }
                    var attrName = item.Attributes["name"]?.Value;
                    var attrForeground = item.Attributes["foreground"]?.Value;
                    

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
            TBoxXshdCache.Text = settings.ReadString("Editor", "XshdFilePath", Application.StartupPath + "\\Config\\Highlightings\\");

        }

        private void FormUpdate(object sender, EventArgs e)
        {
            var font_list = new List<System.Drawing.FontFamily>();
            var xshd_list = new List<string>();
            foreach (var item in new InstalledFontCollection().Families)
            {
                if (!item.Name.ToLower().Contains("Bold"))
                {
                    font_list.Add(item);
                }
            }
            foreach (var item in Directory.EnumerateFiles(Program.STARTUP_PATH+"\\Config\\Highlighting\\"))
            {
                xshd_list.Add(Main.GetFileName(item));
                xshd_files.Add(item);
            }
            SetSunnyCobBoxItems(CBoxEditorXshd, xshd_list);
            SetSunnyCobBoxItems(CBoxEditorFont, font_list.ToArray());
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

        private void GetColors(string path)
        {
            if (path.Contains("PlainText"))
            {
                BtnColor_Com.Disabled();
                BtnColor_Com.BackColor = System.Drawing.Color.Transparent;
                BtnColor_Com.ForeColor = System.Drawing.Color.White;
                BtnColor_Keyword.Disabled();
                BtnColor_Keyword.BackColor = System.Drawing.Color.Transparent;
                BtnColor_Keyword.ForeColor = System.Drawing.Color.White;
                BtnColor_Method.Disabled();
                BtnColor_Method.BackColor = System.Drawing.Color.Transparent;
                BtnColor_Method.ForeColor = System.Drawing.Color.White;
                BtnColor_Normal.Disabled();
                BtnColor_Normal.BackColor = System.Drawing.Color.Transparent;
                BtnColor_Normal.ForeColor = System.Drawing.Color.White;
                BtnColor_Num.Disabled();
                BtnColor_Num.BackColor = System.Drawing.Color.Transparent;
                BtnColor_Num.ForeColor = System.Drawing.Color.White;
                return;
            }
            BtnColor_Com.Enable();
            BtnColor_Keyword.Enable();
            BtnColor_Method.Enable();
            BtnColor_Normal.Enable();
            BtnColor_Num.Enable();
            var stream = new XmlTextReader(path);
            using (var s = new XmlTextReader(path))
            {
                XmlDocument xDoc = new();
                xDoc.Load(s);
                var rootElem = xDoc.DocumentElement;
                var xshd = HighlightingLoader.LoadXshd(stream);
                edit.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                edit.UpdateLayout();
                foreach (XmlNode item in rootElem.ChildNodes)
                {
                    if (item.Name != "Color")
                    {
                        continue;
                    }
                    var attrName = item.Attributes["name"]?.Value;
                    var attrForeground = item.Attributes["foreground"]?.Value;


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

        private void ChangeLanguage(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                var selectedLanguage = CBoxLanguage.Text;
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

        private void ChangeTheme(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                var selectedTheme = CBoxTheme.Text;
                if (selectedTheme != GlobalSettings.theme.Item1)
                {
                    GlobalSettings.theme = Themes.GetTheme(GlobalSettings.theme_set[GlobalSettings.language][selectedTheme]);
                    Program.reConf.Write("General", "Theme", GlobalSettings.theme_set[GlobalSettings.language][selectedTheme]);
                    errorProvider1.SetError(CBoxTheme, tip_1);
                }
            }
        }

        private void Tip(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, tip_1);
        }

        private void ChangeCachePath(object sender, EventArgs e)
        {
            if (!(folderBrowserDialog1.ShowDialog() == DialogResult.OK))
            {
                return;
            }

            settings.Write("Editor", "XshdFilePath", folderBrowserDialog1.SelectedPath);
            TBoxXshdCache.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeXshdColor(object sender, EventArgs e)
        {
            var path = "";
            foreach (var item in xshd_files)
            {
                if (item.EndsWith(CBoxEditorXshd.Text))
                {
                    path = item;
                    break;
                }
            }
            GetColors(path);
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
            var s = ItemsValue.Split(new char[] { ';' });
            for (var i = 0; i <= s.Length - 1; i++)
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
            for (var i = 0; i <= ItemsList.Count - 1; i++)
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
            var s = ItemsValue.Split(new char[] { ';' });
            for (var i = 0; i <= s.Length - 1; i++)
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
            for (var i = 0; i <= ItemsList.Count - 1; i++)
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
            for (var i = 0; i <= families.Length - 1; i++)
            {
                CobBox.Items.Add(families[i].Name);
            }
        }

        #endregion 
    }
}
>>>>>>> Stashed changes
