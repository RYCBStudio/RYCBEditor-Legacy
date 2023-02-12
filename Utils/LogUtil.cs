#region 导入命名空间
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
#endregion

namespace IDE
{
    #region 主类
    public class LogUtil
    {
        #region 变量声明
        internal string logPath;
        private RegistryKey IDE_CFG = Registry.LocalMachine
            .OpenSubKey(@"SOFTWARE", true)
            .OpenSubKey("RYCB", true)
            .OpenSubKey("IDE", true)
            .CreateSubKey("global_cfg", true);
        private string lang;
        #endregion
        #region 构造方法
        public LogUtil(string logPath)
        {
            this.logPath = logPath;
            lang = (string)(IDE_CFG.GetValue("lang") != null ? IDE_CFG.GetValue("lang") : "en");
        }
        #endregion
        #region 写日志
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="data">要写入的数据</param>
        /// <param name="msgLevel">消息级别</param>
        /// <param name="port">端口</param>
        public void WriteLog(string data, EnumMsgLevel msgLevel, EnumPort port)
        {
            FileStream tmpStream;
            try
            {
                tmpStream = new(logPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite | FileShare.Inheritable);
            }
            catch (DirectoryNotFoundException)
            {
                ExecuteCMDWithOutput("mkdir logs");
                tmpStream = new(logPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
            StreamWriter sw = new(tmpStream);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("[{3}:{4}:{5}:{6}] [{0}|{1}] {2} ",
                I18n.Translate((int)port, "port", lang),
                I18n.Translate((int)msgLevel, "msg", lang),
                data, DateTime.Now.Hour, DateTime.Now.Minute,
                DateTime.Now.Second, DateTime.Now.Millisecond);
            tmpStream.Flush();
            sw.Flush();
        }
        #endregion
        #region 写日志
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="data">要写入的数据</param>
        /// <param name="msgLevel">消息级别</param>
        /// <param name="port">端口</param>
        /// <param name="module">模块名</param>
        public void WriteLog(string data, EnumMsgLevel msgLevel, EnumPort port, EnumModule module)
        {
            FileStream tmpStream;
            try
            {
                tmpStream = new(logPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite | FileShare.Inheritable);
            }
            catch (DirectoryNotFoundException)
            {
                ExecuteCMDWithOutput("mkdir logs");
                tmpStream = new(logPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
            StreamWriter sw = new(tmpStream);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("[{3}:{4}:{5}:{6}] [{0}:{7}|{1}] {2} ",
                I18n.Translate((int)port, "port", lang),
                I18n.Translate((int)msgLevel, "msg", lang),
                data, DateTime.Now.Hour, DateTime.Now.Minute,
                DateTime.Now.Second, DateTime.Now.Millisecond,
                I18n.Translate((int)module, "module", lang));
            tmpStream.Flush();
            sw.Flush();
        }
        #endregion
        #region 写错误日志
        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="data">要写入的数据</param>
        /// <param name="ex">捕获的异常</param>
        /// <param name="msgLevel">消息级别</param>
        /// <param name="port">端口</param>
        public void WriteErrLog(Exception ex, EnumMsgLevel msgLevel, EnumPort port)
        {
            string data = ex.Message;
            FileStream tmpStream = new(logPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter sw = new(tmpStream);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("[{3}:{4}:{5}:{6}] [{0}|{1}] [Type {9}] [HResult {7}]" +
                " [InnerException: {10} HResult {8}] 已捕获异常：{11} \n 异常信息：{2}",
                I18n.Translate((int)port, "port", lang),
                I18n.Translate((int)msgLevel, "msg", lang),
                data, DateTime.Now.Hour, DateTime.Now.Minute,
                DateTime.Now.Second, DateTime.Now.Millisecond,
                ex.HResult,
                ex.InnerException != null ? ex.InnerException.HResult : "Null",
                ex.ToString().Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[0],
                ex.InnerException != null ? ex.InnerException.ToString().Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[0] : "Null", 
                ex.GetType());
            sw.WriteLine("[{3}:{4}:{5}:{6}] [{0}|{1}] ======== 堆栈跟踪如下 ======== \n\t\t\t\t[Outer Exception] {7}\n\t\t\t\t[Inner Exception] {8}",
                I18n.Translate((int)port, "port", lang),
                I18n.Translate((int)msgLevel, "msg", lang),
                data, DateTime.Now.Hour, DateTime.Now.Minute,
                DateTime.Now.Second, DateTime.Now.Millisecond,
                ex.StackTrace,
                ex.InnerException != null ? ex.InnerException.StackTrace : "(无 InnerException)");
            tmpStream.Flush();
            sw.Flush();
        }
        #endregion
        #region 写错误日志
        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="data">要写入的数据</param>
        /// <param name="ex">捕获的异常</param>
        /// <param name="msgLevel">消息级别</param>
        /// <param name="port">端口</param>
        public void WriteErrLog(string data, Exception ex, EnumMsgLevel msgLevel, EnumPort port)
        {
            FileStream tmpStream = new(logPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter sw = new(tmpStream);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("[{3}:{4}:{5}:{6}] [{0}|{1}] [Type {9}] [HResult {7}]" +
                " [InnerException: {10} HResult {8}] {2} ",
                I18n.Translate((int)port, "port", lang),
                I18n.Translate((int)msgLevel, "msg", lang),
                data, DateTime.Now.Hour, DateTime.Now.Minute,
                DateTime.Now.Second, DateTime.Now.Millisecond,
                ex.HResult,
                ex.InnerException != null ? ex.InnerException.HResult : "Null",
                ex.ToString().Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[0],
                ex.InnerException != null ? ex.InnerException.ToString().Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[0] : "Null");
            sw.WriteLine("[{3}:{4}:{5}:{6}] [{0}|{1}] ======== 堆栈跟踪如下 ======== \n\t\t\t\t[Outer Exception] {7}\n\t\t\t\t[Inner Exception] {8}",
                I18n.Translate((int)port, "port", lang),
                I18n.Translate((int)msgLevel, "msg", lang),
                data, DateTime.Now.Hour, DateTime.Now.Minute,
                DateTime.Now.Second, DateTime.Now.Millisecond,
                ex.StackTrace,
                ex.InnerException != null ? ex.InnerException.StackTrace : "(无 InnerException)");
            tmpStream.Flush();
            sw.Flush();
        }
        #endregion
        #region 执行CMD
        /// <summary>
        /// 执行带返回值的CMD
        /// </summary>
        /// <param name="command">命令</param>
        /// <returns></returns>
        private string ExecuteCMDWithOutput(string command)
        {
            ProcessStartInfo processInfo = new("cmd")
            {
                Arguments = " /s /c " + command,
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true
            };

            Process process = new() { StartInfo = processInfo };
            process.Start();
            string outpup = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return outpup;
        }
        #endregion
        #region 析构函数
        ~LogUtil()
        {
            //sw.Flush();    //清空缓冲区
            //sw.Close();    //关闭写数据流
            //file1.Close();   //关闭文件流
        }
        #endregion
    }
    #endregion
    #region I18n Translation Module
    public static class I18n
    {
        private static string[] msgLvlEn = new string[] { "INFO", "WARN", "ERROR", "FATAL", "DEBUG" };
        private static string[] msgLvlZh = new string[] { "信息", "警告", "错误", "致命错误", "调试" };
        private static string[] portEn = new string[] { "CLIENT", "SERVER" };
        private static string[] portZh = new string[] { "客户端", "服务端" };
        private static string[] moduleEn = new string[] { "Main Module", "I18n Translation Module", "Command Prompt", "Terminal", "Initialization", "Net Request", "I/O" };
        private static string[] moduleZh = new string[] { "主程序", "I18n翻译模块", "命令提示符模块", "终端", "初始化", "网络请求", "文件交互" };

        #region I18n Translate
        public static string Translate(int index, string type, string lang)
        {
            try
            {
                if ((index >= 0) & (type != null) & (lang != null))
                {
                    switch (lang)
                    {
                        case "zh":
                            switch (type)
                            {
                                case "msg":
                                    return msgLvlZh[index];
                                case "port":
                                    return portZh[index];
                                case "module":
                                    return moduleZh[index];
                                default:
                                    break;
                            }
                            break;
                        case "en":
                            switch (type)
                            {
                                case "msg":
                                    return msgLvlEn[index];
                                case "port":
                                    return portEn[index];
                                case "module":
                                    return moduleEn[index];
                                default:
                                    break;
                            }
                            break;
                        case "zh_CN":
                            switch (type)
                            {
                                case "msg":
                                    return msgLvlZh[index];
                                case "port":
                                    return portZh[index];
                                case "module":
                                    return moduleZh[index];
                                default:
                                    break;
                            }
                            break;
                        case "en_US":
                            switch (type)
                            {
                                case "msg":
                                    return msgLvlEn[index];
                                case "port":
                                    return portEn[index];
                                case "module":
                                    return moduleEn[index];
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtil LOGGER = Main.LOGGER;
                LOGGER.WriteErrLog($"An/Some Exception(s) are caught：{ex.Message}", ex, EnumMsgLevel.FATAL, EnumPort.CLIENT);
            }
            return "invalid param";
        }
        #endregion
    }
    #endregion
    #region Log Warning Level
    public enum EnumMsgLevel
    {
        INFO,
        WARN,
        ERROR,
        FATAL,
        DEBUG,
    }
    #endregion
    #region Log Port
    public enum EnumPort
    {
        CLIENT,
        SERVER,
    }
    #endregion
    #region Program Module
    public enum EnumModule
    {
        MAIN,
        I18N,
        CMD,
        TERMINAL,
        INIT,
        NET,
        IO,
    }
    #endregion
}
