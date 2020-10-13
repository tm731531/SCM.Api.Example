using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{
    public class ProductQuery
    {
        public string formerSaleCode { get; set; }
        public string fugoSaleNo { get; set; }
        public int id_SaleStatus { get; set; }
        public int deliveryWay { get; set; }
        public string saleCode { get; set; }
        public int queryType { get; set; }
        public int eType { get; set; }
        public int productProperty { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
    }

}
