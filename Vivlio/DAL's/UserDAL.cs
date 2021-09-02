using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivlio.Tools;
using Vivlio.Interfaces;
using System.Data.SqlClient;
using System.Data;
using Vivlio.Models;
using Vivlio.Enum_s;

namespace Vivlio.DAL_s
{
    public class UserDAL : Databasehandler, IUserDAL
    {
        PasswordHandler WWHandler = new PasswordHandler();

        //Get User
        public User GetUserByUsername(string username)
        {
            SqlCommand cmd = new SqlCommand("SELECT ID, Name, Username, Email, Phonenumber,Birthdate,FuntionUser FROM [User] WHERE Username = @Username", GetCon());
            cmd.Parameters.AddWithValue("@Username", username);

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable Table = new DataTable();

            OpenCon();
                adapt.Fill(Table);
            CloseCon();

            User user = new User( (int)Table.Rows[0][0], Table.Rows[0][1].ToString(), Table.Rows[0][2].ToString(), Table.Rows[0][3].ToString(), Table.Rows[0][4].ToString(), Convert.ToDateTime(Table.Rows[0][5]), (UserFunction)Enum.Parse(typeof(UserFunction), Table.Rows[0][6].ToString()));

            return user;
        }
        


        // Get DataTables
        public DataTable GetUsers()
        {
            SqlCommand cmd = new SqlCommand("SELECT ID, Name as Roepnaam, Username as Gebruikersnaam, Email,FuntionUser,Phonenumber FROM [User]", GetCon());
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable Table = new DataTable();
              
            OpenCon();
                adapt.Fill(Table);
            CloseCon();
            
            return Table;
        }

        public DataTable GetUserBooks(string username)
        {
            SqlCommand cmd = new SqlCommand("SELECT [Book].[ID],[Book].[Title] as Titel, [Author].[Name] as Auteur , [RetourDate] as Inleverdatum  FROM[UserBook] INNER JOIN[Book] ON[Book].[ID] = [UserBook].[Book_ID] INNER JOIN[Author] ON[Book].[Author_ID] = [Author].[ID] INNER JOIN[User] ON[User].[ID] = [UserBook].[User_ID] WHERE[Username] = @Username AND[UserBook].ReturnDate IS NULL", GetCon());
            cmd.Parameters.AddWithValue("@Username", username);

            OpenCon();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable Table = new DataTable();
            adapt.Fill(Table);

            CloseCon();

            return Table;
        }



        // Login
        private string GetUserHash(string username)
        {
            SqlCommand cmd = new SqlCommand("SELECT [User].[PasswordHash] FROM [User] WHERE [Username] = @Username", GetCon());
            cmd.Parameters.AddWithValue("@Username", username);

            OpenCon();
                string Hash = (string)cmd.ExecuteScalar();
            CloseCon();

            return Hash;
        }

        private string GetUserSalt(string username)
        {
            SqlCommand cmd = new SqlCommand("SELECT [User].[PasswordSalt] FROM [User] WHERE [Username] = @Username", GetCon());
            cmd.Parameters.AddWithValue("@Username", username);

            OpenCon();
                string Salt = (string)cmd.ExecuteScalar();
            CloseCon();

            return Salt;
        }

        public bool ValidatePassword(string username, string password)
        {
            return WWHandler.VerifyPassword(GetUserHash(username), GetUserSalt(username), password);
        }



        //check if exists
        public bool UserIDExists(int userID)
        {
            SqlCommand cmd = new SqlCommand("SELECT CASE WHEN EXISTS (SELECT * FROM[User] WHERE ID = @UserID) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END", GetCon());
            cmd.Parameters.AddWithValue("@UserID", userID);

            OpenCon();
                bool exist = (bool)cmd.ExecuteScalar();
            CloseCon();

            return exist;
        }

