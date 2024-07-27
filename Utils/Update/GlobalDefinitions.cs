using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace IDE.Utils.Update;
internal static class GlobalDefinitions
{
    internal enum AreaInfo
    {
        CHINA,
        GLOBAL
    }

    internal static bool CloudSourceOK;

    internal static bool UpdateCheckOK;

    internal static bool CanUpdate;

    internal static bool CanDeployUpdate;

    internal static bool UpdateDeployed;

    internal static bool UpdateReady;

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

    internal static string UpdateArchive_Path;

    internal static string DecompressedUpdateArchive_Path;

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
            var file = new FileStream(fileName, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            var retVal = md5.ComputeHash(file);
            file.Close();
            var sb = new StringBuilder();
            for (var i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        catch (Exception ex)
        {
            FrmMain.LOGGER.Err(new Exception("GetMD5HashFromFile() fail,error:" + ex.Message), EnumMsgLevel.ERROR, EnumPort.CLIENT);
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

    public static (Dictionary<string, string>, Dictionary<string, string>) ReadJsonFile(string filePath)
    {
        try
        {
            // 读取JSON文件内容
            var jsonContent = System.IO.File.ReadAllText(filePath);

            // 使用Json.NET反序列化JSON内容为字典
            var fileData = JsonConvert.DeserializeObject<Dictionary<string, FileData>>(jsonContent);

            // 创建存储结果的字典
            var md5Dictionary = new Dictionary<string, string>();
            var sha256Dictionary = new Dictionary<string, string>();

            // 填充结果字典
            foreach (var entry in fileData)
            {
                md5Dictionary.Add(entry.Key, entry.Value.MD5);
                sha256Dictionary.Add(entry.Key, entry.Value.SHA256);
            }

            // 返回结果
            return (md5Dictionary, sha256Dictionary);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            return (null, null);
        }
    }

    public class FileData
    {
        public string MD5
        {
            get; set;
        }
        public string SHA256
        {
            get; set;
        }
    }

    internal static bool ValidateRevisionNumber(string revisionNumber)
    {
        FrmMain.LOGGER.Log("验证修订号。", EnumMsgLevel.INFO, EnumPort.CLIENT, EnumModule.UPDATE);
        List<string> rn_list = ["alpha", "beta", "rc", "public"];
        if (rn_list.IndexOf(revisionNumber) >= rn_list.IndexOf(FrmMain.REVISION.ToLower()))
        {
            return true;
        }
        return false;
    }
}
