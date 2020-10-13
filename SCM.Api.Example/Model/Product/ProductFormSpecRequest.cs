using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{
    
        public class ProductFormSpecRequest
        {
            public List<ProductFormSpecRequestSpec> specs { get; set; }
            public int productSpecFormID { get; set; }
            public string formerSaleCode { get; set; }
            public int specType { get; set; }
        }


    public class ProductFormSpecRequestSpec
    {
        public string specID { get; set; }
        public string specValue { get; set; }
    }
}
