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

                    string url = "https://localhost:7083/api/First/Login/" + username + "/" + password;
                    client.BaseAddress = new Uri(url);
                    HttpResponseMessage response = await client.GetAsync("");
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
