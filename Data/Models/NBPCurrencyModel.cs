using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppie.DataAccess.Models
{
    public class NBPCurrencyModel
    {
        public string table { get; set; }
        public string no { get; set; }
        public DateOnly effectiveDate { get; set; }
        public List<Rate> rates { get; set; }
    }

    public class Rate
    {
        public string currency { get; set; }
        public string code { get; set; }
        public double mid { get; set; }
    }
}
