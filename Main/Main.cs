#region 导入命名空间
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextEditor = ICSharpCode.AvalonEdit.TextEditor;
#endregion

namespace IDE
{
    public partial class Main : Form
    {
        #region 一堆变量和常量
        private static readonly string STARTUP_PATH = Program.STARTUP_PATH;
        private static readonly IniFile reConf = Program.reConf;
        private static readonly Stopwatch stopwatch = new();
        private string title = "选择文件：";
        private static StreamWriter keepFile;
        private string LightEdit_File;
        private bool NoTip, isModified = false, LightEdit = false;
        private TextEditor edit;
        private int tmp_;
        internal static string XshdFilePath;
        public const string VERSION = "0.0.1";
        public const string FRIENDLY_VER = "0.0.1a_dev+4";
        public static readonly LogUtil LOGGER = new(Environment.CurrentDirectory + $"\\logs\\{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}.log");
        public string text_tsl2;
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
            ClearLog();
            edit = new TextEditor()
            {
                Width = elementHost1.Width,
                Height = elementHost1.Height,
                FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x2B, 0x2D, 0x30)),
                Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xA9, 0xB7, 0xC6)),
                FontSize = reConf.ReadInt("Editor", "Size", 12),
                ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
            };
            edit.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
            edit.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
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
                string tmp = @openFileDialog1.FileName.Split('\\')[@openFileDialog1.FileName.Split('\\').Length - 1];
                string _ = tmp.Split('.')[tmp.Split('.').Length - 1];
                if (tmp.Equals("BOOTMGR", StringComparison.CurrentCultureIgnoreCase))
                {
                    toolStripStatusLabel2.Text = "Windows NT " + _I18nFile.ReadString("I18n", "text.inprogram.bootfile", "text.inprogram.bootfile") + "(.efi|BOOTMGR)" + text_tsl2;
                    string agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + toolStripStatusLabel2.Text + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                    DialogResult dResult = MessageBoxEX.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.warning", "text.inprogram.title.warning"), MessageBoxButtons.YesNo, new string[] { _I18nFile.ReadString("I18n", "text.inprogram.bootfile.2", "text.inprogram.bootfile.2"), _I18nFile.ReadString("I18n", "text.inprogram.bootfile.3", "text.inprogram.bootfile.3") });
                    if (dResult != DialogResult.Yes) { return; }
                    statusStrip1.Show();
                    func_0a1(tmp);
                }
                else
                {
                    CheckFileTypeAndAlert(_, tmp);
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
        private void New(object sender, EventArgs e)
        {
            var nf = new NewFile("输入文件名");
            LOGGER.WriteLog("新建文件", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            DialogResult _ds = nf.ShowDialog(this);
            string fileName = nf.GetFileName();
            if (string.IsNullOrEmpty(fileName) || nf.GetStatus() == NewFile.FileStatus.Failed)
            {
                LOGGER.WriteLog("已取消新建文件。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                return;
            }

            TableLayoutPanel table = new()
            {
                ColumnCount = 1,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Name = "tableLayoutPanel2",
                RowCount = 1,
                Size = new System.Drawing.Size(858, 299),
                TabIndex = 0,
            };
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            TabPage tab = new TabPage
            {
                Text = fileName,
                BackColor = tabPage1.BackColor,
                ForeColor = tabPage1.ForeColor
            };
            LOGGER.WriteLog($"TabPage已准备就绪。\n文件名: {tab.Text}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);

            ElementHost tmpEHost = new ElementHost
            {
                Size = elementHost1.Size,
                Location = elementHost1.Location,
                BackColor = elementHost1.BackColor,
                ForeColor = elementHost1.ForeColor
            };
            table.Controls.Add(tmpEHost, 0, 0);
            LOGGER.WriteLog("ElementHost已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);

            TextEditor tmpEditor = new TextEditor
            {
                Width = elementHost1.Width,
                Height = elementHost1.Height,
                FontFamily = new FontFamily(reConf.ReadString("Editor", "Font", "Consolas")),
                Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x2B, 0x2D, 0x30)),
                Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xA9, 0xB7, 0xC6)),
                FontSize = reConf.ReadInt("Editor", "Size"),
                ShowLineNumbers = bool.Parse(reConf.ReadString("Editor", "ShowLineNum", "true")),
                VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto,
            };
            LOGGER.WriteLog($"编辑器控件已准备就绪。\n字体: {tmpEditor.FontFamily}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
            tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
            LOGGER.WriteLog("编辑器控件方法入口已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);

            // 快速搜索功能
            SearchPanel.Install(tmpEditor.TextArea);

            // 设置语法规则
            LOGGER.WriteLog("正在获取语法规则信息..");
            var tmpLanguage = AutoGetLanguage(tab.Text);
            string resourceName = XshdFilePath + $"\\{tmpLanguage}.xshd";
            LOGGER.WriteLog("语法规则信息获取成功。");
            LOGGER.WriteLog($"语法规则: {tmpLanguage}\t\t对应文件名: {resourceName}");
            using (FileStream s = new FileStream(resourceName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
            LOGGER.WriteLog("语法规则已成功设置。");

            tmpEHost.Child = tmpEditor;
            tab.Controls.Add(table);
            tabControl1.TabPages.Add(tab);
            LOGGER.WriteLog("所有设置均已完成。");
        }
        #endregion
        #region 实时保存
        private void Save(object sender, EventArgs e)
        {
            var _editor = ((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor;
            if (tabControl1.SelectedTab.ToolTipText != null & tabControl1.SelectedTab.ToolTipText != "")
            {
                StreamWriter streamWriter = new(tabControl1.SelectedTab.ToolTipText, false, Encoding.UTF8);
                streamWriter.Write(_editor.Text);
                streamWriter.Close();
            }
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

                    using (StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8))
                    {
                        streamWriter.Write(_editor.Text);
                    }

                    UpdateTabPageInfo(saveFileDialog1.FileName);
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

            if (selectedTab.Controls[0] is not ElementHost elementHost)
            {
                return null;
            }

            return elementHost.Child as TextEditor;
        }

        private string GetTabTitle()
        {
            string fileName = tabControl1.SelectedTab.Text.Replace("*", "");
            return fileName;
        }

        private void UpdateSaveFileDialogFilter()
        {
            string filter;
            string fileName = saveFileDialog1.FileName;

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
                TabPage tab = new TabPage() { Text = GetFileNameFromPath(fileName), ToolTipText = fileName };
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
                if (tabControl1.SelectedTab == tabPage1 && tabPage1.Text != _I18nFile.ReadString(tabPage1.Text, tabPage1.Text, tabPage1.Text))
                {
                    string _tmpFileName = Convert.ToString(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
                    ExecuteCMDWithOutput("mkdir $tmp_code", "cmd.exe", "/s /c");
                    if (tabControl1.SelectedTab.ToolTipText.Contains(".pycn"))
                    {
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = ".\\Compiler.exe",
                            Arguments = tabControl1.SelectedTab.ToolTipText,
                        });
                        Process.Start(".\\Runner.exe", tabControl1.SelectedTab.ToolTipText.RemoveRight(2));
                    }
                    else if (tabControl1.SelectedTab.ToolTipText.Contains(".py"))
                    {
                        Process.Start(".\\Runner.exe", tabControl1.SelectedTab.ToolTipText);
                    }
                }
                else
                {
                    if (tabControl1.SelectedTab.ToolTipText == "" | tabControl1.SelectedTab.ToolTipText is null)
                    {
                        ExecuteCMDWithOutput("mkdir $tmp_code", "cmd.exe", "/s /c");
                        StreamWriter streamWriter = new(Application.StartupPath + "\\$tmp_code\\" + tabControl1.SelectedTab.Text.Split('*')[0], false, Encoding.UTF8);
                        streamWriter.Write((((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor).Text);
                        streamWriter.Close();
                        tabControl1.SelectedTab.ToolTipText = Application.StartupPath + "\\$tmp_code\\" + tabControl1.SelectedTab.Text.Split('*')[0];
                        if (tabControl1.SelectedTab.ToolTipText.Contains(".py"))
                        {
                            Process.Start(".\\Runner.exe", @tabControl1.SelectedTab.ToolTipText);
                        }
                        else if (tabControl1.SelectedTab.ToolTipText.Contains(".pycn"))
                        {
                            ProcessStartInfo tmpSI = new()
                            {
                                FileName = ".\\Compiler.exe",
                                Arguments = @tabControl1.SelectedTab.ToolTipText,
                            };
                            Process.Start(tmpSI);
                            Process.Start(".\\Runner.exe", @tabControl1.SelectedTab.ToolTipText.RemoveRight(2));
                        }
                        return;
                    }
                    if (@tabControl1.SelectedTab.Text.Contains("exe"))
                    {
                        Process.Start(@tabControl1.SelectedTab.ToolTipText);
                    }
                    else if (@tabControl1.SelectedTab.ToolTipText.Contains(".py"))
                    {
                        Process.Start(".\\Runner.exe", @tabControl1.SelectedTab.ToolTipText);
                    }
                    else if (@tabControl1.SelectedTab.ToolTipText.Contains(".pycn"))
                    {
                        ProcessStartInfo tmpSI = new()
                        {
                            FileName = ".\\Compiler.exe",
                            Arguments = @tabControl1.SelectedTab.ToolTipText,
                        };
                        Process.Start(tmpSI);
                        Process.Start(".\\Runner.exe", @tabControl1.SelectedTab.ToolTipText.RemoveRight(2));
                    }
                }
            }
            catch (Exception ex)
            {
                LOGGER.WriteErrLog(ex, EnumMsgLevel.FATAL, EnumPort.CLIENT);
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
            string outpup = process.StandardOutput.ReadToEnd();
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
            string fileName = tabControl1.SelectedTab.Text;
            string extension = Path.GetExtension(fileName).TrimStart('.');

            statusStrip1.Visible = IsSupportedFileExtension(extension);

            int memoryUsage = GetDigitalMemory() - tmp_;
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
                string text = tabControl1.SelectedTab.Text;
                if (!text.Contains("*"))
                {
                    tabControl1.SelectedTab.Text = text + "*";
                }
            }
            catch (NullReferenceException)
            {
                string text = tabControl1.SelectedTab.Text;
                if (!text.Contains("*"))
                {
                    tabControl1.SelectedTab.Text = text + "*";
                }
            }
        }
        #endregion
        #region <FUNC> 占位方法
        private void func_0a1(string tmp)
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
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Name = "tableLayoutPanel2",
                RowCount = 1,
                Size = new System.Drawing.Size(858, 299),
                TabIndex = 0,
            };
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));


            TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName };
            ElementHost tmpEHost = new()
            {
                Size = elementHost1.Size,
                Location = elementHost1.Location
            };
            table.Controls.Add(tmpEHost, 0, 0);
            TextEditor tmpEditor = edit;
            tmpEditor.Text = "";
            //快速搜索功能
            SearchPanel.Install(tmpEditor.TextArea);
            tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
            tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
            using (Stream s = new FileStream(XshdFilePath + $"\\{AutoGetLanguage(newTab.Text)}.xshd", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
            tmpEHost.Child = tmpEditor;
            newTab.Controls.Add(table);
            tabControl1.TabPages.Add(newTab);
            newTab.ToolTipText = openFileDialog1.FileName;
            tmpEditor.Load(@openFileDialog1.FileName);
            tabControl1.SelectedTab = newTab;
        }
        #endregion
        #region <FUNC> 占位方法
        private bool func_0a2(string tssl2Text, string fileDesc)
        {
            toolStripStatusLabel2.Text = tssl2Text + _I18nFile.ReadString("I18n", "text.st.editprohibited", "text.st.editprohibited");
            string agreeText = _I18nFile.ReadString("I18n", "text.inprogram.normalfile.0", "text.inprogram.normalfile.0") + ' ' + fileDesc + _I18nFile.ReadString("I18n", "text.inprogram.normalfile.1", "text.inprogram.normalfile.1");
            DialogResult dResult = MessageBoxEX.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.warning", "text.inprogram.title.warning"), MessageBoxButtons.YesNo, new string[] { _I18nFile.ReadString("I18n", "text.inprogram.bootfile.2", "text.inprogram.bootfile.2"), _I18nFile.ReadString("I18n", "text.inprogram.bootfile.3", "text.inprogram.bootfile.3") });
            if (dResult != DialogResult.Yes) { return false; }
            statusStrip1.Show();
            return true;
        }
        #endregion
        #region 关闭选项卡
        private void CloseFile(object sender, EventArgs e)
        {
            TabPage tab = tabControl1.TabPages[tabControl1.SelectedIndex];
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
            Process proc = Process.GetCurrentProcess();
            long b = proc.PrivateMemorySize64;
            for (int i = 0; i < 2; i++)
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
            HelpButton.Location = new System.Drawing.Point(this.Width - 44, 7);
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
            Process proc = Process.GetCurrentProcess();
            long b = proc.PrivateMemorySize64;
            for (int i = 0; i < 2; i++)
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
        /// <returns>语言类型</returns>
        public static string AutoGetLanguage(string SuffixName)
        {
            SuffixName = '.' + SuffixName;
            LOGGER.WriteLog($"已获取文件名: {SuffixName}");
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

        private void CheckSyntaxError(object sender, EventArgs e)
        {
            TextEditor editor = (tabControl1.SelectedTab.Controls[2] as ElementHost).Child as TextEditor;
            if (tabControl1.SelectedTab.ToolTipText != null)
            {
                string ret = RunPythonSrcipt(tabControl1.SelectedTab.ToolTipText)[1];
                foreach (var item in ret.Split(Environment.NewLine))
                {
                    if (item.Contains("Traceback (most recent call last):"))
                    {

                    }
                }
            }
        }

        private void CheckErr(object sender, EventArgs e)
        {
            if (((UIListBox)sender).SelectedIndex >= 0)
            {
                MessageBox.Show("选择了" + ((UIListBox)sender).SelectedItem, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion
        #region 循环判断：窗体是否处于最大化状态
        private void IsMaximized(object sender, EventArgs e)
        {
            System.Drawing.Point tmp = new(1860, 0);
            if (this.WindowState == FormWindowState.Maximized)
            {
                LOGGER.WriteLog("已点击最大化按钮", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                try
                {
                    #region 注释
                    /*
                    this.tabControl1.Width = originTabControlX + differenceX;
                    this.tabControl1.Height = originTabControlY + differenceY;
                    this.tabPage1.Width = originMetroTabPageX + differenceX;
                    this.tabPage1.Height = originMetroTabPageY + differenceY;
                    this.edit.Width = originEditX + differenceX;
                    this.edit.Height = originEditY + differenceY;
                    foreach (TextEditor ctrl in this.Controls)
                    {
                        if (ctrl is not null)
                        {
                            try
                            {
                                ctrl.Width = originEditX + differenceX;
                                ctrl.Height = originEditY + differenceY;
                            }
                            catch (Exception ex)
                            {
                                LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                            }
                        }
                    }
                    foreach (TabPage ctrl in this.tabControl1.MetroTabPages)
                    {
                        if (ctrl is not null)
                        {
                            try
                            {
                                foreach (TextEditor txt in ctrl.Controls)
                                {
                                    if (ctrl is not null)
                                    {
                                        try
                                        {
                                            ctrl.Width = originEditX + differenceX;
                                            ctrl.Height = originEditY + differenceY;
                                        }
                                        catch (Exception ex)
                                        {
                                            LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                            }
                        }
                    }
                    */
                    #endregion
                    this.Size = new System.Drawing.Size(1920, 1020);
                    this.Location = new System.Drawing.Point(1, 1);
                    System.Drawing.Point _ = tmp;
                    _.X = 1860 + 20;
                    HelpButton.Location = _;
                }
                catch (Exception ex)
                {
                    LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                    this.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                //this.WindowState = FormWindowState.Normal;
                HelpButton.Location = tmp;
            }
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
            DialogResult dRes = MessageBoxEX.Show("确定退出吗？", "提示", MessageBoxButtons.YesNo, new string[] { "是", "否" });
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
            try
            {
                string result = tabControl1.SelectedTab.ToolTipText;
                var tmpEditor = ((tabControl1.SelectedTab.Controls[0] as TableLayoutPanel).Controls[0] as ElementHost).Child as TextEditor;
                if (result != "" | result != string.Empty)
                {
                    StreamWriter sw = new(result, false, Encoding.UTF8);
                    sw.Write(tmpEditor.Text);
                    sw.Flush();
                    sw.Close();
                    tabControl1.SelectedTab.Text.Replace("*", "");
                }
                else
                {
                    SaveFile(sender, e);
                }
            }
            catch (Exception ex)
            {
                LOGGER.WriteErrLog($"已捕捉异常：{ex.Message}", ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            }
            //StreamWriter sw = new();
        }
        #endregion
        #region 代码提示
        private CompletionWindow _codeSense;
        private string tmpCompletionStr = "";
        private bool isSet = false;

        private void TextAreaOnTextEntered(object sender, TextCompositionEventArgs e)
        {

            // 处理文本修改和代码提示
            HandleTextModification(e.Text, (TextArea)sender);

            // 清除临时完成字符串和标记状态
            ClearTemporaryCompletion();

            toolStripStatusLabel7.Text = tmpCompletionStr;
        }

        private void HandleTextModification(string text, TextArea textArea)
        {
            tmpCompletionStr += text;
            if (!char.IsLetterOrDigit(text[0]))
            {
                tmpCompletionStr = "";
            }
            else
            {
                _codeSense = new CompletionWindow(textArea)
                {
                    Background = Brushes.Black,
                    Foreground = Brushes.WhiteSmoke,
                };
                var completionData = _codeSense.CompletionList.CompletionData;
                var _keywords = new string[] { };
                if (!isSet)
                {
                    string tmp = tabControl1.SelectedTab.Text;
                    string _ = tmp.Split('.')[tmp.Split('.').Length - 1];
                    var lang = AutoGetLanguage(_);
                    switch (lang)
                    {
                        case "Python":
                            _keywords = LangKeywords.Keywords.python;
                            break;
                        case "Py-CN":
                            _keywords = LangKeywords.Keywords.pycn;
                            break;
                        case "C-Sharp":
                            _keywords = LangKeywords.Keywords.cs;
                            break;
                        case "XML":
                            break;
                        case "PlainText":
                            break;
                    }
                    isSet = true;
                }
                foreach (var item in _keywords.Where(IsKeywordMatched))
                {
                    completionData.Add(new RYCBCodeSense(item, CodeSenseType.KEYWORD));
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
            return pinyin.Contains(tmpCompletionStr) && pinyin != tmpCompletionStr;
        }

        private void ClearTemporaryCompletion()
        {
            RYCBCodeSense.Clear(ref tmpCompletionStr);
            RYCBCodeSense._completed = false;
        }

        #endregion
        #region 判断代码是否已修改
        private void TextArea_TextEntering(object sender, EventArgs e)
        {
            tabControl1.SelectedTab.Text += tabControl1.SelectedTab.Text.Contains("*") ? "" : "*";
        }

        private void ResizeControls(object sender, EventArgs e)
        {
            HelpButton.Location = new System.Drawing.Point(this.Width - 44, 7);
        }

        private bool TabControl1_BeforeRemoveTabPage(object sender, int index)
        {
            TabPage tab = tabControl1.TabPages[tabControl1.SelectedIndex];
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

        private void FirstInit(object sender, EventArgs e)
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
            openFileDialog1.Filter = "Py-CN文件|*.pycn|Py-CN编译后文件(Python 文件)|*.py|所有文件|*.*";
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
            this.Resize += new System.EventHandler(this.ResizeControls);
            Program.splash.metroProgressBar1.PerformStep();
            stopwatch.Stop();
            TimeSpan time = stopwatch.Elapsed;
            double end_time = time.TotalSeconds;
            LOGGER.WriteLog("主程序初始化成功！", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"主程序初始化时间共计：{Math.Round(end_time, 2)}s", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            double _end_time = Program.startTime.TotalSeconds;
            LOGGER.WriteLog($"初始化时间共计：{Math.Round(_end_time + end_time, 2)}s", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            Program.splash.metroProgressBar1.PerformStep();
            Program.splash.metroProgressBar1.Value = Program.splash.metroProgressBar1.Maximum;
            Program.splash.Close();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;//获取当前屏幕显示区域大小，让窗体长宽等于这个值，这里不包含任务栏哦
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;//这样窗体打开的时候直接就是屏幕的大小了
            this.WindowState = FormWindowState.Maximized;
            this.Show();
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
            Process pythonSrcipt = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = python,
                    Arguments = path,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
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
            Layout(sender, new TabControlEventArgs(tabPage1, 0, TabControlAction.Selecting));
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
            DialogResult dRes = MessageBox.Show("确定重启吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            LOGGER.WriteLog("已询问重启，返回值：" + dRes, EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
            if (dRes == DialogResult.Yes)
            {
                LOGGER.WriteLog("Stopping!", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                keepFile.WriteLine(long.MaxValue);
                keepFile.Close();
                string programpath = Application.ExecutablePath;
                string[] arguments = Environment.GetCommandLineArgs().Skip(1).ToArray();
                System.Diagnostics.ProcessStartInfo startinfo = new()
                {
                    FileName = programpath,
                    UseShellExecute = true,
                    Arguments = string.Join(" ", arguments)
                };
                System.Diagnostics.Process.Start(startinfo);
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
        #region 检查文件类型并发出警告
        private void CheckFileTypeAndAlert(string fileExtension, string tmp)
        {
            #region 特殊文件
            if (fileExtension.Equals("exe"))
            {
                if (func_0a2("exe", _I18nFile.ReadString("I18n", "text.inprogram.fileex.exe", "text.inprogram.fileex.exe") + "(.exe)"))
                    func_0a1(tmp);
            }
            else if (fileExtension.Equals("dll"))
            {
                if (func_0a2("dll", _I18nFile.ReadString("I18n", "text.inprogram.fileex.dll", "text.inprogram.fileex.dll") + "(.dll)"))
                    func_0a1(tmp);
            }
            else if (fileExtension.Equals("zip") || fileExtension.Equals("7z") || fileExtension.Equals("rar") ||
                     fileExtension.Equals("001") || fileExtension.Equals("tgz") || fileExtension.Equals("tar") ||
                     fileExtension.Equals("bin"))
            {
                if (func_0a2("zip|7z|rar|001|tgz|tar|bin", _I18nFile.ReadString("I18n", "text.inprogram.fileex.compressed", "text.inprogram.fileex.compressed") + "(.zip|.7z|.rar|.001|.tgz|.tar|bin)"))
                    func_0a1(tmp);
            }
            else if (fileExtension.Equals("mp3"))
            {
                if (func_0a2("mp3", _I18nFile.ReadString("I18n", "text.inprogram.fileex.media", "text.inprogram.fileex.media") + "(.mp3)"))
                    func_0a1(tmp);
            }
            else if (fileExtension.Equals("mp4"))
            {
                if (func_0a2("mp4", _I18nFile.ReadString("I18n", "text.inprogram.fileex.vedio", "text.inprogram.fileex.vedio") + "(.mp4)"))
                    func_0a1(tmp);
            }
            else if (fileExtension.Equals("crx"))
            {
                if (func_0a2("crx", _I18nFile.ReadString("I18n", "text.inprogram.fileex.crx", "text.inprogram.fileex.crx") + "(.crx)"))
                    func_0a1(tmp);
            }
            else if (fileExtension.Equals("png") || fileExtension.Equals("jpg") || fileExtension.Equals("gif") ||
                     fileExtension.Equals("webp") || fileExtension.Equals("jpeg") || fileExtension.Equals("jfif") ||
                     fileExtension.Equals("ico") || fileExtension.Equals("bmp"))
            {
                if (func_0a2("png|jpg|gif|webp|jpeg|jfif|ico|bmp", _I18nFile.ReadString("I18n", "text.inprogram.fileex.pic", "text.inprogram.fileex.pic") + "(.png|.jpg|.gif|.webp|.jpeg|.jfif|.ico|.bmp)"))
                    func_0a1(tmp);
            }
            else if (fileExtension.Equals("jar"))
            {
                if (func_0a2("jar", _I18nFile.ReadString("I18n", "text.inprogram.fileex.jar", "text.inprogram.fileex.jar") + "(.jar)"))
                    func_0a1(tmp);
            }
            else if (fileExtension.Equals("pak") || fileExtension.Equals("pkg"))
            {
                if (func_0a2("pkg", _I18nFile.ReadString("I18n", "text.inprogram.fileex.pak", "text.inprogram.fileex.pak") + "(.pak|.pkg)"))
                    func_0a1(tmp);
            }
            else if (fileExtension.Equals("e"))
            {
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.e", "text.inprogram.fileex.e") + "(.e)" + text_tsl2;
                string agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.e", "text.inprogram.fileex.e") + "(.e)" + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                DialogResult dResult = MessageBox.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                MessageBox.Show(_I18nFile.ReadString("I18n", "text.inprogram.fileex.e", "text.inprogram.fileex.e") + "(.e)" + _I18nFile.ReadString("I18n", "text.inprogram.fileex.e.0", "text.inprogram.fileex.e.0"), _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                func_0a1(tmp);
            }
            else if (fileExtension.Equals("xltd"))
            {//迅雷临时数据文件
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.xltd", "text.inprogram.fileex.xltd") + "(.xltd)" + text_tsl2;
                string agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.xltd", "text.inprogram.fileex.xltd") + "(.xltd)" + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                DialogResult dResult = MessageBoxEX.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.warning", "text.inprogram.title.warning"), MessageBoxButtons.YesNo, new string[] { _I18nFile.ReadString("I18n", "text.inprogram.bootfile.2", "text.inprogram.bootfile.2"), _I18nFile.ReadString("I18n", "text.inprogram.bootfile.3", "text.inprogram.bootfile.3") });
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                func_0a1(tmp);
            }
            else if (fileExtension.Equals("iso"))
            {
                if (func_0a2("iso", _I18nFile.ReadString("I18n", "text.inprogram.fileex.iso", "text.inprogram.fileex.iso") + "(.iso)"))
                    func_0a1(tmp);
            }
            else if (fileExtension.Equals("vmdk"))
            {
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.vmdk", "text.inprogram.fileex.vmdk") + "(.vmdk)" + text_tsl2;
                string agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.vmdk", "text.inprogram.fileex.vmdk") + "(.vmdk)" + _I18nFile.ReadString("I18n", "text.inprogram.fileex.vmdk.warn", "text.inprogram.fileex.vmdk.warn");//"文件，该操作将引起IDE未响应和内存溢出，从而导致程序崩溃且极有可能使您的计算机卡死、崩溃甚至蓝屏，请确认是否继续打开：";
                DialogResult dResult = MessageBoxEX.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.warning", "text.inprogram.title.warning"), MessageBoxButtons.YesNo, new string[] { _I18nFile.ReadString("I18n", "text.inprogram.bootfile.2", "text.inprogram.bootfile.2"), _I18nFile.ReadString("I18n", "text.inprogram.bootfile.3", "text.inprogram.bootfile.3") });
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                func_0a1(tmp);
            }
            else if (fileExtension.Equals("sb2") | fileExtension.Equals("sb3"))
            {
                toolStripStatusLabel2.Text = _I18nFile.ReadString("I18n", "text.inprogram.fileex.sb", "text.inprogram.fileex.sb") + "(.sb2|.sb3)" + text_tsl2;
                string agreeText = _I18nFile.ReadString("I18n", "text.inprogram.bootfile.0", "text.inprogram.bootfile.0") + _I18nFile.ReadString("I18n", "text.inprogram.fileex.sb", "text.inprogram.fileex.sb") + "(.sb2|.sb3)" + _I18nFile.ReadString("I18n", "text.inprogram.bootfile.1", "text.inprogram.bootfile.1");
                DialogResult dResult = MessageBox.Show(agreeText, _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                MessageBox.Show(_I18nFile.ReadString("I18n", "text.inprogram.fileex.sb.intro", "text.inprogram.fileex.sb.intro"), _I18nFile.ReadString("I18n", "text.inprogram.title.info", "text.inprogram.title.info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dResult != DialogResult.Yes) { return; }
                statusStrip1.Show();
                func_0a1(tmp);
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
                TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName, BackColor = tabPage1.BackColor };
                ElementHost tmpEHost = new()
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor,
                };
                TextEditor tmpEditor = new()
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new FontFamily("Consolas"),
                    Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x2B, 0x2D, 0x30)),
                    Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xA9, 0xB7, 0xC6)),
                    ShowLineNumbers = true,
                };
                tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
                tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
                //快速搜索功能
                SearchPanel.Install(tmpEditor.TextArea);
                using (Stream s = new FileStream(XshdFilePath + $"\\{AutoGetLanguage(newTab.Text)}.xshd", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
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
                tabControl1.SelectedTab = newTab;
            }
            #endregion
        }

        #endregion
        #region 获取文件名
        public static string GetFileName(string path)
        {
            // 使用 LastIndexOf 方法查找最后一个路径分隔符的索引
            int lastSeparatorIndex = path.LastIndexOf('\\');

            // 如果找到了路径分隔符，则提取文件名
            if (lastSeparatorIndex >= 0)
            {
                return path.Substring(lastSeparatorIndex + 1);
            }

            // 如果没有找到路径分隔符，则返回整个字符串作为文件名（假设输入字符串本身就是文件名）
            return path;
        }
        #endregion
        #endregion
    }
}
