using Cheetah_Transport.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cheetah_Transport.Data
{
    internal class PackageDAO
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Package> FetchAll()
        {
            List<Package> returnList = new List<Package>();

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
                        Package package = new Package();
                        package.ID = reader.GetInt32(0);
                        package.Width = (double)reader.GetDecimal(1);
                        package.Height = (double)reader.GetDecimal(2);
                        package.Length = (double)reader.GetDecimal(3);
                        package.RecordedPackage = reader.GetInt32(4);
                        package.LiveAnimals = reader.GetInt32(5);
                        package.CautiousParcel = reader.GetInt32(6);
                        package.RefregiatedGoods = reader.GetInt32(7);

                        returnList.Add(package);
                    }
                }

            }
            return returnList;
        }

    }
}