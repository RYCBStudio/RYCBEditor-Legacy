using IDE.Utils;
using Microsoft.VisualBasic.Devices;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace IDE;

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
        Application.ThreadException += Application_ThreadException;
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        w.Start();
        //Form class_ = new XshdVisualEditor("F:\\VS 2022\\repos\\IDE\\Py-CN.xshd");
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
        string sys = new ComputerInfo().OSFullName;
        bool sysInfo = sys.Contains("Microsoft Windows");
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
                    func_1a1(class_);
                    break;
                default:
                    MessageBox.Show("您的计算机版本过低，请升级系统后打开此程序！");
                    break;
            }
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
        IDE.Main.LOGGER.WriteErrLog(ex, e.IsTerminating ? EnumMsgLevel.FATAL : EnumMsgLevel.ERROR, EnumPort.CLIENT);
        if (e.IsTerminating)
        {
            end(ex);
        }
    }

    private static void func_1a1(Form form)
    {
        Initializer.Init();
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
        ErrorAnalysiser EA = new(ex);
        EA.GetExceptions();
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
