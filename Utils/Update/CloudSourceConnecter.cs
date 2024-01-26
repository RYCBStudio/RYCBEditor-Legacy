using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IDE.Utils.Update;
internal class CloudSourceConnecter
{
    /// <summary>
    /// 通过服务器超时更改<see cref="AreaInfo"/>信息。
    /// </summary>
    /// <returns>当前的<see cref="AreaInfo"/>。</returns>
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
                    GlobalDefinitions.DownloadBaseUri = "https://raw.githubusercontent.com/RYCBStudio/RE-Update-Resources/UpdateResources/";
                    break;
                default:
                    break;
            }
        }
    }
}