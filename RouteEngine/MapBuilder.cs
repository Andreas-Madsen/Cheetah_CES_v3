using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cheetah_Transport.Data;
using Cheetah_Transport.Models;
using Dijkstra.NET.Graph;

namespace RouteEngine
{
    class MapBuilder
    {
        public Graph<int, string> GetMap()
        {
            

            var graph = new Graph<int, string>();

            TransportCenterDAO transportCenterDao = new TransportCenterDAO();
            List<TransportCenter> centers = transportCenterDao.FetchAll();
            foreach (var center in centers)
            {
                int centerId = center.Id;
                uint key = graph.AddNode(centerId);
                Dictio.centerIdToKey.Add(centerId, key);
                Dictio.keyToCenterId.Add(key, centerId);
            }

            RoutesDAO routesDAO = new RoutesDAO();
            List<Routes> routes = routesDAO.FetchAll();
            foreach (var route in routes)
            {
                var x = route.CenterA;
                var y = route.CenterB;
                var cost = route.TravelTime;
                
                var centerA = route.CenterA;
                var keyA = Dictio.centerIdToKey[centerA.Id];

                var centerB = route.CenterB;
                var keyB = Dictio.centerIdToKey[centerB.Id];

                var transportType = route.Type.Name;

                graph.Connect(keyA, keyB, cost, transportType);
                graph.Connect(keyB, keyA, cost, transportType);
            }

            
            return graph;
        }
    }
}
