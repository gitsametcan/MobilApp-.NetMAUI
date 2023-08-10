using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendWorks.NonTable
{
    public class Constants
    {
        static string fromDevTunnels = "https://5tqp6zwb-7083.euw.devtunnels.ms"; 
        static string token = "asdasd";

        public static string getBaseAddress()
        {
            return fromDevTunnels;
        }

        public static string getToken()
        {
            return token;
        }
    }
}
