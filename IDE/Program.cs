using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Form _class_ = new XshdVisualEditor("F:\\VS 2022\\repos\\IDE\\Py-CN.xshd");
            Form _class_ = new Main();
            string sys = new ComputerInfo().OSFullName;
            bool sysInfo = sys.Contains("Microsoft Windows");
            if (!(sysInfo)) { }
            else
            {
                if (sys.Contains("10"))
                {
                    func_1a1(_class_);
                }
                else if (sys.Contains("11"))
                {
                    func_1a1(_class_);
                }
                else if (sys.Contains("8"))
                {
                    func_1a1(_class_);
                }
                else if (sys.Contains("8.1"))
                {
                    func_1a1(_class_);
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
