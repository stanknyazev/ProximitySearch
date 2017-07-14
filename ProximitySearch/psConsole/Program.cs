using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

using psLib;

namespace psConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer unity = new UnityContainer().LoadConfiguration();
            var program = unity.Resolve<UnityEnabledProgram>();
            program.Run(args);
        }
    }
    public class UnityEnabledProgram
    {
        readonly IProximitySearch _proximitySearch;

        public UnityEnabledProgram(IProximitySearch proximitySearch)
        {
            _proximitySearch = proximitySearch;
        }

        public void Run(string[] args)
        {
            // here we might need to create and use argument provider with argument validations and name mapping instead of direct array references
            // here is also 3rd party providers for argument line parcing, that could be used
            _proximitySearch.SetSearcheableText(File.ReadAllText(args[0]));
            Console.WriteLine(_proximitySearch.CountInstances(args[1], args[2], Convert.ToInt32(args[3])));
           
        }
    }
}
