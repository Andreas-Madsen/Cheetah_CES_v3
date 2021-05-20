using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cheetah_Transport.Models;
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
        public Tuple<List<int>, int> ComputeRoute(Package packageInfo, TransportCenter from, TransportCenter to)
        {
            var keyFrom = Dictio.centerIdToKey[from.Id];
            var keyTo = Dictio.centerIdToKey[to.Id];
            ShortestPathResult result = _map.Dijkstra(keyFrom, keyTo);

            List<int> shortestRoute = new List<int>();
            
            foreach (var node in result.GetPath())
            {

                var centerId = Dictio.keyToCenterId[node];
                shortestRoute.Add(centerId);
            }

            Tuple<List<int>, int> output = new Tuple<List<int>, int>(shortestRoute, result.Distance);
            return output;
        }
    }
}
