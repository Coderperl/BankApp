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
            Console.ForegroundColor = ConsoleColor.White;
            BankLogic BankLogic = new();
            //SavingsAccount savingsAccount= new();
            
            //SavingsAccount = SavingsAccount = new();

            bool loggedIn = false;
            string userInput = "";
            BankLogic.AddAccountsMetaData();
           

            //List<Customer> Customers = BankLogic.GetAllCustomers();
            List<SavingsAccount> SavingsAccounts = new List<SavingsAccount>();
            //foreach (Customer i in Customers)
            //{
            //    int index = i.SocialSecurityNumber;
            //    i.AddSavingsAccount(index);
            //    Console.WriteLine("");
            //    Console.WriteLine($"--User-- Social Number: {i.SocialSecurityNumber} - Fullname: {i.FirstName} {i.LastName}");
            //    i.PrintSavingsAccounts();
            //}

            //int pNr = 19900340;
            //Customer c = BankLogic.GetAllCustomers().Where(cust => cust.SocialSecurityNumber == pNr).First();

            //Console.WriteLine($"{c.FullName} {c.SocialSecurityNumber}");

            //foreach (string row in List)
            //{
            //    Console.WriteLine(row);
            //}

            //int test = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Test: {Customers[test].FirstName}");


            //Console.WriteLine($"Fullname: {customerList[test].FirstName} {customerList[test].LastName}");
            //Console.WriteLine($"Socialdnwdoa {customerList[test].SocialSecurityNumber}");

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
                        //Console.WriteLine($"Account Number:  {LoggedIn.GetListOfAccounts().First().AccountNumber} Type: {LoggedIn.GetListOfAccounts().First().AccountType}\nBalance: {LoggedIn.GetListOfAccounts().First().AccountBalance}");
                        Console.WriteLine("");
                        Console.WriteLine("Manage Your Account");
                        Console.WriteLine("1. Make a Deposit\n2. Make a Withdrawal\n3. Change Name\n4. Close Bank Accounts\n5. Return to Menu");
                        Console.Write("\nWhat is your choice? ");
                        userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                //Console.WriteLine($"Current Balance: {LoggedIn.GetListOfAccounts().First().ShowAccount()}");
                                //Console.WriteLine($"\nSocial Number: {LoggedIn.SocialSecurityNumber}  Name: {LoggedIn.FullName}");
                                //Console.WriteLine(sa.ShowAccount());
                                Console.Write("How much do you wanna deposit? ");
                                int deposit = int.Parse(Console.ReadLine());
                                sa.DepositMoney(deposit);

                                //Console.WriteLine($"Current dwadwadBalance: {LoggedIn.GetListOfAccounts().First().AccountBalance}");
                                Thread.Sleep(1500);
                                Console.Clear();
                                Console.WriteLine($"Added {deposit} into account {LoggedIn.GetListOfAccounts().First().AccountNumber} which makes it now have a total of {LoggedIn.GetListOfAccounts().First().AccountBalance}\n");
                                //Vi kan lägga in pengar men värdena sparar inte i SavingsAccount som går att återhämta

                                //Console.WriteLine(SavingsAccount.ShowAccount());
                                //Console.WriteLine($"Added {input} into account {SavingsAccounts[inputSocialSecurityNumber].AccountNumber} which makes it now have a total of {SavingsAccounts[inputSocialSecurityNumber].AccountBalance + input}");
                                break;
                            case "2":
                                Console.Write("How much do you wanna withdrawal? ");
                                int withdrawal = int.Parse(Console.ReadLine());
                                sa.WithdrawMoney(withdrawal);

                                //Console.WriteLine($"Current dwadwadBalance: {LoggedIn.GetListOfAccounts().First().AccountBalance}");
                                Thread.Sleep(1500);
                                Console.Clear();
                                Console.WriteLine($"Added {withdrawal} into account {LoggedIn.GetListOfAccounts().First().AccountNumber} which makes it now have a total of {LoggedIn.GetListOfAccounts().First().AccountBalance}\n");
                                //Vi kan lägga in pengar men värdena sparar inte i SavingsAccount som går att återhämta

                                //Console.WriteLine(SavingsAccount.ShowAccount());
                                //Console.WriteLine($"Added {input} into account {SavingsAccounts[inputSocialSecurityNumber].AccountNumber} which makes it now have a total of {SavingsAccounts[inputSocialSecurityNumber].AccountBalance + input}");
                                break;
                            case "3":
                                Console.WriteLine("\nThese are the names you can change");
                                Console.WriteLine("1. First Name");
                                Console.WriteLine("2. Last Name");
                                Console.Write("\nWhat is your choice? ");
                                int inputchangename = int.Parse(Console.ReadLine());
                                if (inputchangename == 1)
                                {
                                    Console.Write("What do you wanna change your First Name to? ");
                                    string changefirstname = Console.ReadLine();
                                    //////////////////////////////////////////////////FUNKER EJ
                                    BankLogic.GetAllCustomers().First().ChangeCustomerFirstName(inputSocialSecurityNumber, changefirstname);
                                    Console.WriteLine($"{LoggedIn.FullName}");
                                }
                                else if (inputchangename == 2)
                                {
                                    Console.Write("What do you wanna change your First Name to? ");
                                    string changelastname = Console.ReadLine();
                                    //////////////////////////////////////////////////FUNKER EJ
                                    BankLogic.GetAllCustomers().First().ChangeCustomerLastName(inputSocialSecurityNumber, changelastname);
                                    Console.WriteLine($"{LoggedIn.FullName}");
                                }

                                //Console.WriteLine($"Current dwadwadBalance: {LoggedIn.GetListOfAccounts().First().AccountBalance}");
                                //Thread.Sleep(1500);
                                //Console.WriteLine($"Added {withdrawal} into account {LoggedIn.GetListOfAccounts().First().AccountNumber} which makes it now have a total of {LoggedIn.GetListOfAccounts().First().AccountBalance}\n");
                                //Vi kan lägga in pengar men värdena sparar inte i SavingsAccount som går att återhämta

                                //Console.WriteLine(SavingsAccount.ShowAccount());
                                //Console.WriteLine($"Added {input} into account {SavingsAccounts[inputSocialSecurityNumber].AccountNumber} which makes it now have a total of {SavingsAccounts[inputSocialSecurityNumber].AccountBalance + input}");
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
                        //SavingsAccounts.Add(new SavingsAccount(BankLogic.CreateAccNum()+1, createUserSocialSecurityNumber, 66000, "hej", 5));
                        //SavingsAccount.Add(new SavingAccount(55, createUserFirstName, createUserLastName, createUserSocialSecurityNumber));
                        Console.Clear();
                        Console.WriteLine("Loading Currenty Users..");
                        foreach (Customer i in BankLogic.GetAllCustomers())
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
