﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enjoy.Core
{
    public interface IAuth
    {
        string Token { get; }
        long Id { get; }
    }
}
