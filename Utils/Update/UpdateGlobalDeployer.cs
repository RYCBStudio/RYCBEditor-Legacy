﻿using System;
using System.Diagnostics;
using System.IO;

namespace IDE.Utils.Update;
internal partial class UpdateGlobalDeployer
{
    public void DeployUpdate()
    {
        if (GlobalDefinitions.CanDeployUpdate)
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\Update");
            if (DecompressFile(GlobalDefinitions.UpdateArchive_Path, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\Update"))
            {
                if (GlobalDefinitions.ValidateFile(GlobalDefinitions.UpdateArchive_Path, ARCHIVE_MD5, ARCHIVE_SHA256))
                {
                    Main.instance.toolStripStatusLabel9.Text = "Updates are ready.";
                    GlobalDefinitions.UpdateDeployed = true;
                }
                Main.instance.toolStripStatusLabel9.Text = "Updates are broken";
                Main.LOGGER.WriteLog("Fatal Error: The MD5 value or SHA256 value does not match the original value. The update file may have been modified. To keep your computer safe, IDE has stopped reading it.", EnumMsgLevel.FATAL, EnumPort.CLIENT, EnumModule.UPDATE);
            }
        }
    }

    public bool DecompressFile(string zipPath, string filePath)
    {
        bool exeRes = false;
        try
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            string message = "";
            string command0 = "cd " + Program.STARTUP_PATH + "\\Tools";
            string command = "";

            command = $"7Z x -t7z " + zipPath + " -o" + filePath + " -y";
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
