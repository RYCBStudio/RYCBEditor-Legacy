using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static IDE.Utils.Update.GlobalDefinitions;

namespace IDE.Utils.Update;
internal class CloudSourceConnecter
{
    /// <summary>
    /// 通过服务器超时更改<see cref="AreaInfo"/>信息。
    /// </summary>
    /// <returns>当前的<see cref="AreaInfo"/>。</returns>
    public async void RecognizeArea()
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
                CloudSourceOK = true;
                CurrentArea = AreaInfo.CHINA;
                return;
            }
        }
        catch 
        {
            CloudSourceOK = false;
            return;
        }

        CloudSourceOK = true;
        CurrentArea = AreaInfo.GLOBAL;
    }


    internal void GenerateDownloadURL()
    {
        if (CloudSourceOK)
        {
            switch (CurrentArea)
            {
                case AreaInfo.CHINA:
                    DownloadBaseUri = "https://share.asytech.cn/remote.php/webdav/IDE/";
                    break;
                case AreaInfo.GLOBAL:
                    DownloadBaseUri = "https://raw.githubusercontent.com/RYCBStudio/RE-Update-Resources/UpdateResources/";
                    break;
                default:
                    break;
            }
        }
    }
}