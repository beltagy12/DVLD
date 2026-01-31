using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccsess
{
    public static class UsersData
    {
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Users;";
            SqlCommand cmd =new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool FindUserByID(int UserID ,ref int PersonID,ref string UserName,ref string Password ,ref int IsActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Users Where UserID=@UserID";
            
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password=(string)reader["Password"];
                    IsActive = (int)reader["IsActive"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound=false;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool FindUserByUserName(string UserName , ref int UserID, ref int PersonID, ref string Password, ref int IsActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Users Where UserName=@UserName";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@ID", UserID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserID = (int)reader["UserID"];
                    Password = (string)reader["Password"];
                    IsActive = (int)reader["IsActive"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool UpdateUser(int UserID,int PersonID,string UserName,string Password, int IsActive)
        {
            int RowsAfficted = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Users
            set PersonID=@PersonID ,
            UserName=@UserName,
            Password=@Password
            IsActive=@IsActive
            where UserID=@UserID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();
               RowsAfficted=cmd.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (RowsAfficted > 0);
        }

         public static int AddNewUser(int PersonID, string UserName, string Password, int IsActive)
        {
            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"insert into Users (PersonID,UserName ,Password, IsActive)
            value(@PersonID,@UserName ,@Password, @IsActive))
            SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null&&int.TryParse(result.ToString(), out int UserId))
                {
                    UserID = UserId;
                }
                
               
            }   
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }
        public static bool DeleteUser(int UserID)
        {
            int RowAfficted = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Delete * from Users Where UserID=@UserID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", UserID);


            try
            {
                connection.Open();
                RowAfficted = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return RowAfficted > 0;
        }

        public static bool IsUserExist(int UserID)
        {
            bool IsUserExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Users Where UserID=@UserID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", UserID);


            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                IsUserExist = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                IsUserExist = false;
            }
            finally
            { connection.Close(); }

            return IsUserExist;
        }

        public static bool IsUserExist(string UserName)
        {
            bool IsUserExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Users Where UserName=@UserName;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", UserName);

 
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                IsUserExist = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                IsUserExist = false;
            }
            finally
            { connection.Close(); }

            return IsUserExist;
        }

        public static bool IsUserActive(string UserName)
        {
            bool IsUserActive = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Users Where UserName=@UserName and IsActive=1";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                IsUserActive = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                IsUserActive = false;
            }
            finally
            { connection.Close(); }

            return IsUserActive;
        }

        public static bool IsUserActive(int UserID)
        {
            bool IsUserActive = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Users Where UserID=@UserID and IsActive=1";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                IsUserActive = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                IsUserActive = false;
            }
            finally
            { connection.Close(); }

            return IsUserActive;
        }

    }
}
