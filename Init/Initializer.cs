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
        }

        private static void RegisterFileType()
        {
            #region RegisterFileNames
            HKCR.CreateSubKey(".py", true).SetValue("", "RE.File.0");
            HKCR.CreateSubKey(".pycn", true).SetValue("", "RE.File.1");
            HKCR.CreateSubKey(".recc", true).SetValue("", "RE.File.2");
            HKCR.CreateSubKey(".reconf", true).SetValue("", "RE.File.3");
            #endregion
            #region RegisterTypes
            var RE_F_0 = HKCR.CreateSubKey("RE.FIle.0", true);
            RE_F_0.SetValue("", "Python 文件");
            RE_F_0.CreateSubKey("DefaultIcon", true).SetValue("", $"{Application.StartupPath}\\IcoResources.dll,10");
            RE_F_0.CreateSubKey("Shell", true).CreateSubKey("Open").CreateSubKey("Command").SetValue("", $"\"{Application.ExecutablePath}\" \"%1\"");
            var RE_F_1 = HKCR.CreateSubKey("RE.FIle.1", true);
            RE_F_1.SetValue("", "The Py-CN Project 源文件");
            RE_F_1.CreateSubKey("DefaultIcon", true).SetValue("", $"{Application.StartupPath}\\IcoResources.dll,11");
            RE_F_1.CreateSubKey("Shell", true).CreateSubKey("Open").CreateSubKey("Command").SetValue("", $"\"{Application.ExecutablePath}\" \"%1\"");
            var RE_F_2 = HKCR.CreateSubKey("RE.FIle.2", true);
            RE_F_2.SetValue("", "RYCB Editor 运行配置文件");
            RE_F_2.CreateSubKey("DefaultIcon", true).SetValue("", $"{Application.StartupPath}\\IcoResources.dll,20");
            RE_F_2.CreateSubKey("Shell", true).CreateSubKey("Open").CreateSubKey("Command").SetValue("", $"\"{Application.ExecutablePath}\" \"%1\"");
            var RE_F_3 = HKCR.CreateSubKey("RE.FIle.3", true);
            RE_F_3.SetValue("", "RYCB Editor 配置文件");
            RE_F_3.CreateSubKey("DefaultIcon", true).SetValue("", $"{Application.StartupPath}\\IcoResources.dll,21");
            RE_F_3.CreateSubKey("Shell", true).CreateSubKey("Open").CreateSubKey("Command").SetValue("", $"\"{Application.ExecutablePath}\" \"%1\"");
            #endregion
        }
    }
}
