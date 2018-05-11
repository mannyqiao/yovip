using Enjoy.Core;


namespace ConsoleApp
{
    using Org.Joey.Common;
    class Program
    {
        static void Main(string[] args)
        {
            FeatureDescriptor feature = new FeatureDescriptor() { };
            string xx = feature.ToJson();
        }
    }
}
