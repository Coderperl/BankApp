using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankApp
{
    class BankAppUI
    {
        static void Main(string[] args)
        {
            BankLogic BankLogic = new();
            bool loggedIn = false;
            string userInput = "";
            BankLogic.AddAccountsMetaData();

            //List<Customer> Customers = BankLogic.GetAllCustomers();
            List<SavingsAccount> SavingsAccounts = new List<SavingsAccount>();

            /////////////////////////////////////////////
            //Testing loading customersData from XML file
            var customersFilePath = @"C:\Users\PhilipHero\Source\Repos\BankApp2\BankApp\Customers.xml";
            var customersData = XElement.Load(customersFilePath);
            var realCustomersData = customersData.Descendants("Customer").Where(st => (int)st.Element("SocialSecurityNumber") == 252525);
            foreach (var customer in realCustomersData)
            {
                Console.WriteLine($"Gathering Data: {customer.Element("SocialSecurityNumber")}");
                Console.WriteLine($"Gathering Data: {customer.Element("FirstName")}");
                Console.WriteLine($"Gathering Data: {customer.Element("LastName")}");
                Console.WriteLine($"Gathering Data: {customer.Element("FullName")}");

                var marks = customer.Descendants("SocialSecurityNumber");
                foreach (var item in marks)
                {
                    Console.WriteLine($"SocialSecurityNumber: {item.Value}");
                }
            }
            /////////////////////////////////////////////
            //Testing loading savingsAccountsData from XML file
            Console.WriteLine("");
            var savingsAccountsFilePath = @"C:\Users\PhilipHero\Source\Repos\BankApp2\BankApp\SavingsAccounts.xml";
            var savingsAccountsData = XElement.Load(savingsAccountsFilePath);
            var realSavingsAccountsData = savingsAccountsData.Descendants("SavingsAccount").Where(st => (int)st.Element("AccountNumber") == 1000);
            foreach (var savingsaccount in realSavingsAccountsData)
            {
                Console.WriteLine($"Gathering Data: {savingsaccount.Element("AccountNumber")}");
                Console.WriteLine($"Gathering Data: {savingsaccount.Element("AccountType")}");
                Console.WriteLine($"Gathering Data: {savingsaccount.Element("AccountBalance")}");
                Console.WriteLine($"Gathering Data: {savingsaccount.Element("Interest")}");

                var marks = savingsaccount.Descendants("AccountNumber");
                foreach (var item in marks)
                {
                    Console.WriteLine($"AccountNumber: {item.Value}");
                }
            }
            Console.WriteLine("");

            while (loggedIn == false)
            {
                Console.WriteLine("Choose one of the following options");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create User");
                Console.WriteLine("3. Exit");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--Users and their accounts--");
                        foreach (Customer i in BankLogic.GetAllCustomers())
                        {
                            long index = i.SocialSecurityNumber;
                            Console.WriteLine($"Social Number: {i.SocialSecurityNumber}  Name: {i.FirstName} {i.LastName}");
                            i.PrintSavingsAccounts();
                            Console.WriteLine("");
                        }
                        Console.Write("What users do you wanna login as? ");
                        int inputSocialSecurityNumber = int.Parse(Console.ReadLine());
                        Customer LoggedIn = null;
                        foreach (Customer i in BankLogic.GetAllCustomers())
                        {
                            if (i.SocialSecurityNumber == inputSocialSecurityNumber)
                            {
                                LoggedIn = i;
                            }
                        }

                        SavingsAccount sa = LoggedIn.GetListOfAccounts().First();
                        Console.WriteLine($"Logging in as {LoggedIn.FullName}..");
                        Thread.Sleep(1500);
                        Console.Clear();
                        Console.WriteLine($"Social Number: {LoggedIn.SocialSecurityNumber}  Name: {LoggedIn.FullName}");
                        Console.WriteLine(sa.ShowAccount()); 
                        Console.WriteLine("");
                        Console.WriteLine("Manage Your Account");
                        Console.WriteLine("1. Make a Deposit\n2. Make a Withdrawal\n3. Change Name\n4. Close Bank Accounts\n5. Return to Menu");
                        Console.Write("\nWhat is your choice? ");
                        userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                Console.Write("How much do you wanna deposit? ");
                                int deposit = int.Parse(Console.ReadLine());
                                sa.DepositMoney(deposit);
                                Thread.Sleep(1500);
                                Console.Clear();
                                Console.WriteLine($"Added {deposit} into account {LoggedIn.GetListOfAccounts().First().AccountNumber} which makes it now have a total of {LoggedIn.GetListOfAccounts().First().AccountBalance}\n");
                                break;
                            case "2":
                                Console.Write("How much do you wanna withdrawal? ");
                                int withdrawal = int.Parse(Console.ReadLine());
                                sa.WithdrawMoney(withdrawal);
                                Thread.Sleep(1500);
                                Console.Clear();
                                Console.WriteLine($"Added {withdrawal} into account {LoggedIn.GetListOfAccounts().First().AccountNumber} which makes it now have a total of {LoggedIn.GetListOfAccounts().First().AccountBalance}\n");
                                //Vi kan lägga in pengar men värdena sparar inte i SavingsAccount som går att återhämta
                                break;
                            case "3":
                                Console.WriteLine("\nThese are the names you can change");
                                Console.WriteLine($"1.{LoggedIn.FirstName}");
                                Console.WriteLine($"2.{LoggedIn.LastName}");
                                Console.Write("\nWhat is your choice? ");
                                int inputchangename = int.Parse(Console.ReadLine());
                                if (inputchangename == 1)
                                {
                                    Console.Write("What do you wanna change your First Name to? ");
                                    string changefirstname = Console.ReadLine();
                                    //////////////////////////////////////////////////FUNKER EJ
                                    LoggedIn.ChangeCustomerFirstName(changefirstname);
                                    Console.WriteLine($"{LoggedIn.FullName}");
                                }
                                else if (inputchangename == 2)
                                {
                                    Console.Write("What do you wanna change your Last Name to? ");
                                    string changelastname = Console.ReadLine();
                                    //////////////////////////////////////////////////FUNKER EJ
                                    LoggedIn.ChangeCustomerLastName(changelastname);
                                    Console.WriteLine($"{LoggedIn.FullName}");
                                }
                                break;
                            case "4":
                                ///////////////////////////////////////////////////foreach som kollar 
                                Console.WriteLine("\nThese are your currently bank accounts");
                                Console.WriteLine("1. ??");
                                Console.WriteLine("2. ??");
                                Console.Write("\nWhich do you wanna close? ");
                                int inputcloseaccount = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Closed your bank account with id {"??"} into account {LoggedIn.GetListOfAccounts().First().AccountNumber} which makes it now have a total of {LoggedIn.GetListOfAccounts().First().AccountBalance}\n");
                                break;
                            case "5":
                                Console.Clear();
                                break;
                            default:
                                Console.Clear();
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
                        BankLogic.GetAllCustomers().Add(new Customer(createUserFirstName, createUserLastName, createUserSocialSecurityNumber));
                        Console.Clear();
                        Console.WriteLine("Loading Currenty Users..");
                        foreach (Customer i in BankLogic.GetAllCustomers())
                        {
                            int index = i.SocialSecurityNumber;
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
