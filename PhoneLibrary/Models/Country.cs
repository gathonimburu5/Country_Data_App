using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneLibrary.Models
{
    public class Country
    {
        public string Name { get; set; }
        public string Flag { get; set; }
        public string ShortCode { get; set; }
    }

    public class Region
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class Currency
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
