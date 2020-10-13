using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{

    public class ProductSpecQuyery
    {
        public int specType { get; set; }
        public List<string> formerSaleCode { get; set; }
        public List<int> productSpecFormID { get; set; }
    }

}
