using Cheetah_Transport.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Cheetah_Transport.Data
{
    public class TransportTypeDAO
    {
        private string ConnectionString = "Data Source=tcp:dbs-tl-dk2.database.windows.net,1433;Initial Catalog=db-tl-dk2;User ID=admin-tl-dk2;Password=telStarRox16";

        public List<TransportType> FetchAll()
        {
            List<TransportType> returnList = new List<TransportType>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sqlQuery = "SELECT * from dbo.Transport_types";

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
                        transportType.PricePerHour = (double) reader.GetFloat(2);

                        returnList.Add(transportType);
                    }
                }

            }
            return returnList;
        }

        public TransportType FetchOne(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sqlQuery = "SELECT * from dbo.Transport_Types WHERE Id = @id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                TransportType transportType= new TransportType();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        transportType.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        transportType.Name = reader.GetString(reader.GetOrdinal("Name"));
                        transportType.PricePerHour = reader.GetDouble(reader.GetOrdinal("Hour_Rate_USD"));
                    }
                }
                return transportType;
            }
        }

    }
}