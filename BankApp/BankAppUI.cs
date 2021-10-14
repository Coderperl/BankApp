using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace BankApp
{
    class BankAppUI
    {
        static void Main(string[] args)
        {
            BankLogic BankLogic = new();
            bool loggedIn = false;
            int userInput = 0;
            string dataText = "data.txt";

            BankLogic.AddAccountsMetaData();

            //Loading our lists
            List<Customer> ListCustomers = BankLogic.GetCustomers();
            List<SavingsAccount> ListSavingsAccounts = new List<SavingsAccount>();

            //Big while meny
            while (loggedIn == false)
            {
                Console.WriteLine("Choose one of the following options");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create User");
                Console.WriteLine("3. Remove User");
                Console.WriteLine("4. Exit");
                userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("--Users and their accounts--");
                        //prints our currently users and their accounts though method PrintSavingsAccounts();
                        foreach (Customer i in BankLogic.GetCustomers())
                        {
                            long index = i.SocialSecurityNumber;
                            Console.WriteLine($"Social Number: {i.SocialSecurityNumber}  Name: {i.FirstName} {i.LastName}");
                            i.PrintSavingsAccounts();
                            Console.WriteLine("");
                        }
                        //What user you wanna login as
                        Console.WriteLine($"0. Return to Menu");
                        Console.Write("What user do you wanna login as? ");
                        int inputSocialSecurityNumber = int.Parse(Console.ReadLine());
                        if (inputSocialSecurityNumber != 0)
                        {
                            Customer LoggedInCustomer = null;
                            SavingsAccount sa = null;
                            foreach (Customer i in BankLogic.GetCustomers())
                            {
                                if (i.SocialSecurityNumber == inputSocialSecurityNumber)
                                {
                                    LoggedInCustomer = i;
                                }
                            }
                            //Makes so you load SocialSecurityNumber instead of the index the users where input as
                            
                            Console.WriteLine($"Logging in as {LoggedInCustomer.FullName}..");
                            Thread.Sleep(1500);
                            Console.Clear();
                            Console.WriteLine($"Social Number: {LoggedInCustomer.SocialSecurityNumber}  Name: {LoggedInCustomer.FullName}");
                            Console.WriteLine("--Accounts--");
                            sa = LoggedInCustomer.GetSavingsAccounts().First();
                            if (LoggedInCustomer.GetSavingsAccounts().Count > 1)
                            {
                                foreach (var item in LoggedInCustomer.GetSavingsAccounts())
                                {
                                    Console.WriteLine($"SavingsAccount: {item.AccountNumber} - Balance: {item.AccountBalance} - Type: {item.AccountType}");
                                }
                                Console.WriteLine("\nWhich SavingsAccount do you wanna select?");
                                int LoggedInSavingsAccount = int.Parse(Console.ReadLine());
                                sa = LoggedInCustomer.GetSavingsAccounts().Find(account => account.AccountNumber == LoggedInSavingsAccount);
                            }
                            
                            Console.WriteLine(sa.ShowAccount());
                            Console.WriteLine("");
                            //Shows the alternatives of your options of the account you have chosen.
                            Console.WriteLine("Manage Your Account");
                            Console.WriteLine("1. Make a Deposit\n2. Make a Withdrawal\n3. Change Name\n4. Create SavingsAccount\n5. Remove SavingsAccount\n0. Return to Menu");
                            Console.Write("\nWhat is your choice? ");
                            userInput = int.Parse(Console.ReadLine());
                            if (userInput != 0)
                            {

                            }
                            switch (userInput)
                            {
                                //Actual account choices meny
                                case 1:
                                    //Deposit
                                    Console.Write("How much do you wanna deposit? ");
                                    int deposit = int.Parse(Console.ReadLine());
                                    sa.DepositMoney(deposit);
                                    Console.WriteLine($"Added {deposit} into account {LoggedInCustomer.GetSavingsAccounts().First().AccountNumber} which makes it now have a total of {LoggedInCustomer.GetSavingsAccounts().First().AccountBalance}");
                                    Thread.Sleep(1500);
                                    break;
                                case 2:
                                    //Withdrawal
                                    Console.Write("How much do you wanna withdrawal? ");
                                    int withdrawal = int.Parse(Console.ReadLine());
                                    sa.WithdrawMoney(withdrawal);
                                    Console.WriteLine($"Added {withdrawal} into account {LoggedInCustomer.GetSavingsAccounts().First().AccountNumber} which makes it now have a total of {LoggedInCustomer.GetSavingsAccounts().First().AccountBalance}");
                                    Thread.Sleep(1500);
                                    //Vi kan lägga in pengar men värdena sparar inte i SavingsAccount som går att återhämta
                                    break;
                                case 3:
                                    //Name Change
                                    Console.WriteLine("\nThese are the names you can change");
                                    Console.WriteLine($"1. {LoggedInCustomer.FirstName}");
                                    Console.WriteLine($"2. {LoggedInCustomer.LastName}");
                                    Console.WriteLine($"0. Return to Menu");
                                    Console.Write("\nWhat is your choice? ");
                                    int inputchangename = int.Parse(Console.ReadLine());
                                    if (inputchangename == 1)
                                    {
                                        Console.Write("What do you wanna change your First Name to? ");
                                        string changefirstname = Console.ReadLine();
                                        LoggedInCustomer.ChangeCustomerFirstName(changefirstname);
                                        Console.WriteLine($"{LoggedInCustomer.FirstName}");
                                    }
                                    else if (inputchangename == 2)
                                    {
                                        Console.Write("What do you wanna change your Last Name to? ");
                                        string changelastname = Console.ReadLine();
                                        LoggedInCustomer.ChangeCustomerLastName(changelastname);
                                        Console.WriteLine($"{LoggedInCustomer.LastName}");
                                    }
                                    Thread.Sleep(3000);
                                    break;
                                case 4:
                                    //Create SavingsAccount
                                    LoggedInCustomer.CreateSavingsAccount();
                                    break;
                                case 5:
                                    //Remove SavingsAccount
                                    Console.Clear();
                                    Console.WriteLine("--Accounts--");
                                    foreach (var item in LoggedInCustomer.GetSavingsAccounts())
                                    {
                                        Console.WriteLine($"SavingsAccount: {item.AccountNumber} - Balance: {item.AccountBalance} - Type: {item.AccountType}");
                                    }
                                    Console.WriteLine($"0. Return to Menu");
                                    Console.Write("Which do you wanna remove? ");
                                    int removeAtIndex2 = int.Parse(Console.ReadLine());
                                    if (removeAtIndex2 != 0)
                                    {
                                        Console.WriteLine(BankLogic.RemoveSavingsAccount(LoggedInCustomer.SocialSecurityNumber, removeAtIndex2));
                                        Thread.Sleep(3000);
                                        Console.Clear();
                                    }
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                    break;
                                case 0:
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Clear();
                                    break;
                            }
                        }
                        Console.Clear();
                        //Creates users in a textfile
                        StreamWriter strm = File.CreateText("data.txt");
                        strm.Flush();
                        strm.Close();
                        if (!File.Exists(dataText))
                        {
                            using (File.Create(dataText))
                            {

                            }
                        }
                        using (StreamWriter sw = File.AppendText(dataText))
                        {
                            sw.Write("");
                            foreach (var item in ListCustomers)
                            {
                                sw.WriteLine(item);
                            }
                        }
                        break;
                    case 2:
                        //Create User
                        Console.WriteLine("-----------");
                        Console.WriteLine("Social Security Number: ");
                        int createUserSocialSecurityNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Firstname: ");
                        string createUserFirstName = Console.ReadLine();
                        Console.WriteLine("Lastname: ");
                        string createUserLastName = Console.ReadLine();
                        BankLogic.CreateCustomer(createUserSocialSecurityNumber, createUserFirstName, createUserLastName);
                        //BankLogic.GetAllSavingsAccounts().Add(new SavingsAccount(55000));
                        Console.Clear();
                        Console.WriteLine("--Users and their accounts--");
                        foreach (Customer i in BankLogic.GetCustomers())
                        {
                            int index = i.SocialSecurityNumber;
                            Console.WriteLine($"Social Number: {i.SocialSecurityNumber}  Name: {i.FirstName} {i.LastName}");
                            i.PrintSavingsAccounts();
                            Console.WriteLine("");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("--Users and their accounts--");
                        //prints our currently users and their accounts though method PrintSavingsAccounts();
                        foreach (Customer i in BankLogic.GetCustomers())
                        {
                            long index = i.SocialSecurityNumber;
                            Console.WriteLine($"Social Number: {i.SocialSecurityNumber}  Name: {i.FirstName} {i.LastName}");
                            i.PrintSavingsAccounts();
                            Console.WriteLine("");
                        }

                        Console.WriteLine($"0. Return to Menu");
                        Console.Write("Which do you wanna remove? ");
                        int removeAtIndex = int.Parse(Console.ReadLine());
                        if (removeAtIndex != 0)
                        {
                            foreach (string line in BankLogic.RemoveCustomer(removeAtIndex))
                            {
                                Console.WriteLine(line);
                            }
                            Thread.Sleep(1500);
                            Console.Clear();
                        }
                        break;
                    case 4:
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
