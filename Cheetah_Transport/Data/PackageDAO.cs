using Cheetah_Transport.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cheetah_Transport.Data
{
    public class PackageDAO
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
                        package.Weight = (double)reader.GetDecimal(4);
                        package.RecordedPackage = reader.GetInt32(5);
                        package.LiveAnimals = reader.GetInt32(6);
                        package.CautiousParcel = reader.GetInt32(7);
                        package.RefregiatedGoods = reader.GetInt32(8);

                        returnList.Add(package);
                    }
                }

            }
            return returnList;
        }
        public int CreateOne(Package package)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                string sqlQuery = "INSERT INTO dbo.Gadgets Values(@ID, @Width_cm, @Height_cm, @Length_cm, @Weight_KG, @RECOMMENDED, @ANIMALS, @CAUTIOUS, @REFRIGIATED)";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = package.ID;
                command.Parameters.Add("@Width_cm", System.Data.SqlDbType.VarChar, 1000).Value = package.Weight;
                command.Parameters.Add("@Height_cm", System.Data.SqlDbType.VarChar, 1000).Value = package.Height;
                command.Parameters.Add("@Length_cm", System.Data.SqlDbType.VarChar, 1000).Value = package.Length;
                command.Parameters.Add("@Weight_KG", System.Data.SqlDbType.VarChar, 1000).Value = package.Weight;
                command.Parameters.Add("@RECOMMENDED", System.Data.SqlDbType.VarChar, 1000).Value = package.RecordedPackage;
                command.Parameters.Add("@ANIMALS", System.Data.SqlDbType.VarChar, 1000).Value = package.LiveAnimals;
                command.Parameters.Add("@CAUTIOUS", System.Data.SqlDbType.VarChar, 1000).Value = package.CautiousParcel;
                command.Parameters.Add("@REFRIGIATED", System.Data.SqlDbType.VarChar, 1000).Value = package.RefregiatedGoods;

                connection.Open();
                int newID = command.ExecuteNonQuery();

                return newID;
            }
        }

    }
}