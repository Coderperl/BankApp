using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankApp
{
    class BankAppUI
    {
        static void Main(string[] args)
        {
            BankLogic BankLogic = new();
            SavingsAccount SavingsAccount = new();
            
            //SavingsAccount = SavingsAccount = new();

            bool loggedIn = false;
            string userInput = "";

            List<Customer> Customers = new List<Customer>(BankLogic.GetAllCustomers());
            List<SavingsAccount> SavingsAccounts = new List<SavingsAccount>(BankLogic.GetAllAccounts());
            //foreach (Customer i in Customers)
            //{
            //    int index = i.SocialSecurityNumber;
            //    i.AddSavingsAccount(index);
            //    Console.WriteLine("");
            //    Console.WriteLine($"--User-- Social Number: {i.SocialSecurityNumber} - Fullname: {i.FirstName} {i.LastName}");
            //    i.PrintSavingsAccounts();
            //}






            //int test = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Test: {Customers[test].FirstName}");


            //Console.WriteLine($"Fullname: {customerList[test].FirstName} {customerList[test].LastName}");
            //Console.WriteLine($"Socialdnwdoa {customerList[test].SocialSecurityNumber}");

            while (loggedIn == false)
            {
                Console.WriteLine("Choose one of the following options.");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create User");
                Console.WriteLine("3. Exit");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--Users--");
                        foreach (Customer i in Customers)
                        {
                            long index = i.SocialSecurityNumber;
                            Console.WriteLine($"ID: {0} Social Number: {i.SocialSecurityNumber} - Fullname: {i.FirstName} {i.LastName}");
                            i.PrintSavingsAccounts();
                        }
                        foreach (SavingsAccount i in SavingsAccounts)
                        {
                            long index = i.AccountNumber;
                            Console.WriteLine($"ID: {0} Account Number: {i.AccountNumber} - {i.AccountType} - {i.AccountNumberParent}");
                            //i.PrintSavingsAccounts();
                        }
                        Console.Write("What users do you wanna login as? ");
                        int inputSocialSecurityNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Logging in as {Customers[inputSocialSecurityNumber].FullName}..");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine($"Name: {Customers[inputSocialSecurityNumber].FullName}\nSocial Security Number: {Customers[inputSocialSecurityNumber].SocialSecurityNumber}");
                        Console.WriteLine($"Account Number: {SavingsAccounts[inputSocialSecurityNumber].AccountNumber} Type: {SavingsAccounts[inputSocialSecurityNumber].AccountType}\nBalance: {SavingsAccounts[inputSocialSecurityNumber].AccountBalance}");
                        Console.WriteLine("");
                        Console.WriteLine("Manage Your Account");
                        Console.WriteLine("1. Make a Deposit\n2. Make a Withdrawal\n3. Change Name\n4. Close Account\n5. Return to Menu");
                        userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                Console.WriteLine($"Current Balance: {SavingsAccounts[inputSocialSecurityNumber].AccountBalance}");
                                Console.WriteLine("How much do you wanna deposit?");
                                int deposit = int.Parse(Console.ReadLine());

                                SavingsAccounts.Add(new SavingsAccount(SavingsAccounts[inputSocialSecurityNumber].AccountNumber, Customers[inputSocialSecurityNumber].SocialSecurityNumber, SavingsAccounts[inputSocialSecurityNumber].AccountBalance + deposit, "Saving Account Metadata", 1));
                                Console.WriteLine($"Added {deposit} into account {SavingsAccounts[inputSocialSecurityNumber].AccountNumber} which makes it now have a total of {SavingsAccounts[inputSocialSecurityNumber].AccountBalance + deposit}");
                                //Vi kan lägga in pengar men värdena sparar inte i SavingsAccount som går att återhämta

                                //Console.WriteLine(SavingsAccount.ShowAccount());
                                //Console.WriteLine($"Added {input} into account {SavingsAccounts[inputSocialSecurityNumber].AccountNumber} which makes it now have a total of {SavingsAccounts[inputSocialSecurityNumber].AccountBalance + input}");
                                break;
                            case "2":
                                Console.WriteLine($"Current Balance: {SavingsAccounts[inputSocialSecurityNumber].AccountBalance}");
                                Console.WriteLine("How much do you wanna Withdrawal?");
                                int withdrawal = int.Parse(Console.ReadLine());

                                SavingsAccounts.Add(new SavingsAccount(SavingsAccounts[inputSocialSecurityNumber].AccountNumber, Customers[inputSocialSecurityNumber].SocialSecurityNumber, SavingsAccounts[inputSocialSecurityNumber].AccountBalance + withdrawal, "Saving Account Metadata", 1));
                                Console.WriteLine($"Added {withdrawal} into account {SavingsAccounts[inputSocialSecurityNumber].AccountNumber} which makes it now have a total of {SavingsAccounts[inputSocialSecurityNumber].AccountBalance - withdrawal}");

                                //Vi kan lägga in pengar men värdena sparar inte i SavingsAccount som går att återhämta

                                break;
                            case "3":
                                break;
                            case "4":
                                break;
                            case "5":
                                Console.Clear();
                                break;
                            default:
                                break;
                        }
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
                        SavingsAccounts.Add(new SavingsAccount(BankLogic.CreateAccNum()+1, createUserSocialSecurityNumber, 66000, "hej", 5));
                        //SavingsAccount.Add(new SavingAccount(55, createUserFirstName, createUserLastName, createUserSocialSecurityNumber));
                        Console.Clear();
                        Console.WriteLine("Loading Currenty Users..");
                        foreach (Customer i in Customers)
                        {
                            int index = i.SocialSecurityNumber;
                            //i.AddSavingsAccount(index);
                            Console.WriteLine($"--User-- Social Number: {i.SocialSecurityNumber} - Fullname: {i.FirstName} {i.LastName}");
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
