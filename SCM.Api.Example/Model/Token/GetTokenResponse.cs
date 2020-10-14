using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Token
{

    public class GetTokenResponse
    {
        public bool success { get; set; }
        public string desc { get; set; }
        public GetTokenModel data { get; set; }
    }

    public class GetTokenModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string account { get; set; }
        public object userName { get; set; }
        public string userFullName { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime validFromTo { get; set; }
    }

}
