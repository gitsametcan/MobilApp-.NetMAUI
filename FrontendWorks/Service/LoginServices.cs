﻿using FrontendWorks.Models;
using FrontendWorks.NonTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata;
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
                    

                    //string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://3ch9ls5d-5267.euw.devtunnels.ms" : "https://localhost:7083";
                    //string BaseAddress = "https://vc4bmvk6-7083.euw.devtunnels.ms";
                    
                    string url = $"{Constants.getBaseAddress}/api/User/Login/" + username + "/" + password;
                    client.BaseAddress = new Uri(url);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress);
                    request.Headers.Add("Authorization", Constants.getToken());
                    //var ba = await client.GetAsync("");
                    HttpResponseMessage response = await client.SendAsync(request);
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
