using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.ShipManage
{

    public class ChangeShipStatusRequest
    {
        public List<SimpleShipOrder> orderList { get; set; }
    }

    public class SimpleShipOrder
    {
        public int orderID { get; set; }
        public int itemID { get; set; }
        public int shipStatus { get; set; }
        public string shipCompanyName { get; set; }
        public string deliveryOrderID { get; set; }
        public string shipInfo { get; set; }
        public string rejectReason { get; set; }
    }


}
