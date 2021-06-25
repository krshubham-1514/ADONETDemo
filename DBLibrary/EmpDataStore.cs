using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DBLibrary
{
    public class EmpDataStore
    {

        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataReader reader = null;

        public EmpDataStore(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        //get all emp details

        public List<Emp> GetEmps()
        {

            try
            {

                string sql = "select empno,ename,hiredate,sal from emp";
                command = new SqlCommand(sql, connection);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                reader = command.ExecuteReader();
                List<Emp> empList = new List<Emp>();
                while (reader.Read())
                {
                    Emp emp = new Emp();
                    emp.EmpNo = (int)reader["empno"];
                    emp.EmpName = reader["ename"].ToString();
                    emp.HireDate = reader["hiredate"] as DateTime?;
                    emp.Salary = reader["sal"] as decimal?;
                    empList.Add(emp);


                }

                return empList;



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

        public Emp GetEmp(int EmpNo)
        {
            try
            {

                string sql = "select empno,ename,hiredate,sal from emp WHERE empno=@eno";
                command = new SqlCommand(sql, connection);
                command.Parameters.Add("eno", EmpNo);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                reader = command.ExecuteReader();
                Emp emp = new Emp();
                while (reader.Read())
                {


                    emp.EmpNo = (int)reader["empno"];
                    emp.EmpName = reader["ename"].ToString();
                    emp.HireDate = reader["hiredate"] as DateTime?;
                    emp.Salary = reader["sal"] as decimal?;


                }


                return emp;





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

        public int InsertEmp(Emp emp)
        {
            try
            {
                string sql = "INSERT INTO EMP(EMPNO,ENAME,HIREDATE,SAL) VALUES (@eno,@name,@date,@sal)";
                command = new SqlCommand(sql, connection);
                //command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("eno", emp.EmpNo);
                command.Parameters.AddWithValue("name", emp.EmpName);
                command.Parameters.AddWithValue("date", emp.HireDate);
                command.Parameters.AddWithValue("sal", emp.Salary);


                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                int countt = command.ExecuteNonQuery();


                return countt;
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


        public int updateEmp(Emp emp)
        {
            try
            {

            
            string sql = "UPDATE EMP SET ENAME=@ename,HIREDATE=@hire,SAL=@sal WHERE EMPNO=@eno";
            command = new SqlCommand(sql, connection);
            
            command.Parameters.AddWithValue("eno", emp.EmpNo);
            command.Parameters.AddWithValue("ename", emp.EmpName);
            command.Parameters.AddWithValue("hire", emp.HireDate);
            command.Parameters.AddWithValue("sal", emp.Salary);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            int countt = command.ExecuteNonQuery();


            return countt;
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


        public int deleteEmp(int EmpNo)
        {
            try
            {


                string sql = "DELETE FROM EMP WHERE EMPNO=@eno";
                command = new SqlCommand(sql, connection);
                //command.CommandType = CommandType.StoredProcedure;
               
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                int countt = command.ExecuteNonQuery();


                return countt;
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




    }



}
