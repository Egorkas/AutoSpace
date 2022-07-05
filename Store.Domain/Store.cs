using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class Store
    {
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public IList<Product> Products { get; set; }
    }
}
