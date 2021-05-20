using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra.NET.Graph;

namespace RouteEngine
{
    class MapBuilder
    {
        public Graph<int, string> GetMap()
        {
            var graph = new Graph<int, string>();

            var s = graph.AddNode(1);
            var a = graph.AddNode(2);
            //graph.AddNode("B");
            var c = graph.AddNode(3);
            //graph.AddNode("D");
            //graph.AddNode("E");
            //graph.AddNode("F");

            //graph.Connect(1, 2, 5, "some custom information in edge"); //First node has key equal 1
            graph.Connect(a, s, 3, "Car");
            graph.Connect(s, a, 3, "Car");

            graph.Connect(c, s, 1, "Car");
            graph.Connect(s, c, 1, "Car");

            graph.Connect(c, a, 1, "Car");
            graph.Connect(a, c, 1, "Car");
            return graph;
        }
    }
}
