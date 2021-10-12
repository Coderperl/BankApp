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
            BankLogic startBank = new();

            string userInput = "";
            Console.WriteLine("Welcome to the Bank!");
            Console.WriteLine("What can we do for you?");
            //Customer c = startBank.GetCustomer(19900340);
            //startBank.GetAllCustomers()[0].AddSavingsAccount(19900340);
            
            startBank.GetAllCustomers()[1].AddSavingsAccount(19910740);
            Console.WriteLine();
            //startBank.GetAllCustomers()[0].GetListOfAccounts()[0].DepositMoney(100000);
            startBank.GetAllCustomers()[1].GetListOfAccounts()[0].DepositMoney(50000);
            startBank.GetAllCustomers()[1].GetListOfAccounts()[0].WithdrawMoney(20000);
            Console.WriteLine();
           
            List<string> List = startBank.RemoveCustomer(19910740);

            foreach (string row in List)
            {
                Console.WriteLine(row);
            }

            while (userInput!= "7")
            {
                Console.WriteLine();
                Console.WriteLine("Choose one of the following options.");
                Console.WriteLine("1. ");
                Console.WriteLine("2. ");
                Console.WriteLine("3. ");
                Console.WriteLine("4. ");
                Console.WriteLine("5. ");
                Console.WriteLine("6. ");
                Console.WriteLine("7. ");
                Console.WriteLine("0. Exit the app.");

                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("You chose an Unvalid Input, Please try again. ");
                        break;
                }
            }
        }
    }
}
