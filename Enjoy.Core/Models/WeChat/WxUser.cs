﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enjoy.Core.Models
{
    public class WxUser
    {
        [Newtonsoft.Json.JsonProperty("openid")]
        public string OpenId { get; set; }
        [Newtonsoft.Json.JsonProperty("nickName")]
        public string NickName { get; set; }
        [Newtonsoft.Json.JsonProperty("gender")]
        public string Gender { get; set; }
        [Newtonsoft.Json.JsonProperty("city")]
        public string city { get; set; }
        [Newtonsoft.Json.JsonProperty("province")]
        public string province { get; set; }
        [Newtonsoft.Json.JsonProperty("country")]
        public string Country { get; set; }
        [Newtonsoft.Json.JsonProperty("avatarUrl")]
        public string avatarUrl { get; set; }
        [Newtonsoft.Json.JsonProperty("unionId")]
        public string UnionId { get; set; }

        [Newtonsoft.Json.JsonProperty("watermark")]
        public Watermark watermark { get; set; }

        public class Watermark
        {
            [Newtonsoft.Json.JsonProperty("appid")]
            public string appid { get; set; }

            [Newtonsoft.Json.JsonProperty("timestamp")]            
            public string timestamp { get; set; }
        }
    }
}
