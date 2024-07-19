using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IDE.Utils.Update;
internal class CloudSourceConnecter
{
    /// <summary>
    /// 通过服务器超时更改<see cref="IDE.Utils.Update.GlobalDefinitions.AreaInfo"/>信息。
    /// </summary>
    /// <returns>当前的<see cref="IDE.Utils.Update.GlobalDefinitions.AreaInfo"/>。</returns>
    public async Task RecognizeAreaAsync()
    {
        HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://share.asytech.cn"),
            Timeout = TimeSpan.FromSeconds(1),
        };
        try
        {
            var response = await httpClient.GetAsync(httpClient.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                GlobalDefinitions.CloudSourceOK = true;
                GlobalDefinitions.CurrentArea = GlobalDefinitions.AreaInfo.CHINA;
                return;
            }
        }
        catch 
        {
            GlobalDefinitions.CloudSourceOK = false;
            return;
        }

        GlobalDefinitions.CloudSourceOK = true;
        GlobalDefinitions.CurrentArea = GlobalDefinitions.AreaInfo.GLOBAL;
    }


    internal void GenerateDownloadURL()
    {
        if (GlobalDefinitions.CloudSourceOK)
        {
            switch (GlobalDefinitions.CurrentArea)
            {
                case GlobalDefinitions.AreaInfo.CHINA:
                    GlobalDefinitions.DownloadBaseUri = "https://share.asytech.cn/remote.php/webdav/IDE/";
                    break;
                case GlobalDefinitions.AreaInfo.GLOBAL:
                    GlobalDefinitions.DownloadBaseUri = "https://github.com/RYCBStudio/RE-Update-Resources/releases/download/0.1.0-rc/";
                    break;
                default:
                    break;
            }
        }
    }
}