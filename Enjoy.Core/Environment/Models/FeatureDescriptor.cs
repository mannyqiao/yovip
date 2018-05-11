


namespace Enjoy.Core
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public class FeatureDescriptor
    {
        public string Name { get; set; }

        public bool StartFromThisFeature { get; set; }

        public bool Enabled { get; set; }

        [JsonIgnore]
        public string VirtualPath { get; set; }

        public string Description { get; set; }

        public IEnumerable<FeatureDescriptor> Dependences { get; set; }
    }
}
