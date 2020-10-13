using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Product
{
    public class AccessNum
    {
        public string fugoSaleNo { get; set; }
        public List<AccessNumAccessednum> accessedNum { get; set; }
    }

    public class AccessNumAccessednum
    {
        public int panID { get; set; }
        public int num_e { get; set; }
        public DateTime stockDate { get; set; }
    }

}
