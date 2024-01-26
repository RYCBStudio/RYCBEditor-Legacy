using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
