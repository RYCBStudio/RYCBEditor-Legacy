using Microsoft.VisualBasic.Devices;
using System;
using System.Windows.Forms;

namespace IDE
{
    internal static class Program
    {
        static Form class_;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0)
            {
                class_ = new Main();
            }
            else if (args.Length == 1)
            {
                class_ = new LightEdit(args[0]);
            }
            //Form class_ = new XshdVisualEditor("F:\\VS 2022\\repos\\IDE\\Py-CN.xshd");
            //Form class_ = new Main();
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

        static void func_1a1(Form form)
        {
            Application.Run(form);
        }
    }
}