        public bool UsernameExists(string username)
        {
            SqlCommand cmd = new SqlCommand("SELECT CASE WHEN EXISTS (SELECT * FROM[User] WHERE Username = @Username) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END", GetCon());
            cmd.Parameters.AddWithValue("@Username", username);

            OpenCon();
                bool exist = (bool)cmd.ExecuteScalar();
            CloseCon();

            return exist;
        }



        // Create User
        public bool CreateUser(string name, string username, DateTime birthdate, string userFunction, string email, string phonenumber, string password)
        {
            bool Finished = false;

            OpenCon();

            transaction = GetCon().BeginTransaction();

            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[User] ([Name], [Username], [Email], [Phonenumber], [FuntionUser], [Birthdate], [PasswordHash], [PasswordSalt])  VALUES(@name, @username, @email, @phonenumber, @functionUser, @birthdate, @hash, @salt)", GetCon(), transaction);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@email", email);
            if (phonenumber == null)
            {
                cmd.Parameters.AddWithValue("@phonenumber", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@phonenumber", phonenumber);
            }
            
            cmd.Parameters.AddWithValue("@functionUser", userFunction);
            cmd.Parameters.AddWithValue("@birthdate", birthdate);
            string[] HashSalt = WWHandler.GenerateSaltAndHash(password);

            cmd.Parameters.AddWithValue("@hash", HashSalt[0]);
            cmd.Parameters.AddWithValue("@salt", HashSalt[1]);

            try
            {
                cmd.ExecuteNonQuery();
                transaction.Commit();
                Finished = true;
            }
            catch (SqlException)
            {
                transaction.Rollback();
            }

            CloseCon();

            return Finished;
        }



        // Update User
        public bool UpdateUser(int userID,string name, string username, string email, string phonenumber)
        {
            bool Finished = false;

            OpenCon();

            transaction = GetCon().BeginTransaction();

            SqlCommand cmd = new SqlCommand("UPDATE [dbo].[User] SET[Name] = @name ,[Username] = @username ,[Email] = @email ,[Phonenumber] = @phonenumber WHERE[User].[ID] = @userID", GetCon(), transaction);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@email", email);
            
            if (phonenumber == null)
            {
                cmd.Parameters.AddWithValue("@phonenumber", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@phonenumber", Convert.ToInt32(phonenumber));
            }

            try
            {
                cmd.ExecuteNonQuery();
                transaction.Commit();
                Finished = true;
            }
            catch (SqlException)
            {
                transaction.Rollback();
            }

            CloseCon();

            return Finished;
        }

        public bool UpdatePassword(int userID, string password)
        {
            bool Finished = false;

            OpenCon();

            transaction = GetCon().BeginTransaction();

            SqlCommand cmd = new SqlCommand("UPDATE [dbo].[User] SET[PasswordHash] = @hash ,[PasswordSalt] = @salt WHERE[User].[ID] = @userID", GetCon(), transaction);
            cmd.Parameters.AddWithValue("@userID", userID);

            string[] HashSalt = WWHandler.GenerateSaltAndHash(password);
            cmd.Parameters.AddWithValue("@hash", HashSalt[0]);
            cmd.Parameters.AddWithValue("@salt", HashSalt[1]);

            try
            {
                cmd.ExecuteNonQuery();
                transaction.Commit();
                Finished = true;
            }
            catch (SqlException)
            {
                transaction.Rollback();
            }

            CloseCon();

            return Finished;
        }

        public bool UpdateUserFunction(int userID, UserFunction function)
        {
            bool Finished = false;

            OpenCon();

            transaction = GetCon().BeginTransaction();

            SqlCommand cmd = new SqlCommand("UPDATE [dbo].[User] SET[FuntionUser] = @userfunction WHERE [User].[ID] = @userID", GetCon(), transaction);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@userFunction", function.ToString());


            try
            {
                cmd.ExecuteNonQuery();
                transaction.Commit();
                Finished = true;
            }
            catch (SqlException)
            {
                transaction.Rollback();
            }

            CloseCon();

            return Finished;
        }
    }
}
