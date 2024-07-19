using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.Utils.Update;
internal partial class UpdateValidater
{
    internal async Task ValidateFileAsync()
    {
        List<string> files = new(System.IO.Directory.GetFiles(GlobalDefinitions.DecompressedUpdateArchive_Path));
        FrmMain.LOGGER.WriteLog("需验证文件数量：" + files.Count.ToString(), EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
        FrmMain.instance.UpdateProgress.Maximum = files.Count;
        FrmMain.instance.UpdateProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        FrmMain.instance.Percent.Visible = true;
        FrmMain.instance.ReceivedBytesSeparatorSign.Visible = true;
        FrmMain.instance.DownloadProgress.Text = "";
        FrmMain.instance.ToReceiveBytes.Text = files.Count.ToString();

        var _ = GlobalDefinitions.ReadJsonFile(GlobalDefinitions.DecompressedUpdateArchive_Path+"\\pkg_version");
        var _MD5Values = _.Item1;
        var _SHA256Values = _.Item2;

        #region Validate MD5 Values        
        FrmMain.instance.Downloading.Text = "Validating MD5 Values: ";
        for (var j = 1; j <= files.Count; j++)
        {
            var md5 = await Task.Run(() => GlobalDefinitions.GetMD5HashFromFile(files[j - 1]));
            var rp = Microsoft.IO.Path.GetRelativePath(GlobalDefinitions.DecompressedUpdateArchive_Path, files[j - 1]);
            if (rp == "pkg_version"||rp == "package.info")
            {

                FrmMain.instance.UpdateProgress.Value = j;
                FrmMain.instance.ReceivedBytes.Text = j.ToString();
                FrmMain.instance.DownloadProgress.Text = (Math.Round((double)(FrmMain.instance.UpdateProgress.Value / FrmMain.instance.UpdateProgress.Maximum), 4) * 100).ToString();
                continue;
            }
            var isSame = await Task.Run(() => md5.Equals(_MD5Values[rp], StringComparison.CurrentCultureIgnoreCase));
            if (isSame)
            {
                FrmMain.instance.UpdateProgress.Value = j;
                FrmMain.instance.ReceivedBytes.Text = j.ToString();
                FrmMain.instance.DownloadProgress.Text = (Math.Round((double) (FrmMain.instance.UpdateProgress.Value/FrmMain.instance.UpdateProgress.Maximum), 4)*100).ToString();
            }
        }
        FrmMain.LOGGER.WriteLog("MD5值验证完毕。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
        #endregion
        FrmMain.instance.UpdateProgress.Value = 0;
        #region Validate SHA256 Values        
        FrmMain.instance.Downloading.Text = "Validating SHA256 Values: ";
        for (var j = 1; j <= files.Count; j++)
        {
            var sha256 = await Task.Run(() => GlobalDefinitions.GetSHA256(files[j - 1]));
            var rp = Microsoft.IO.Path.GetRelativePath(GlobalDefinitions.DecompressedUpdateArchive_Path, files[j - 1]);
            if (rp == "pkg_version" || rp == "package.info")
            {

                FrmMain.instance.UpdateProgress.Value = j;
                FrmMain.instance.ReceivedBytes.Text = j.ToString();
                FrmMain.instance.DownloadProgress.Text = (Math.Round((double)(FrmMain.instance.UpdateProgress.Value / FrmMain.instance.UpdateProgress.Maximum), 4) * 100).ToString();
                continue;
            }
            var isSame = await Task.Run(() => sha256.Equals(_SHA256Values[rp], StringComparison.CurrentCultureIgnoreCase));
            if (isSame)
            {
                FrmMain.instance.UpdateProgress.Value = j;
                FrmMain.instance.ReceivedBytes.Text = j.ToString();
                FrmMain.instance.DownloadProgress.Text = (Math.Round((double)(FrmMain.instance.UpdateProgress.Value / FrmMain.instance.UpdateProgress.Maximum), 4) * 100).ToString();
            }
        }
        FrmMain.LOGGER.WriteLog("SHA256值验证完毕。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
        #endregion
        GlobalDefinitions.UpdateReady = true;
        System.IO.File.WriteAllText(GlobalDefinitions.DecompressedUpdateArchive_Path + "\\package.info", $"RYCB Editor {GlobalDefinitions.UpdateInfo.FriendlyVersion} Update Package\nRYCB Studio\nCopyright © {DateTime.Now.Year} RYCBStudio\n");
    }

}
