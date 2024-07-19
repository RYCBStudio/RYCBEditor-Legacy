using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Downloader;
using Sunny.UI;

namespace IDE.Utils.Update;
internal partial class UpdateChecker
{
    private readonly CloudSourceConnecter csc = new();

    public async Task InitAsync()
    {
        await csc.RecognizeAreaAsync();
        if (!GlobalDefinitions.CloudSourceOK) { return; }
        csc.GenerateDownloadURL();
    }

    public void ValidateUpdate()
    {
        if (GlobalDefinitions.UpdateInfo.MajorVersion >= FrmMain.MAJOR_VER &
            GlobalDefinitions.UpdateInfo.MinorVersion >= FrmMain.MINOR_VER &
            GlobalDefinitions.UpdateInfo.MicroVersion >= FrmMain.MICRO_VER &
            GlobalDefinitions.ValidateRevisionNumber(GlobalDefinitions.UpdateInfo.RevisionNumber))
        {
            GlobalDefinitions.CanUpdate = true;
            return;
        }
        else
        {
            GlobalDefinitions.CanUpdate = false;
        }
        return;
    }

    public async Task DownloadTestAsync()
    {
        if (!GlobalDefinitions.CloudSourceOK) { return; }
        var url = GlobalDefinitions.TestFileLists[GlobalDefinitions.CurrentArea];
        var DownloadOpt = new DownloadConfiguration()
        {
            BufferBlockSize = 8000, // 通常，主机最大支持8000字节，默认值为8000。
            ChunkCount = 16, // 要下载的文件分片数量，默认值为1
            MaxTryAgainOnFailover = 10, // 失败的最大次数
            ParallelDownload = GlobalSettings.Downloading.ParallelDownload, // 下载文件是否为并行的。默认值为false
            ParallelCount = GlobalSettings.Downloading.ParallelCount,
            Timeout = 2000, // 每个 stream reader  的超时（毫秒），默认值是1000

            RequestConfiguration = // 定制请求头文件
                {
                    Accept = "*/*",
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    CookieContainer =  new CookieContainer(), // Add your cookies
                    Headers = [], // Add your custom headers
                    KeepAlive = false,
                    ProtocolVersion = HttpVersion.Version11, // Default value is HTTP 1.1
                    UseDefaultCredentials = false,
                    UserAgent ="Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36 Edg/126.0.0.0",
                    Credentials = GetCredentialCache(url, USERNAME, PASSWORD),

                }
        };
        var downloader = new DownloadService(DownloadOpt);
        downloader.DownloadStarted += Downloader_DownloadStarted;
        downloader.DownloadFileCompleted += Downloader_DownloadTestFileCompleted;
        var path = new DirectoryInfo(Program.STARTUP_PATH + "\\Cache\\Update");
        await downloader.DownloadFileTaskAsync(url, path);
    }

    public async Task DownloadUpdateFileAsync()
    {
        if (!GlobalDefinitions.CloudSourceOK || !GlobalDefinitions.UpdateCheckOK) { return; }
        var url = GlobalDefinitions.DownloadBaseUri + "Update.ucf";
        var DownloadOpt = new DownloadConfiguration()
        {
            BufferBlockSize = 8000, // 通常，主机最大支持8000字节，默认值为8000。
            ChunkCount = 16, // 要下载的文件分片数量，默认值为1
            MaxTryAgainOnFailover = 10, // 失败的最大次数
            ParallelDownload = GlobalSettings.Downloading.ParallelDownload, // 下载文件是否为并行的。默认值为false
            ParallelCount = GlobalSettings.Downloading.ParallelCount,
            Timeout = 2000, // 每个 stream reader  的超时（毫秒），默认值是1000

            RequestConfiguration = // 定制请求头文件
                {
                    Accept = "*/*",
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    CookieContainer =  new CookieContainer(), // Add your cookies
                    Headers = [], // Add your custom headers
                    KeepAlive = false,
                    ProtocolVersion = HttpVersion.Version11, // Default value is HTTP 1.1
                    UseDefaultCredentials = false,
                    UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36 Edg/126.0.0.0s",
                    Credentials =GetCredentialCache(url, USERNAME, PASSWORD),

                }
        };
        var downloader = new DownloadService(DownloadOpt);
        downloader.DownloadStarted += Downloader_DownloadStarted;
        downloader.DownloadFileCompleted += Downloader_DownloadFileCompleted;
        var path = new DirectoryInfo(Program.STARTUP_PATH + "\\Cache\\Update");
        await downloader.DownloadFileTaskAsync(url, path);
        GlobalDefinitions.UpdateFile_Path = path + "\\Update.ucf";
    }

