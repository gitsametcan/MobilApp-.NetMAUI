using FrontendWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FrontendWorks.Service
{
    public class LoginServices : ILoginRepo
    {
        public async Task<UserInfo> Login(string username, string password)
        {

            try
            {
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                {
                    var userInfo = new UserInfo();
                    var client = new HttpClient();

                    string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://3ch9ls5d-5267.euw.devtunnels.ms" : "https://localhost:7083";
                    //string BaseAddress = "https://3ch9ls5d-5267.euw.devtunnels.ms";
                    string url = $"{BaseAddress}/api/First/Login/" + username + "/" + password;
                    client.BaseAddress = new Uri(url);
                    //var ba = await client.GetAsync("");
                    HttpResponseMessage response = await client.GetAsync("");
                    String a = response.Content.ToString();
                    if (response.IsSuccessStatusCode)
                    {
                        //string content = response.Content.ReadAsStringAsync().Result;
                        userInfo = await response.Content.ReadFromJsonAsync<UserInfo>();

                        return await Task.FromResult(userInfo);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
