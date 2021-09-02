using System;
using System.Data;
using System.Data.SqlClient;

namespace Vivlio.Tools
{
    public class Databasehandler
    {
        SqlConnectionStringBuilder ConBuilder;
        SqlConnection Con;
        public SqlTransaction transaction;



        public Databasehandler()
        {
            ConBuilder = new SqlConnectionStringBuilder();

            ConBuilder.DataSource = "db,1433";
            ConBuilder.UserID = "SA";
            ConBuilder.Password = "Welkom12345";
            ConBuilder.InitialCatalog = "Vivlio";

            Con = new SqlConnection(ConBuilder.ConnectionString);
        }



        public void OpenCon()
        {
            Con.Open();
        }

        public void CloseCon()
        {
            Con.Close();
        }

        public SqlConnection GetCon()
        {
            return Con;
        }

        public bool TestCon()
        {
            bool open = false;

            try
            {
                if (Con.State != ConnectionState.Open)
                {
                    Con.Open();
                    open = true;
                    Con.Close();
                }
            }
            catch (Exception)
            {
                open = false;
            }
            return open;
        }
    }
}
