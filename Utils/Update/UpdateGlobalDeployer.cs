using System;
using System.Diagnostics;
using System.IO;

namespace IDE.Utils.Update;
internal partial class UpdateGlobalDeployer
{

    public void DeployUpdate()
    {
        if (GlobalDefinitions.CanDeployUpdate)
        {
            var path = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\Update").FullName;

            if (GlobalDefinitions.ValidateFile(GlobalDefinitions.UpdateArchive_Path, ARCHIVE_MD5, ARCHIVE_SHA256))
            {
                FrmMain.instance.UpdateProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
                FrmMain.instance.ReceivedBytesSeparatorSign.Visible = false;
                FrmMain.instance.ToReceiveBytes.Text = "";
                FrmMain.instance.Downloading.Text = "Decompressing: ";
                FrmMain.instance.DownloadProgress.Text = "";
                FrmMain.instance.Percent.Visible = false;
                if (DecompressFile(GlobalDefinitions.UpdateArchive_Path, path))
                {
                    FrmMain.instance.NewUpdateTip.Text = "Updates are ready.";
                    GlobalDefinitions.UpdateDeployed = true;
                    GlobalDefinitions.DecompressedUpdateArchive_Path = path;
                }
                else
                {
                    FrmMain.LOGGER.Log("Errors occured when decompressing the update file.", EnumMsgLevel.ERROR, EnumPort.CLIENT, EnumModule.UPDATE);
                }
            }
            else
            {
                FrmMain.instance.NewUpdateTip.Text = "Updates are broken.";
                FrmMain.instance.CanUpdateIcon.Image = Properties.Resources.Exception_32X;
                FrmMain.LOGGER.Log("Fatal Error: The MD5 value or SHA256 value does not match the original value. The update file may have been modified. To keep your computer safe, IDE has stopped reading it.", EnumMsgLevel.FATAL, EnumPort.CLIENT, EnumModule.UPDATE);
            }
        }
    }

    public bool DecompressFile(string zipPath, string filePath)
    {
        var exeRes = true;
        try
        {
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            var message = "";
            var command0 = "cd \"" + Program.STARTUP_PATH + "\\Tools\"";
            var command = "";

            command = $"7Z x -t7z \"" + zipPath + "\" -o\"" + filePath + "\" -y";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.StandardInput.WriteLine(command0);
            process.StandardInput.WriteLine(command);
            process.StandardInput.WriteLine("exit");
            //process.WaitForExit();
            message = process.StandardOutput.ReadToEnd();//要等压缩完成后才可以来抓取这个压缩文件

            process.Close();
            if (!message.Contains("Everything is Ok"))
            {
                exeRes = false;
            }
        }
        catch
        {
            exeRes = false;
        }

        return exeRes;
    }

}
