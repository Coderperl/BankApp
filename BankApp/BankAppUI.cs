using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class BankAppUI
    {
        static void Main(string[] args)
        {
            BankLogic BankLogic = new();
            //SavingsAccount = SavingsAccount = new();

            bool loggedIn = false;
            string userInput = "";
            Console.WriteLine("Bank is starting up..");
            Console.WriteLine("");



            Console.WriteLine("Loading Currenty Users..");
            List<Customer> Customers = new List<Customer>(BankLogic.GetAllCustomers());
            List<SavingsAccount> SavingsAccounts = new List<SavingsAccount>(BankLogic.GetAllAccounts());
            foreach (Customer i in Customers)
            {
                int index = i.SocialSecurityNumber;
                i.AddSavingsAccount(index);
                Console.WriteLine("--User--");
                Console.WriteLine($"Social Number: {i.SocialSecurityNumber} - Fullname: {i.FirstName} {i.LastName}");
                Console.WriteLine($"Social Number: {i.SocialSecurityNumber} - Fullname: {i.FirstName} {i.LastName}");
                i.PrintSavingsAccounts();
            }

            foreach (SavingsAccount i in SavingsAccounts)
            {
                int index = i.AccountNumberParent;
                Console.WriteLine($"Social Number: {i.AccountNumberParent[1]} - Fullname: ");
            }



            Console.WriteLine("Done Loading Currenty Users..");
            //int test = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Test: {Customers[test].FirstName}");


            //Console.WriteLine($"Fullname: {customerList[test].FirstName} {customerList[test].LastName}");
            //Console.WriteLine($"Socialdnwdoa {customerList[test].SocialSecurityNumber}");

            while (loggedIn == false)
            {
                Console.WriteLine();
                Console.WriteLine("Choose one of the following options.");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create User");
                Console.WriteLine("3. Exit");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Loading Currenty Users..");
                        foreach (Customer i in Customers)
                        {
                            long index = i.SocialSecurityNumber;
                            Console.WriteLine("--User--");
                            Console.WriteLine($"Social Number: {i.SocialSecurityNumber} - Fullname: {i.FirstName} {i.LastName}");
                            i.PrintSavingsAccounts();
                        }
                        Console.WriteLine("Done Loading Currenty Users..");
                        Console.WriteLine("");
                        Console.WriteLine("What users do you wanna login as?");


                        break;
                    case "2":
                        Console.WriteLine("-----------");
                        Console.WriteLine("Firstname: ");
                        string createUserFirstName = Console.ReadLine();
                        Console.WriteLine("Lastname: ");
                        string createUserLastName = Console.ReadLine();
                        Console.WriteLine("Social Security Number: ");
                        int createUserSocialSecurityNumber = int.Parse(Console.ReadLine());
                        Customers.Add(new Customer(createUserSocialSecurityNumber, createUserFirstName, createUserLastName));
                        //SavingsAccount.Add(new SavingAccount(55, createUserFirstName, createUserLastName, createUserSocialSecurityNumber));
                        Console.Clear();
                        Console.WriteLine("Loading Currenty Users..");
                        foreach (Customer i in Customers)
                        {
                            int index = i.SocialSecurityNumber;
                            i.AddSavingsAccount(index);
                            Console.WriteLine("--User--");
                            Console.WriteLine($"Social Number: {i.SocialSecurityNumber} - Fullname: {i.FirstName} {i.LastName}");
                            i.PrintSavingsAccounts();
                        }
                        Console.WriteLine("Done Loading Currenty Users..");
                        break;
                    case "3":
                        loggedIn = true;
                        Console.Clear();
                        Console.WriteLine("Shuting Down Bank..");
                        break;
                    default:
                        Console.WriteLine("Helt ute i skogen1");
                        break;
                }
            }
        }
    }
}
