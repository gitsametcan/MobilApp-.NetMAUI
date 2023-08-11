using FrontendWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendWorks.Service
{
    public interface IPolicyRepo
    {
        public Task<TrafficPolicy> GetTrafficPolicyById(int id, string token);
        public Task<List<DaskPolicy>> GetDaskPolicyById(int id, string token);
    }
}
