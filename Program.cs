using IDE.Utils;
using Microsoft.VisualBasic.Devices;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace IDE
{
    static class Program
    {
        private static Form class_;
        private static readonly Stopwatch w = new();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            w.Start();
            //Form class_ = new XshdVisualEditor("F:\\VS 2022\\repos\\IDE\\Py-CN.xshd");
            #region 判断参数
            if (args.Length == 0)
            {
                class_ = new Main();
            }
            else if (args.Length == 1)
            {
                class_ = new LightEdit(args[0]);
            }
            else if (args.Length == 2)
            {
                if (args[0] == "-LE" | args[0] == "-le" | args[0] == "-lightedit" | args[0] == "-LightEdit")
                {
                    class_ = new LightEdit(args[1]);
                }
                else if (args[0] == "-XSHD" | args[0] == "-xshd" | args[0] == "-xv" | args[0] == "-ve")
                {
                    class_ = new XshdVisualEditor(args[1]);
                }
            }
            else
            {
                class_ = new Main();
            }
            #endregion
            //class_ = new CustomSettings("D:\\Desktop\\config\\xshd\\");
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            string sys = new ComputerInfo().OSFullName;
            bool sysInfo = sys.Contains("Microsoft Windows");
            if (!(sysInfo)) { }
            else
            {
                if (sys.Contains("10"))
                {
                    func_1a1(class_);
                }
                else if (sys.Contains("11"))
                {
                    func_1a1(class_);
                }
                else if (sys.Contains("8"))
                {
                    func_1a1(class_);
                }
                else if (sys.Contains("8.1"))
                {
                    func_1a1(class_);
                }
                else { MessageBox.Show("您的计算机版本过低，请升级系统后打开此程序！"); }
                end();
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            IDE.Main.LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            end(ex);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            IDE.Main.LOGGER.WriteErrLog(ex, (e.IsTerminating ? EnumMsgLevel.FATAL : EnumMsgLevel.ERROR), EnumPort.CLIENT);
            if (e.IsTerminating)
            {
                end(ex);
            }
        }

        private static void func_1a1(Form form)
        {
            Application.Run(form);
        }

        private static void end(Exception ex)
        {
            w.Stop();
            TimeSpan time = w.Elapsed;
            System.IO.File.WriteAllText(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                + "\\RYCB\\IDE\\protect\\time",
                time.TotalSeconds.ToString());
            CrashHandler crashHandler = new(ex, $"D:\\Desktop");
            crashHandler.CollectCrashInfo();
            crashHandler.WriteDumpFile();
        }

        private static void end()
        {
            w.Stop();
            TimeSpan time = w.Elapsed;
            System.IO.File.WriteAllText(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                + "\\RYCB\\IDE\\protect\\time",
                time.TotalSeconds.ToString());
        }
    }
}
