using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DBLibrary;
using System.Collections.Generic;

namespace DatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //DisconnectedData();
            //ConnectedData();
            
        }


        static void DisconnectedData()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

            string sql = "Select * from dept";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "dept");


            foreach (DataRow row in ds.Tables["dept"].Rows)
            {
                Console.WriteLine($"DeptNo :{row["DeptNo"]} DeptName :{row["Dname"]} Location :{row["Loc"]}");
            }


        }

        static void ConnectedData()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            string sql = "Select * from emp";

            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"EmpName:{reader["ename"]} Salary:{reader["sal"]}");

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
            
        }


    }
}
