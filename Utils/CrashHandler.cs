using Microsoft.VisualBasic.Devices;
using Sunny.UI;
using System;
using System.Globalization;
using System.IO;
using System.Management;

namespace IDE.Utils
{
    public class CrashHandler
    {
        private static Exception _ex;
        private static string _path;
        private static readonly string[] _jokes =
            {
            "我们都有不顺利的时候。",
            "滚回功率，坐和放宽。",
            "好东西就要来了",
            "你好。正在为你作准备。",
            "你正在成功！",
            "嗨，别来无恙啊！",
            "你已完成30%",
            "做！轰！",
            "免 费 花 分 文",
            "幸福倒计时",
            "Windows 10 不是面向我们所有人，而是面向我们每一个人。",
            "您和您的电脑需要重新启动。",
            "头抬起",
            "Windows 整了这些设置以与你的硬件性能匹配",
            "术语(in)",
            "请勿™关闭计算机",
            "微软边缘有新面貌！",
            "这真是让人尴尬",
            "恶意的外部设备免受攻击保护你的设备的内存",
            "Windows沙盒正在关闭并将关闭",
            "海記憶體知己，天涯若比鄰",
            "滚回到以前的版本",
            "100%完全收费",
            "你今天看起来很聪明！",
            "不要怪我们没有警告过你",
            "头抬起，为了确保你是最新的，我们将要对你的窗10进行更新，请勿™关闭计算机，坐和放宽，你正在成功。",
            "如果更新失败，没关系，我们都有不顺利的时候。建议你滚回到以前的版本，" +
                "或者按下功率 (Power)，打开一种新的植物性燃料 " +
                "(BIOS) 进行设置，然后可以打开微软边缘流量器 (Microsoft Edge)，进入微软官网进行反映，" +
                "或者打开内部集线器 (Insider Hub) 进行反馈。我们会对你的反馈进行审批.",
            "您正在成功！ 头抬起，全新的窗11来了！您可以在窗11中做完全一样的事，如轰、嚓嚓嚓、推推。您可以和家人分享美妙的内存，分了又分。",
                "全新的界面和分屏功能使Windows Tablet使用便捷。升级到窗11完全免费花分文，您只需要在内部集线器中找到预览体验计划，并点击升级，电脑会自动滚回功率。" +
                "请坐和放宽。",
            "你永远可以相信BugJump的更新速度！",
            "Never Gonna Give the Minecraft Up",
            };
        private static string _res =
            """
            =======================
            = RYCB Editor 崩溃报告 =
            =======================
            //{0}

            时间：{1}
            错误类型：{2}
            描述：{3}
            HResult：{18}
            {4}

            详细信息如下：
            -----------------------
            == 主线程 ==
            堆栈调用：
            {4}

            == 内部错误 ==
            是否有内部错误：{16}
            {17}

            == 系统信息 ==
            软件版本：{5}
            操作系统：{6}
            启动参数：(合计{7}) {8}
            正常运行时间：{9}s
            文件路径：{11}
            类型：{12}
            当前语言：{13}
            最后一次内存占用查询：{14}
            CPU：{15}{10}
            """;
        private IniFileEx IniFile = new(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\SoftInfo");

        public CrashHandler(Exception ex, string path)
        {
            _ex = ex;
            _path = path + $"\\崩溃报告_{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}_{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}+{DateTime.Now.Millisecond}*Client.txt";
        }

        public void CollectCrashInfo()
        {
            var LogPath = Main.LOGGER.logPath;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"\\Temp\\RYCB\\IDE\\{Main.LOGGER.logPath.Split('\\')[Main.LOGGER.logPath.Split('\\').Length - 1]}";
            var ret_foo = foo();
            var InnerExceptionProcess = _ex.InnerException != null ? $"""
                    错误类型：{_ex.InnerException.GetType()}
                    HResult：{_ex.InnerException.HResult}
                    堆栈调用：
                    {_ex.InnerException.StackTrace}
                    """
                : "";
            _res = string.Format(_res,
                _jokes[new Random().Next(0, _jokes.Length - 1)],
                DateTime.Now.TimeOfDay,
                _ex.GetType(),
                _ex.Message,
                _ex.StackTrace,
                IniFile.Read("Version", "friendly", "Unknown"),
                new ComputerInfo().OSFullName,
                IniFile.Read("Startup", "param_count", "Unknown"),
                IniFile.Read("Startup", "params", "Unknown"),
                System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect\\time"),
                "",//满足兼容
                IniFile.Read("Startup", "path", "Unknown"),
                "客户端",
                CultureInfo.CurrentCulture.DisplayName,
                System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect\\memory"),
                ret_foo,
                _ex.InnerException != null,
                InnerExceptionProcess,
                _ex.HResult
                );
        }

        public bool WriteDumpFile()
        {
            try
            {
                File.WriteAllText(_path, _res);
            }
            catch { return false; }
            return true;
        }

        private string foo()
        {
            string CPUs = "";
            {
                var management = new ManagementObjectSearcher("Select * from Win32_Processor");
                foreach (var baseObject in management.Get())
                {
                    var managementObject = (ManagementObject)baseObject;
                    var CPUName = managementObject["Name"].ToString();
                    CPUs += CPUName;
                }
            }
            return CPUs;
        }
    }
}
