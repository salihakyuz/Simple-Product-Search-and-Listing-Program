using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT1.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }//smallint
        public string QuantityPerUnit { get; set; }
        public Int16 UnitsOnOrder { get; set; }
        public Int16 ReorderLEvel { get; set; }
    }
}
//add other asigned attributes...