using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccsess
{
    public class clsPersonDataAccsess
    {

        public static DataTable GetAllPersons()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People;";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch
            (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();

            }


            return dt;
        }

        public static DataTable Filter(string column, string value)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = $"SELECT * FROM People WHERE CAST({column} AS NVARCHAR) LIKE @value";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@value", "%" + value + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch
            (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            { connection.Close(); }

            return dt;
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName,
      string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email,
      int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO People ( NationalNo,   FirstName,  SecondName ,  ThirdName, LastName, DateOfBirth, Gendor, Address ,  Phone,  Email, NationalityCountryID, ImagePath)
                          Values ( @NationalNo,   @FirstName,  @SecondName ,  @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address ,  @Phone,  @Email, @NationalityCountryID, @ImagePath)
                           SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@SecondName", SecondName);
            cmd.Parameters.AddWithValue("@ThirdName", ThirdName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != "")
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                cmd.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int PerID))
                {
                    PersonID = PerID;

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return PersonID;
        }


        public static bool UpdataPerson(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName,
          string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email,
          int NationalityCountryID, string ImagePath)
        {
            int RowsEffected = 0;
            SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" UPDATE People 
            SET 
         NationalNo = @NationalNo,
          FirstName = @FirstName,
    SecondName = @SecondName,
    ThirdName = @ThirdName,
    LastName = @LastName,
    DateOfBirth = @DateOfBirth,
    Gendor = @Gendor,
    Address = @Address,
    Phone = @Phone,
    Email = @Email,
    NationalityCountryID = @NationalityCountryID,
    ImagePath = @ImagePath
WHERE 
    PersonID = @PersonID; ";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", ID);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@SecondName", SecondName);
            cmd.Parameters.AddWithValue("@ThirdName", ThirdName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != "")
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                cmd.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            Console.WriteLine(ImagePath);

            try
            {
                connection.Open();
                RowsEffected=cmd.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
           
            }
            finally
            {
                connection.Close();
            }
            return (RowsEffected > 0);
        }

        public static bool GetPersonInfoByID(int ID,ref string NationalNo,ref string FirstName, ref string SecondName, ref string ThirdName,
          ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address,  ref string Phone, ref string Email,
          ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE PersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue(@"PersonID", ID);

            try
            {
                connection.Open ();
              SqlDataReader reader=cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (int)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];


                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];

                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                    { isFound = false; }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                connection.Close();
            }


            return isFound;
        }


        public static bool DeletePerson(int ID)
        {
            int RowsEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE from People where PersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("PersonID", ID);

            try
            {
                connection.Open();
               RowsEffected = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return (RowsEffected > 0);
        } 

        public static  bool IsPersonExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Ahmed=1 FROM People WHERE PersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("PersonID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

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

    }
}

