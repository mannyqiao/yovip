using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enjoy.Core
{
    public interface IDataWritter<T> : IDisposable
        where T : IDataEntity
    {
        string GenerateExecuteNonQuery(IEnumerable<IDataEntity> entities);
    }
}
