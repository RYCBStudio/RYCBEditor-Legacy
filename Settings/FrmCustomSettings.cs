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

namespace IDE
{
    public partial class FrmCustomSettings : UIForm
    {
        private static string _path, _path_oringin, tip_1 = "tip.restart";
        private bool isInitialized = false;
        private static readonly IniFile settings = Program.reConf;
        private static TextEditor edit;
        private static readonly System.Drawing.Size SHOW_SIZE = new(1343, 787);
        private List<string> xshd_files = [];

        public FrmCustomSettings(string path)
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
            List<string> items = [];
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
        }private void CustomSettings_Load(object sender, EventArgs e)
        {
            this.Size = SHOW_SIZE;
            SwtchParallelDownload.Active = settings.ReadBool("Downloading", "ParallelDownload");
            SwtchAutoParallelDownloadCount.Active = settings.ReadBool("Downloading", "AutoParallelCount");
            TBPC.Value = settings.ReadInt("Downloading", "ParallelCount");
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
            tip_1 = _I18nFile.Localize(tip_1);
        }

        private void EdtPylintrcFile(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CustomSettingsFileEditor(Program.STARTUP_PATH+"\\Tools\\.pylintrc").Show();
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
            foreach (var item in Directory.EnumerateFiles(Program.STARTUP_PATH + "\\Config\\Highlighting\\"))
            {
                xshd_list.Add(FrmMain.GetFileName(item));
                xshd_files.Add(item);
            }
            SetSunnyCobBoxItems(CBoxEditorXshd, xshd_list);
            SetSunnyCobBoxItems(CBoxEditorFont, font_list.ToArray());
            SetSunnyCobBoxItems(CBoxFont, font_list.ToArray());
            CBoxEditorFont.SelectedItem = settings.ReadString("Editor", "Font", "Consolas");
            CBoxFont.SelectedItem = settings.ReadString("General", "Font", "Microsoft YaHei UI");
            NUDFontSize.Value = 12;
            CkBoxShowLN.Checked = settings.ReadBool("Editor", "ShowLineNum", true);
            edit.FontFamily = new FontFamily(CBoxEditorFont.SelectedText);
            edit.FontSize = NUDFontSize.Value; isInitialized = true;
            InitializeFileFormat();
        }

        

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

