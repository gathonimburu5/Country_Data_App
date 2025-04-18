using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneLibrary.Models
{
    public class ModifiedCountry
    {
        public string Name { get; set; }
        public string Flag { get; set; }
        public string ShortCode { get; set; }
        public string PhoneCode { get; set; }
    }

    public class ModifiedRegion
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class ModifiedCurrency
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
