using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Api.Example.Model.Token
{
    public class GetTokenResponse
    {
        public string success { get; set; }
        public string desc { get; set; }
        public GetTokenModel data { get; set; }
    }

    public class GetTokenModel
    {
        public DateTime validFrom { get; set; }
        public DateTime validFromTo { get; set; }
    }
}
