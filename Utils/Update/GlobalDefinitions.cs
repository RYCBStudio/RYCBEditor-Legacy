using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IDE.Utils.Update;
internal static class GlobalDefinitions
{
    internal enum AreaInfo
    {
        CHINA,
        GLOBAL
    }

    internal static bool CloudSourceOK;

    internal static bool UpdateCheckOK = true;

    internal static AreaInfo CurrentArea;

    internal static string DownloadBaseUri;

    internal static readonly Dictionary<AreaInfo, string> TestFileLists = new()
    {
        {AreaInfo.CHINA, "https://share.asytech.cn/remote.php/webdav/TestDownloadFile.Text"},
            {AreaInfo.GLOBAL,
    "https://raw.githubusercontent.com/RYCBStudio/RE-Update-Resources/UpdateResources/TestDownloadFile.Text"}
    };

    internal static string UpdateFile_URL;

    internal static string UpdateFile_Path;

    internal static class UpdateInfo
    {
        public static string FriendlyVersion;
        public static int MajorVersion;
        public static int MinorVersion;
        public static int MicroVersion;
        public static string RevisionNumber;
        public static string Channel;
    }

    internal static bool ValidateFile(string FilePath, string md5, string sha256)
    {
        var CurrentMd5 = GetMD5HashFromFile(FilePath);
        var CurrentSHA256 = GetSHA256(FilePath);
        if (CurrentMd5 == md5 & CurrentSHA256 == sha256)
        {
            return true;
        }
        return false;
    }

    internal static string GetMD5HashFromFile(string fileName)
    {
        try
        {
            FileStream file = new FileStream(fileName, System.IO.FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        catch (Exception ex)
        {
            Main.LOGGER.WriteErrLog(new Exception("GetMD5HashFromFile() fail,error:" + ex.Message), EnumMsgLevel.ERROR, EnumPort.CLIENT);
        }
        return string.Empty;
    }

    internal static string GetSHA256(string filePath)
    {
        using (var sha256 = SHA256.Create())
        {
            using (var stream = File.OpenRead(filePath))
            {
                var hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
