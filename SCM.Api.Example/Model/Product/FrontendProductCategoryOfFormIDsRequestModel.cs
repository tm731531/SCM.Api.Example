using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{
    public class FrontendProductCategoryOfFormIDsRequestModel
    {
        public int platform { get; set; }
        public string categoryRootName { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string status { get; set; }
    }
}
