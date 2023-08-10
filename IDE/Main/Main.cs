#region 导入命名空间
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Search;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Windows.Forms.Integration;
using TextEditor = ICSharpCode.AvalonEdit.TextEditor;
using System.Windows.Media;
using System.Text;
using ICSharpCode.AvalonEdit.CodeCompletion;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.Editing;
using System.Reflection;
using MetroFramework.Controls;
using Sunny.UI;
using System.Linq;
using Sunny.UI.Win32;
#endregion

namespace IDE
{
    public partial class Main : Form
    {
        #region 一堆变量和常量
        private static readonly string STARTUP_PATH = Program.STARTUP_PATH;
        private static readonly IniFile reConf = Program.reConf;
        private static readonly Stopwatch stopwatch = new();
        public const string VERSION = "0.0.1";
        public const string FRIENDLY_VER = "0.0.1a_dev+4";
        private string title = "选择文件：";
        public static readonly LogUtil LOGGER = new(Environment.CurrentDirectory + $"\\logs\\{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}.log");
        private static StreamWriter keepFile;
        private bool NoTip, isModified = false;
        public string text_tsl2;
        private static bool IsModified
        {
            get; set;
        }
        private static bool IsSaved
        {
            get; set;
        }
        private TextEditor edit;
        private int tmp_;
        #endregion
        #region 一堆方法
        #region 构造函数
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
        #endregion
        #region 初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            ClearLog();
            edit = new TextEditor()
            {
                Width = elementHost1.Width,
                Height = elementHost1.Height,
                FontFamily = new FontFamily("Consolas"),
                Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x2B, 0x2D, 0x30)),
                Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xA9, 0xB7, 0xC6)),
                ShowLineNumbers = true,
            };
            edit.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
            edit.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
            elementHost1.Child = edit;
            //快速搜索功能
            SearchPanel.Install(edit.TextArea);
            System.Reflection.Assembly assembly = Assembly.GetExecutingAssembly();
            //设置语法规则
            string name = assembly.GetName().Name + ".Py-CN.xshd";
            using (Stream s = assembly.GetManifestResourceStream(name))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                edit.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
        }
        #endregion
        #region Resize方法
        private void Form1_Resize(object sender, EventArgs e)
        {
            //SendMessage(this.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
            //float newx = (this.Width) / AutoSizeFormClass.X;
            //float newy = this.Height / AutoSizeFormClass.Y;
            //AutoSizeFormClass.setControls(newx, newy, this);
            //SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
            //this.Invalidate(true);
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
            if (nf.GetFileName() == "" | nf.GetFileName() == null | nf.GetStatus() == NewFile.FileStatus.Failed)
            {
                LOGGER.WriteLog("已取消新建文件。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                return;
            }
            else
            {
                TabPage tab = new()
                {
                    Text = nf.GetFileName(),
                    BackColor = tabPage1.BackColor,
                    ForeColor = tabPage1.ForeColor,
                };
                LOGGER.WriteLog($"TabPage已准备就绪。\n文件名: {tab.Text}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                ElementHost tmpEHost = new()
                {
                    Size = elementHost1.Size,
                    Location = elementHost1.Location,
                    BackColor = elementHost1.BackColor,
                    ForeColor = elementHost1.ForeColor,
                };
                LOGGER.WriteLog("ElementHost已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                TextEditor tmpEditor = new()
                {
                    Width = elementHost1.Width,
                    Height = elementHost1.Height,
                    FontFamily = new FontFamily("Consolas"),
                    Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x2B, 0x2D, 0x30)),
                    Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xA9, 0xB7, 0xC6)),
                    ShowLineNumbers = true,
                };
                LOGGER.WriteLog($"编辑器控件已准备就绪。\n字体: {tmpEditor.FontFamily}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
                tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
                LOGGER.WriteLog("编辑器控件方法入口已准备就绪。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                //快速搜索功能
                SearchPanel.Install(tmpEditor.TextArea);
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                //设置语法规则
                LOGGER.WriteLog("正在获取语法规则信息..");
                var tmp_ = AutoGetLanguage(tab.Text);
                if (tmp_.Contains("纯文本")) tmp_ = "PlainText";
                if (tmp_.Contains("C#")) tmp_ = "C-Sharp";
                string name = assembly.GetName().Name + $".{tmp_}.xshd";
                LOGGER.WriteLog("语法规则信息获取成功。");
                LOGGER.WriteLog($"语法规则: {tmp_}\t\t对应文件名: {name}");
                using (Stream s = assembly.GetManifestResourceStream(name))
                {
                    using XmlTextReader reader = new(s);
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }
                LOGGER.WriteLog("语法规则已成功设置。");
                tmpEHost.Child = tmpEditor;
                tab.Controls.Add(tmpEHost);
                tabControl1.TabPages.Add(tab);
                LOGGER.WriteLog("所有设置均已完成。");
            }
        }
        #endregion
        #region 实时保存
        private void Save(object sender, EventArgs e)
        {
            var _editor = (tabControl1.SelectedTab.Controls[0] as ElementHost).Child as TextEditor;
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
            var _editor = (tabControl1.SelectedTab.Controls[0] as ElementHost).Child as TextEditor;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName == null || saveFileDialog1.FileName == "")
                {
                    return;
                }
                StreamWriter streamWriter = new(saveFileDialog1.FileName, false, Encoding.UTF8);
                streamWriter.Write(_editor.Text);
                streamWriter.Close();
                if (tabControl1.SelectedIndex != 0)
                {
                    tabControl1.SelectedTab.Text = saveFileDialog1.FileName.Split('\\')[saveFileDialog1.FileName.Split('\\').Length - 1];
                    tabControl1.SelectedTab.ToolTipText = @saveFileDialog1.FileName;
                }
                else
                {
                    TabPage tab = new() { Text = saveFileDialog1.FileName.Split('\\')[saveFileDialog1.FileName.Split('\\').Length - 1], ToolTipText = @saveFileDialog1.FileName };
                    tabControl1.TabPages.Add(tab);
                    ElementHost tmpEHost = new()
                    {
                        Size = elementHost1.Size,
                        Location = elementHost1.Location
                    };
                    TextEditor tmpEditor = new()
                    {
                        FontFamily = new FontFamily("Consolas"),
                        Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x2B, 0x2D, 0x30)),
                        Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xA9, 0xB7, 0xC6)),
                        ShowLineNumbers = true,
                    };
                    tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
                    tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
                    //快速搜索功能
                    SearchPanel.Install(tmpEditor.TextArea);
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                    //设置语法规则
                    string name = assembly.GetName().Name + $".Py-CN.xshd";
                    using (Stream s = assembly.GetManifestResourceStream(name))
                    {
                        using XmlTextReader reader = new(s);
                        var xshd = HighlightingLoader.LoadXshd(reader);
                        tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                    }
                    tmpEHost.Child = tmpEditor;
                    tab.Controls.Add(tmpEHost);
                    tabControl1.SelectedTab = tab;
                    ((MetroTabPage)tabControl1.SelectedTab).Style = MetroFramework.MetroColorStyle.Blue;
                }
            }
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
                if (tabControl1.SelectedTab == tabPage1)
                {
                    string _tmpFileName = Convert.ToString(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
                    ExecuteCMDWithOutput("mkdir $tmp_code", "cmd.exe", "/s /c");
                    if (tabControl1.SelectedTab.ToolTipText.Contains(".py"))
                    {
                        Process.Start(".\\Runner.exe", tabControl1.SelectedTab.ToolTipText);
                    }
                    else if (((tabControl1.SelectedTab.Controls[2] as ElementHost).Child as TextEditor).Text.Contains("py-cn"))
                    {
                        ProcessStartInfo tmpSI = new()
                        {
                            FileName = ".\\Compiler.exe",
                            Arguments = tabControl1.SelectedTab.ToolTipText,
                        };
                        Process.Start(tmpSI);
                        Process.Start(".\\Runner.exe", tabControl1.SelectedTab.ToolTipText.RemoveRight(2));
                    }
                }
                else
                {
                    if (tabControl1.SelectedTab.ToolTipText == "" | tabControl1.SelectedTab.ToolTipText is null)
                    {
                        ExecuteCMDWithOutput("mkdir $tmp_code", "cmd.exe", "/s /c");
                        StreamWriter streamWriter = new(Application.StartupPath + "\\$tmp_code\\" + tabControl1.SelectedTab.Text.Split('*')[0], false, Encoding.UTF8);
                        streamWriter.Write(((tabControl1.SelectedTab.Controls[0] as ElementHost).Child as TextEditor).Text);
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
        #region <FUNC> getFiletype
        /// <summary>
        /// 判断文件类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getFiletype(object sender, EventArgs e)
        {
            string tmp = tabControl1.SelectedTab.Text;
            if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("exe"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("dll"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("zip") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("7z") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("rar") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("001") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("tgz") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("tar"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("mp3"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("mp4"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("crx"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("png") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("jpg") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("gif") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("webp") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("jpeg") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("jfif") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("ico") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("bmp"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("jar"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("pak") | tmp.Split('.')[tmp.Split('.').Length - 1].Equals("pkg"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("e"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("xltd"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("iso"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("efi"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("sb2"))
            {
                statusStrip1.Show();
            }
            else if (tmp.Split('.')[tmp.Split('.').Length - 1].Equals("sb3"))
            {
                statusStrip1.Show();
            }
            else
            {
                statusStrip1.Hide();
            }
            int mem = GetDigtalMemory() - tmp_;
            toolStripStatusLabel3.Text = $"{_I18nFile.ReadString("I18n", "text.st.mem", "text.st.mem")} {GetMemory()} {(mem > 0 ? ('+'.ToString() + mem.ToString()) : mem)}MB";
            try
            {
                if (isModified)
                {
                    string text = tabControl1.SelectedTab.Text;
                    if (!tabControl1.SelectedTab.Text.Contains("*"))
                        tabControl1.SelectedTab.Text = text + "*";
                }
            }
            catch (NullReferenceException)
            {
                if (isModified)
                {
                    string text = tabControl1.SelectedTab.Text;
                    if (!tabControl1.SelectedTab.Text.Contains("*"))
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
            TabPage newTab = new() { Text = tmp, ToolTipText = @openFileDialog1.FileName };
            ElementHost tmpEHost = new()
            {
                Size = elementHost1.Size,
                Location = elementHost1.Location
            };
            TextEditor tmpEditor = new()
            {
                FontFamily = new FontFamily("Consolas"),
                Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x2B, 0x2D, 0x30)),
                Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xA9, 0xB7, 0xC6)),
                IsReadOnly = true,
                ShowLineNumbers = true,
            };
            //快速搜索功能
            SearchPanel.Install(tmpEditor.TextArea);
            tmpEditor.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
            tmpEditor.TextArea.TextEntering += new TextCompositionEventHandler(this.TextArea_TextEntering);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            string _ = tmp.Split('.')[tmp.Split('.').Length - 1];
            //设置语法规则
            string name = assembly.GetName().Name + $".{AutoGetLanguage(_)}.xshd";
            using (Stream s = assembly.GetManifestResourceStream(name))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
            tmpEHost.Child = tmpEditor;
            newTab.Controls.Add(tmpEHost);
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
            tmp_ = GetDigtalMemory();
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
        public static int GetDigtalMemory()
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
            timer4.Start();
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
        #region 生成I18n示例文件
        private void GenerateI18nExampleFile(object sender, EventArgs e)
        {
            //StreamWriter sw = new(new FileStream(STARTUP_PATH + "\\zh-CN.relang", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite));
            //sw.WriteLine("[LangSet]");
            //sw.WriteLine("Name=简体中文（中国）");
            //sw.WriteLine();
            //sw.WriteLine("[I18n]");
            //foreach (Control item in this.Controls)
            //{
            //    sw.WriteLine($"{item.Name}={item.Text}");
            //}
            //sw.WriteLine(@"######StatusStrip1#######");
            //foreach (ToolStripItem item in this.statusStrip1.Items)
            //{
            //    sw.WriteLine($"{item.Name}={item.Text}");
            //}
            //sw.WriteLine(@"######StatusStrip2#######");
            //foreach (ToolStripItem item in this.statusStrip2.Items)
            //{
            //    sw.WriteLine($"{item.Name}={item.Text}");
            //}
            //sw.WriteLine(@"######ToolStrip1#######");
            //sw.WriteLine(@"######ContextMenuStrip1#######");
            //foreach (ToolStripItem item in this.contextMenuStrip1.Items)
            //{
            //    sw.WriteLine($"{item.Name}={item.Text}");
            //}
            //sw.WriteLine(@"######MenuStrip1#######");
            //foreach (ToolStripItem item in this.menuStrip1.Items)
            //{
            //    sw.WriteLine($"{item.Name}={item.Text}");
            //}
            //sw.WriteLine(@"######文件FToolStripMenuItem#######");
            //foreach (ToolStripItem item in this.文件FToolStripMenuItem.DropDownItems)
            //{
            //    sw.WriteLine($"{item.Name}={item.Text}");
            //}
            //sw.WriteLine(@"######编辑EToolStripMenuItem#######");
            //foreach (ToolStripItem item in this.编辑EToolStripMenuItem.DropDownItems)
            //{
            //    sw.WriteLine($"{item.Name}={item.Text}");
            //}
            //sw.WriteLine(@"######运行RToolStripMenuItem#######");
            //foreach (ToolStripItem item in this.运行RToolStripMenuItem.DropDownItems)
            //{
            //    sw.WriteLine($"{item.Name}={item.Text}");
            //}
            //sw.WriteLine(@"######工具TToolStripMenuItem#######");
            //foreach (ToolStripItem item in this.工具TToolStripMenuItem.DropDownItems)
            //{
            //    sw.WriteLine($"{item.Name}={item.Text}");
            //}
            //sw.WriteLine(@"######帮助HToolStripMenuItem#######");
            //foreach (ToolStripItem item in this.帮助HToolStripMenuItem.DropDownItems)
            //{
            //    sw.WriteLine($"{item.Name}={item.Text}");
            //}
            //sw.WriteLine($"this.openFileDialog1.Title={this.openFileDialog1.Title}");
            //sw.Close();
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
                if (result != "" | result != string.Empty)
                {
                    StreamWriter sw = new(result, true, Encoding.UTF8);
                    sw.Write(edit.Text);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                LOGGER.WriteErrLog($"已捕捉异常：{ex.Message}", ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            }
            //StreamWriter sw = new();
        }
        #endregion
        #region 同步代码设置
        private void SyncCC(object sender, EventArgs e)
        {
            //try
            //{
            //    foreach (string settings in IDE_cfg.GetSubKeyNames())
            //    {
            //        foreach (string item in toolStripComboBox2.Items)
            //        {
            //            if (!settings.Equals(item))
            //            {
            //                toolStripComboBox2.Items.Add(settings);
            //                break;
            //            }
            //            break;
            //        }
            //        break;
            //    }
            //}
            //catch { }
        }
        #endregion
        #region 代码提示
        private CompletionWindow _codeSense;
        private string tmpCompletionStr = "";
        private void TextAreaOnTextEntered(object sender, TextCompositionEventArgs e)
        {
            IsModified = true;
            /*
                #region 关键字
                if (e.Text.ToLower() == "a")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("and", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("as", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("assert", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("async", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("await", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "b")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("break", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("捕获", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("捕获异常", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("遍历", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("不是", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("不", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "c")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("continue", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("class", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("尝试运行", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("尝试", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("抽象资源处理逻辑", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("抽象处理逻辑", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("抽象", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "d")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("当", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("定义", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("定义方法", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("定义函数", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("打断循环", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("等候", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("等待", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("断言", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("当作", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("def", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("del", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "e")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("elif", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("else", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("except", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "f")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("finally", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("for", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("from", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("否则", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("否则如果", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("非本地变量", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("非本地化变量", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "g")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("global", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "h")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("或", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("或者", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "i")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("if", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("import", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("in", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("is", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "j")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("假", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "k")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("快速", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("空", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "l")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("lambda", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("->", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "n")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("匿名函数", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("nonlocal", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("not", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "o")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("or", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "p")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("抛出", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("pass", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "r")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("raise", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("return", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("如果", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("若捕获异常", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "s")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("删除", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("使变量全局", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("使变量全局化", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "t")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("try", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("通过", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("跳过并继续", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "w")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("while", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("with", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "y")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("yield", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("异步", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("异步操作", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("抑或", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("语句占位符", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                else if (e.Text.ToLower() == "z")
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    completionData.Add(new RYCBCodeSense("占位语句", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("占位符", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("作为", CodeSenseType.KEYWORD));
                    completionData.Add(new RYCBCodeSense("真", CodeSenseType.KEYWORD));
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                #endregion
                #region 方法
                else
                {
                    _codeSense = new CompletionWindow(edit.TextArea)
                    {
                        Background = Brushes.Black,
                        Foreground = Brushes.White,
                    };
                    var completionData = _codeSense.CompletionList.CompletionData;
                    CodeAnalyser analyser = new(edit.TextArea);
                    string[] funcs = analyser.GetFunctions();
                    foreach (var item in funcs)
                    {
                        completionData.Add(new RYCBCodeSense(item, CodeSenseType.FUNC));
                    }
                    _codeSense.Show();
                    _codeSense.Closed += (o, args) => _codeSense = null;
                }
                #endregion
                */
            tmpCompletionStr += e.Text;
            if (!char.IsLetterOrDigit(e.Text[0])) { tmpCompletionStr = ""; }
            else
            {
                _codeSense = new CompletionWindow((TextArea)sender)
                {
                    Background = Brushes.Black,
                    Foreground = Brushes.WhiteSmoke,
                };
                var completionData = _codeSense.CompletionList.CompletionData;
                foreach (var item in LangKeywords.Keywords.pycn)
                {
                    if (item.Contains(tmpCompletionStr) & item != tmpCompletionStr)
                    {
                        completionData.Add(new RYCBCodeSense(item, CodeSenseType.KEYWORD));
                    }
                    else
                    {
                        continue;
                    }
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
            RYCBCodeSense.Clear(ref tmpCompletionStr);
            RYCBCodeSense._completed = false;
            toolStripStatusLabel7.Text = tmpCompletionStr;
        }
        #endregion
        #region 判断代码是否已修改
        private void TextArea_TextEntering(object sender, EventArgs e)
        {
            IsModified = true;
            tabControl1.SelectedTab.Text += tabControl1.SelectedTab.Text.Contains("*") ? "" : "*";
        }

        private void ResizeControls(object sender, EventArgs e)
        {
            foreach (TabPage item in tabControl1.TabPages)
            {
                try
                {
                    ElementHost __host = item.Controls[0] as ElementHost;
                    TextEditor __editor = __host.Child as TextEditor;
                    item.Width = tabControl1.Width - 8;
                    item.Height = tabControl1.Height - 42;
                    __host.Width = item.Width;
                    __host.Height = item.Height;
                    __editor.Width = __host.Width;
                    __editor.Height = __host.Height;
                }
                catch (Exception ex)
                {
                    LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                }
            }
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
            this.Hide();
            ExecuteCMDWithOutput("mkdir " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect", "cmd", "/s /c");
            keepFile = new StreamWriter(new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect\\.KEEP", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite), Encoding.UTF8);
            stopwatch.Start();
            this.Size = new(957, 646);
            LOGGER.WriteLog($"窗口大小修改成功 (水平长度{this.Size.Width}px, 垂直长度{this.Size.Height}px)", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"窗口位置：{this.Location}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"窗口PID：{Process.GetCurrentProcess().Id}", EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"窗口句柄：{Process.GetCurrentProcess().Handle}", EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog("主程序正在初始化...", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            keepFile.WriteLine(long.MinValue);
            keepFile.Flush();
            //this.Size = new System.Drawing.Size(1920, 1020);
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
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                //设置语法规则
                string name = assembly.GetName().Name + $".{AutoGetLanguage(fileExtension)}.xshd";
                using (Stream s = assembly.GetManifestResourceStream(name))
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
        #endregion
    }
}
