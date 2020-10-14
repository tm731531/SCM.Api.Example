using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.ShipManage
{


    public class ChangeShipStatusResponse
    {
        public int totalCount { get; set; }
        public int successCount { get; set; }
        public int failCount { get; set; }
        public string success { get; set; }
        public string desc { get; set; }
        public List<ChangeSaleStatusReportDataModel> data { get; set; }
    }

    public class ChangeSaleStatusReportDataModel
    {
        public int orderID { get; set; }
        public int itemID { get; set; }
        public string errorMessage { get; set; }
    }

}
