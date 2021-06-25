using DBLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;

namespace DatabaseApp
{
    class ClientTest
    {

        UserDataStore userDataStore;
        public ClientTest(string connectionstring)
        {
            userDataStore = new UserDataStore(connectionstring);
        }

        bool ValidateUserTestConnected()
        {
            try
            {
                UserData user = new UserData();
                Console.Write("Username: ");
                user.UserName = Console.ReadLine();
                Console.Write("Password: ");
                user.Password = Console.ReadLine();
                return userDataStore.validateUser_connected(user);

            }
            catch (Exception)
            {
                throw;
                
            }
        }


        bool ValidateUserTestDisconnected()
        {
            try
            {
                UserData user = new UserData();
                Console.Write("Username: ");
                user.UserName = Console.ReadLine();
                Console.Write("Password: ");
                user.Password = Console.ReadLine();
                return userDataStore.validateUser_disconnected(user);

            }
            catch (Exception)
            {
                throw;
                
            }
        }

        static void Main(string[] args)
        {

            ClientTest clientTest = new ClientTest(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

            bool check1 = clientTest.ValidateUserTestDisconnected();
            if (check1==true)
            {
                Console.WriteLine("User Authenticated");
            }
            else
            {
                Console.WriteLine("User Not Authenticated");
            }
            bool check2= clientTest.ValidateUserTestConnected();
            if ( check2== true)
            {
                Console.WriteLine("User Authenticated");
            }
            else
            {
                Console.WriteLine("User Not Authenticated");
            }


        }
    }
}
