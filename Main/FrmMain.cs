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
using Sunny.UI;
using TextEditor = ICSharpCode.AvalonEdit.TextEditor;
using Engines = IDE.ErrorMessageBox.Engines;
using Markdig;
using Microsoft.Web.WebView2.WinForms;
using System.Threading.Tasks;
using IDE.Init;
using IDE.Utils.Update;
using System.Drawing;
using System.Web.UI.WebControls;
#endregion

namespace IDE
{

    public partial class FrmMain : Form
    {

        #region 一堆变量和常量
        private Utils.PackageManagerMain _pmm = new();
        private Utils.PythonPackageManagerMain _ppmm = new();
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
        internal FrmMsgBox msgBox;
        internal UpdateBackgroundDownloader activeubd;
        internal static string XshdFilePath;
        internal static readonly Dictionary<Engines, string> SearchEngines = new()
        {
            { Engines.SIMPLIFIED_CHINESE, "https://cn.bing.com/search?q=Python+{text}+{desc}"},
            { Engines.TRADITIONAL_CHINESE_CHINA, "https://www.bing.com/search?q=Python+{text}+{desc}"},
            { Engines.TRADITIONAL_CHINESE_GLOBAL, "https://www.google.com/search?q=Python+{text}+{desc}"},
            { Engines.JAPANESE, "https://www.google.com/search?q=Python+{text}+{desc}"},
        };
        public const string VERSION = "0.1.0";
        public const string FRIENDLY_VER = "0.1.0-rc.64";
        public const int MAJOR_VER = 0;
        public const int MINOR_VER = 1;
        public const int MICRO_VER = 0;
        public const string REVISION = "rc";
        public static readonly LogUtil LOGGER = new(Environment.CurrentDirectory + $"\\logs\\{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}.log");
        public string text_tsl2;
        public static FrmMain instance;
        #endregion
        #region 一堆方法
        #region 构造函数
        /// <summary>
        /// Common
        /// </summary>
        public FrmMain()
        {
            try
            {
                InitializeComponent();
                InitializeTranslation();
                CheckForIllegalCrossThreadCalls = false;
                proc = Process.GetCurrentProcess();
                msgBox = new(FrmMsgBox.MsgType.Normal, "", this);
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
        public FrmMain(string file)
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
                FontFamily = new System.Windows.Media.FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
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
            uiTabControl1.TabPages.Clear();
            uiTabControl1.TabPages.Add(ErrorAndExceptionsPage);
            //快速搜索功能
            SearchPanel.Install(edit.TextArea);
            using (Stream s = new FileStream(XshdFilePath + "\\Py-CN.xshd", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                edit.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
            tabPage1.Hide();
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabPage3);
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
            var isAutoOpen = false;
            try
            {
                isAutoOpen = (bool)sender;
            }
            catch { }
            if (isAutoOpen)
            {
                var tmp = @openFileDialog1.FileName.Split('\\')[@openFileDialog1.FileName.Split('\\').Length - 1];
                foreach (TabPage tab in tabControl1.TabPages)
                {
                    if (tab.Text == tmp)
                    {
                        tabControl1.SelectedTab = tab;
                        return;
                    }
                }
                TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName, BackColor = tabPage1.BackColor };
                ElementHost tmpEHost = new()
                {
                    Size = new Size(1052, 399),
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor,
                    Dock = DockStyle.Fill,
                };
                TextEditor tmpEditor = new()
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new System.Windows.Media.FontFamily("Consolas"),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    ShowLineNumbers = true,
                    VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    IsReadOnly = true,
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
                newTab.Controls.Add(tmpEHost);
                newTab.ToolTipText = @openFileDialog1.FileName;
                tabControl1.TabPages.Add(newTab);
                tmpEditor.Load(@openFileDialog1.FileName);
                if (tmpEditor.Text.IsNullOrEmpty())
                {
                    tmpEditor.Text = """
                        # RYCB Editor Welcome Python Srcipt V 1.0

                        def main() -> None:
                            print("Hello, RYCB Editor!")
                            return None

                        if __name__ == "__main__":
                            main()
                        """;
                }
                tabControl1.SelectedTab = newTab;
            }
            else if (openFileDialog1.ShowDialog() == DialogResult.OK)
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
        }
        #endregion
        #region 关于
        private void AboutThis(object sender, EventArgs e)
        {
            LOGGER.WriteLog("即将打开“关于”窗口。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            FrmAbout form = new();
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
            var nf = new FrmNewFileBox("输入文件名");
            LOGGER.WriteLog("新建文件", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            var _ds = nf.ShowDialog(this);
            var fileName = nf.GetFileName();
            if (string.IsNullOrEmpty(fileName) || nf.GetStatus() == FrmNewFileBox.FileStatus.Failed)
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
                FrmWBBox bBox = new(0, false, 5);
                bBox.Show();
                TableLayoutPanel tableMd = new()
                {
                    ColumnCount = 3,
                    Dock = DockStyle.Fill,
                    Location = new Point(0, 0),
                    Name = "tableLayoutPanel2",
                    RowCount = 1,
                    Size = new Size(858, 299),
                    TabIndex = 0,
                    BackColor = System.Drawing.Color.Transparent,
                };
                bBox.uiProcessBar1.Value += 1;
                tableMd.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0F));
                tableMd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
                tableMd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
                tableMd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
                bBox.uiProcessBar1.Value += 1;
                var tmpEHostMd = new ElementHost
                {
                    Size = new Size(1052, 399),
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor,
                    Dock = DockStyle.Fill,
                };
                var tmpEHostHtml = new ElementHost
                {
                    Size = new Size(1052, 399),
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor,
                    Dock = DockStyle.Fill,
                };
                LOGGER.WriteLog("ElementHostForMarkdown已准备就绪。");
                bBox.uiProcessBar1.Value += 1;
                var tmpEditorMd = new TextEditor
                {
                    Width = tmpEHostMd.Width,
                    Height = tmpEHostMd.Height,
                    FontFamily = new System.Windows.Media.FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
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
                    FontFamily = new System.Windows.Media.FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
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
                WebView2 webView = new();
                webView.SuspendLayout();
                webView.Size = new Size(1052, 399);
                webView.Dock = DockStyle.Fill;
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
                var tmpEHost = new ElementHost
                {
                    Size = new Size(1052, 399),
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor,
                    Dock = DockStyle.Fill,
                };
                LOGGER.WriteLog("ElementHost已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);

                var tmpEditor = new TextEditor
                {
                    Width = tmpEHost.Width,
                    Height = tmpEHost.Height,
                    FontFamily = new System.Windows.Media.FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
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
                tab.Controls.Add(tmpEHost);
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
            var _editor = GetCurrentTextEditor();
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
        }

        private string GetFileNameFromPath(string path)
        {
            return path.Split('\\').Last();
        }

        #endregion
        #region 自定义设置
        private void CustomSet(object sender, EventArgs e)
        {
            Form cs = new FrmCustomSettings(STARTUP_PATH + "\\config")
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
                        SetForegroundWindow(RunnerProc.Handle);
                    }
                    else if (tabControl1.SelectedTab.ToolTipText.Contains(".py"))
                    {
                        if (!GetCurrentTextEditor().Text.Contains("import turtle"))
                        {
                            var error = RunPythonSrcipt(tabControl1.SelectedTab.ToolTipText)[1];
                            if (error != "")
                            {
                                errMsgBox = new(error, GetCurrentTextEditor(), this);
                                errMsgBox.Show();
                                return;
                            }
                        }

                        RunnerProc = Process.Start(".\\Runner.exe", tabControl1.SelectedTab.ToolTipText);
                        SetForegroundWindow(RunnerProc.Handle);
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
                            SetForegroundWindow(RunnerProc.Handle);
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
                            SetForegroundWindow(RunnerProc.Handle);
                        }
                        return;
                    }
                    else if (@tabControl1.SelectedTab.ToolTipText.Contains("exe"))
                    {
                        SetForegroundWindow(Process.Start(@tabControl1.SelectedTab.ToolTipText).Handle);
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
                        SetForegroundWindow(RunnerProc.Handle);
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
                            WindowStyle = ProcessWindowStyle.Normal,
                            ErrorDialog = true,
                        };
                        LOGGER.WriteLog("ProcessStartInfo对象已创建。", EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.MAIN);
                        LOGGER.WriteLog(string.Format("ProcessStartInfo对象属性：FileName={0}, Arguments={1}", ps.FileName, ps.Arguments), EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.MAIN);
                        Process p = new() { StartInfo = ps };
                        LOGGER.WriteLog("Process对象已创建。", EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.MAIN);
                        p.Start();
                        RunnerProc = p;
                        LOGGER.WriteLog("Process对象是否已运行：" + (p.StartTime != null), EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.MAIN);
                        SetForegroundWindow(RunnerProc.Handle);
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
            TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName };
            if (tmp != "md" || tmp != "dmp" || tmp != "dump" || tmp != "minidump")
            {

                ElementHost tmpEHost = new()
                {
                    Size = new Size(1052, 399),
                    Location = elementHost1.Location,
                    Dock = DockStyle.Fill,
                };
                var tmpEditor = new TextEditor
                {
                    Width = tmpEHost.Width,
                    Height = tmpEHost.Height,
                    FontFamily = new System.Windows.Media.FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    FontSize = reConf.ReadInt("Editor", "Size"),
                    ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                    VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                    IsReadOnly = true,
                };
                var file = AutoGetLanguage(newTab.Text);
                using (Stream s = new FileStream(XshdFilePath + $"\\{file}.xshd", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                {
                    using XmlTextReader reader = new(s);
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }
                tmpEHost.Child = tmpEditor;
                newTab.Controls.Add(tmpEHost);
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
            if (tabControl1.TabPages.Count == 1)
            {
                return;
            }
            var si = tabControl1.SelectedIndex;
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
            else if (tab.Equals(tabPage3))
            {
                if (tabControl1.TabPages.Count == 1)
                {
                    return;
                }
                tabControl1.SelectedIndex = si;
            }
            else
            {
                try
                {
                    var webView = (tabControl1.SelectedTab.Tag as Dictionary<WebView2, TextEditor>).Keys.ToList()[0];
                    webView?.Dispose();
                }
                catch { }
                tabControl1.SelectedIndex = si;
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
            FrmCodeSettings cc = new();
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
            new FrmLicenseAndCopyrights().Show();
        }
        #endregion
        #region 检查语法错误
        private void CheckSyntaxError(object sender, EventArgs e)
        {
            if (!tabControl1.SelectedTab.Text.EndsWith(".py")) { return; }
            listView1.Items.Clear();
            var editor = GetCurrentTextEditor();
            if (editor is null) { return; }
            var content = editor.Text; if (content.IsNullOrEmpty()) return;
            var res = PythonSyntaxErrorChecker.SyntaxCheck(content).Split("\r\n");
            if (res.Length == 1 & res[0] == "Find No Error.") { res = []; }
            var _res = PythonErrorAnalyzer.AnalyzePythonFile(content);
            var tmpExs = new List<System.Windows.Forms.ListViewItem>();
            for (; _i < res.Length; _i++)
            {
                var tmpEx = new System.Windows.Forms.ListViewItem("[ERROR]", imageKey: "EII")
                {
                    Text = "   ",
                };
                tmpExs.Add(tmpEx);
            }
            for (var i = 0; i < tmpExs.Count; i++)
            {
                tmpExs[i].SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem() { Text = "" });
                tmpExs[i].SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem() { Text = res[i].Between("|Ls-", "-Le|") });
                tmpExs[i].SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem() { Text = res[i].Between("|Ds-", "-De|") });
            }
            foreach (var item in _res)
            {
                var tmpEx = new System.Windows.Forms.ListViewItem("[ERROR]", imageKey: "EII")
                {
                    Text = "   ",
                };
                tmpEx.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem()
                {
                    Text = item["Type"]
                });
                if (item["Type"].Contains("Exception") || item["Type"].Contains("Error"))
                {
                    tmpEx.ImageKey = "exception";
                }
                tmpEx.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem()
                {
                    Text = item["Desc"]
                });
                tmpEx.SubItems.Add(new System.Windows.Forms.ListViewItem.ListViewSubItem()
                {
                    Text = item["Line"]
                });
                tmpExs.Add(tmpEx);
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
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                LOGGER.WriteLog("Stopped by Patch Applyer", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                keepFile.WriteLine(long.MaxValue);
                keepFile.Close();
                Process.GetCurrentProcess().Kill();
                e.Cancel = false;
            }
            else
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
            // ClearTemporaryCompletion();

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
            var _editor = GetCurrentTextEditor();
            tmpCompletionStr += text;
            LOGGER.WriteLog($"tmpCompletionStr: {tmpCompletionStr}; text: {text}", EnumMsgLevel.DEBUG);
            if (text[0] == ' ')
            {
                LOGGER.WriteLog($"[MATCHED TEXT[0]=BLANK tmpCompletionStr: {tmpCompletionStr}; text: {text}", EnumMsgLevel.DEBUG);
                tmpCompletionStr = "";
            }
            else if (!text[0].IsLetterOrDigit())
            {
                LOGGER.WriteLog($"[MATCHED ISNTLETTERORDIGIT] tmpCompletionStr: {tmpCompletionStr}; text: {text}", EnumMsgLevel.DEBUG);
                tmpCompletionStr = "";
            }
            else if (_regex_unclosedstring.IsMatch(GetLineInTextEditor(_editor, text)) & !_regex_closedstring.IsMatch(GetLineInTextEditor(_editor, text)))
            {
                tmpCompletionStr = "";
                LOGGER.WriteLog($"[MATCHED UNCLOSED STRING] tmpCompletionStr: {tmpCompletionStr}; text: {text}", EnumMsgLevel.DEBUG);
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
                var _fields = new List<string>();
                var tmp = tabControl1.SelectedTab.Text;
                var lang = AutoGetLanguage(tmp, false);
                var _tmpfilepath = (string)tabControl1.SelectedTab.Tag;
                switch (lang)
                {
                    case "Python":
                        _keywords = LangKeywords.Keywords.python;
                        _specialdefs = LangKeywords.SpecialDefs.python;
                        _builtins = LangKeywords.BulitIns.py;
                        _fields.AddRange(new PythonVariableAnalyzer(GetCurrentTextEditor().Text).Process());
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
            //Graphics g = this.tabControl1.SelectedTab.CreateGraphics();
            //SizeF s = g.MeasureString(this.tabControl1.SelectedTab.Text, this.tabControl1.SelectedTab.Font);
            //tabControl1.ItemSize = s.Size();
            SizeController.Start();
        }

        private bool TabControl1_BeforeRemoveTabPage(object sender, int index)
        {
            var si = tabControl1.SelectedIndex;
            var tab_count = tabControl1.TabPages.Count;
            var tab = tabControl1.SelectedTab;
            if (tab_count == 1)
            {
                tabControl1.SelectedIndex = si;
                var editor = GetCurrentTextEditor();
                tab.Text = _I18nFile.Read("I18n", "text.tc.tp.tmp", "text.tc.tp.tmp");
                editor.Text = "";
                return false;
            }
            else if (tab.Equals(tabPage3))
            {
                if (tabControl1.TabPages.Count == 1)
                {
                    return false;
                }
                tabControl1.SelectedIndex = si;
            }
            else
            {
                tab.Controls[0].Dispose();
                tab.Controls.Clear();
                tab.Dispose();
            }
            return true;
        }

        private void OpenUsrTutorial(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var d = Program.STARTUP_PATH + "/Tools/UserTutorial_l" + reConf.Read("General", "Language", "zh-CN") + ".html";
            Process.Start(d);
        }

        private void CreatePySample(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.FileName = Program.STARTUP_PATH + "\\Tools\\Hello.py";
            OpenFile(true, e);
        }

        private void OpenFirstBoot(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmFirstBootStep1().ShowDialog();
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
            this.Location = new Point(1, 1);
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
            this.TopMost = true;
            Program.splash.metroProgressBar1.PerformStep();
            this.WindowState = FormWindowState.Maximized;
            Program.splash.metroProgressBar1.Value = Program.splash.metroProgressBar1.Maximum;
            this.Show();
            Program.splash.Hide();
            Program.splash.Close();
            this.Show();
            this.Focus();
            this.TopMost = false;
            var isFirstBoot = reConf.ReadBool("FirstBoot", "IsFirstBoot");
            if (isFirstBoot) { new FrmFirstBootStep1().ShowDialog(); }
            await UpdateCheckAsync();
        }

        private void ForceExit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private new void Layout(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == null) { return; }
            //if (tabControl1.SelectedTab.Text.Length >= 32)
            //{
            //    tabControl1.ItemSize = new System.Drawing.Size(500, tabControl1.ItemSize.Height);
            //}
            //else if (tabControl1.SelectedTab.Text.Length >= 16)
            //{
            //    tabControl1.ItemSize = new System.Drawing.Size(350, tabControl1.ItemSize.Height);
            //}
            //else if (tabControl1.SelectedTab.Text.Length >= 8)
            //{
            //    tabControl1.ItemSize = new System.Drawing.Size(200, tabControl1.ItemSize.Height);
            //}
            //else
            //{
            //    tabControl1.ItemSize = new System.Drawing.Size(100, tabControl1.ItemSize.Height);
            //}
            //Graphics g = this.tabControl1.SelectedTab.CreateGraphics();
            //SizeF s = g.MeasureString(this.tabControl1.SelectedTab.Text, this.tabControl1.SelectedTab.Font);
            //tabControl1.ItemSize = s.Size();
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
            new FrmTBox().Show();
        }
        #endregion
        #region 界面调整
        private void Validating_Layout(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Layout(sender, new TabControlEventArgs(tabControl1.SelectedTab, tabControl1.SelectedIndex, TabControlAction.Selecting));
        }

        private new void Layout(object sender, EventArgs e)
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
            new FrmThanks().Show();
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
            //Graphics g = this.tabControl1.SelectedTab.CreateGraphics();
            //SizeF s = g.MeasureString(this.tabControl1.SelectedTab.Text, this.tabControl1.SelectedTab.Font);
            //tabControl1.ItemSize = s.Size();
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
                editor.ScrollToLine(Convert.ToInt32(listView1.CheckedItems[0].SubItems[2].Text));
            }
        }
        #endregion
        #region 包管理
        private void OpenPkgMgmt(object sender, EventArgs e)
        {
            _pmm.Show();
        }
        private void PythonPkgMgmt(object sender, EventArgs e)
        {
            _ppmm.Show();
        }
        private void Reset(object sender, EventArgs e)
        {
            if (MessageBox.Show(_I18nFile.Localize("tip.reboottoapply"), "Tip", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                Extensions.DecompressFile(Program.STARTUP_PATH + "/Package/Reset/InitialDirectory.7z", Program.STARTUP_PATH + "/Cache/InitialDirectory");
                File.WriteAllText(Program.STARTUP_PATH + "/Tools/InitialDirectory.path", Program.STARTUP_PATH + "/Cache/InitialDirectory");
                File.Copy(Program.STARTUP_PATH + "/Package/Reset/package.info", Program.STARTUP_PATH + "/Cache/InitialDirectory/package.info", true);
                Process.Start(new ProcessStartInfo() { Arguments = $"{Program.STARTUP_PATH + "/Tools/InitialDirectory.path"} F:/VSProj/repos/IDE-PatchApplyer/bin/Debug", FileName = Program.STARTUP_PATH + "/Tools/IDE-PatchApplyer.exe" });
                ExitByClosing(sender, new FormClosingEventArgs(CloseReason.ApplicationExitCall, false));
            }
        }
        #endregion
        #region 清理缓存
        private void ClearCache(object sender, EventArgs e)
        {
            new FrmCacheCleaner().Show();
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
                FrmWBBox bBox = new(0, false, 5);
                bBox.Show();
                TableLayoutPanel table = new()
                {
                    ColumnCount = 1,
                    Dock = DockStyle.Fill,
                    Location = new Point(0, 0),
                    Name = "tableLayoutPanel" + DateTime.Now.Millisecond,
                    RowCount = 1,
                    Size = new Size(858, 299),
                    TabIndex = 0,
                };
                bBox.uiProcessBar1.Value += 1;
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 50.00F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.00F));
                ElementHost tmpEHost = new()
                {
                    Size = new Size(1052, 399),
                    Location = elementHost1.Location
                };
                table.Controls.Add(tmpEHost, 0, 0);
                bBox.uiProcessBar1.Value += 1;
                var tmpEditor = new TextEditor
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new System.Windows.Media.FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
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
                FrmWBBox bBox = new(0, false, 5);
                bBox.Show();
                TableLayoutPanel table = new()
                {
                    ColumnCount = 2,
                    Dock = DockStyle.Fill,
                    Location = new Point(0, 0),
                    Name = "tableLayoutPanel" + DateTime.Now.Millisecond,
                    RowCount = 1,
                    Size = new Size(858, 299),
                    TabIndex = 0,
                };
                bBox.uiProcessBar1.Value += 1;
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 50.00F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
                ElementHost tmpEHostForRawData = new()
                {
                    Size = new Size(1052, 399),
                    Location = elementHost1.Location
                }; ElementHost tmpEHostForStringData = new()
                {
                    Size = new Size(1052, 399),
                    Location = elementHost1.Location
                };
                table.Controls.Add(tmpEHostForRawData, 0, 0);
                table.Controls.Add(tmpEHostForStringData, 1, 0);
                bBox.uiProcessBar1.Value += 1;
                var tmpEditorForRawData = new TextEditor
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new System.Windows.Media.FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
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
                    FontFamily = new System.Windows.Media.FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
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

                TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName };
                FrmWBBox bBox = new(0, false, 5);
                bBox.Show();
                TableLayoutPanel tableMd = new()
                {
                    ColumnCount = 3,
                    Dock = DockStyle.Fill,
                    Location = new Point(0, 0),
                    Name = "tableLayoutPanel2",
                    RowCount = 1,
                    Size = new Size(858, 299),
                    TabIndex = 0,
                };
                bBox.uiProcessBar1.Value += 1;
                tableMd.RowStyles.Add(new RowStyle(SizeType.Percent, 100.00F));
                tableMd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
                tableMd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
                tableMd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
                bBox.uiProcessBar1.Value += 1;
                var tmpEHostMd = new ElementHost
                {
                    Size = new Size(1052, 399),
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor
                }; var tmpEHostHtml = new ElementHost
                {
                    Size = new Size(1052, 399),
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
                    FontFamily = new System.Windows.Media.FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
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
                    FontFamily = new System.Windows.Media.FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
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
                WebView2 webView = new();
                webView.SuspendLayout();
                webView.Size = new Size(1052, 399);
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
                tmpEditorMd.Text.Append('\n');
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
                TabPage newTab = new()
                {
                    Text = tmp,
                    ToolTipText = openFileDialog1.FileName,
                    BackColor = tabPage1.BackColor
                };

                ElementHost tmpEHost = new()
                {
                    Dock = DockStyle.Fill,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor,
                };

                TextEditor tmpEditor = new()
                {
                    FontFamily = new System.Windows.Media.FontFamily("Consolas"),
                    Background = new SolidColorBrush(Editor.Back),
                    Foreground = new SolidColorBrush(Editor.Fore),
                    ShowLineNumbers = true,
                };

                tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
                tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
                tmpEditor.DocumentChanged += Edit_DocumentChanged;

                // 快速搜索功能
                SearchPanel.Install(tmpEditor.TextArea);

                var file = AutoGetLanguage(newTab.Text);
                using (Stream s = new FileStream(XshdFilePath + $"\\{file}.xshd", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                {
                    using XmlTextReader reader = new(s);
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }

                tmpEHost.Child = tmpEditor;
                newTab.Controls.Add(tmpEHost);
                newTab.ToolTipText = openFileDialog1.FileName;
                tabControl1.TabPages.Add(newTab);
                tmpEditor.Load(openFileDialog1.FileName);
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
        private void CIT(object sender, EventArgs e)
        {
            InfoTip.Visible = false;
            CloseInfoTip.Visible = false;
        }

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
                var tmpEHost = tabControl1.SelectedTab.Controls[0] as ElementHost;
                if (tmpEHost is not null) return tmpEHost.Child as TextEditor;
            }
            catch
            {
                return null;
            }
            return null;
        }
        #endregion
        #region 配置运行器
        private void ConfigRunners(object sender, EventArgs e)
        {
            new FrmInterpreterConfigBox(Program.STARTUP_PATH + "\\config\\runners\\").Show();
        }
        #endregion
        #region 更新
        private async Task UpdateCheckAsync()
        {
            var uc = new UpdateChecker();
            LOGGER.WriteLog("开始检查更新。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
            await uc.InitAsync();
            LOGGER.WriteLog("UpdateChecker初始化完毕。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
            LOGGER.WriteLog("下载测试文件。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
            await uc.DownloadTestAsync();
            LOGGER.WriteLog("下载更新配置文件。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
            await uc.DownloadUpdateFileAsync();
            LOGGER.WriteLog("分析更新配置文件。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
            uc.AnalyzeUpdateFile();
            LOGGER.WriteLog("验证更新。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
            uc.ValidateUpdate();
            if (GlobalDefinitions.CanUpdate)
            {
                UpdateIcon.Visible = true;
                CanUpdateIcon.Visible = true;
                UpdateIconsSeparator.Visible = true;
                NewUpdateTip.Visible = true;
                DownloadUpdateButton.Visible = true;
            }
        }

        private async void DownloadUpdate(object sender, EventArgs e)
        {
            UpdateStatusBar.Show();
            activeubd = new UpdateBackgroundDownloader();
            DownloadUpdateButton.Enabled = false;
            LOGGER.WriteLog("下载更新文件。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
            await activeubd.DownloadUpdateAsync();
            if (activeubd.downloader.IsCancelled)
            {
                return;
            }
            LOGGER.WriteLog("开始部署更新。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
            DeployUpdate();
        }

        private async void DeployUpdate()
        {
            double i = 0;
            while (!GlobalDefinitions.CanDeployUpdate & !GlobalDefinitions.UpdateDeployed)
            {
                i += 0.01;
                if (i % 1 == 0)
                {
                    LOGGER.WriteLog("等待开始更新：次数" + i.ToString(), EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
                }
            }
            var ugd = new UpdateGlobalDeployer();
            LOGGER.WriteLog("正在部署更新。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
            ugd.DeployUpdate();
            LOGGER.WriteLog("更新部署完成。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
            while (!GlobalDefinitions.UpdateDeployed)
            {
                i += 0.1;
                if (i % 1 == 0)
                {
                    LOGGER.WriteLog("等待验证更新：次数" + i.ToString(), EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
                }
            }
            UpdateValidater uv = new();
            LOGGER.WriteLog("正在验证更新。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
            await uv.ValidateFileAsync();
            if (MessageBox.Show(_I18nFile.Localize("tip.reboottoapply"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                Process.Start(new ProcessStartInfo() { Arguments = $"{GlobalDefinitions.DecompressedUpdateArchive_Path} {Program.STARTUP_PATH}", FileName = Program.STARTUP_PATH + "/Tools/IDE-PatchApplyer.exe" });
                ExitByClosing(this, new FormClosingEventArgs(CloseReason.ApplicationExitCall, false));
            }
        }

        private void StopDownload(object sender, EventArgs e)
        {
            LOGGER.WriteLog("Try to cancel update task.", EnumMsgLevel.INFO, EnumPort.SERVER, EnumModule.UPDATE);
            activeubd.downloader.CancelAsync();
            if (activeubd.downloader.IsCancelled)
            {
                UpdateCancelledTip.Visible = true;
                LOGGER.WriteLog("Update Cancelled.", EnumMsgLevel.WARN, EnumPort.CLIENT, EnumModule.UPDATE);
                return;
            }
            LOGGER.WriteLog("Fail to cancel update task.", EnumMsgLevel.WARN, EnumPort.SERVER, EnumModule.UPDATE);
        }
        private void CloseUpdateBar(object sender, EventArgs e)
        {
            UpdateStatusBar.Visible = false;
            DownloadUpdateButton.Enabled = true;
        }
        #endregion
        #region extern模块
        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("User32.dll ", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);//关键方法
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendMessage(IntPtr HWnd, uint Msg, int WParam, int LParam);
        public const int WM_SYSCOMMAND = 0x112;public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const uint WM_SYSCOMMAND2 = 0x0112;
        public const uint SC_MAXIMIZE2 = 0xF030;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        #endregion
        #endregion
    }
}
