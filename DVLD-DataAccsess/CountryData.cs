using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccsess
{
    public static class CountryData
    {
        public static DataTable GetAllCountries()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return table;

        }

        public static bool GetCountryInfoByID(int CountryID,ref string CountryName)
        {
            bool IsFound=false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryID=@CountryID";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue(@"CountryID", CountryID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    CountryName = (string)reader["CountryName"];
                    
                }
                else
                {
                    IsFound = false;
                }
                    reader.Close();
            }
            catch (Exception e)
            {
              // Console.WriteLine(e.ToString());
              IsFound=false;
            }
            finally
            {
                connection.Close ();
            }
            return IsFound;
        }

        public static bool GetCountryInfoByName(string CountryName, ref int CountryID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT CountryID FROM Countries WHERE CountryName = @CountryName";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CountryName", CountryName.Trim());

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    CountryID = (int)reader["CountryID"]; // 🔥 السطر الناقص
                }
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

    }
}
