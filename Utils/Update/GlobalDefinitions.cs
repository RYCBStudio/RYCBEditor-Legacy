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

    internal static bool CloudSourceOK
    {
        get; set;
    }
    
    internal static bool UpdateCheckOK
    {
        get; set;
    }

    internal static AreaInfo CurrentArea
    {
        get; set;
    }

    internal static string DownloadBaseUri
    {
        get; set;
    }

    internal static readonly List<Dictionary<AreaInfo, string>> TestFileLists =
    [
        new(){{AreaInfo.CHINA, "https://share.asytech.cn/remote.php/webdav/TestDownloadFile.Text" }, {AreaInfo.GLOBAL, "https://raw.githubusercontent.com/RYCBStudio/RE-Update-Resources/UpdateResources/TestDownloadFile.Text" } }
    ];

    internal static string Update_URL
    {
        get; set;
    }

    internal static string UpdateFile_URL
    {
        get; set;
    }
}
