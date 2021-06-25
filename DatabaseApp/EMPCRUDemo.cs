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

        EmpDataStore empDataStore;

        public EMPCRUDemo(string connectionstring)
        {
            empDataStore= new EmpDataStore(connectionstring);
        }

        public void displayEmps()
        {

           

           List<Emp> ListEmp = new List<Emp>();

            ListEmp = empDataStore.GetEmps();
            foreach (Emp i in ListEmp)
            {
                Console.WriteLine("{0}\t", i.ToString());

            }

        }

        public void displayEmp()
        {

            Emp emp = new Emp();
            emp = empDataStore.GetEmp(7499);
            Console.WriteLine("{0}\t", emp.ToString());

        }

        public void InsertEmp()
        {
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

            int status = empDataStore.InsertEmp(emp2);

            if (status > 0)
            {
                Console.WriteLine("Emp record inserted successfully");
            }
            else
            {
                Console.WriteLine("No record Inserted");
            }


            Console.ReadLine();
        }

        public void UpdateEmp()
        {
            Emp emp3 = new Emp();
            Console.WriteLine("Enter Employee Number ");
            emp3.EmpNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Employee Name ");
            emp3.EmpName = Console.ReadLine();

            Console.WriteLine("Enter Employee HireDate ");
            emp3.HireDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Employee Salary" +
                " ");
            emp3.Salary = Int64.Parse(Console.ReadLine());

            int status = empDataStore.updateEmp(emp3);

            if (status > 0)
            {
                Console.WriteLine("Emp record Updated successfully");
            }
            else
            {
                Console.WriteLine("No record Updated");
            }


            Console.ReadLine();
        }

        public void DeleteEmp()
        {
            int EmpNo;
            Console.WriteLine("Enter Employee Number ");
            EmpNo = int.Parse(Console.ReadLine());

            int status = empDataStore.deleteEmp(EmpNo);

            if (status > 0)
            {
                Console.WriteLine("Emp record Deleted successfully");
            }
            else
            {
                Console.WriteLine("No record Deleted");
            }




        }

        static void Main(string[] args)
        {


            EMPCRUDemo eMPCRUDemo = new EMPCRUDemo(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            eMPCRUDemo.displayEmps();

            Console.WriteLine("-------------------------------");


            eMPCRUDemo.displayEmp();

            Console.WriteLine("----------------------------------");

            eMPCRUDemo.InsertEmp();

            Console.WriteLine("----------------------------------");
            eMPCRUDemo.UpdateEmp();

            Console.WriteLine("----------------------------------");

            eMPCRUDemo.DeleteEmp();





        }

    }
}
