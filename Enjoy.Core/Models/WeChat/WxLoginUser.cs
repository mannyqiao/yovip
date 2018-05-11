using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enjoy.Core.Models
{
    public class WeChatLoginUser : IWxLoginUser
    {
        public WeChatLoginUser(string code, string iv, string data, string signature)
        {
            this.Code = code;
            this.IV = iv;
            this.Data = data;
            this.Signature = signature;
        }
        public string Code { get; private set; }

        public string IV { get; private set; }

        public string Data { get; private set; }
        public string Signature { get; private set; }
    }
}
