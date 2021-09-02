using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Vivlio.Interfaces;
using Vivlio.Tools;

namespace Vivlio.DAL_s
{
    public class BookDAL : Databasehandler , IBookDAL
    {
        // Return Bool
        private bool IsBorrowed(int BookID)
        {
            SqlCommand cmd = new SqlCommand("SELECT [Book].[IsBorrowed]  FROM[Book]  WHERE[ID] = @BookID", GetCon());
            cmd.Parameters.AddWithValue("BookID", BookID);

            OpenCon();
                bool uitgeleend = (bool)cmd.ExecuteScalar();
            CloseCon();

            return uitgeleend;
        }

        public bool BookIDExists(int BookID)
        {
            SqlCommand cmd = new SqlCommand("SELECT CASE WHEN EXISTS (SELECT * FROM[Book] WHERE ID = @BookID) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END", GetCon());
            cmd.Parameters.AddWithValue("BookID", BookID);

            OpenCon();
            bool exist = (bool)cmd.ExecuteScalar();
            CloseCon();

            return exist;
        }

        private bool CheckTimesProlonged(int userID, int bookID)
        {
            SqlCommand cmd = new SqlCommand("SELECT CASE WHEN EXISTS (SELECT * FROM[UserBook] WHERE[Book_ID] = @BookID AND[User_ID] = @UserID AND[ReturnDate] IS NULL AND[TimesProlonged] = 3) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END", GetCon());
            cmd.Parameters.AddWithValue("BookID", bookID);
            cmd.Parameters.AddWithValue("UserID", userID);

            OpenCon();
            bool TooManyTimes = (bool)cmd.ExecuteScalar();
            CloseCon();

            return TooManyTimes;
        }

        public bool UserIDBookIDExists(int userID, int bookID)
        {
            SqlCommand cmd = new SqlCommand("SELECT CASE WHEN EXISTS (SELECT * FROM[UserBook] WHERE [Book_ID] = @bookID AND [User_ID]= @userID AND [ReturnDate] IS NULL) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END", GetCon());
            cmd.Parameters.AddWithValue("@bookID", bookID);
            cmd.Parameters.AddWithValue("@userID", userID);

            OpenCon();
                bool exist = (bool)cmd.ExecuteScalar();
            CloseCon();

            return exist;
        }


        //Lend Book
        public bool LendBook(int UserID, int BookID)
        {
            bool uitgeleend = IsBorrowed(BookID);
            bool Finished = false;

            if (!uitgeleend)
            {
                OpenCon();
                transaction = GetCon().BeginTransaction();

                SqlCommand cmd1 = new SqlCommand("INSERT INTO[dbo].[UserBook]   ([User_ID],[Book_ID],[RetourDate],[ReturnDate],[TimesProlonged]) VALUES( @UserID, @BookID, GETDATE() + 21, NULL, 0)", GetCon(), transaction);
                cmd1.Parameters.AddWithValue("UserID", UserID);
                cmd1.Parameters.AddWithValue("BookID", BookID);

                SqlCommand cmd2 = new SqlCommand("UPDATE[Book]   SET[IsBorrowed] = 1   WHERE ID = @BookID", GetCon(), transaction);
                cmd2.Parameters.AddWithValue("BookID", BookID);

                try
                {
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    transaction.Commit();
                    Finished = true;
                }
                catch (SqlException)
                {
                    transaction.Rollback();
                }

                CloseCon();
            }

            return Finished;
        }


        
        //Return book
        public bool ReturnBook(int userID, int bookID)
        {
            bool uitgeleend = IsBorrowed(bookID);
            bool UserLendBook = UserIDBookIDExists(bookID,userID);
            bool Finished = false;
            
            if (uitgeleend )
            {
                OpenCon();
                transaction = GetCon().BeginTransaction();

                SqlCommand cmd1 = new SqlCommand("UPDATE[UserBook]  SET[ReturnDate] = GETDATE()   WHERE[Book_ID] = @BookID   AND[User_ID] = @UserID  AND [ReturnDate] IS NULL", GetCon(), transaction );
                cmd1.Parameters.AddWithValue("UserID", userID);
                cmd1.Parameters.AddWithValue("BookID", bookID);

                SqlCommand cmd2 = new SqlCommand("UPDATE [Book]  SET[IsBorrowed] = 0   WHERE ID = @BookID", GetCon(), transaction);
                cmd2.Parameters.AddWithValue("BookID", bookID);

                try
                {
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    transaction.Commit();
                    Finished = true;
                }
                catch (SqlException)
                {
                    transaction.Rollback();
                }

                CloseCon(); 
            }
            return Finished;
        }



        //Prolong book
        public bool ProlongBook(int userID, int bookID)
        {
            bool Finished = false;

            if (!CheckTimesProlonged(userID, bookID))
            {
                OpenCon();
                transaction = GetCon().BeginTransaction();

                SqlCommand cmd = new SqlCommand("UPDATE UserBook SET[RetourDate] = GETDATE() + 21, [TimesProlonged] = [TimesProlonged]+1 WHERE[User_ID] = @UserID AND[Book_ID] =@BookID AND[ReturnDate] IS NULL AND[TimesProlonged] < 3", GetCon(), transaction);
                cmd.Parameters.AddWithValue("UserID", userID);
                cmd.Parameters.AddWithValue("BookID", bookID);

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
            } 

            return Finished;
        }



        // Return DataTables
        public DataTable GetPopulairBooks()
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 3 Book.Title, Author.Name, Book.ISBN FROM UserBook INNER JOIN[Book] ON[Book_ID] = [Book].[ID] INNER JOIN[Author] ON[Author_ID] = [Author].[ID] GROUP BY Title, Name, ISBN ORDER BY COUNT(Book_ID) DESC", GetCon());
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            
            OpenCon();
                adapt.Fill(table);
            CloseCon();

            return table;
        }

        public DataTable GetBooks()
        {
            SqlCommand cmd = new SqlCommand("SELECT Book.ID, Book.Title as Titel, Author.Name as Auteur, Genre.Genre, Book.Blurb ,Book.ISBN, Book.ReleaseDate, Book.IsBorrowed FROM Book INNER JOIN Author ON Author.ID = Book.Author_ID INNER JOIN Genre ON Genre.ID = Book.Genre_ID ", GetCon());
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable Table = new DataTable();

            OpenCon();
            adapt.Fill(Table);
            CloseCon();

            return Table;
        }
    }
}
