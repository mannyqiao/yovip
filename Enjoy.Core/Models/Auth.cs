﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enjoy.Core
{
    public class Auth : IAuth
    {
        public string Token { get; private set; }
        public long Id { get; private set; }
    }
}
