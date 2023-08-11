using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendWorks.Models
{
    public class TrafficPolicy
    {
        public Policy PolicyObj { get; set; }
        public int TrafficId { get; set; }
        public int PolicyId { get; set; }
        public string PlakaIlKodu { get; set; }
        public string PlakaKodu { get; set; }
    }
}
