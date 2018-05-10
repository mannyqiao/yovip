using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Enjoy.Core
{
    public interface IWorkContextScope
    {
        IAuth GetAuth();
        HttpContext Context { get;  }

    }
}
