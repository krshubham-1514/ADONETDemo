using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DBLibrary
{
    class UserDataStore
    {

        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataReader reader = null;

        public UserDataStore(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public bool validateUser_connected(UserData user)
        {
            string sql = "SELECT * FROM USERDATE WHERE username=@uname AND password=@pass";
            command = new SqlCommand(sql, connection);
            command.Parameters.Add("uname", user.UserName);
            command.Parameters.Add("pass", user.Password);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return true;

                }

                
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return false;
        }

        public bool validateUser_disconnected(UserData user)
        {

            string sql = "SELECT * FROM USERDATE";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "user");

            DataTable dataTable = ds.Tables["user"];
            DataRow[] dr = dataTable.Select($"USERNAME='{user.UserName}' AND PASSWORD='{user.Password}'");
            if (dr != null && dr.Length != 0)
                return true;
            return false;






        }
    }
}
