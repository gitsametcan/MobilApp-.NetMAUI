using FrontendWorks.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FrontendWorks.Service
{
    public class PolicyService : IPolicyRepo
    {
        public async Task<List<DaskPolicy>> GetDaskPolicyById(int id, string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                id = 1;
                var response = await client.GetAsync("https://vhp8b29z-7083.euw.devtunnels.ms/api/Dask");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<DaskPolicy>>(json);
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<TrafficPolicy> GetTrafficPolicyById(int id, string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync("https://kpgr67j6-7083.euw.devtunnels.ms/api/Account/authenticate/" + id.ToString());

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TrafficPolicy>(json);
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