    #region # 生成 Http Basic 访问凭证 #
    private static CredentialCache GetCredentialCache(string uri, string username, string password)
    {
        var authorization = string.Format("{0}:{1}", username, password);
        var credCache = new CredentialCache
            {
                { new Uri(uri), "Basic", new NetworkCredential(username, password) }
            };
        return credCache;
    }
    private static string GetAuthorization(string username, string password)
    {
        var authorization = string.Format("{0}:{1}", username, password);
        return "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(authorization));
    }
    #endregion

    #region Downloader 事件
    private void Downloader_DownloadTestFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (e.Error is not null) { FrmMain.LOGGER.WriteErrLog(e.Error, EnumMsgLevel.WARN, EnumPort.SERVER); }
        FrmMain.LOGGER.WriteLog("测试文件下载完成", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.NET);
        GlobalDefinitions.UpdateCheckOK = true;
    }

    private void Downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (e.Error is not null) { FrmMain.LOGGER.WriteErrLog(e.Error, EnumMsgLevel.WARN, EnumPort.SERVER); }
        FrmMain.LOGGER.WriteLog("文件下载完成", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.NET);
    }

    private void Downloader_DownloadStarted(object sender, DownloadStartedEventArgs e)
    {
        FrmMain.LOGGER.WriteLog("开始下载文件", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.NET);
        FrmMain.LOGGER.WriteLog("文件名：" + e.FileName, EnumMsgLevel.INFO, EnumPort.SERVER, EnumModule.NET);
        FrmMain.LOGGER.WriteLog("文件大小：" + ProcessFileSize(e.TotalBytesToReceive), EnumMsgLevel.INFO, EnumPort.SERVER, EnumModule.NET);
    }

    /// <summary>
    /// 根据<paramref name="fileSize"/>的大小自动返回对应的文件大小值。
    /// <br/>
    /// 如：若<paramref name="fileSize"/>32743879328,则返回30.50GB；
    /// 返回值的数值范围为1~1000。
    /// </summary>
    /// <param name="fileSize">文件大小，单位为Bytes</param>
    /// <returns>处理后的文件大小值。</returns>
    private string ProcessFileSize(long fileSize)
    {
        string[] sizeUnits = ["B", "KB", "MB", "GB", "TB"];
        double size = fileSize;
        var unitIndex = 0;

        while (size >= 1024 && unitIndex < sizeUnits.Length - 1)
        {
            size /= 1024;
            unitIndex++;
        }

        return $"{Math.Round(size, 2)}{sizeUnits[unitIndex]}";
    }

    #endregion

    public bool AnalyzeUpdateFile()
    {
        if (!GlobalDefinitions.CloudSourceOK || !GlobalDefinitions.UpdateCheckOK || GlobalDefinitions.UpdateFile_Path.IsNullOrEmpty()) { FrmMain.LOGGER.WriteLog("云端模块未初始化完成或传入数据为空。", EnumMsgLevel.WARN, EnumPort.CLIENT, EnumModule.UPDATE); return false; }

        if (!GlobalDefinitions.ValidateFile(GlobalDefinitions.UpdateFile_Path, UCF_MD5, UCF_SHA256)) { FrmMain.LOGGER.WriteLog("Fatal Error: The MD5 value or SHA256 value does not match the original value. The update file may have been modified. To keep your computer safe, IDE has stopped reading it.", EnumMsgLevel.FATAL, EnumPort.CLIENT, EnumModule.UPDATE); return false; }

        IniFile ucf = new(GlobalDefinitions.UpdateFile_Path)
        {
            IniEncoding = Encoding.UTF8
        };

        try
        {
            GlobalDefinitions.UpdateInfo.RevisionNumber = ucf.ReadString("Update", "revision_number");
            GlobalDefinitions.UpdateInfo.Channel = ucf.ReadString("Update", "channel");
            GlobalDefinitions.UpdateInfo.FriendlyVersion = string.Format("{0}-{1}[{2}]", ucf.ReadString("Update", "version"), GlobalDefinitions.UpdateInfo.RevisionNumber, GlobalDefinitions.UpdateInfo.Channel);
            GlobalDefinitions.UpdateInfo.MajorVersion = ucf.ReadInt("Update", "major");
            GlobalDefinitions.UpdateInfo.MinorVersion = ucf.ReadInt("Update", "minor");
            GlobalDefinitions.UpdateInfo.MicroVersion = ucf.ReadInt("Update", "micro");
        }
        catch (Exception ex)
        {
            FrmMain.LOGGER.WriteErrLog(ex, EnumMsgLevel.WARN, EnumPort.CLIENT);
            return false;
        }
        return true;
    }
}
