using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLibrary;
using System.Configuration;
using System.Collections.Generic;

namespace DatabaseApp
{
    class EMPCRUDemo
    {

        public void displayEmps()
        {

        }
        
        static void Main(string[] args)
        {

            //List<Emp> ListEmp = new List<Emp>();
            EmpDataStore empDataStore = new EmpDataStore(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            //ListEmp = empDataStore.GetEmps();



            //foreach (Emp i in ListEmp)
            //{
            //    Console.WriteLine("{0}\t", i.ToString());

            //}


            //Console.WriteLine("-------------------------------");
            //Emp emp = new Emp();
            //emp = empDataStore.GetEmp(7499);
            //Console.WriteLine("{0}\t", emp.ToString());

           

            Console.WriteLine("----------------------------------");

            Emp emp2 = new Emp();
            Console.WriteLine("Enter Employee Number ");
            emp2.EmpNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Employee Name ");
            emp2.EmpName = Console.ReadLine();

            Console.WriteLine("Enter Employee HireDate ");
            emp2.HireDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Employee Salary" +
                " ");
            emp2.Salary = Int64.Parse(Console.ReadLine());

            int status=empDataStore.InsertEmp(emp2);

            if (status > 0)
            {
                Console.WriteLine("Emp record inserted successfully");
            }
            else
            {
                Console.WriteLine("No record Inserted");
            }

            Console.WriteLine(emp2.EmpNo + ' ' + emp2.EmpName + ' ' + emp2.HireDate+' '+emp2.Salary);

            Console.ReadLine();



        }

    }
}
