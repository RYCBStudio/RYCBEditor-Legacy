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
using System.Linq;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using ICSharpCode.AvalonEdit.CodeCompletion;
using System.Windows.Input;
using static IDE.FileTypeRegistryFactory;
using ICSharpCode.AvalonEdit.Editing;
#endregion

namespace IDE
{
    public partial class Main : Form
    {
        #region 一堆变量
        private readonly Stopwatch stopwatch = new();
        public const string VERSION = "0.0.1";
        internal static readonly LogUtil LOGGER = new(Environment.CurrentDirectory + $"\\logs\\{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}.log");
        private static StreamWriter keepFile;
        private const string title = "选择文件：";
        private const string field_a1 = "警告：用户取消了选择文件。";
        private const string field_a2 = "警告";
        private bool NoTip, isModified = false;
        TextEditor edit;
        int tmp_;
        int i = 1;
        public string text_tsl2;
        private string[] paths = new string[] { };
        RegistryKey IDE_CFG, IDE_cfg;
        private static readonly System.Drawing.Size NO_CONSOLE_SIZE = new(957, 646);
        private static readonly System.Drawing.Size WITH_CONSOLE_SIZE = NO_CONSOLE_SIZE;
        const int originX = 957;
        const int originY = 682;
        int originEditX, originEditY, originTabPageX, originTabPageY, originTabControlX, originTabControlY;
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 0xB;
        #endregion
        #region 一堆方法
        #region 构造函数
        public Main()
        {
            ExecuteCMDWithOutput("mkdir " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect", "cmd", "/s /c");
            keepFile = new StreamWriter(new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect\\.KEEP", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite), Encoding.UTF8);
            stopwatch.Start();
            Entry splash = new();
            splash.Show();
            LOGGER.WriteLog("启动画面初始化成功", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            splash.Close();
            InitializeComponent();
            this.Size = NO_CONSOLE_SIZE;
            LOGGER.WriteLog($"窗口大小修改成功 (水平长度{this.Size.Width}px, 垂直长度{this.Size.Height}px)", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            IDE_CFG = Registry.LocalMachine.OpenSubKey(@"SOFTWARE", true).CreateSubKey("RYCB", true).CreateSubKey("IDE", true);
            IDE_cfg = IDE_CFG.CreateSubKey("code_cfg");
            LOGGER.WriteLog("注册表项配置成功", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            //int count = this.Controls.Count * 2 + 2;
            //float[] factor = new float[count];
            //int i = 0;
            //factor[i++] = Size.Width;
            //factor[i++] = Size.Height;
            //foreach (System.Windows.Forms.Control ctrl in this.Controls)
            //{
            //    factor[i++] = ctrl.Location.X / (float)Size.Width;
            //    factor[i++] = ctrl.Location.Y / (float)Size.Height;
            //    ctrl.Tag = ctrl.Size;//!!!
            //}
            //Tag = factor;
        }
        #endregion
        #region 初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            LOGGER.WriteLog($"窗口位置：{this.Location}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"窗口PID：{Process.GetCurrentProcess().Id}", EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog($"窗口句柄：{Process.GetCurrentProcess().Handle}", EnumMsgLevel.DEBUG, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog("初始化...", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            if (!FileTypeRegister.FileTypeRegistered(".pycn"))
            {
                LOGGER.WriteLog("正在注册文件关联...", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
                try
                {
                    FileTypeRegInfo fileTypeRegInfo = new(".pycn")
                    {
                        Description = "The Py-CN Project项目文件",
                        ExePath = Application.ExecutablePath,
                        ExtendName = ".pycn",
                        IconPath = Application.ExecutablePath
                    };
                    FileTypeRegister fileTypeRegister = new();
                    FileTypeRegister.RegisterFileType(fileTypeRegInfo);
                    LOGGER.WriteLog("注册成功", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
                }
                catch (Exception ex)
                {
                    LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
                }
            }
            keepFile.WriteLine(long.MinValue);
            keepFile.Flush();
            this.Size = new System.Drawing.Size(1920, 1020);
            this.Location = new System.Drawing.Point(1, 1);
            originTabPageX = this.tabPage1.Width;
            originTabPageY = this.tabPage1.Height;
            originTabControlX = this.tabControl1.Width;
            originTabControlY = this.tabControl1.Height;
            NoTip = (bool)IDE_cfg.GetValue("NoTip", false);
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            statusStrip1.Hide();
            openFileDialog1.Filter = "Py-CN文件|*.pycn|Py-CN编译后文件|*.py|所有文件|*.*";
            openFileDialog1.Title = title;
            edit = new TextEditor()
            {
                FontFamily = new FontFamily("Consolas"),
                Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x2B, 0x2D, 0x30)),
                Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xA9, 0xB7, 0xC6)),
                ShowLineNumbers = true,
            };
            edit.TextArea.TextEntered += new TextCompositionEventHandler(this.TextAreaOnTextEntered);
            elementHost1.Child = edit;
            text_tsl2 = toolStripStatusLabel2.Text;
            //快速搜索功能
            SearchPanel.Install(edit.TextArea);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //设置语法规则
            string name = assembly.GetName().Name + ".Py-CN.xshd";
            using (Stream s = assembly.GetManifestResourceStream(name))
            {
                using XmlTextReader reader = new(s);
                var xshd = HighlightingLoader.LoadXshd(reader);
                edit.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
            originEditX = (int)this.edit.Width;
            originEditY = (int)this.edit.Height;
            LOGGER.WriteLog("编辑器控件加载完毕。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            toolStripComboBox1.SelectedIndex = 0;
            LOGGER.WriteLog("开始查找代码运行项...", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            foreach (string settings in IDE_cfg.GetSubKeyNames())
            {
                toolStripComboBox2.Items.Add(settings);
                LOGGER.WriteLog("发现代码运行项：" + settings, EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            }
            LOGGER.WriteLog("查找完毕。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            LOGGER.WriteLog("初始化成功！", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
            stopwatch.Stop();
            TimeSpan time = stopwatch.Elapsed;
            double end_time = time.TotalSeconds;
            LOGGER.WriteLog($"初始化时间共计：{Math.Round(end_time, 2)}s", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
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
                    MessageBox.Show(field_a1, field_a2, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string tmp = @openFileDialog1.FileName.Split('\\')[@openFileDialog1.FileName.Split('\\').Length - 1];
                paths.Append(openFileDialog1.FileName);
                string _ = tmp.Split('.')[tmp.Split('.').Length - 1];
                RegistryKey tmpKey = IDE_CFG.CreateSubKey("tmp_path").CreateSubKey(tmp);
                tmpKey.SetValue("path", openFileDialog1.FileName);
                #region 判断文件类型并提出警告
                if (_.Equals("exe"))
                {
                    func_0a2("exe", "可执行文件(.exe)");
                    func_0a1(tmp);
                }
                else if (_.Equals("dll"))
                {
                    func_0a2("dll", "动态链接库(.dll)");
                    func_0a1(tmp);
                }
                else if (_.Equals("zip") | _.Equals("7z") | _.Equals("rar") | _.Equals("001") | _.Equals("tgz") | _.Equals("tar"))
                {
                    func_0a2("zip|7z|rar|001|tgz|tar", "压缩文件(.zip|.7z|.rar|.001|.tgz|.tar)");
                    func_0a1(tmp);
                }
                else if (_.Equals("mp3"))
                {
                    func_0a2("mp3", "媒体文件(.mp3)");
                    func_0a1(tmp);
                }
                else if (_.Equals("mp4"))
                {
                    func_0a2("mp4", "视频文件(.mp4)");
                    func_0a1(tmp);
                }
                else if (_.Equals("crx"))
                {
                    func_0a2("crx", "Chromium内核浏览器扩展(.crx)");
                    func_0a1(tmp);
                }
                else if (_.Equals("png") | _.Equals("jpg") | _.Equals("gif") | _.Equals("webp") | _.Equals("jpeg") | _.Equals("jfif") | _.Equals("ico") | _.Equals("bmp"))
                {
                    func_0a2("png|jpg|gif|webp|jpeg|jfif|ico|bmp", "图片文件(.png|.jpg|.gif|.webp|.jpeg|.jfif|.ico|.bmp)");
                    func_0a1(tmp);
                }
                else if (_.Equals("jar"))
                {
                    func_0a2("jar", "Java 归档文件|Minecraft Mod文件(.jar)");
                    func_0a1(tmp);
                }
                else if (_.Equals("pak") | _.Equals("pkg"))
                {
                    func_0a2("pkg", "包文件|ASTRONEER Mod文件(.pkg)");
                    func_0a1(tmp);
                }
                else if (_.Equals("e"))
                {
                    toolStripStatusLabel2.Text = "易语言代码文件(.e)" + text_tsl2;
                    string agreeText = "检测到您正在打开易语言代码文件(.e)文件，该操作或将引起IDE未响应、内存溢出等不确定行为，请确认是否继续打开：";
                    DialogResult dResult = MessageBoxEX.Show(agreeText, "信息", MessageBoxButtons.YesNo, new string[] { "确认", "否" });
                    MessageBoxEX.Show("易语言代码文件(.e)可以使用易语言官方编辑器打开\n网站：http://www.eyuyan.com/ 或 http://www.dywt.com.cn/", "提示", MessageBoxButtons.OK, new string[] { "知道了" });
                    if (dResult != DialogResult.Yes) { return; }
                    statusStrip1.Show();
                    func_0a1(tmp);
                }
                else if (_.Equals("xltd"))
                {
                    toolStripStatusLabel2.Text = "迅雷临时数据文件(.xltd)" + text_tsl2;
                    string agreeText = "检测到您正在打开迅雷临时数据文件(.xltd)文件，该操作将引起IDE未响应和内存溢出，从而导致程序崩溃，请确认是否继续打开：";
                    DialogResult dResult = MessageBoxEX.Show(agreeText, "警告", MessageBoxButtons.YesNo, new string[] { "我已知晓风险", "否" });
                    if (dResult != DialogResult.Yes) { return; }
                    statusStrip1.Show();
                    func_0a1(tmp);
                }
                else if (_.Equals("iso"))
                {
                    func_0a2("iso", "镜像文件(.iso)");
                    func_0a1(tmp);
                }
                else if (_.Equals("efi"))
                {
                    toolStripStatusLabel2.Text = "Windows NT启动文件(.efi)" + text_tsl2;
                    string agreeText = "检测到您正在打开 Windows NT启动文件(.efi) 文件，该操作将引起IDE未响应和内存紧张，从而导致程序崩溃，请确认是否继续打开：";
                    DialogResult dResult = MessageBoxEX.Show(agreeText, "警告", MessageBoxButtons.YesNo, new string[] { "我已知晓风险", "否" });
                    if (dResult != DialogResult.Yes) { return; }
                    statusStrip1.Show();
                    func_0a1(tmp);
                }
                else if (_.Equals("sb2"))
                {
                    toolStripStatusLabel2.Text = "Scratch 2代码文件(.sb2)" + text_tsl2;
                    string agreeText = "检测到您正在打开Scratch 2代码文件(.sb2)文件，该操作或将引起IDE未响应、内存溢出等不确定行为，请确认是否继续打开：";
                    DialogResult dResult = MessageBoxEX.Show(agreeText, "信息", MessageBoxButtons.YesNo, new string[] { "确认", "否" });
                    MessageBoxEX.Show("Scratch 2代码文件(.sb2)可以使用Scratch 2或Scratch 3官方编辑器打开\n网站：https://scratch.mit.edu/download/scratch2/(官网) 或 https://cn.bing.com/search?q=scratch+2/", "提示", MessageBoxButtons.OK, new string[] { "知道了" });
                    if (dResult != DialogResult.Yes) { return; }
                    statusStrip1.Show();
                    func_0a1(tmp);
                }
                else if (_.Equals("sb3"))
                {
                    toolStripStatusLabel2.Text = "Scratch 3代码文件(.sb3)" + text_tsl2;
                    string agreeText = "检测到您正在打开Scratch 3代码文件(.sb3)文件，该操作或将引起IDE未响应、内存溢出等不确定行为，请确认是否继续打开：";
                    DialogResult dResult = MessageBoxEX.Show(agreeText, "信息", MessageBoxButtons.YesNo, new string[] { "确认", "否" });
                    MessageBoxEX.Show("Scratch 3代码文件(.sb3)可以使用Scratch 3官方编辑器、Mind+或KittenBlock打开\n网站：\n官网：https://scratch.mit.edu/download/scratch3/\nMind+：https://www.mindplus.cc\nKittenBlock：https://www.kittenbot.cn/kittenblock_download", "提示", MessageBoxButtons.OK, new string[] { "知道了" });
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
                    TabPage newTab = new(tmp);
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
                    //快速搜索功能
                    SearchPanel.Install(tmpEditor.TextArea);
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
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
                    tmpEditor.Load(@openFileDialog1.FileName);
                    tabControl1.SelectedTab = newTab;
                }
                #endregion
            }
            else
            {
                MessageBox.Show(field_a1, field_a2, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            var tmp_ = toolStripComboBox1.Text.Split(new string[] { "(内置) " }, StringSplitOptions.RemoveEmptyEntries)[0];
            TabPage tab = new($"新建{tmp_}文件" + i);
            tabControl1.TabPages.Add(tab);
            i++;
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
            //快速搜索功能
            SearchPanel.Install(tmpEditor.TextArea);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //设置语法规则
            if (tmp_.Contains("纯文本")) tmp_ = "PlainText";
            if (tmp_.Contains("C#")) tmp_ = "C-Sharp";
            string name = assembly.GetName().Name + $".{tmp_}.xshd";
            using (Stream s = assembly.GetManifestResourceStream(name))
            {
                using (XmlTextReader reader = new(s))
                {
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }
            }
            tmpEHost.Child = tmpEditor;
            tab.Controls.Add(tmpEHost);
        }
        #endregion
        #region 实时保存
        private void Save(object sender, EventArgs e)
        {
            byte[] array = Convert.FromBase64String(edit.Text);
        }
        #endregion
        #region 另存为
        private void SaveFile(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName == null || openFileDialog1.FileName == "")
                {
                    MessageBox.Show("警告：用户取消了保存文件。", field_a2, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                StreamWriter streamWriter = new(saveFileDialog1.FileName, true, Encoding.UTF8);
                streamWriter.Write(edit.Text);
                streamWriter.Close();
                if (tabControl1.SelectedIndex != 0)
                    tabControl1.SelectedTab.Text = saveFileDialog1.FileName.Split('\\')[saveFileDialog1.FileName.Split('\\').Length - 1];
                else
                {
                    TabPage tab = new(saveFileDialog1.FileName.Split('\\')[saveFileDialog1.FileName.Split('\\').Length - 1]);
                    tabControl1.TabPages.Add(tab);
                    i++;
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
                    //快速搜索功能
                    SearchPanel.Install(tmpEditor.TextArea);
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                    //设置语法规则
                    string name = assembly.GetName().Name + $".Py-CN.xshd";
                    using (Stream s = assembly.GetManifestResourceStream(name))
                    {
                        using (XmlTextReader reader = new(s))
                        {
                            var xshd = HighlightingLoader.LoadXshd(reader);
                            tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                        }
                    }
                    tmpEHost.Child = tmpEditor;
                    tab.Controls.Add(tmpEHost);
                    tabControl1.SelectedTab = tab;
                }
            }
        }
        #endregion
        #region 自定义设置
        private void CustomSet(object sender, EventArgs e)
        {
            Form cs = new CustomSettings
            {
                Owner = this
            };
            cs.Show();
        }
        #endregion
        #region 运行配置（烂代码）
        private void Run(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    ExecuteCMDWithOutput("mkdir $tmp_code", "cmd.exe", "/s /c");
                    File.WriteAllText(".\\$tmp_code\\$" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".py", edit.Text);
                    Process.Start(".\\Runner.exe " + System.Windows.Forms.Application.StartupPath + "\\$tmp_code\\$" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".py");
                }
                else
                {
                    if (tabControl1.SelectedTab.Text.Contains("exe"))
                    {
                        //Process.Start();
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
        string ExecuteCMDWithOutput(string command, string interpreter, string interpreter_params)
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
        #region <FUNC> isExeFile
        /// <summary>
        /// 判断文件类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isExeFile(object sender, EventArgs e)
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
            toolStripStatusLabel3.Text = $"[Debug|调试] 程序内存占用：{GetMemory()} {(mem > 0 ? ('+'.ToString() + mem.ToString()) : mem)}MB";
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
        void func_0a1(string tmp)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab.Text == tmp)
                {
                    tabControl1.SelectedTab = tab;
                    return;
                }
            }
            TabPage newTab = new(tmp);
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
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            string _ = tmp.Split('.')[tmp.Split('.').Length - 1];
            //设置语法规则
            string name = assembly.GetName().Name + $".{AutoGetLanguage(_)}.xshd";
            using (Stream s = assembly.GetManifestResourceStream(name))
            {
                using (XmlTextReader reader = new(s))
                {
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    tmpEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }
            }
            tmpEHost.Child = tmpEditor;
            newTab.Controls.Add(tmpEHost);
            tabControl1.TabPages.Add(newTab);
            tmpEditor.Load(@openFileDialog1.FileName);
            tabControl1.SelectedTab = newTab;
        }
        #endregion
        #region <FUNC> 占位方法
        void func_0a2(string tssl2Text, string fileDesc)
        {
            toolStripStatusLabel2.Text = tssl2Text + text_tsl2;
            string agreeText = $"检测到您正在打开 {fileDesc} 文件，该操作或将引起IDE未响应、内存溢出等不确定行为，请确认是否继续打开：";
            DialogResult dResult = MessageBoxEX.Show(agreeText, "信息", MessageBoxButtons.YesNo, new string[] { "确认", "否" });
            if (dResult != DialogResult.Yes) { return; }
            statusStrip1.Show();
        }
        #endregion
        #region 关闭选项卡
        private void CloseFile(object sender, EventArgs e)
        {
            TabPage tab = tabControl1.SelectedTab;
            if (tab.Equals(tabPage1))
            {
                if (!NoTip)
                {
                    if (MessageBoxEX.Show("无法关闭临时页面！", "提示", MessageBoxButtons.OKCancel, new string[] { "不再显示", "我已知晓" }) == DialogResult.OK)
                    {
                        NoTip = true;
                        IDE_cfg.CreateSubKey("global_cfg").SetValue("NoTip", NoTip);
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
        #region 运行文件
        private void RunFile(object sender, EventArgs e)
        {
            // RegistryKey cc;
            if (toolStripComboBox2.Items.Count != 0)
            {
                if (toolStripComboBox2.SelectedItem != null)
                {
                    string executePath = (string)IDE_cfg.OpenSubKey(toolStripComboBox2.SelectedItem.ToString()).GetValue("path");
                    string param = (string)IDE_cfg.OpenSubKey(toolStripComboBox2.SelectedItem.ToString()).GetValue("params");
                    string interpreter = (string)IDE_cfg.OpenSubKey(toolStripComboBox2.SelectedItem.ToString()).GetValue("interpreter");
                    string interpreter_params = (string)IDE_cfg.OpenSubKey(toolStripComboBox2.SelectedItem.ToString()).GetValue("interpreter_params");
                    LOGGER.WriteLog($"已发现运行项：", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.TERMINAL);
                    LOGGER.WriteLog($"\texecutePath={executePath}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.TERMINAL);
                    LOGGER.WriteLog($"\tparam={param}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.TERMINAL);
                    LOGGER.WriteLog($"\tinterpreter={interpreter}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.TERMINAL);
                    LOGGER.WriteLog($"\tinterpreterParams={interpreter_params}", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.TERMINAL);
                    ProcessStartInfo tmp = new()
                    {
                        FileName = interpreter,
                        Arguments = $"{interpreter_params} {executePath} {param}",
                    };
                    Process.Start(tmp).WaitForExit();
                    //    label2.Text = $" 当前使用：[{interpreter}]";
                    //    textBox1.Text += $"> {(interpreter.Contains("\\") ? ($"\"{interpreter}\"") : (interpreter))} {interpreter_params} \"{executePath}\" {param} \r\n";
                    //    panel1_isHiding = false;
                    //    panel1.Show();
                    //    textBox1.Text += ExecuteCMDWithOutput($"{(interpreter.Contains("\\") ? ($"\"{interpreter}\"") : (interpreter))} {interpreter_params} \"{executePath}\" {param}", interpreter, interpreter_params) + "\r\n";
                }
            }
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
        private static string AutoGetLanguage(string SuffixName)
        {
            if (SuffixName.Equals("cs"))
            {
                return "C-Sharp";
            }
            else if (SuffixName.Equals("py") | SuffixName.Equals("pyw") | SuffixName.Equals("pyi"))
            {
                return "Python";
            }
            else if (SuffixName.Equals("pycn") | SuffixName.Equals("pyCN"))
            {
                return "Py-CN";
            }
            else if (SuffixName.Equals("xml") | SuffixName.Equals("xshd"))
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
        private void ClearLog(string path)
        {
            LOGGER.WriteLog("已清除过期的日志文件！", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.INIT);
        }
        #endregion
        #region 许可与版权声明
        private void copyrightsAndLicense(object sender, EventArgs e)
        {
            new LicenseAndCopyrights().Show();
        }
        #endregion
        #region 循环判断：窗体是否处于最大化状态
        private void isMaximized(object sender, EventArgs e)
        {
            System.Drawing.Point tmp = new(1860, 0);
            if (this.WindowState == FormWindowState.Maximized)
            {
                int X = this.Size.Width;
                int Y = this.Size.Height;
                int differenceX = X - originX;
                int differenceY = Y - originY;
                LOGGER.WriteLog("已点击最大化按钮", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.MAIN);
                try
                {
                    #region 注释
                    /*
                    this.tabControl1.Width = originTabControlX + differenceX;
                    this.tabControl1.Height = originTabControlY + differenceY;
                    this.tabPage1.Width = originTabPageX + differenceX;
                    this.tabPage1.Height = originTabPageY + differenceY;
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
                    foreach (TabPage ctrl in this.tabControl1.TabPages)
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
                    button1.Location = _;
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
                button1.Location = tmp;
            }
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
                e.Cancel = false;
            }
        }
        #endregion
        #region 静默保存
        private void QuietSave(object sender, EventArgs e)
        {
            try
            {
                RegistryKey tmpKey = IDE_CFG.CreateSubKey("tmp_path").CreateSubKey(tabControl1.SelectedTab.Text);
                string result = (string)tmpKey.GetValue("path", "not_found");
                if (result.Equals("not_found"))
                {
                    tmpKey.SetValue("path", paths[paths.ToList().FindIndex(a => a.Equals(tabControl1.SelectedTab.Text))]);
                }
                else if (result != "" | result != string.Empty)
                {
                    StreamWriter sw = new(result, true, Encoding.UTF8);
                    sw.WriteLine(edit.Text);
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
            try
            {
                foreach (string settings in IDE_cfg.GetSubKeyNames())
                {
                    foreach (string item in toolStripComboBox2.Items)
                    {
                        if (!settings.Equals(item))
                        {
                            toolStripComboBox2.Items.Add(settings);
                            break;
                        }
                        break;
                    }
                    break;
                }
            }
            catch { }
        }
        #endregion
        #region 代码提示
        private CompletionWindow _codeSense;
        string tmpCompletionStr = "";
        private void TextAreaOnTextEntered(object sender, TextCompositionEventArgs e)
        {
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
        #endregion
    }
}
