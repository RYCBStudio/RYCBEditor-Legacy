using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Downloader;
using IDE.Utils.PackageManager;
using IDE.Utils.Update;

namespace IDE;
internal partial class PackageProcessor
{
    private string TitleBase = "Downloading {0}:{2}/{3} {1}";
    internal bool CloudSourceOK;
    internal string BaseUrl;
    List<string> PackagesNames = [];
    internal FrmWPFDownloadProgressWindow dpw;
    internal FrmWPFDownloadProgressViewModel dpwViewModel;

    internal PackageProcessor(List<string> PackageNames)
    {
        CloudSourceOK = GlobalDefinitions.CloudSourceOK;
        BaseUrl = (GlobalDefinitions.CurrentArea == GlobalDefinitions.AreaInfo.CHINA) ? "https://share.asytech.cn/remote.php/webdav/IDE/packages/" : "";
        this.PackagesNames = PackageNames;
        dpw = new FrmWPFDownloadProgressWindow();
        dpwViewModel = new FrmWPFDownloadProgressViewModel();
        dpw.DataContext = dpwViewModel;
    }

    internal async Task DownloadAsync()
    {
        CloudSourceOK = true;
        if (CloudSourceOK)
        {
            dpw.Show();
            dpwViewModel.IsIntermediate = true;
            dpw.Topmost = true;
            dpwViewModel.Maximum = this.PackagesNames.Count;
            dpwViewModel.IsIntermediate = false;
            foreach (var PackageName in this.PackagesNames)
            {
                dpwViewModel.Title = $"Prepare to download {PackageName}...";
                dpwViewModel.IsSingleIntermediate = true;
                var downloadUrl = BaseUrl + PackageName.ToLower() + ".7z";
                //downloadUrl = "https://share.asytech.cn/remote.php/webdav/IDE/IDE.7z";
                var downloadOpt = new DownloadConfiguration()
                {
                    BufferBlockSize = 10240, // 通常，主机最大支持8000字节，默认值为8000。
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
                        UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36 Edg/126.0.0.0",
                        Credentials = GetCredentialCache(downloadUrl, USERNAME, PASSWORD),
                    }
                };
                var downloader = new DownloadService(downloadOpt);
                downloader.DownloadFileCompleted += GetPackageCompleted;
                downloader.DownloadProgressChanged += GetDownloadProgress;
                downloader.DownloadStarted += StartDownloading;
                var file = Program.STARTUP_PATH + "\\Cache\\Packages\\" + PackageName + ".repkg";
                TitleBase = string.Format(TitleBase, PackageName, "{1}", "{2}", "{3}");
                dpwViewModel.Title = TitleBase.Format("", "", "", "");
                await downloader.DownloadFileTaskAsync(downloadUrl, file);
            }
            dpwViewModel.Maximum = PackagesNames.Count;
            dpwViewModel.IsIntermediate = true;
            foreach (var PackageName in PackagesNames)
            {
                dpwViewModel.IsIntermediate = false;
                dpwViewModel.IsSingleIntermediate = true;
                var file = Program.STARTUP_PATH + "\\Cache\\Packages\\" + PackageName + ".repkg";
                await Task.Run(() => Extensions.DecompressFile(file, Program.STARTUP_PATH + $"Package\\{PackageName}"));
                dpwViewModel.Value++;
            }
        }
        else
        {
            FrmMain.LOGGER.Log("连接失败。", EnumMsgLevel.WARN, EnumPort.SERVER, EnumModule.NET);
        }
    }

    private void StartDownloading(object sender, DownloadStartedEventArgs e)
    {
        dpwViewModel.IsSingleIntermediate = false;
        dpwViewModel.SingleMaximum = (int)e.TotalBytesToReceive;
    }

    private void GetDownloadProgress(object sender, Downloader.DownloadProgressChangedEventArgs e)
    {
        var res = (int)e.ReceivedBytesSize;
        dpwViewModel.SingleValue = res;
        dpwViewModel.Title = string.Format(TitleBase, "", ProcessFileSize((long)e.BytesPerSecondSpeed) + "/s", ProcessFileSize(e.ReceivedBytesSize), ProcessFileSize(e.TotalBytesToReceive));
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

    private void GetPackageCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        FrmMain.LOGGER.Log("获取包成功。");
        dpwViewModel.Title = "Download success.";
        dpwViewModel.Value++;
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
}
