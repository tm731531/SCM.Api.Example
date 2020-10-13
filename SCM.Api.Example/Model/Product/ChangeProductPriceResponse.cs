using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{

    public class ChangeProductPriceResponse
    {
        public string success { get; set; }
        public string desc { get; set; }
        public List<ChangeProductPriceResponseModel> data { get; set; }
    }

    public class ChangeProductPriceResponseModel
    {
        public string fugoSaleNo { get; set; }
        public int type { get; set; }
        public int marketPrice { get; set; }
        public int salePrice { get; set; }
        public int costPrice { get; set; }
        public string returnCode { get; set; }
        public string returnMsg { get; set; }
    }

}
