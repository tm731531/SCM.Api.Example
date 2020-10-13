using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{
    public class ChangeProductPrice
    {
        public string fugoSaleNo { get; set; }
        public int type { get; set; }
        public int marketPrice { get; set; }
        public int salePrice { get; set; }
        public int costPrice { get; set; }
    }

}
