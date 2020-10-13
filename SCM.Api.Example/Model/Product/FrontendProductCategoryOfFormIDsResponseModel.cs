using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{
    public class RootObject
    {
        public List<FrontendProductCategoryOfFormIDsResponseModel> Property1 { get; set; }
    }

    public class FrontendProductCategoryOfFormIDsResponseModel
    {
        public string platform { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string categoryPath { get; set; }
        public bool adultFlag { get; set; }
        public bool eanCodeFlag { get; set; }
        public string declareTextType { get; set; }
        public List<FormIDsInfo> formIDsInfos { get; set; }
        public List<string> recommendCategory { get; set; }
    }

    public class FormIDsInfo
    {
        public string formID { get; set; }
        public string formName { get; set; }
    }

}
