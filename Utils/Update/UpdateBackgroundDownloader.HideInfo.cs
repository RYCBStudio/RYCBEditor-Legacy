using System;
using System.Net;
using System.Text;
using Downloader;

namespace IDE.Utils.Update;
internal partial class UpdateBackgroundDownloader
{
    private const string USERNAME = "rycbqyf@163.com";
    private const string PASSWORD = "rycbqyf666";

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
    private void Downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (e.Error is not null) { Main.LOGGER.WriteErrLog(e.Error, EnumMsgLevel.WARN, EnumPort.SERVER); return; }
        Main.LOGGER.WriteLog("文件下载完成", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.NET);
        GlobalDefinitions.CanDeployUpdate = true;
    }

    private void Downloader_DownloadStarted(object sender, DownloadStartedEventArgs e)
    {
        Main.LOGGER.WriteLog("开始下载文件", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.NET);
        Main.LOGGER.WriteLog("文件名：" + e.FileName, EnumMsgLevel.INFO, EnumPort.SERVER, EnumModule.NET);
        Main.LOGGER.WriteLog("文件大小：" + ProcessFileSize(e.TotalBytesToReceive), EnumMsgLevel.INFO, EnumPort.SERVER, EnumModule.NET);
        Main.instance.UpdateProgress.Maximum = (int)e.TotalBytesToReceive;
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

        return $"{Math.Round(size, 2).ToString().PadRight(2, '0')}{sizeUnits[unitIndex]}";
    }

    #endregion
}
