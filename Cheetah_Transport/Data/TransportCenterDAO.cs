using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Cheetah_Transport.Models;

namespace Cheetah_Transport.Data
{
    public class TransportCenterDAO
    {
        private string connectionString =
            "Data Source=tcp:dbs-tl-dk2.database.windows.net,1433;Initial Catalog=db-tl-dk2;User ID=admin-tl-dk2;Password=telStarRox16";


        public List<TransportCenter> FetchAll()
        {
            List<TransportCenter> returnList = new List<TransportCenter>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Centers";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TransportCenter center = new TransportCenter();
                        center.Id = reader.GetInt32(0);
                        center.Name = reader.GetString(1);

                        returnList.Add(center);
                    }
                }
            }
            return returnList;
        }

        public TransportCenter FetchOne(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Centers WHERE Id = @id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                TransportCenter transportCenter = new TransportCenter();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        transportCenter.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        transportCenter.Name = reader.GetString(reader.GetOrdinal("Name"));
                    }
                }
                return transportCenter;
            }
        }
    }
}