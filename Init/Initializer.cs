using Microsoft.Win32;
using System.Windows.Forms;

namespace IDE
{
    internal static class Initializer
    {
        /// <summary>
        /// HKEY_LOCAL_MACHINE
        /// </summary>
        private static readonly RegistryKey HKLM = Registry.LocalMachine;
        /// <summary>
        /// HKEY_CLASSES_ROOT
        /// </summary>
        private static readonly RegistryKey HKCR = Registry.ClassesRoot;

        internal static void Init()
        {
            RegisterFileType();
            System.Diagnostics.Process.Start(Program.STARTUP_PATH + "\\Tools\\BanFileWarnings.bat");
        }

        private static void RegisterFileType()
        {
            #region RegisterFileNames
            HKCR.CreateSubKey(".py", true).SetValue("", "RE.File.py");
            HKCR.CreateSubKey(".pyx", true).SetValue("", "RE.File.pyx");
            HKCR.CreateSubKey(".pyi", true).SetValue("", "RE.File.pyi");
            HKCR.CreateSubKey(".pycn", true).SetValue("", "RE.File.pycn");
            HKCR.CreateSubKey(".icbconfig", true).SetValue("", "RE.File.icbc");
            HKCR.CreateSubKey(".reconf", true).SetValue("", "RE.File.rec");
            #endregion
            #region RegisterTypes
            var RE_F_py = HKCR.CreateSubKey("RE.File.py", true);
            RE_F_py.SetValue("", "Python 文件");
            RE_F_py.CreateSubKey("DefaultIcon", true).SetValue("", $"{Application.StartupPath}\\IcoResources.dll,2");
            RE_F_py.CreateSubKey("Shell", true).CreateSubKey("Open").CreateSubKey("Command").SetValue("", $"\"{Application.ExecutablePath}\" \"%1\"");
            var RE_F_pycn = HKCR.CreateSubKey("RE.File.pycn", true);
            RE_F_pycn.SetValue("", "The Py-CN Project 源文件");
            RE_F_pycn.CreateSubKey("DefaultIcon", true).SetValue("", $"{Application.StartupPath}\\IcoResources.dll,-1");
            RE_F_pycn.CreateSubKey("Shell", true).CreateSubKey("Open").CreateSubKey("Command").SetValue("", $"\"{Application.ExecutablePath}\" \"%1\"");
            var RE_F_icbc = HKCR.CreateSubKey("RE.File.icbc", true);
            RE_F_icbc.SetValue("", "RYCB Editor 运行配置文件");
            RE_F_icbc.CreateSubKey("DefaultIcon", true).SetValue("", $"{Application.StartupPath}\\IcoResources.dll,1");
            var RE_F_rec = HKCR.CreateSubKey("RE.File.rec", true);
            RE_F_rec.SetValue("", "RYCB Editor 配置文件");
            RE_F_rec.CreateSubKey("DefaultIcon", true).SetValue("", $"{Application.StartupPath}\\IcoResources.dll,8");
            var RE_F_pyx = HKCR.CreateSubKey("RE.File.pyx", true);
            RE_F_pyx.SetValue("", "Cython 文件");
            RE_F_pyx.CreateSubKey("DefaultIcon", true).SetValue("", $"{Application.StartupPath}\\IcoResources.dll,7");
            var RE_F_pyi = HKCR.CreateSubKey("RE.File.pyi", true);
            RE_F_pyi.SetValue("", "Python 存根文件");
            RE_F_pyi.CreateSubKey("DefaultIcon", true).SetValue("", $"{Application.StartupPath}\\IcoResources.dll,5");
            #endregion
        }
    }
}
