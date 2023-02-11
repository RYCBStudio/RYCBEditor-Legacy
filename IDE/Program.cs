using Microsoft.VisualBasic.Devices;
using System;
using System.Windows.Forms;

namespace IDE
{
    internal static class Program
    {
        private static Form class_;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Form class_ = new XshdVisualEditor("F:\\VS 2022\\repos\\IDE\\Py-CN.xshd");
            #region 判断参数
            if (args.Length == 0)
            {
                class_ = new Main();
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
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)

        {
            Exception ex = e.Exception;
            IDE.Main.LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            IDE.Main.LOGGER.WriteErrLog(ex, (e.IsTerminating ? EnumMsgLevel.FATAL : EnumMsgLevel.ERROR), EnumPort.CLIENT);
        }

        static void func_1a1(Form form)
        {
            Application.Run(form);
        }
    }
}
