using IDE.Utils;
using Microsoft.VisualBasic.Devices;
using Sunny.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace IDE
{
    static class Program
    {
        internal static readonly string STARTUP_PATH = Application.StartupPath;
        internal static bool isInitialized = false;
        private static Form class_;
        private static bool isLightEdit = false;
        private static string param = "";
        private static readonly Stopwatch w = new();
        private static readonly Stopwatch startTimer = new();
        private static int CrashAttempts = 0;
        internal static Entry splash;
        internal static TimeSpan startTime;
        internal static IniFile reConf = new(STARTUP_PATH + "\\Config\\.reconf");

        [STAThread]
        static void Main(string[] args)
        {
            bool createdNew;
            var CurrentMutexForRE = new Mutex(true, "RYCB_Editor_Running", out createdNew);
            if (!createdNew)
            {
                MessageBox.Show("F You");
                return;
            }
            else
            {
                CurrentMutexForRE.ReleaseMutex();
            }
            GlobalSettings.CrashAttempts = reConf.ReadInt("CrashHanding", "CrashAttempts", 3);
            reConf.Write("Editor", "XshdFilePath", STARTUP_PATH + "\\Config\\Highlighting");
            if (GlobalSettings.CrashAttempts == 0)
            {
                GlobalSettings.CrashAttempts = int.MaxValue;
            }
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            w.Start();
            startTimer.Start();

            #region 判断参数
            switch (args.Length)
            {
                case 1:
                    isLightEdit = true;
                    param = args[0];
                    break;
                case 2:
                    switch (args[0])
                    {
                        case "-LE":
                        case "-le":
                        case "-lightedit":
                        case "-LightEdit":
                            isLightEdit = true;
                            param = args[1];
                            break;
                        case "-XSHD":
                        case "-xshd":
                        case "-xv":
                        case "-ve":
                            class_ = new XshdVisualEditor(args[1]);
                            break;
                    }
                    break;
                default:
                    break;
            }
            #endregion

            splash = new(isLightEdit);
            splash.Show();
            if (param == "") { class_ = new Main(); }
            else { class_ = new Main(param); }

            splash.metroProgressBar1.PerformStep();
            GlobalSettings.language = reConf.Read("General", "Language", "zh-CN");
            var sys = new ComputerInfo().OSFullName;
            var sysInfo = sys.Contains("Microsoft Windows");
            splash.metroProgressBar1.PerformStep();

            #region 判断系统类型
            if (!sysInfo)
            {
                return;
            }
            else
            {
                switch (true)
                {
                    case bool _ when sys.Contains("10"):
                    case bool _ when sys.Contains("11"):
                    case bool _ when sys.Contains("8"):
                    case bool _ when sys.Contains("8.1"):
                    {
                        splash.metroProgressBar1.PerformStep();
                        func_1a1(class_);
                        break;
                    }
                    default:
                    {
                        MessageBox.Show("您的计算机版本过低，请升级系统后打开此程序！");
                        break;
                    }
                }

                End();
            }
            #endregion 
            
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            IDE.Main.LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            Infrastructure.MiniDump.TryDump(STARTUP_PATH + $"\\Crash\\{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}_{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}+{DateTime.Now.Millisecond}.dmp");
            ((Main)class_).msgBox.MainForm = class_;
            //((Main)class_).msgBox.MarkdownText =
            //    "<h3> Error</h3> <hr /> <p>Message:" + ex.Message + "</p><h5>Stacktrace(s):</h5><p>" + ex.StackTrace + "</p><h3>Error has written into the log file.</h3>";
            ((Main)class_).msgBox.CurrentMsgType = MsgBox.MsgType.Error;
            ((Main)class_).msgBox.CurrentException = ex;
            //((Main)class_).msgBox.Invalidate();
            ((Main)class_).msgBox.Show();
            
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            //IDE.Main.LOGGER.WriteErrLog(ex, e.IsTerminating ? EnumMsgLevel.FATAL : EnumMsgLevel.ERROR, EnumPort.CLIENT);
            //((Main)class_).msgBox.MarkdownText =
            //    "## Error <hr /> <h5>Message:" + ex.Message + "</h5><h5>Stacktrace(s):</h5><h5>==============</h5><h5>" + ex.StackTrace + "</h5><h5>Error has written into the log file.</h5>";
            //((Main)class_).msgBox.Show();
            if (e.IsTerminating)
            {
                End(ex);
            }
        }

        private static void func_1a1(Form form)
        {
            Initializer.Init();
            startTimer.Stop();
            startTime = startTimer.Elapsed;
            splash.metroProgressBar1.PerformStep();
            Application.Run(form);
            isInitialized = true;
        }

        private static void End(Exception ex)
        {
            if (CrashAttempts == GlobalSettings.CrashAttempts - 1 || !isInitialized)
            {
                IDE.Main.LOGGER.WriteLog("RYCB Editor 已崩溃。崩溃尝试次数：" + (CrashAttempts + 1).ToString());

                w.Stop();
                var time = w.Elapsed;
                var filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect\\time";
                File.WriteAllText(filePath, time.TotalSeconds.ToString());
                CrashHandler crashHandler = new(ex, Environment.GetFolderPath(Environment.SpecialFolder.Desktop)); ;
                crashHandler.CollectCrashInfo();
                crashHandler.WriteDumpFile();
                ErrorAnalysiser EA = new(ex);
                EA.GetExceptions();
                Infrastructure.MiniDump.TryDump(STARTUP_PATH + $"\\Crash\\{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}_{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}+{DateTime.Now.Millisecond}.dmp");
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                CrashAttempts++;
                IDE.Main.LOGGER.WriteLog($"捕获异常：{{Type={ex.GetType()}, Message={ex.Message}}}\t尝试次数：{CrashAttempts}(距离崩溃还剩{GlobalSettings.CrashAttempts - CrashAttempts}次异常)", EnumMsgLevel.FATAL, EnumPort.CLIENT, EnumModule.MAIN); ;
            }
        }

        private static void End()
        {
            w.Stop();
            var time = w.Elapsed;
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect\\time";
            File.WriteAllText(filePath, time.TotalSeconds.ToString());
        }
    }
}
