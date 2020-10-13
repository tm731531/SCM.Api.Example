using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.ShipManage
{

    public class SearchRequest
    {
        public int orderID { get; set; }
        public string fugoSaleNo { get; set; }
        public string fugoProductPN { get; set; }
        public string formerSaleCode { get; set; }
        public int shipStatus { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int shipType { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
    }


}
