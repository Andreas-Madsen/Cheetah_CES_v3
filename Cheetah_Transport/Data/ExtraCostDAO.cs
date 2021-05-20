using Cheetah_Transport.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cheetah_Transport.Data
{
    public class ExtraCostDAO
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<ExtraCost> FecthAll()
        {
            List<ExtraCost> returnList = new List<ExtraCost>();

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
                        ExtraCost extracost = new ExtraCost();
                        extracost.ID = reader.GetInt32(0);
                        extracost.Type = reader.GetString(1);
                        extracost.Fee = reader.GetDouble(2);
                        extracost.PackageID = reader.GetInt32(3);
                       
                        returnList.Add(extracost);
                    }
                }

            }
            return returnList;
        }

    }
}