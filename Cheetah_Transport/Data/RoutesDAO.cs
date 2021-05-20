using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Cheetah_Transport.Models;

namespace Cheetah_Transport.Data
{
    public class RoutesDAO
    {
        private string connectionString =
            "Data Source=tcp:dbs-tl-dk2.database.windows.net,1433;Initial Catalog=db-tl-dk2;User ID=admin-tl-dk2;Password=telStarRox16";


        public List<Routes> FetchAll()
        {
            List<Routes> returnList = new List<Routes>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Routes";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Routes route = new Routes();

                        TransportCenterDAO tcDAO = new TransportCenterDAO();
                        
                        int centerAId = reader.GetInt32(reader.GetOrdinal("Center_A_Id"));
                        TransportCenter centerA = tcDAO.FetchOne(centerAId);

                        int centerBId = reader.GetInt32(reader.GetOrdinal("Center_B_Id"));
                        TransportCenter centerB = tcDAO.FetchOne(centerBId);

                        TransportTypeDAO ttDAO = new TransportTypeDAO();
                        int typeId = reader.GetOrdinal("Transport_Id");
                        TransportType transportType = ttDAO.FetchOne(typeId);

                        route.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        route.CenterA = centerA;
                        route.CenterB = centerB;
                        route.Type = transportType;
                        if (reader.IsDBNull(reader.GetOrdinal("Travel_Time_Hours")))
                        {
                            route.TravelTime = 1000;
                        }
                        else
                        {
                            route.TravelTime = reader.GetInt32(reader.GetOrdinal("Travel_Time_Hours"));
                        }
                        

                        returnList.Add(route);
                    }
                }
            }
            return returnList;
        }
    }
}