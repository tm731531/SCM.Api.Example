using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.ShipManage
{

    public class ChangeSaleStatusResponse
    {
        public string success { get; set; }
        public string desc { get; set; }
        public List<ChangeSaleStatusReportDataModel> data { get; set; }
    }

    public class ChangeSaleStatusReportDataModel
    {
        public string formerSaleCode { get; set; }
        public string fugoSaleNo { get; set; }
        public string changeResult { get; set; }
        public string originalSaleStatus { get; set; }
        public string changeSaleStatus { get; set; }
    }


}
