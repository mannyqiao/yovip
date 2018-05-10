using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enjoy.Core.Models
{
    public class WxSession
    {
        public IMiniprogram Miniprogram { get; set; }
        public IWxAuthorization Authorization { get; set; }
        public IWxLoginUser LoginUser { get; set; }

        public WxUser WeCharUser { get; set; }
    }
}
