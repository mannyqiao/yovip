
namespace Enjoy.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Org.Joey.Common;
    public class DefaultExtensionLoader : IExtensionLoader
    {
        private readonly string BaseVirtualPath = "~/Modules";
        private readonly IHostEnvironment _environment;


        public DefaultExtensionLoader(IHostEnvironment environment)
        {
            this._environment = environment;
        }

        public FeatureDescriptor GetDefault()
        {
            throw new NotImplementedException();
        }

        public void Load(FeatureDescriptor feature)
        {

        }

        public IEnumerable<FeatureDescriptor> Probe()
        {
            return new DirectoryInfo(this._environment.MapPath(BaseVirtualPath))
                .GetDirectories()
                .Select((moduleFolder) =>
                {
                    var settings = File.ReadAllText(Path.Combine(moduleFolder.FullName, "module.json"));
                    var feature = settings.DeserializeToObject<FeatureDescriptor>();
                    feature.VirtualPath = string.Concat(BaseVirtualPath, "/", moduleFolder.Name);
                    return feature;
                });
        }
    }
}
