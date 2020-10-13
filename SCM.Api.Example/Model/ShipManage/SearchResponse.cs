using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.ShipManage
{

    public class SearchResponse
    {
        public int totalCount { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public string success { get; set; }
        public string desc { get; set; }
        public List<SimpleQueryResult> data { get; set; }
    }

    public class SimpleQueryResult
    {
        public int saleNo { get; set; }
        public string productPN { get; set; }
        public string productName { get; set; }
        public string colorName { get; set; }
        public string styleName { get; set; }
        public int qty { get; set; }
        public string gift { get; set; }
        public int price { get; set; }
        public int orderID { get; set; }
        public int itemID { get; set; }
        public string status { get; set; }
        public string orderTypeName { get; set; }
        public string returnStatusNM { get; set; }
        public string readyShipDate { get; set; }
        public string expectShipDate { get; set; }
        public string receivedDate { get; set; }
        public string terminatedDate { get; set; }
        public string consignee { get; set; }
        public string contactNumber { get; set; }
        public string deliveryAddressNM { get; set; }
        public string remark { get; set; }
        public string freightCompanyNM { get; set; }
        public string deliveryOrderID { get; set; }
        public string shippingInfo { get; set; }
    }

}
