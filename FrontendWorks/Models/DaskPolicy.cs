using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendWorks.Models
{
    public class DaskPolicy
    {
        public Policy PolicyObj { get; set; }
        public int DaskId { get; set; }
        public int PolicyId { get; set; }
        public string Adres { get; set; }
        public string Ilce { get; set; }
        public string Il { get; set; }
    }
}
