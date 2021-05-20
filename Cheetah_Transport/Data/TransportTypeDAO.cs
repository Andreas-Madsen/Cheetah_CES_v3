using Cheetah_Transport.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cheetah_Transport.Data
{
    public class TransportTypeDAO
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<TransportType> FetchAll()
        {
            List<TransportType> returnList = new List<TransportType>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sqlQuery = "SELECT * from ";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TransportType transportType = new TransportType();
                        transportType.Id= reader.GetInt32(0);
                        transportType.Name = reader.GetString(1);
                        transportType.PricePerHour = reader.GetDouble(2);

                        returnList.Add(transportType);
                    }
                }

            }
            return returnList;
        }

    }
}