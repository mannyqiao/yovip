using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enjoy.Core
{
    public interface IDataWriteStreamService<T>
        where T : IDataEntity
    {
        void Write(T entity);
        //void Run(CancellationToken token);
        void Stop();
    }
}
