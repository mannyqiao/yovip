﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enjoy.Core.Models
{
    public class WeChatAuthorization : IWxAuthorization
    {
        [Newtonsoft.Json.JsonProperty("session_key")]
        public string SessionKey { get; set; }
        [Newtonsoft.Json.JsonProperty("openid")]
        public string OpenId { get; set; }
        [Newtonsoft.Json.JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
