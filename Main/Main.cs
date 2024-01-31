#region 导入命名空间
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Search;
using Microsoft.Scripting.Utils;
using Sunny.UI;
using TextEditor = ICSharpCode.AvalonEdit.TextEditor;
using Engines = IDE.ErrorMessageBox.Engines;
using Markdig;
using Microsoft.Web.WebView2.WinForms;
using System.Threading.Tasks;
using IDE.Init;
using IDE.Utils.Update;
#endregion

namespace IDE
{

    public partial class Main : Form
    {

        #region 一堆变量和常量
        private static readonly string STARTUP_PATH = Program.STARTUP_PATH;
        private static readonly IniFile reConf = Program.reConf;
        private static readonly Stopwatch stopwatch = new();
        private string query = "SELECT * FROM Win32_Process WHERE Name='Runner'";
        private string title = "选择文件：", filter = "Py-CN文件|*.pycn|Py-CN编译后文件(Python 文件)|*.py|所有文件|*.*";
        private static StreamWriter keepFile, markdownFileConverter;
        private string LightEdit_File;
        private bool NoTip, isModified = false, LightEdit = false;
        private TextEditor edit;
        private int tmp_, _i;
        private static string CachePath = Application.StartupPath + "\\Cache\\";
        private static Process proc, RunnerProc;
        //private static StreamWriter CacheWriter;
        //private struct elementHost1
        //{
        //    private elementHost1()
        //    {
        //    }

