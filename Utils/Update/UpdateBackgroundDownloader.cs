using System.Net;
using System.Reflection;
using System;
using System.Threading.Tasks;
using Downloader;
using System.IO;

namespace IDE.Utils.Update;
internal partial class UpdateBackgroundDownloader
{

    internal static bool updateFLAG = true;
    internal DownloadService downloader;
    public async Task DownloadUpdateAsync()
    {
        if (!GlobalDefinitions.CloudSourceOK & !GlobalDefinitions.UpdateCheckOK) { return; }
        var url = GlobalDefinitions.DownloadBaseUri + "\\IDE.7z";
        var DownloadOpt = new DownloadConfiguration()
        {
            BufferBlockSize = 10240, // 通常，主机最大支持8000字节，默认值为8000。
            ChunkCount = Environment.ProcessorCount * 16, // 要下载的文件分片数量，默认值为1
            MaximumBytesPerSecond = (long)(1024 * Math.Pow(1024, 2)), // 下载速度限制为1GB/s，默认值为零或无限制
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
                    UserAgent = $"DownloaderSample/{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}",
                    Credentials = GetCredentialCache(url, USERNAME, PASSWORD),

                }
        };
        downloader = new DownloadService(DownloadOpt);
        downloader.DownloadStarted += Downloader_DownloadStarted;
        downloader.DownloadFileCompleted += Downloader_DownloadFileCompleted;
        downloader.DownloadProgressChanged += Downloader_DownloadProgressChanged;
        var file = Program.STARTUP_PATH + $"\\Cache\\Update\\IDE_{GlobalDefinitions.UpdateInfo.FriendlyVersion}+y{DateTime.Now.Year}m{DateTime.Now.Month}d{DateTime.Now.Day}.7z";
        GlobalDefinitions.UpdateArchive_Path = file;
        if (File.Exists(GlobalDefinitions.UpdateArchive_Path)) { GlobalDefinitions.CanDeployUpdate = true; return; }
        await downloader.DownloadFileTaskAsync(url, file);
    }

    public void Downloader_DownloadProgressChanged(object sender, Downloader.DownloadProgressChangedEventArgs e)
    {
        FrmMain.instance.DownloadSpeed.Text = ProcessFileSize((long)e.BytesPerSecondSpeed) + "/s";
        FrmMain.instance.ReceivedBytes.Text = ProcessFileSize(e.ReceivedBytesSize);
        FrmMain.instance.ToReceiveBytes.Text = ProcessFileSize(e.TotalBytesToReceive);
        FrmMain.instance.UpdateProgress.Value = (int)e.ReceivedBytesSize;
        FrmMain.instance.DownloadProgress.Text = (Math.Round((double)FrmMain.instance.UpdateProgress.Value / FrmMain.instance.UpdateProgress.Maximum, 4) * 100).ToString();
    }
}
