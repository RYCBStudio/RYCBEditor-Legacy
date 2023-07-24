using IDE.Utils;
using Microsoft.VisualBasic.Devices;
using Sunny.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace IDE
{
    static class Program
    {
        internal static readonly string STARTUP_PATH = Application.StartupPath;
        private static Form class_;
        private static readonly Stopwatch w = new();
        private static readonly Stopwatch startTimer = new();
        internal static Entry splash;
        internal static TimeSpan startTime;
        internal static IniFileEx reConf = new(STARTUP_PATH + "\\Config\\.reconf");

        [STAThread]
        static void Main(string[] args)
        {
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            w.Start();
            startTimer.Start();

            splash = new();
            splash.Show();
            splash.metroProgressBar1.PerformStep();

            #region 判断参数
            switch (args.Length)
            {
                case 1:
                    class_ = new LightEdit(args[0]);
                    break;
                case 2:
                    switch (args[0])
                    {
                        case "-LE":
                        case "-le":
                        case "-lightedit":
                        case "-LightEdit":
                            class_ = new LightEdit(args[1]);
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
                    class_ = new Main();
                    break;
            }
            #endregion

            splash.metroProgressBar1.PerformStep();
            GlobalSuppressions.language = reConf.Read("general", "language", "zh-CN");
            string sys = new ComputerInfo().OSFullName;
            bool sysInfo = sys.Contains("Microsoft Windows");
            splash.metroProgressBar1.PerformStep();

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
                        splash.metroProgressBar1.PerformStep();
                        func_1a1(class_);
                        break;
                    default:
                        MessageBox.Show("您的计算机版本过低，请升级系统后打开此程序！");
                        break;
                }

                End();
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            IDE.Main.LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            End(ex);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            IDE.Main.LOGGER.WriteErrLog(ex, e.IsTerminating ? EnumMsgLevel.FATAL : EnumMsgLevel.ERROR, EnumPort.CLIENT);
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
            Application.Run(class_);
        }

        private static void End(Exception ex)
        {
            w.Stop();
            TimeSpan time = w.Elapsed;
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect\\time";
            File.WriteAllText(filePath, time.TotalSeconds.ToString());
            CrashHandler crashHandler = new(ex, "D:\\Desktop");
            crashHandler.CollectCrashInfo();
            crashHandler.WriteDumpFile();
            ErrorAnalysiser EA = new(ex);
            EA.GetExceptions();
        }

        private static void End()
        {
            w.Stop();
            TimeSpan time = w.Elapsed;
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect\\time";
            File.WriteAllText(filePath, time.TotalSeconds.ToString());
        }
    }
}
