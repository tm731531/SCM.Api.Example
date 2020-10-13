using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{
    public class ProductSpecResponse
    {
        public int totalCount { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public string success { get; set; }
        public string desc { get; set; }
        public List<ProducSpecResultModel> data { get; set; }
    }

    public class ProducSpecResultModel
    {
        public string formerSaleCode { get; set; }
        public string saleName { get; set; }
        public int productSpecFormID { get; set; }
        public string productSpecFormName { get; set; }
        public List<Spec> specs { get; set; }
    }

    public class Spec
    {
        public int specID { get; set; }
        public string name { get; set; }
        public string maxChoices { get; set; }
        public bool isRequired { get; set; }
        public string choiceType { get; set; }
        public List<Specoption> specOptions { get; set; }
    }

    public class Specoption
    {
        public string name { get; set; }
        public int id { get; set; }
    }

}
