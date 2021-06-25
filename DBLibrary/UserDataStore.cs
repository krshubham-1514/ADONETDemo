using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DBLibrary
{
    public class UserDataStore
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
            string sql = "SELECT * FROM userdata WHERE username=@uname AND password=@pass";
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

                return false;


            }
            catch (SqlException)
            {
                throw;

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            
        }

        public bool validateUser_disconnected(UserData user)
        {

            string sql = "SELECT * FROM userdata";
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
