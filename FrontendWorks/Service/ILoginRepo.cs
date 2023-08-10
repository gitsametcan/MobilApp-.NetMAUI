using FrontendWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendWorks.Service
{
    public interface ILoginRepo
    {
        public Task<LoginResponse> Authenticate(LoginRequest lr);
    }
}
