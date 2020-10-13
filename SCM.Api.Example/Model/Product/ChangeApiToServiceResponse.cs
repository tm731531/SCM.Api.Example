using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{
    public class ChangeApiToServiceResponse
    {
        public string success { get; set; }
        public string desc { get; set; }
        public  List<ChangeApiToServiceModel> data { get; set; }
    }

    public class ChangeApiToServiceModel
    {
        public string fugoSaleNo { get; set; }
        public List<ChangeApiToServiceAccessedNumModel> accessedNum { get; set; }
    }

    public class ChangeApiToServiceAccessedNumModel
    {
        public int panID { get; set; }
        public int num_e { get; set; }
        public DateTime stockDate { get; set; }
        public string returnCode { get; set; }
        public string returnMsg { get; set; }
    }

}
