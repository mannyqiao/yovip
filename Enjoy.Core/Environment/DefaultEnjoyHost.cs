


namespace Enjoy.Core
{
  
    using System.Linq;
    public class DefaultEnjoyHost : IEnjoyHost
    {

        public DefaultEnjoyHost(IExtensionLoader loader)
        {
            var xxx = loader.Probe().ToList();
        }
        public void BeginRequest()
        {

        }

        public IWorkContextScope CreateStandaloneEnvironment()
        {
            throw new System.NotImplementedException();
        }

        public void EndRequest()
        {

        }

        public void Initialize()
        {

        }

        public void ReloadExtensions()
        {

        }
    }
}
