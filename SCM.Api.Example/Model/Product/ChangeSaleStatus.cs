using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{

    public class ChangeSaleStatus
    {
        public string formerSaleCode { get; set; }
        public string fugoSaleNo { get; set; }
        public int id_SaleStatus { get; set; }
    }

}
