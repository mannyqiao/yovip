﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enjoy.Core
{
    public interface IWxAccessToken
    {
        string Token { get; }
        int Expiresin { get; }
    }
}
