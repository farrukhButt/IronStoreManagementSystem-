using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronStore
{
   public class InvoiceOrderList
    {
        public string Item { get; set; }

        public string Kilo { get; set; }

        public string Gram { get; set; }

        public string PricePerUnit {get; set;}
        public string TotalPrice { get; set; }
        public string  Bundle { get; set; }
        public string Length { get; set; }
        public string PieceCut { get; set; }
    }
}
