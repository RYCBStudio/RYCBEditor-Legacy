using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.Utils.Update;
internal partial class UpdateValidater
{
    internal async Task ValidateFileAsync()
    {
        List<string> files = new(System.IO.Directory.GetFiles(GlobalDefinitions.DecompressedUpdateArchive_Path));
        Main.LOGGER.WriteLog("需验证文件数量：" + files.Count.ToString(), EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
        Main.instance.UpdateProgress.Maximum = files.Count;
        Main.instance.UpdateProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        Main.instance.Percent.Visible = true;
        Main.instance.ReceivedBytesSeparatorSign.Visible = true;
        Main.instance.DownloadProgress.Text = "";
        Main.instance.ToReceiveBytes.Text = files.Count.ToString();

        #region Validate MD5 Values        
        Main.instance.Downloading.Text = "Validating MD5 Values: ";
        for (var j = 1; j <= files.Count; j++)
        {
            var md5 = await Task.Run(() => GlobalDefinitions.GetMD5HashFromFile(files[j - 1]));
            var isSame = await Task.Run(() => md5.Equals(MD5Values[Microsoft.IO.Path.GetRelativePath(GlobalDefinitions.DecompressedUpdateArchive_Path, files[j - 1])], StringComparison.CurrentCultureIgnoreCase));
            if (isSame)
            {
                Main.instance.UpdateProgress.Value = j;
                Main.instance.ReceivedBytes.Text = j.ToString();
                Main.instance.DownloadProgress.Text = (Math.Round((double) (Main.instance.UpdateProgress.Value/Main.instance.UpdateProgress.Maximum), 4)*100).ToString();
            }
        }
        Main.LOGGER.WriteLog("MD5值验证完毕。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
        #endregion
        Main.instance.UpdateProgress.Value = 0;
        #region Validate SHA256 Values        
        Main.instance.Downloading.Text = "Validating SHA256 Values: ";
        for (var j = 1; j <= files.Count; j++)
        {
            var sha256 = await Task.Run(() => GlobalDefinitions.GetSHA256(files[j - 1]));
            var isSame = await Task.Run(() => sha256.Equals(SHA256Values[Microsoft.IO.Path.GetRelativePath(GlobalDefinitions.DecompressedUpdateArchive_Path, files[j - 1])], StringComparison.CurrentCultureIgnoreCase));
            if (isSame)
            {
                Main.instance.UpdateProgress.Value = j;
                Main.instance.ReceivedBytes.Text = j.ToString();
                Main.instance.DownloadProgress.Text = (Math.Round((double)(Main.instance.UpdateProgress.Value / Main.instance.UpdateProgress.Maximum), 4) * 100).ToString();
            }
        }
        Main.LOGGER.WriteLog("SHA256值验证完毕。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
        #endregion
    }

}
