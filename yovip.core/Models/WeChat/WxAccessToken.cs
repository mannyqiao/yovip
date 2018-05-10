using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enjoy.Core
{
    public class WxAccessToken : IWxAccessToken
    {
        public WxAccessToken() { }
        public WxAccessToken(string token, int expriesin)
        {
            this.Token = token;
            this.Expiresin = expriesin;
        }
        [Newtonsoft.Json.JsonProperty("access_token")]
        public string Token { get; set; }
        [Newtonsoft.Json.JsonProperty("expires_in")]
        public int Expiresin { get; set; }
    }
}
