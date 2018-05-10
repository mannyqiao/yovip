using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enjoy.Core
{
    public class DefaultEnjoyHost : IEnjoyHost
    {
        public IWorkContextScope WorkContext { get; private set; }
    }
}
