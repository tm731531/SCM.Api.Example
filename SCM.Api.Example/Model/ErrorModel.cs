using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model
{
    public class ErrorModel
    {
        public class ProductSKUV2
        {
            public string vendorCode { get; set; }
            public string formerSaleCode { get; set; }
            public string fugoSaleNo { get; set; }
            public string returnCode { get; set; }
            public string returnMsg { get; set; }
        }
    }

}