        //    Size Size = new Size(852, 293);
        //}
        private static ErrorMessageBox errMsgBox;
        internal MsgBox msgBox;
        internal static string XshdFilePath;
        internal static readonly Dictionary<Engines, string> SearchEngines = new()
        {
            { Engines.SIMPLIFIED_CHINESE, "https://cn.bing.com/search?q=Python+{text}+{desc}"},
            { Engines.TRADITIONAL_CHINESE_CHINA, "https://www.bing.com/search?q=Python+{text}+{desc}"},
            { Engines.TRADITIONAL_CHINESE_GLOBAL, "https://www.google.com/search?q=Python+{text}+{desc}"},
            { Engines.JAPANESE, "https://www.google.com/search?q=Python+{text}+{desc}"},
        };
        public const string VERSION = "0.0.3";
        public const string FRIENDLY_VER = "0.0.3-Alpha.64";
        public const int MAJOR_VER = 0;
        public const int MINOR_VER = 0;
        public const int MICRO_VER = 2;
        public const string REVISION = "alpha";
        public static readonly LogUtil LOGGER = new(Environment.CurrentDirectory + $"\\logs\\{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}.log");
        public string text_tsl2;
        public static Main instance;
        #endregion
        #region 一堆方法
        #region 构造函数
        /// <summary>
        /// Common
        /// </summary>
        public Main()
        {
            try
            {
                InitializeComponent();
                InitializeTranslation();
                CheckForIllegalCrossThreadCalls = false;
                proc = Process.GetCurrentProcess();
                msgBox = new(MsgBox.MsgType.Normal, "", this);
                instance = this;
                Program.splash.metroProgressBar1.PerformStep();
            }
            catch (Exception ex)
            {
                try
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show($"{ex.GetType()}\n{ex.Message}\nInnerEx:\n{ex.InnerException.GetType()}\n{ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    }
                    else
                    {
                        MessageBox.Show($"{ex.GetType()}\n{ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    }
                }
                catch (NullReferenceException ex1)
                {
                    MessageBox.Show($"{ex1.GetType()}\n{ex1.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// LightEdit
        /// </summary>
        /// <param name="file">File</param>
        public Main(string file)
        {
            try
            {
                InitializeComponent();
                InitializeTranslation();
                LightEdit_File = file;
                LightEdit = true;
                Program.splash.metroProgressBar1.PerformStep();
            }
            catch (Exception ex)
            {
                try
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show($"{ex.GetType()}\n{ex.Message}\nInnerEx:\n{ex.InnerException.GetType()}\n{ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    }
                    else
                    {
                        MessageBox.Show($"{ex.GetType()}\n{ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    }
                }
                catch (NullReferenceException ex1)
                {
                    MessageBox.Show($"{ex1.GetType()}\n{ex1.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region 初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            XshdFilePath = reConf.ReadString("Editor", "XshdFilePath", STARTUP_PATH + "\\Config\\Highlighting");
            //CacheWriter = new(CachePath + "\\Cache.pycncachelist", true, Encoding.UTF8);
            ClearLog();
            edit = new TextEditor()
            {
                Width = elementHost1.Width,
                Height = elementHost1.Height,
                FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                Background = new SolidColorBrush(Editor.Back),
                Foreground = new SolidColorBrush(Editor.Fore),
                FontSize = reConf.ReadInt("Editor", "Size", 12),
                ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
            };
            edit.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
            edit.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
            edit.DocumentChanged += Edit_DocumentChanged;
            elementHost1.Child = edit;
            //快速搜索功能
            SearchPanel.Install(edit.TextArea);
            using (Stream s = new FileStream(XshdFilePath + "\\Py-CN.xshd", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                edit.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;//获取当前屏幕显示区域大小，让窗体长宽等于这个值，这里不包含任务栏哦
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;//这样窗体打开的时候直接就是屏幕的大小了
            if (LightEdit)
            {
                edit.Load(LightEdit_File);
                tabPage1.Text = GetFileName(LightEdit_File);
                tabPage1.ToolTipText = LightEdit_File;
            }
        }

        private void Edit_DocumentChanged(object sender, EventArgs e)
        {
            Save(new object(), e);
        }
        #endregion
        #region 打开文件
        private void OpenFile(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName == null || openFileDialog1.FileName == "")
                {
                    return;
                }
                var tmp = @openFileDialog1.FileName.Split('\\')[@openFileDialog1.FileName.Split('\\').Length - 1];
                var _ = tmp.Split('.')[tmp.Split('.').Length - 1];
                if (tmp.Equals("BOOTMGR", StringComparison.CurrentCultureIgnoreCase))
                {
                    toolStripStatusLabel2.Text = "Windows NT " + _I18nFile.ReadString("I18n", "text.inprogram.bootfile", "text.inprogram.bootfile") + "(.efi|BOOTMGR)" + text_tsl2;
                    var agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + toolStripStatusLabel2.Text + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                    var dResult = MessageBoxEX.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.warning", "text.inprogram.title.warning"), MessageBoxButtons.YesNo, new string[] { _I18nFile.ReadString("I18n", "text.inprogram.bootfile.2", "text.inprogram.bootfile.2"), _I18nFile.ReadString("I18n", "text.inprogram.bootfile.3", "text.inprogram.bootfile.3") });
                    if (dResult != DialogResult.Yes) { return; }
                    statusStrip1.Show();
                    func_0a1(tmp);
                }
                else
                {
                    CheckFileTypeAndAlert(_, tmp, openFileDialog1.FileName);
                }
            }
            else { }
        }
        #endregion
        #region 关于
        private void AboutThis(object sender, EventArgs e)
        {
            LOGGER.WriteLog("即将打开“关于”窗口。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            About form = new();
            form.Show();
            LOGGER.WriteLog("成功。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            LOGGER.WriteLog($"窗口位置：({form.Location.X}, {form.Location.Y})", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
        }
        #endregion
        #region 新建文件
        private async void TextAreaMarkdownEntered(object sender, EventArgs e)
        {
            var editor = GetCurrentTextEditor();
            if (editor != null)
            {
                var text = editor.Text;
                if (text != null)
                {
                    var mdDoc = Markdown.ToHtml(text);
                    var webView = (tabControl1.SelectedTab.Tag as Dictionary<WebView2, TextEditor>).Keys.ToList()[0];
                    var textEditor = (tabControl1.SelectedTab.Tag as Dictionary<WebView2, TextEditor>).Values.ToList()[0];
                    webView.DoubleBuffered();
                    await webView.ExecuteScriptAsync($"document.body.style.backgroundColor = '{tabPage1.BackColor.ToHTML()}';");
                    await webView.ExecuteScriptAsync($"document.body.style.foregroundColor = '{tabPage1.ForeColor.ToHTML()}';");
                    webView.CoreWebView2.NavigateToString(mdDoc);
                    textEditor.Text = mdDoc;
                }
            }
        }

        private async void New(object sender, EventArgs e)
        {
            var nf = new NewFileBox("输入文件名");
            LOGGER.WriteLog("新建文件", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            var _ds = nf.ShowDialog(this);
            var fileName = nf.GetFileName();
            if (string.IsNullOrEmpty(fileName) || nf.GetStatus() == NewFileBox.FileStatus.Failed)
            {
                LOGGER.WriteLog("已取消新建文件。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                return;
            }
            var tab = new TabPage
            {
                Text = fileName,
                BackColor = tabPage1.BackColor,
                ForeColor = tabPage1.ForeColor
            };
            LOGGER.WriteLog($"TabPage已准备就绪。\n文件名: {tab.Text}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);

            if (fileName.EndsWith(".md", StringComparison.CurrentCultureIgnoreCase))
            {
                WBBox bBox = new(0, false, 5);
                bBox.Show();
                TableLayoutPanel tableMd = new()
                {
                    ColumnCount = 3,
                    Dock = DockStyle.Fill,
                    Location = new System.Drawing.Point(0, 0),
                    Name = "tableLayoutPanel2",
                    RowCount = 1,
                    Size = new System.Drawing.Size(858, 299),
                    TabIndex = 0,
                };
                bBox.uiProcessBar1.Value += 1;
                tableMd.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tableMd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
                tableMd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
                tableMd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
                bBox.uiProcessBar1.Value += 1;
                var tmpEHostMd = new ElementHost
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor
                }; var tmpEHostHtml = new ElementHost
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor
                };
                LOGGER.WriteLog("ElementHostForMarkdown已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                bBox.uiProcessBar1.Value += 1;
                var tmpEditorMd = new TextEditor
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    FontSize = reConf.ReadInt("Editor", "Size"),
                    ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                    VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                };
                var tmpEditorHtml = new TextEditor
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    FontSize = reConf.ReadInt("Editor", "Size"),
                    ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                    VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    IsReadOnly = true,
                };
                bBox.uiProcessBar1.Value += 1;
                LOGGER.WriteLog($"编辑器控件已准备就绪。\n字体: {tmpEditorHtml.FontFamily}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                tmpEditorMd.TextChanged += new EventHandler(this.TextAreaMarkdownEntered);
                LOGGER.WriteLog("编辑器控件方法入口已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                tmpEHostHtml.Child = tmpEditorHtml;
                tmpEHostMd.Child = tmpEditorMd;
                var resourceName = XshdFilePath + "\\HTML.xshd";
                using (Stream s = new FileStream(resourceName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                {
                    using XmlTextReader reader = new(s);
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    tmpEditorHtml.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }
                bBox.uiProcessBar1.Value += 1;
                Microsoft.Web.WebView2.WinForms.WebView2 webView = new();
                webView.SuspendLayout();
                webView.Size = elementHost1.Size;
                await webView.EnsureCoreWebView2Async();
                webView.DoubleBuffered();
                webView.CoreWebView2.Settings.IsWebMessageEnabled = true;
                webView.BackColor = this.BackColor;
                webView.ForeColor = this.ForeColor;
                webView.ResumeLayout(false);
                webView.PerformLayout();
                bBox.uiProcessBar1.Value += 1;

                tab.Tag = new Dictionary<WebView2, TextEditor>() { { webView, tmpEditorHtml } };
                tableMd.Controls.Add(tmpEHostMd);
                tableMd.Controls.Add(tmpEHostHtml);
                tableMd.Controls.Add(webView);
                tab.Controls.Add(tableMd);
                bBox.Close();
            }
            else
            {

                TableLayoutPanel table = new()
                {
                    ColumnCount = 1,
                    Dock = DockStyle.Fill,
                    Location = new System.Drawing.Point(0, 0),
                    Name = "tableLayoutPanel2",
                    RowCount = 1,
                    Size = tab.Size,
                    TabIndex = 0,
                };
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));


                var tmpEHost = new ElementHost
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor
                };
                table.Controls.Add(tmpEHost, 0, 0);
                LOGGER.WriteLog("ElementHost已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);

                var tmpEditor = new TextEditor
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    FontSize = reConf.ReadInt("Editor", "Size"),
                    ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                    VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,

                };
                LOGGER.WriteLog($"编辑器控件已准备就绪。\n字体: {tmpEditor.FontFamily}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
                tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
                tmpEditor.DocumentChanged += Edit_DocumentChanged;
                LOGGER.WriteLog("编辑器控件方法入口已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);

                // 快速搜索功能
                SearchPanel.Install(tmpEditor.TextArea);

                // 设置语法规则
                LOGGER.WriteLog("正在获取语法规则信息..");
                var tmpLanguage = AutoGetLanguage(tab.Text);
                var resourceName = XshdFilePath + $"\\{tmpLanguage}.xshd";
                LOGGER.WriteLog("语法规则信息获取成功。");
                LOGGER.WriteLog($"语法规则: {tmpLanguage}\t\t对应文件名: {resourceName}");
                using (Stream s = new FileStream(resourceName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                {
                    using XmlTextReader reader = new(s);
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }
                LOGGER.WriteLog("语法规则已成功设置。");

                tmpEHost.Child = tmpEditor;
                tab.Controls.Add(table);
            }
            tabControl1.TabPages.Add(tab);
            LOGGER.WriteLog("所有设置均已完成。");
            tabControl1.SelectedTab = tab;
        }
        #endregion
        #region 实时保存
        private void Save(object sender, EventArgs e)
        {
            FileSavingIcon.Visible = false;
            FileSavingTip.Visible = false;
            var _editor = GetCurrentTextEditor();
            if (_editor is null) { return; }
            if (tabControl1.SelectedTab != tabPage1 & tabControl1.SelectedTab.ToolTipText != null & tabControl1.SelectedTab.ToolTipText != "")
            {
                try
                {
                    StreamWriter streamWriter = new(tabControl1.SelectedTab.ToolTipText, false, Encoding.UTF8);
                    streamWriter.Write(_editor.Text);
                    streamWriter.Close();
                    FileSavingIcon.Image = Properties.Resources.file_saved_dark;
                    FileSavingTip.Text = _I18nFile.Localize("text.st.filesaved");
                    tabControl1.SelectedTab.Text.Replace("*", "");
                }
                catch (Exception ex)
                {
                    FileSavingIcon.Image = Properties.Resources.file_save_failed_dark;
                    FileSavingTip.Text = _I18nFile.Localize("text.st.filesavefailed");
                    LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                }
            }
            else
            {
                FileSavingIcon.Image = Properties.Resources.file_ready_to_save_dark;
                FileSavingTip.Text = _I18nFile.ReadString("I18n", "text.st.filereadytosave", "text.st.filereadytosave");
            }
            FileSavingIcon.Visible = true;
            FileSavingTip.Visible = true;
        }
        #endregion
        #region 另存为
        private void SaveFile(object sender, EventArgs e)
        {
            var _editor = GetTextEditor();
            if (_editor == null)
            {
                return;
            }

            saveFileDialog1.FileName = GetTabTitle();
            UpdateSaveFileDialogFilter();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (string.IsNullOrEmpty(saveFileDialog1.FileName))
                    {
                        return;
                    }

                    using (var streamWriter = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8))
                    {
                        streamWriter.Write(_editor.Text);
                    }

                    UpdateTabPageInfo(saveFileDialog1.FileName);
                    //tabControl1.SelectedTab.ToolTipText = saveFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    // 处理异常情况
                    LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                }
            }
        }

        private TextEditor GetTextEditor()
        {
            var selectedTab = tabControl1.SelectedTab;
            if (selectedTab == null)
            {
                return null;
            }

            if (selectedTab.Controls[0] is not TableLayoutPanel table)
            {
                return null;
            }

            return (table.Controls[0] as ElementHost).Child as TextEditor;
        }

        private string GetTabTitle()
        {
            var fileName = tabControl1.SelectedTab.Text.Replace("*", "");
            return fileName;
        }

        private void UpdateSaveFileDialogFilter()
        {
            string filter;
            var fileName = saveFileDialog1.FileName;

            if (fileName.Contains(".py"))
            {
                filter = "Python|*.py|Py-CN|*.pycn||*.*";
            }
            else if (fileName.Contains(".pycn"))
            {
                filter = "Py-CN|*.pycn|Python|*.py||*.*";
            }
            else
            {
                filter = "|*.*|Python|*.py|Py-CN|*.pycn";
            }

            saveFileDialog1.Filter = filter;
        }

        private void UpdateTabPageInfo(string fileName)
        {
            if (tabControl1.SelectedIndex != 0)
            {
                tabControl1.SelectedTab.Text = GetFileNameFromPath(fileName);
                tabControl1.SelectedTab.ToolTipText = fileName;
            }
            else
            {
                var tab = new TabPage() { Text = GetFileNameFromPath(fileName), ToolTipText = fileName };
                // 添加选项卡的其他相关代码...
            }
        }

        private string GetFileNameFromPath(string path)
        {
            return path.Split('\\').Last();
        }

        #endregion
        #region 自定义设置
        private void CustomSet(object sender, EventArgs e)
        {
            Form cs = new CustomSettings(STARTUP_PATH + "\\config")
            {
                Owner = this
            };
            cs.Show();
        }
        #endregion
        #region 运行
        private void Run(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1 & tabPage1.Text != _I18nFile.ReadString("I18n", "text.tc.tp.tmp", tabPage1.Text))
                {
                    var _tmpFileName = Convert.ToString(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
                    ExecuteCMDWithOutput("mkdir $tmp_code", "cmd.exe", "/s /c");
                    if (tabControl1.SelectedTab.ToolTipText.Contains(".pycn"))
                    {
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = ".\\Compiler.exe",
                            Arguments = "\"" + tabControl1.SelectedTab.ToolTipText + "\"",
                            CreateNoWindow = true,
                        });
                        SetPyCNFileCache(GetFileName(tabControl1.SelectedTab.ToolTipText) + Path.GetExtension(tabControl1.SelectedTab.ToolTipText)); ;
                        var error = RunPythonSrcipt(@tabControl1.SelectedTab.ToolTipText)[1];
                        if (error != "")
                        {
                            errMsgBox = new(error, GetCurrentTextEditor(), this);
                            errMsgBox.Show();
                            return;
                        }
                        RunnerProc = Process.Start(".\\Runner.exe", "\"" + tabControl1.SelectedTab.ToolTipText.Replace(".pycn", ".py") + "\"");
                    }
                    else if (tabControl1.SelectedTab.ToolTipText.Contains(".py"))
                    {
                        var error = RunPythonSrcipt(tabControl1.SelectedTab.ToolTipText)[1];
                        if (error != "")
                        {
                            errMsgBox = new(error, GetCurrentTextEditor(), this);
                            errMsgBox.Show();
                            return;
                        }
                        RunnerProc = Process.Start(".\\Runner.exe", tabControl1.SelectedTab.ToolTipText);
                    }
                }
                else
                {
                    if (tabControl1.SelectedTab.ToolTipText == "" | tabControl1.SelectedTab.ToolTipText is null)
                    {
                        string tmpPath;
                        ExecuteCMDWithOutput("mkdir $tmp_code", "cmd.exe", "/s /c");
                        if (tabControl1.SelectedTab == tabPage1 & tabPage1.Text == _I18nFile.ReadString("I18n", "text.tc.tp.tmp", tabPage1.Text))
                        {
                            tmpPath = Application.StartupPath + "\\$tmp_code\\tmp.pycn";
                            StreamWriter sw = new(tabPage1.ToolTipText, false, Encoding.UTF8);
                            sw.Write((GetCurrentTextEditor()).Text);
                            sw.Close();
                        }
                        tmpPath = Application.StartupPath + "\\$tmp_code\\" + tabControl1.SelectedTab.Text.Split('*')[0];
                        StreamWriter streamWriter = new(tmpPath, false, Encoding.UTF8);
                        streamWriter.Write((GetCurrentTextEditor()).Text);
                        streamWriter.Close();
                        tabControl1.SelectedTab.Tag = tmpPath;
                        if (tmpPath.Contains(".pycn"))
                        {
                            ProcessStartInfo tmpSI = new()
                            {
                                FileName = ".\\Compiler.exe",
                                Arguments = "\"" + tmpPath + "\"",
                                CreateNoWindow = true,
                            };
                            Process.Start(tmpSI);
                            SetPyCNFileCache(GetFileName(tmpPath) + Path.GetExtension(tmpPath)); ;
                            var error = RunPythonSrcipt(@tmpPath)[1];
                            if (error != "")
                            {
                                errMsgBox = new(error, GetCurrentTextEditor(), this);
                                errMsgBox.Show();
                                return;
                            }
                            RunnerProc = Process.Start(".\\Runner.exe", "\"" + tmpPath.Replace(".pycn", ".py") + "\"");
                        }
                        else if (tmpPath.Contains(".py"))
                        {
                            var error = RunPythonSrcipt(tmpPath)[1];
                            if (error != "")
                            {
                                errMsgBox = new(error, GetCurrentTextEditor(), this);
                                errMsgBox.Show();
                                return;
                            }
                            RunnerProc = Process.Start(".\\Runner.exe", tmpPath);
                        }
                        return;
                    }
                    else if (@tabControl1.SelectedTab.ToolTipText.Contains("exe"))
                    {
                        Process.Start(@tabControl1.SelectedTab.ToolTipText);
                    }
                    else if (Path.GetExtension(tabControl1.SelectedTab.ToolTipText) == ".pycn")
                    {
                        ProcessStartInfo tmpSI = new()
                        {
                            FileName = ".\\Compiler.exe",
                            Arguments = "\"" + tabControl1.SelectedTab.ToolTipText + "\"",
                            CreateNoWindow = true,
                        };
                        Process.Start(tmpSI);
                        SetPyCNFileCache(GetFileName(tabControl1.SelectedTab.ToolTipText) + Path.GetExtension(tabControl1.SelectedTab.ToolTipText)); ;
                        var error = RunPythonSrcipt(@tabControl1.SelectedTab.ToolTipText.Replace(".pycn", ".py"))[1];
                        if (error != "")
                        {
                            errMsgBox = new(error, GetCurrentTextEditor(), this);
                            errMsgBox.Show();
                            return;
                        }
                        RunnerProc = Process.Start(".\\Runner.exe", "\"" + tabControl1.SelectedTab.ToolTipText.Replace(".pycn", ".py") + "\"");
                    }
                    else if (@tabControl1.SelectedTab.ToolTipText.Contains(".py"))
                    {
                        var error = RunPythonSrcipt(@tabControl1.SelectedTab.ToolTipText)[1];
                        if (error != "")
                        {
                            errMsgBox = new(error, GetCurrentTextEditor(), this);
                            errMsgBox.Show();
                            return;
                        }
                        var ps = new ProcessStartInfo()
                        {
                            FileName = "Runner.exe",
                            Arguments = @tabControl1.SelectedTab.ToolTipText,
                            WindowStyle = ProcessWindowStyle.Minimized,
                            ErrorDialog = true,
                        };
                        LOGGER.WriteLog("ProcessStartInfo对象已创建。", EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.MAIN);
                        LOGGER.WriteLog(string.Format("ProcessStartInfo对象属性：FileName={0}, Arguments={1}", ps.FileName, ps.Arguments), EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.MAIN);
                        Process p = new() { StartInfo = ps };
                        LOGGER.WriteLog("Process对象已创建。", EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.MAIN);
                        //LOGGER.WriteLog("Process对象是否已运行：" + p.Start(), EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.MAIN);
                        p.Start();
                        RunnerProc = p;
                        //var p_name = p.MainWindowTitle;
                        //LOGGER.WriteLog("Process对象标题名称：" + p_name, EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.MAIN);
                        //appContainer1.AppProcess = p;

                        //appContainer1.Start();
                        LOGGER.WriteLog("Process对象是否已运行：" + (p.StartTime != null), EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.MAIN);
                        //    Task.Run(() =>
                        //    {
                        //        if (SetWindow.FindWindow(p_name))
                        //        {
                        //            LOGGER.WriteLog("找到窗体。" + p_name, EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.MAIN);
                        //            LOGGER.WriteLog("程序路径：" + p.MainModule.FileName, EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.MAIN);
                        //            //Process[] processes = Process.GetProcessesByName("Runner.exe");
                        //            //if (processes.Length > 0)
                        //            //{
                        //            //    IntPtr handle = processes[0].MainWindowHandle;
                        //            //    SendMessage(handle, WM_SYSCOMMAND2, new IntPtr(SC_MAXIMIZE2), IntPtr.Zero); // 最大化
                        //            //    SwitchToThisWindow(handle, true);   // 激活
                        //            //}
                        //            this.Invoke(new Action(() =>
                        //            {
                        //                //SetWindow.SetParent(panel1.Handle, p_name);  //设置父容器
                        //                appContainer1.AppProcess = p;
                        //                appContainer1.Start();
                        //            }));
                        //        }
                        //        else
                        //        {
                        //            p.Kill();
                        //            LOGGER.WriteErrLog(new InvalidOperationException("未查找到窗体。"), EnumMsgLevel.ERROR, EnumPort.CLIENT);
                        //        }
                        //    });
                    }
                }
            }
            catch (Exception ex)
            {
                LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            }
        }
        #endregion
        #region 执行CMD
        /// <summary>
        /// 执行带返回值的CMD
        /// </summary>
        /// <param name="command">命令</param>
        /// <param name="interpreter">解释器</param>
        /// <param name="interpreter_params">解释器参数</param>
        /// <returns></returns>
        internal static string ExecuteCMDWithOutput(string command, string interpreter, string interpreter_params)
        {
            ProcessStartInfo processInfo = new(interpreter, $"{interpreter_params} " + command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true
            };

            Process process = new() { StartInfo = processInfo };
            process.Start();
            var outpup = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return outpup;
        }
        #endregion
        #region <FUNC> GetFileType
        /// <summary>
        /// 判断文件类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetFileType(object sender, EventArgs e)
        {
            var fileName = tabControl1.SelectedTab.Text;
            var extension = Path.GetExtension(fileName).TrimStart('.');

            statusStrip1.Visible = IsSupportedFileExtension(extension);

            var memoryUsage = GetDigitalMemory() - tmp_;
            toolStripStatusLabel3.Text = $"{_I18nFile.ReadString("I18n", "text.st.mem", "text.st.mem")} {GetMemory()} {(memoryUsage > 0 ? ('+'.ToString() + memoryUsage.ToString()) : memoryUsage)}MB";

            if (isModified)
            {
                SetModifiedTabTitle();
            }
        }

        private bool IsSupportedFileExtension(string extension)
        {
            switch (extension.ToLower())
            {
                case "exe":
                case "dll":
                    return true;
                case "zip":
                case "7z":
                case "rar":
                case "001":
                case "tgz":
                case "tar":
                    return true;
                case "mp3":
                case "mp4":
                    return true;
                case "crx":
                    return true;
                case "png":
                case "jpg":
                case "gif":
                case "webp":
                case "jpeg":
                case "jfif":
                case "ico":
                case "bmp":
                    return true;
                case "jar":
                    return true;
                case "pak":
                case "pkg":
                    return true;
                case "e":
                    return true;
                case "xltd":
                    return true;
                case "iso":
                    return true;
                case "efi":
                    return true;
                case "sb2":
                case "sb3":
                    return true;
                default:
                    return false;
            }
        }

        private void SetModifiedTabTitle()
        {
            try
            {
                var text = tabControl1.SelectedTab.Text;
                if (!text.Contains("*"))
                {
                    tabControl1.SelectedTab.Text = text + "*";
                }
            }
            catch (NullReferenceException)
            {
                var text = tabControl1.SelectedTab.Text;
                if (!text.Contains("*"))
                {
                    tabControl1.SelectedTab.Text = text + "*";
                }
            }
        }
        #endregion
        #region <FUNC> 占位方法
        private async void func_0a1(string tmp)
        {
            CurrentWorkTip.Text = "Working on...";
            WorkingIcon.Visible = true;
            CurrentWorkTip.Visible = true;
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab.Text == tmp)
                {
                    tabControl1.SelectedTab = tab;
                    return;
                }
            }
            TableLayoutPanel table = new()
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Name = "tableLayoutPanel2",
                RowCount = 1,
                Size = new System.Drawing.Size(858, 299),
                TabIndex = 0,
            };
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName };
            if (tmp != "md" || tmp != "dmp" || tmp != "dump" || tmp != "minidump")
            {

                ElementHost tmpEHost = new()
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location
                };
                table.Controls.Add(tmpEHost, 0, 0);
                var tmpEditor = edit;
                tmpEditor.Text = "";
                //快速搜索功能
                SearchPanel.Install(tmpEditor.TextArea);
                tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
                tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
                tmpEditor.DocumentChanged += Edit_DocumentChanged;
                var file = AutoGetLanguage(newTab.Text);
                using (Stream s = new FileStream(XshdFilePath + $"\\{file}.xshd", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                {
                    using XmlTextReader reader = new(s);
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }
                tmpEHost.Child = tmpEditor;
                newTab.Controls.Add(table);
                tabControl1.TabPages.Add(newTab);
                newTab.ToolTipText = openFileDialog1.FileName;
                tmpEditor.Text = await ReadTextAsync(@openFileDialog1.FileName);
                tabControl1.SelectedTab = newTab;
                WorkingIcon.Visible = false;
                CurrentWorkTip.Visible = false;
            }
        }

        /// <summary>
        /// Method taken from <see href="https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/using-async-for-file-access">MSDN</see>.
        /// </summary>
        /// <param name="filePath">File Path</param>
        /// <returns>The string value of the file.</returns>
        internal static async Task<string> ReadTextAsync(string filePath)
        {
            using var sourceStream =
                new FileStream(
                    filePath,
                    FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: 4096, useAsync: true);

            var sb = new StringBuilder();

            var buffer = new byte[0x1000];
            int numRead;
            while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                var text = Encoding.Unicode.GetString(buffer, 0, numRead);
                sb.Append(text);
            }

            return sb.ToString();
        }
        #endregion
        #region <FUNC> 占位方法
        private bool func_0a2(string tssl2Text, string fileDesc)
        {
            toolStripStatusLabel2.Text = tssl2Text + _I18nFile.ReadString("I18n", "text.st.editprohibited", "text.st.editprohibited");
            var agreeText = _I18nFile.ReadString("I18n", "text.inprogram.normalfile.0", "text.inprogram.normalfile.0") + ' ' + fileDesc + _I18nFile.ReadString("I18n", "text.inprogram.normalfile.1", "text.inprogram.normalfile.1");
            var dResult = MessageBoxEX.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.warning", "text.inprogram.title.warning"), MessageBoxButtons.YesNo, new string[] { _I18nFile.ReadString("I18n", "text.inprogram.bootfile.2", "text.inprogram.bootfile.2"), _I18nFile.ReadString("I18n", "text.inprogram.bootfile.3", "text.inprogram.bootfile.3") });
            if (dResult != DialogResult.Yes) { return false; }
            statusStrip1.Show();
            return true;
        }
        #endregion
        #region 关闭选项卡
        private void CloseFile(object sender, EventArgs e)
        {
            var tab = tabControl1.TabPages[tabControl1.SelectedIndex];
            if (tab.Equals(tabPage1))
            {
                if (!NoTip)
                {
                    if (MessageBoxEX.Show("无法关闭临时页面！", "提示", MessageBoxButtons.OKCancel, new string[] { "不再显示", "我已知晓" }) == DialogResult.OK)
                    {
                        NoTip = true;
                        reConf.Write("General", "NoTipForClosingTempPage", NoTip);
                    }
                }
            }
            else
            {
                try
                {
                    var webView = (tabControl1.SelectedTab.Tag as Dictionary<WebView2, TextEditor>).Keys.ToList()[0];
                    webView?.Dispose();
                }
                catch { }
                tab.Controls[0].Dispose();
                tab.Controls.Clear();
                tab.Dispose();
            }
        }
        #endregion
        #region 获取程序运行时内存占用
        /// <summary>
        /// 获取程序运行时内存占用
        /// </summary>
        /// <returns>string形式的内存</returns>
        public static string GetMemory()
        {
            var b = proc.PrivateMemorySize64;
            for (var i = 0; i < 2; i++)
            {
                b /= 1024;
            }
            return b < 1000 ? (b + "MB") : (Math.Round((double)b / 1024, 2) + "GB");
        }
        #endregion
        #region 写入内存
        private void WriteDownMem(object sender, EventArgs e)
        {
            tmp_ = GetDigitalMemory();
            HelpButton.Location = new System.Drawing.Point(this.Width - HelpButton.Width, 7);
            var tmpETable = tabControl1.SelectedTab.Controls[0] as TableLayoutPanel;
            var CurrentEdtior = GetCurrentTextEditor();
            if (CurrentEdtior is not null)
            {
                CurrentEdtior.Width = tmpETable.Controls[0].Width;
                CurrentEdtior.Height = tmpETable.Controls[0].Height;
            }
        }
        #endregion
        #region 帮助窗口
        private void help(object sender, EventArgs e)
        {
            Uri url = new($"File:///{Environment.CurrentDirectory}/help.html");
            Help help = new(url);
            help.Show();
            this.Hide();
        }
        #endregion
        #region 获取int型的内存
        /// <summary>
        /// 获取int型的内存
        /// </summary>
        /// <returns>int型的内存</returns>
        public static int GetDigitalMemory()
        {
            var proc = Process.GetCurrentProcess();
            var b = proc.PrivateMemorySize64;
            for (var i = 0; i < 2; i++)
            {
                b /= 1024;
            }
            return (int)b;
        }
        #endregion
        #region 代码设置
        private void CodeConfig(object sender, EventArgs e)
        {
            CodeSettings cc = new();
            //timer4.Start();
            cc.Show();
        }
        #endregion
        #region 识别文件语言
        /// <summary>
        /// 识别文件语言
        /// </summary>
        /// <param name="SuffixName">文件后缀名</param>
        /// <param name="log">是否记录于日志中</param>
        /// <returns>语言类型</returns>
        public static string AutoGetLanguage(string SuffixName, bool log = true)
        {
            SuffixName = Path.GetExtension(SuffixName);
            if (log)
            {
                LOGGER.WriteLog($"已获取文件名: {SuffixName}");
            }
            if (SuffixName.Contains(".cs"))
            {
                return "C-Sharp";
            }
            else if (SuffixName.Contains(".pycn") | SuffixName.Contains(".pyCN"))
            {
                return "Py-CN";
            }
            else if (SuffixName.Contains(".py") | SuffixName.Contains(".pyw") | SuffixName.Contains(".pyi"))
            {
                return "Python";
            }
            else if (SuffixName.Contains(".xml") | SuffixName.Contains(".xshd"))
            {
                return "XML";
            }
            else
            {
                return "PlainText";
            }

        }
        #endregion
        #region 清除日志
        private void ClearLog()
        {
            File.WriteAllText(LOGGER.logPath, "");
            LOGGER.WriteLog("已清除过期的日志文件！", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
        }
        #endregion
        #region 许可与版权声明
        private void copyrightsAndLicense(object sender, EventArgs e)
        {
            new LicenseAndCopyrights().Show();
        }
        #endregion
        #region 检查语法错误
        private void CheckSyntaxError(object sender, EventArgs e)
        {
            var editor = GetCurrentTextEditor();
            if (editor is null) { return; }
            var content = editor.Text;
            if (tabControl1.SelectedTab.ToolTipText != null)
            {
                //var ret = RunPythonSrcipt(tabControl1.SelectedTab.ToolTipText)[1];
                if (content.IsNullOrEmpty()) return;
                var res = PythonSyntaxErrorChecker.SyntaxCheck(content).Split("\r\n");
                //var res = PythonErrorAnalyzer.AnalyzePythonFile(content);
                //var types = (List<string>)res["Type"];
                //var desc = new List<string>()/*(List<string>)res["Description"]*/;
                //var lines = new List<int>()/*(List<int>)res["Line"]*/;
                var tmpExs = new List<ListViewItem>();
                for (; _i < res.Length; _i++)
                {
                    var tmpEx = new ListViewItem("[ERROR]", imageKey: "EII")
                    {
                        Text = "   ",
                    };
                    tmpExs.Add(tmpEx);
                }
                for (var i = 0; i <= tmpExs.Count; ++i)
                {
                    tmpExs[i].SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "" });
                    tmpExs[i].SubItems.Add(new ListViewItem.ListViewSubItem() { Text = res[i].Between("|Ls-", "-Le|") });
                    tmpExs[i].SubItems.Add(new ListViewItem.ListViewSubItem() { Text = res[i].Between("|Ds-", "-De|") });
                }
                foreach (var item in tmpExs)
                {
                    listView1.Items.Add(item);
                }
                //foreach (var item in types)
                //{
                //    listView1.Items[types.IndexOf(item)].SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item });
                //}
                //foreach (var item in desc)
                //{
                //    listView1.Items[desc.IndexOf(item)].SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item });
                //}
                //foreach (var item in lines)
                //{
                //    listView1.Items[lines.IndexOf(item)].SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.ToString() });
                //}
            }
        }
        #endregion
        #region 循环判断：窗体是否处于最大化状态
        private void IsMaximized(object sender, EventArgs e)
        {

        }
        #endregion
        #region 测试崩溃
        private void TestCrash(object sender, EventArgs e)
        {
            throw new Exception("测试异常");
        }
        #endregion
        #region 退出
        private void ExitByClosing(object sender, FormClosingEventArgs e)
        {
            var dRes = MessageBoxEX.Show("确定退出吗？", "提示", MessageBoxButtons.YesNo, new string[] { "是", "否" });
            LOGGER.WriteLog("已询问退出，返回值：" + dRes, EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            if (dRes == DialogResult.Yes)
            {
                LOGGER.WriteLog("Stopping!", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                keepFile.WriteLine(long.MaxValue);
                keepFile.Close();
                Process.GetCurrentProcess().Kill();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion
        #region 静默保存
        private void QuietSave(object sender, EventArgs e)
        {
            FileSavingIcon.Visible = false;
            FileSavingTip.Visible = false;
            try
            {
                var result = tabControl1.SelectedTab.ToolTipText;
                var tmpEditor = GetCurrentTextEditor();
                if (result != "" | result != string.Empty)
                {
                    StreamWriter sw = new(result, false, Encoding.UTF8);
                    sw.Write(tmpEditor.Text);
                    sw.Flush();
                    sw.Close();
                    tabControl1.SelectedTab.Text.Replace("*", "");
                    FileSavingTip.Text = _I18nFile.Localize("text.st.filesaved");
                    FileSavingIcon.Image = Properties.Resources.file_saved_dark;
                }
                else
                {
                    SaveFile(sender, e);
                }
            }
            catch (Exception ex)
            {
                LOGGER.WriteErrLog($"已捕捉异常：{ex.Message}", ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                FileSavingIcon.Image = Properties.Resources.file_save_failed_dark;
                FileSavingTip.Text = _I18nFile.Localize("text.st.filesavefailed");
            }
            FileSavingIcon.Visible = true;
            FileSavingTip.Visible = true;
            //StreamWriter sw = new();
        }
        #endregion
        #region 代码提示
        private CompletionWindow _codeSense;
        private string tmpCompletionStr = "";

        private void TextAreaOnTextEntered(object sender, TextCompositionEventArgs e)
        {

            // 处理文本修改和代码提示
            HandleTextModification(e.Text, (TextArea)sender);

            // 清除临时完成字符串和标记状态
            ClearTemporaryCompletion();

            toolStripStatusLabel7.Text = tmpCompletionStr;
        }

        private string GetLineInTextEditor(TextEditor _editor, string text)
        {
            foreach (var item in _editor.Text.GetLines())
            {
                if (item.Contains(text))
                {
                    return item;
                }
            }
            return string.Empty;
        }

        private void HandleTextModification(string text, TextArea textArea)
        {
            Regex _regex_unclosedstring = new("\".+[^\")]");
            Regex _regex_closedstring = new("\".+\"");
            var _editor = ((ElementHost)((TableLayoutPanel)tabControl1.SelectedTab.Controls[0]).Controls[0]).Child as TextEditor;
            tmpCompletionStr += text;
            if (!text[0].IsLetterOrDigit())
            {
                tmpCompletionStr = "";
            }
            else if (_regex_unclosedstring.IsMatch(GetLineInTextEditor(_editor, text)) & !_regex_closedstring.IsMatch(GetLineInTextEditor(_editor, text)))
            {
                tmpCompletionStr = "";
            }
            else
            {
                _codeSense = new CompletionWindow(textArea)
                {
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                };
                var completionData = _codeSense.CompletionList.CompletionData;
                var _keywords = new string[] { };
                var _specialdefs = new string[] { };
                var _builtins = new string[] { };
                var _fields = new string[] { };
                var tmp = tabControl1.SelectedTab.Text;
                var lang = AutoGetLanguage(tmp, false);
                var _tmpfilepath = (string)tabControl1.SelectedTab.Tag;
                switch (lang)
                {
                    case "Python":
                        _keywords = LangKeywords.Keywords.python;
                        _specialdefs = LangKeywords.SpecialDefs.python;
                        _builtins = LangKeywords.BulitIns.py;
                        if (!_tmpfilepath.IsNullOrEmpty())
                        {
                            _fields.AddRange(PythonVariableAnalyzer.Analyze(GetCurrentTextEditor().Text));
                        }
                        break;
                    case "Py-CN":
                        _keywords = LangKeywords.Keywords.pycn;
                        _specialdefs = LangKeywords.SpecialDefs.pycn;
                        _builtins = LangKeywords.BulitIns.pycn;
                        if (!_tmpfilepath.IsNullOrEmpty())
                        {
                            //_fields = PythonVariableAnalyzer.AnalyzeVariables(_tmpfilepath)["Global"].ToArray();
                            //_fields.AddRange(PythonVariableAnalyzer.AnalyzeVariables(_tmpfilepath)["Private"]);
                        }
                        break;
                    case "C-Sharp":
                        _keywords = LangKeywords.Keywords.cs;
                        _specialdefs = LangKeywords.SpecialDefs.cs;
                        break;
                    case "XML":
                        break;
                    case "PlainText":
                        break;
                }
                foreach (var item in _keywords.Where(IsKeywordMatched))
                {
                    completionData.Add(new RYCBCodeSense(item, tmpCompletionStr.Length, CodeSenseType.KEYWORD));
                }
                foreach (var item in _specialdefs.Where(IsKeywordMatched))
                {
                    completionData.Add(new RYCBCodeSense(item, tmpCompletionStr.Length, CodeSenseType.FIELD));
                }
                foreach (var item in _builtins.Where(IsKeywordMatched))
                {
                    completionData.Add(new RYCBCodeSense(item, tmpCompletionStr.Length, CodeSenseType.BUILTIN));
                }
                foreach (var item in _fields.Where(IsKeywordMatched))
                {
                    completionData.Add(new RYCBCodeSense(item, tmpCompletionStr.Length, CodeSenseType.FIELD));
                }

                if (completionData.Count > 0)
                {
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => { _codeSense = null; };
                }
                else
                {
                    tmpCompletionStr = "";
                }
            }
        }

        private bool IsKeywordMatched(string keyword)
        {
            var pinyin = ChinsesePinYinHelper.GetPinYinFull(keyword);
            return pinyin.StartsWith(tmpCompletionStr)/* || pinyin != tmpCompletionStr*/;
        }

        private void ClearTemporaryCompletion()
        {
            if (RYCBCodeSense._completed)
            {
                tmpCompletionStr = _codeSense.CompletionList.SelectedItem?.Text ?? "";
            }
            else
            {
                tmpCompletionStr = "";
            }
            RYCBCodeSense._completed = false;
        }


        #endregion
        #region 判断代码是否已修改
        private void TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            FileSavingIcon.Image = Properties.Resources.file_ready_to_save_dark;
            if (e.Text.Length > 0 && _codeSense != null && !e.Text[0].IsLetterOrDigit())
            {
                _codeSense.CompletionList.RequestInsertion(e);
            }
        }

        private void ResizeControls(object sender, EventArgs e)
        {
            HelpButton.Location = new System.Drawing.Point(this.Width - 44, 7);
            SizeController.Start();
        }

        private bool TabControl1_BeforeRemoveTabPage(object sender, int index)
        {
            var tab_count = tabControl1.TabPages.Count;
            var tab = tabControl1.SelectedTab;
            if (tab_count == 1)
            {
                var editor = GetCurrentTextEditor();
                tab.Text = _I18nFile.Read("I18n", "text.tc.tp.tmp", "text.tc.tp.tmp");
                editor.Text = "";
                return false;
            }
            else
            {
                tab.Controls[0].Dispose();
                tab.Controls.Clear();
                tab.Dispose();
            }
            return true;
        }

        private async void FirstInit(object sender, EventArgs e)
        {
            ExecuteCMDWithOutput("mkdir " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect", "cmd", "/s /c");
            keepFile = new StreamWriter(new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect\\.KEEP", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite), Encoding.UTF8);
            stopwatch.Start();
            LOGGER.WriteLog($"窗口大小修改成功 (水平长度{this.Size.Width}px, 垂直长度{this.Size.Height}px)", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"窗口位置：{this.Location}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"窗口PID：{Process.GetCurrentProcess().Id}", EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"窗口句柄：{Process.GetCurrentProcess().Handle}", EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog("主程序正在初始化...", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            keepFile.WriteLine(long.MinValue);
            keepFile.Flush();
            this.Location = new System.Drawing.Point(1, 1);
            NoTip = reConf.ReadBool("General", "NoTipForClosingTempPage");
            statusStrip1.Hide();
            openFileDialog1.Filter = filter;
            openFileDialog1.Title = title;
            text_tsl2 = toolStripStatusLabel2.Text;
            LOGGER.WriteLog("编辑器控件加载完毕。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\SoftInfo",
                $"""
                [Version]
                Version={VERSION}
                friendly={FRIENDLY_VER}

                [Startup]
                param_count=0
                params=None
                path={STARTUP_PATH}
                """);
            this.Resize += new EventHandler(this.ResizeControls);
            Program.splash.metroProgressBar1.PerformStep();
            stopwatch.Stop();
            if (reConf.ReadBool("DevMode", "DevMode"))
            {
                开发者选项DToolStripMenuItem.Visible = true;
            }
            var time = stopwatch.Elapsed;
            var end_time = time.TotalSeconds;
            LOGGER.WriteLog("主程序初始化成功！", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"主程序初始化时间共计：{Math.Round(end_time, 2)}s", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            var _end_time = Program.startTime.TotalSeconds;
            LOGGER.WriteLog($"初始化时间共计：{Math.Round(_end_time + end_time, 2)}s", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            Program.splash.metroProgressBar1.PerformStep();
            Program.splash.metroProgressBar1.Value = Program.splash.metroProgressBar1.Maximum;
            Program.splash.Close();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;//获取当前屏幕显示区域大小，让窗体长宽等于这个值，这里不包含任务栏哦
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;//这样窗体打开的时候直接就是屏幕的大小了
            this.WindowState = FormWindowState.Maximized;
            this.Show();
            var isFirstBoot = reConf.ReadBool("FirstBoot", "IsFirstBoot");
            if (isFirstBoot) { new FirstBootStep1().ShowDialog(); }
            await UpdateCheckAsync();
        }

        private void ForceExit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private new void Layout(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab.Text.Length >= 32)
            {
                tabControl1.ItemSize = new System.Drawing.Size(500, tabControl1.ItemSize.Height);
            }
            else if (tabControl1.SelectedTab.Text.Length >= 16)
            {
                tabControl1.ItemSize = new System.Drawing.Size(350, tabControl1.ItemSize.Height);
            }
            else if (tabControl1.SelectedTab.Text.Length >= 8)
            {
                tabControl1.ItemSize = new System.Drawing.Size(200, tabControl1.ItemSize.Height);
            }
            else
            {
                tabControl1.ItemSize = new System.Drawing.Size(100, tabControl1.ItemSize.Height);
            }
        }

        #endregion
        #region 后台运行Python代码 (Copyright © 2023 RYCBStudio by CC 2.0 License)
        private static string[] RunPythonSrcipt(string path, string python = "python.exe")
        {
            var pythonSrcipt = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = python,
                    Arguments = "\"" + path + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true,
                }
            };
            pythonSrcipt.Start();
            return new string[] { pythonSrcipt.StandardOutput.ReadToEnd(), pythonSrcipt.StandardError.ReadToEnd() };
        }
        #endregion
        #region 打开百宝箱
        private void OpenTheTBox(object sender, EventArgs e)
        {
            new TBox().Show();
        }
        #endregion
        #region 界面调整
        private void Validating_Layout(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Layout(sender, new TabControlEventArgs(tabControl1.SelectedTab, tabControl1.SelectedIndex, TabControlAction.Selecting));
        }

        private void Layout(object sender, EventArgs e)
        {
            Layout(sender, new TabControlEventArgs(tabControl1.SelectedTab, tabControl1.SelectedIndex, TabControlAction.Selecting));
        }
        #endregion
        #region 退出
        private void Exit(object sender, EventArgs e)
        {
            ExitByClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }
        #endregion
        #region 重启
        private void Restart(object sender, EventArgs e)
        {
            var dRes = MessageBox.Show("确定重启吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            LOGGER.WriteLog("已询问重启，返回值：" + dRes, EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            if (dRes == DialogResult.Yes)
            {
                LOGGER.WriteLog("Stopping!", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                keepFile.WriteLine(long.MaxValue);
                keepFile.Close();
                var programpath = Application.ExecutablePath;
                var arguments = Environment.GetCommandLineArgs().Skip(1).ToArray();
                ProcessStartInfo startinfo = new()
                {
                    FileName = programpath,
                    UseShellExecute = true,
                    Arguments = string.Join(" ", arguments)
                };
                Process.Start(startinfo);
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                return;
            }
        }
        #endregion
        #region “鸣谢”模块
        private void Thanks(object sender, EventArgs e)
        {
            new Thanks().Show();
        }
        #endregion
        #region 强制停止
        private void ForceStop(object sender, EventArgs e)
        {
            Cmd.RunCmd("taskkill /im runner.exe /f /t");
            //RunnerProc.CloseMainWindow();
        }
        #endregion
        #region 全选
        private void SelectAll(object sender, EventArgs e)
        {
            var _editor = (tabControl1.SelectedTab.Controls[0] as ElementHost).Child as TextEditor;
            _editor.SelectAll();
        }
        #endregion
        #region 捐助
        private void DonateLink(object sender, EventArgs e)
        {
            Process.Start("https://afdian.net/a/RYCBStudio");
        }
        #endregion
        #region 查找
        private void Find(object sender, EventArgs e)
        {
            //new RYCBSearchPanel(GetCurrentTextEditor()).Show();
        }

        private void LayoutForConsole(object sender, EventArgs e)
        {
            if (SetWindow.intPtr != IntPtr.Zero)
            {
                var t = new Thread(SetWindow.ResizeWindow);
                t.Start();  //开线程刷新第三方窗体大小
                Thread.Sleep(50); //略加延时
                BackgroundWorker_GetFileType.Stop();  //停止定时器
            }
        }

        private void GotoLine(object sender, EventArgs e)
        {
            var editor = GetCurrentTextEditor();
            if (editor != null)
            {
                editor.ScrollToLine(Convert.ToInt32(listView1.CheckedItems[0].SubItems[3].Text));
            }
        }
        #endregion
        #region 清理缓存
        private void ClearCache(object sender, EventArgs e)
        {
            new CacheCleaner().Show();
        }
        #endregion
        #region 检查文件类型并发出警告
        private async void CheckFileTypeAndAlert(string fileExtension, string tmp, string fileName)
        {
            #region 特殊文件
            if (fileExtension.Equals("exe"))
            {
                if (func_0a2("exe", _I18nFile.ReadString("I18n", "text.inprogram.fileex.exe", "text.inprogram.fileex.exe") + "(.exe)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("dll"))
            {
                if (func_0a2("dll", _I18nFile.ReadString("I18n", "text.inprogram.fileex.dll", "text.inprogram.fileex.dll") + "(.dll)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("zip") || fileExtension.Equals("7z") || fileExtension.Equals("rar") ||
                     fileExtension.Equals("001") || fileExtension.Equals("tgz") || fileExtension.Equals("tar") ||
                     fileExtension.Equals("bin"))
            {
                if (func_0a2("zip|7z|rar|001|tgz|tar|bin", _I18nFile.ReadString("I18n", "text.inprogram.fileex.compressed", "text.inprogram.fileex.compressed") + "(.zip|.7z|.rar|.001|.tgz|.tar|bin)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("mp3"))
            {
                if (func_0a2("mp3", _I18nFile.ReadString("I18n", "text.inprogram.fileex.media", "text.inprogram.fileex.media") + "(.mp3)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("mp4"))
            {
                if (func_0a2("mp4", _I18nFile.ReadString("I18n", "text.inprogram.fileex.vedio", "text.inprogram.fileex.vedio") + "(.mp4)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("crx"))
            {
                if (func_0a2("crx", _I18nFile.ReadString("I18n", "text.inprogram.fileex.crx", "text.inprogram.fileex.crx") + "(.crx)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("png") || fileExtension.Equals("jpg") || fileExtension.Equals("gif") ||
                     fileExtension.Equals("webp") || fileExtension.Equals("jpeg") || fileExtension.Equals("jfif") ||
                     fileExtension.Equals("ico") || fileExtension.Equals("bmp"))
            {
                if (func_0a2("png|jpg|gif|webp|jpeg|jfif|ico|bmp", _I18nFile.ReadString("I18n", "text.inprogram.fileex.pic", "text.inprogram.fileex.pic") + "(.png|.jpg|.gif|.webp|.jpeg|.jfif|.ico|.bmp)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("jar"))
            {
                if (func_0a2("jar", _I18nFile.ReadString("I18n", "text.inprogram.fileex.jar", "text.inprogram.fileex.jar") + "(.jar)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("pak") || fileExtension.Equals("pkg"))
            {
                if (func_0a2("pkg", _I18nFile.ReadString("I18n", "text.inprogram.fileex.pak", "text.inprogram.fileex.pak") + "(.pak|.pkg)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("e"))
            {
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.e", "text.inprogram.fileex.e") + "(.e)" + text_tsl2;
                var agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.e", "text.inprogram.fileex.e") + "(.e)" + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                var dResult = MessageBox.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                MessageBox.Show(_I18nFile.ReadString("I18n", "text.inprogram.fileex.e", "text.inprogram.fileex.e") + "(.e)" + _I18nFile.ReadString("I18n", "text.inprogram.fileex.e.0", "text.inprogram.fileex.e.0"), _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                func_0a1(tmp);
            }
            else if (fileExtension.Equals("xltd"))
            {//迅雷临时数据文件
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.xltd", "text.inprogram.fileex.xltd") + "(.xltd)" + text_tsl2;
                var agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.xltd", "text.inprogram.fileex.xltd") + "(.xltd)" + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                var dResult = MessageBoxEX.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.warning", "text.inprogram.title.warning"), MessageBoxButtons.YesNo, new string[] { _I18nFile.ReadString("I18n", "text.inprogram.bootfile.2", "text.inprogram.bootfile.2"), _I18nFile.ReadString("I18n", "text.inprogram.bootfile.3", "text.inprogram.bootfile.3") });
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                func_0a1(tmp);
            }
            else if (fileExtension.Equals("iso"))
            {
                if (func_0a2("iso", _I18nFile.ReadString("I18n", "text.inprogram.fileex.iso", "text.inprogram.fileex.iso") + "(.iso)"))
                {
                    func_0a1(tmp);
                }
            }
            else if (fileExtension.Equals("vmdk"))
            {
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.vmdk", "text.inprogram.fileex.vmdk") + "(.vmdk)" + text_tsl2;
                var agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.vmdk", "text.inprogram.fileex.vmdk") + "(.vmdk)" + _I18nFile.ReadString("I18n", "text.inprogram.fileex.vmdk.warn", "text.inprogram.fileex.vmdk.warn");//"文件，该操作将引起IDE未响应和内存溢出，从而导致程序崩溃且极有可能使您的计算机卡死、崩溃甚至蓝屏，请确认是否继续打开：";
                var dResult = MessageBoxEX.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.warning", "text.inprogram.title.warning"), MessageBoxButtons.YesNo, new string[] { _I18nFile.ReadString("I18n", "text.inprogram.bootfile.2", "text.inprogram.bootfile.2"), _I18nFile.ReadString("I18n", "text.inprogram.bootfile.3", "text.inprogram.bootfile.3") });
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                func_0a1(tmp);
            }
            else if (fileExtension.Equals("sb2") | fileExtension.Equals("sb3"))
            {
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.sb", "text.inprogram.fileex.sb") + "(.sb2|.sb3)" + text_tsl2;
                var agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.sb", "text.inprogram.fileex.sb") + "(.sb2|.sb3)" + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                var dResult = MessageBox.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                MessageBox.Show(_I18nFile.ReadString("I18n", "text.inprogram.fileex.sb.intro", "text.inprogram.fileex.sb.intro"), _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                func_0a1(tmp);
            }
            else if (fileExtension.Equals("dmp", StringComparison.CurrentCultureIgnoreCase) | fileExtension.Equals("dump", StringComparison.CurrentCultureIgnoreCase) | fileExtension.ToLower().Equals("minidump"))
            {
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.dmp", "text.inprogram.fileex.dmp") + "(.dmp|.dump|.minidump)" + text_tsl2;
                var agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.dmp", "text.inprogram.fileex.dmp") + "(.dmp|.dump|.minidump)" + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                var dResult = MessageBox.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                CurrentWorkTip.Text = "Working on...";
                WorkingIcon.Visible = true;
                CurrentWorkTip.Visible = true;
                TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName };
                WBBox bBox = new(0, false, 5);
                bBox.Show();
                TableLayoutPanel table = new()
                {
                    ColumnCount = 1,
                    Dock = DockStyle.Fill,
                    Location = new System.Drawing.Point(0, 0),
                    Name = "tableLayoutPanel" + DateTime.Now.Millisecond,
                    RowCount = 1,
                    Size = new System.Drawing.Size(858, 299),
                    TabIndex = 0,
                };
                bBox.uiProcessBar1.Value += 1;
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                ElementHost tmpEHost = new()
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location
                };
                table.Controls.Add(tmpEHost, 0, 0);
                bBox.uiProcessBar1.Value += 1;
                var tmpEditor = new TextEditor
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    FontSize = reConf.ReadInt("Editor", "Size"),
                    ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                    VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,

                };
                bBox.uiProcessBar1.Value += 1;
                tmpEditor.Text = "";
                tmpEHost.Child = tmpEditor;
                newTab.Controls.Add(table);
                tabControl1.TabPages.Add(newTab);
                bBox.uiProcessBar1.Value += 1;
                newTab.ToolTipText = openFileDialog1.FileName;
                tmpEditor.Text = MiniDumpReader.ReadDumpFile(@openFileDialog1.FileName);
                bBox.uiProcessBar1.Value += 1;
                tabControl1.SelectedTab = newTab;
                bBox.Close();
                WorkingIcon.Visible = false;
                CurrentWorkTip.Visible = false;
            }
            else if (fileExtension.ToLower().Equals("dat"))
            {
                toolStripStatusLabel2.Text = _I18nFile.Localize("text.inprogram.fileex.dat") + "(.dat)" + text_tsl2;
                var agreeText = _I18nFile.Localize("text.inprogram.bootfile.0") + _I18nFile.Localize("text.inprogram.fileex.dat") + "(.dat)" + _I18nFile.Localize("text.inprogram.bootfile.1");
                var dResult = MessageBox.Show(agreeText, _I18nFile.Localize("text.inprogram.title.info"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                CurrentWorkTip.Text = "Working on...";
                WorkingIcon.Visible = true;
                CurrentWorkTip.Visible = true;
                TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName };
                WBBox bBox = new(0, false, 5);
                bBox.Show();
                TableLayoutPanel table = new()
                {
                    ColumnCount = 2,
                    Dock = DockStyle.Fill,
                    Location = new System.Drawing.Point(0, 0),
                    Name = "tableLayoutPanel" + DateTime.Now.Millisecond,
                    RowCount = 1,
                    Size = new System.Drawing.Size(858, 299),
                    TabIndex = 0,
                };
                bBox.uiProcessBar1.Value += 1;
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
                ElementHost tmpEHostForRawData = new()
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location
                }; ElementHost tmpEHostForStringData = new()
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location
                };
                table.Controls.Add(tmpEHostForRawData, 0, 0);
                table.Controls.Add(tmpEHostForStringData, 1, 0);
                bBox.uiProcessBar1.Value += 1;
                var tmpEditorForRawData = new TextEditor
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    FontSize = reConf.ReadInt("Editor", "Size"),
                    ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                    VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    Text = "",
                };
                var tmpEditorForStringData = new TextEditor
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    FontSize = reConf.ReadInt("Editor", "Size"),
                    ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                    VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    Text = "",
                };
                bBox.uiProcessBar1.Value += 1;
                tmpEHostForRawData.Child = tmpEditorForRawData;
                tmpEHostForStringData.Child = tmpEditorForStringData;
                newTab.Controls.Add(table);
                tabControl1.TabPages.Add(newTab);
                bBox.uiProcessBar1.Value += 1;
                newTab.ToolTipText = openFileDialog1.FileName;
                tmpEditorForRawData.Text = BinaryFileReader.ReadBinaryFile(fileName).Item1;
                tmpEditorForStringData.Text = BinaryFileReader.ReadBinaryFile(fileName).Item2;
                bBox.uiProcessBar1.Value += 1;
                tabControl1.SelectedTab = newTab;
                bBox.Close();
                WorkingIcon.Visible = true;
                CurrentWorkTip.Visible = true;
            }
            else if (fileExtension.Equals("md"))
            {
                CurrentWorkTip.Text = "Working on...";
                WorkingIcon.Visible = true;
                CurrentWorkTip.Visible = true;
                TableLayoutPanel table = new()
                {
                    ColumnCount = 1,
                    Dock = DockStyle.Fill,
                    Location = new System.Drawing.Point(0, 0),
                    Name = "tableLayoutPanel2",
                    RowCount = 1,
                    Size = new System.Drawing.Size(858, 299),
                    TabIndex = 0,
                };
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName };
                WBBox bBox = new(0, false, 5);
                bBox.Show();
                TableLayoutPanel tableMd = new()
                {
                    ColumnCount = 3,
                    Dock = DockStyle.Fill,
                    Location = new System.Drawing.Point(0, 0),
                    Name = "tableLayoutPanel2",
                    RowCount = 1,
                    Size = new System.Drawing.Size(858, 299),
                    TabIndex = 0,
                };
                bBox.uiProcessBar1.Value += 1;
                tableMd.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tableMd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
                tableMd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
                tableMd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
                bBox.uiProcessBar1.Value += 1;
                var tmpEHostMd = new ElementHost
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor
                }; var tmpEHostHtml = new ElementHost
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor
                };
                LOGGER.WriteLog("ElementHostForMarkdown已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                bBox.uiProcessBar1.Value += 1;
                var tmpEditorMd = new TextEditor
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    FontSize = reConf.ReadInt("Editor", "Size"),
                    ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                    VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                };
                var tmpEditorHtml = new TextEditor
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    FontSize = reConf.ReadInt("Editor", "Size"),
                    ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                    VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    IsReadOnly = true,
                };
                bBox.uiProcessBar1.Value += 1;
                LOGGER.WriteLog($"编辑器控件已准备就绪。\n字体: {tmpEditorHtml.FontFamily}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                LOGGER.WriteLog("编辑器控件方法入口已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                tmpEHostHtml.Child = tmpEditorHtml;
                tmpEHostMd.Child = tmpEditorMd;
                var resourceName = XshdFilePath + "\\HTML.xshd";
                using (Stream s = new FileStream(resourceName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                {
                    using XmlTextReader reader = new(s);
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    tmpEditorHtml.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }
                bBox.uiProcessBar1.Value += 1;
                Microsoft.Web.WebView2.WinForms.WebView2 webView = new();
                webView.SuspendLayout();
                webView.Size = elementHost1.Size;
                await webView.EnsureCoreWebView2Async();
                webView.BackColor = this.BackColor;
                webView.ForeColor = this.ForeColor;
                webView.ResumeLayout(false);
                webView.PerformLayout();
                bBox.uiProcessBar1.Value += 1;

                newTab.Tag = new Dictionary<WebView2, TextEditor>() { { webView, tmpEditorHtml } };
                tableMd.Controls.Add(tmpEHostMd);
                tableMd.Controls.Add(tmpEHostHtml);
                tableMd.Controls.Add(webView);
                newTab.Controls.Add(tableMd);
                tmpEditorMd.Load(fileName);
                tmpEditorMd.TextChanged += new EventHandler(this.TextAreaMarkdownEntered);
                var mdDoc = Markdown.ToHtml(tmpEditorMd.Text);
                await webView.ExecuteScriptAsync($"document.body.style.backgroundColor = '{tabPage1.BackColor.ToHTML()}';");
                await webView.ExecuteScriptAsync($"document.body.style.foregroundColor = '{tabPage1.ForeColor.ToHTML()}';");
                webView.CoreWebView2.NavigateToString(mdDoc);
                webView.DoubleBuffered();
                tmpEditorHtml.Text = mdDoc;
                bBox.Close();
                tmpEditorMd.Text.Append<char>('\n');
                tabControl1.TabPages.Add(newTab);
                tabControl1.SelectedTab = newTab;
                WorkingIcon.Visible = false;
                CurrentWorkTip.Visible = false;
            }
            #endregion
            #region 普通文件
            else
            {
                foreach (TabPage tab in tabControl1.TabPages)
                {
                    if (tab.Text == tmp)
                    {
                        tabControl1.SelectedTab = tab;
                        return;
                    }
                }
                TableLayoutPanel table = new()
                {
                    ColumnCount = 1,
                    Dock = DockStyle.Fill,
                    Location = new System.Drawing.Point(0, 0),
                    Name = "tableLayoutPanel2",
                    RowCount = 1,
                    Size = new System.Drawing.Size(858, 299),
                    TabIndex = 0,
                };
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName, BackColor = tabPage1.BackColor };
                ElementHost tmpEHost = new()
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor,
                };
                table.Controls.Add(tmpEHost);
                TextEditor tmpEditor = new()
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new FontFamily("Consolas"),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    ShowLineNumbers = true,
                };
                tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
                tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
                tmpEditor.DocumentChanged += Edit_DocumentChanged;
                //快速搜索功能
                SearchPanel.Install(tmpEditor.TextArea);
                var file = AutoGetLanguage(newTab.Text);
                using (Stream s = new FileStream(XshdFilePath + $"\\{file}.xshd", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                {
                    using XmlTextReader reader = new(s);
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }
                tmpEHost.Child = tmpEditor;
                newTab.Controls.Add(table);
                newTab.ToolTipText = @openFileDialog1.FileName;
                tabControl1.TabPages.Add(newTab);
                tmpEditor.Load(@openFileDialog1.FileName);
                tabControl1.SelectedTab = newTab;
            }
            #endregion
        }
        #endregion
        #region 获取文件名
        public static string GetFileName(string path)
        {
            // 使用 LastIndexOf 方法查找最后一个路径分隔符的索引
            var lastSeparatorIndex = path.LastIndexOf('\\');

            // 如果找到了路径分隔符，则提取文件名
            if (lastSeparatorIndex >= 0)
            {
                return path.Substring(lastSeparatorIndex + 1);
            }

            // 如果没有找到路径分隔符，则返回整个字符串作为文件名（假设输入字符串本身就是文件名）
            return path;
        }
        #endregion
        #region 创建PyCN文件缓存文件夹，以便更好地清除
        private void SetPyCNFileCache(string fileName)
        {
            //CacheWriter.WriteLine(fileName);
        }
        #endregion
        #region
        private void GetExceptionHelp(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count != 0)
            {
                var SelectedItem = listView1.SelectedItems[0];
                if (SelectedItem != null)
                {
                    var SelectedSubItems = SelectedItem.SubItems;
                    if (SelectedSubItems != null)
                    {
                        var lang = GlobalSettings.language;
                        switch (lang)
                        {
                            case "zh-CN":
                                Process.Start(SearchEngines[Engines.SIMPLIFIED_CHINESE].Replace("{text}", SelectedSubItems[0].Text).Replace("{desc}", SelectedSubItems[1].Text));
                                break;
                            case "zh-TD":
                                if (MessageBoxEX.Show("Please select the search engine: ", "Info", MessageBoxButtons.OKCancel, new string[] { "Google", "Bing" }) == DialogResult.OK)
                                {
                                    Process.Start(SearchEngines[Engines.TRADITIONAL_CHINESE_GLOBAL].Replace("{text}", SelectedSubItems[0].Text).Replace("{desc}", SelectedSubItems[1].Text));
                                }
                                else
                                {
                                    Process.Start(SearchEngines[Engines.TRADITIONAL_CHINESE_CHINA].Replace("{text}", SelectedSubItems[0].Text).Replace("{desc}", SelectedSubItems[1].Text));
                                }
                                break;
                            case "ja-JP":
                                Process.Start(SearchEngines[Engines.JAPANESE].Replace("{text}", SelectedSubItems[0].Text).Replace("{desc}", SelectedSubItems[1].Text));
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        LOGGER.WriteErrLog(new NullReferenceException("SelectedSubItems为null。"), EnumMsgLevel.WARN, EnumPort.CLIENT);
                    }
                }
                else
                {
                    LOGGER.WriteErrLog(new NullReferenceException("SelectedItem为null。"), EnumMsgLevel.WARN, EnumPort.CLIENT);
                }
            }
        }
        #endregion
        #region 获取当前所呈现的TextEditor
        private TextEditor GetCurrentTextEditor()
        {
            try
            {
                var tmpETable = tabControl1.SelectedTab.Controls[0] as TableLayoutPanel;
                if (tmpETable.Controls[0] is not null)
                {
                    return ((tmpETable.Controls[0] as ElementHost).Child as TextEditor);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region 布置TextEditor
        private void LayoutTextEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {

            var tmpETable = tabControl1.SelectedTab.Controls[0] as TableLayoutPanel;
            var CurrentEdtior = GetCurrentTextEditor();
            if (CurrentEdtior is not null)
            {
                CurrentEdtior.Width = tmpETable.Controls[0].Width;
                CurrentEdtior.Height = tmpETable.Controls[0].Height;
            }
        }
        #endregion
        #region 配置运行器
        private void ConfigRunners(object sender, EventArgs e)
        {
            new InterpreterConfigBox(Program.STARTUP_PATH + "\\config\\runners\\test.icbconfig");
        }
        #endregion
        #region 检查&下载更新
        private async Task UpdateCheckAsync()
        {
            var uc = new UpdateChecker();
            await uc.InitAsync();
            await uc.DownloadTestAsync();
            await uc.DownloadUpdateFileAsync();
            uc.AnalyzeUpdateFile();
            uc.ValidateUpdate();
        }

        private async void DownloadUpdate(object sender, EventArgs e)
        {
            var ubd = new UpdateBackgroundDownloader();
            toolStripStatusLabel12.Enabled = false;
            await ubd.DownloadUpdateAsync();
            DeployUpdate();
        }

        private void DeployUpdate()
        {
            while (GlobalDefinitions.CanDeployUpdate & !GlobalDefinitions.UpdateDeployed)
            {
                toolStripStatusLabel12.Enabled = true;
                var ugd = new UpdateGlobalDeployer();
                ugd.DeployUpdate();
            }
        }
        #endregion
        #region extern模块
        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("User32.dll ", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);//关键方法
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendMessage(IntPtr HWnd, uint Msg, int WParam, int LParam);
        public const int WM_SYSCOMMAND = 0x112;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const uint WM_SYSCOMMAND2 = 0x0112;
        public const uint SC_MAXIMIZE2 = 0xF030;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        #endregion
        #endregion
    }
}
