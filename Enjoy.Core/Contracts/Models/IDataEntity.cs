using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enjoy.Core
{
    public interface IDataEntity
    {
        DateTime ModifyTime { get; }
        string GenernateInsertValueString();
    }
}
