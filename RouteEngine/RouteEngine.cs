using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace RouteEngine
{
    class RouteEngine
    {
        private Graph<int, string> _map;

        public RouteEngine()
        {
            var builder = new MapBuilder();
            _map = builder.GetMap();
        }
        public ShortestPathResult ComputeRoute(string packageInfo, uint from, uint to)
        {

            ShortestPathResult result = _map.Dijkstra(from, to);

            return result;
        }
    }
}
