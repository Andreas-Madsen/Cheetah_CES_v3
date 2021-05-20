using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteEngine
{
    class Driver
    {
        static void Main(string[] args)
        {
            var routeEngine = new RouteEngine();
            var res = routeEngine.ComputeRoute(null, 1, 2);
            var path = res.GetPath();
            System.Console.WriteLine(res.ToString());
            System.Console.Read();
        }
    }
}
