

namespace Enjoy.Core
{
    using Org.Joey.Common;
    public interface IEnjoyHost : ISingletonDependency
    {
        IWorkContextScope WorkContext { get; }
    }
}
