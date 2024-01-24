using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Downloader;
using Sunny.UI.Win32;

namespace IDE.Utils.Update;
internal class UpdateChecker
{
    public async void DownloadTest()
    {
        var csc = new CloudSourceConnecter();
        csc.RecognizeArea();
        if (!GlobalDefinitions.CloudSourceOK) { return; }
        csc.GenerateDownloadURL();
        var downloadOpt = new DownloadConfiguration()
        {
            BufferBlockSize = 10240,
            ChunkCount = Environment.ProcessorCount * 16,
            MaximumBytesPerSecond = 5368709120,
            MaxTryAgainOnFailover = 5,
            MaximumMemoryBufferBytes = 5368709120,
            ParallelDownload = true,
            ParallelCount = Environment.ProcessorCount * 2,
            Timeout = 1000,
            RequestConfiguration =
    {
            Accept = "*/*",
        Headers = [],
        KeepAlive = true,
        ProtocolVersion = HttpVersion.Version11,
        UseDefaultCredentials = false,
        UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 Edg/122.0.0.0",
    }
        };
        var downloader = new DownloadService(downloadOpt);
        downloader.DownloadStarted += Downloader_DownloadStarted;
        downloader.DownloadFileCompleted += Downloader_DownloadFileCompleted;
        var path = new DirectoryInfo(Program.STARTUP_PATH + "\\Cache\\Update");
        var url = GlobalDefinitions.DownloadBaseUri + @"TestDownloadFile.Text";
        await downloader.DownloadFileTaskAsync(url, path);
    }

    private void Downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        Main.LOGGER.WriteLog("测试文件下载完成", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.NET);
        GlobalDefinitions.UpdateCheckOK = true;
    }

    private void Downloader_DownloadStarted(object sender, DownloadStartedEventArgs e)
    {
        Main.LOGGER.WriteLog("开始下载测试文件", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.NET);
        Main.LOGGER.WriteLog("文件大小：" + Math.Round((double)e.TotalBytesToReceive / 1024 / 1024) + "MB", EnumMsgLevel.INFO, EnumPort.SERVER, EnumModule.NET);
    }
}
