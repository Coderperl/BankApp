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
            int userInput = 0;
            string dataText = "data.txt";

            BankLogic.AddAccountsMetaData();

            //Loading our lists
            List<Customer> Customers = BankLogic.GetCustomers();
            List<SavingsAccount> SavingsAccounts = new List<SavingsAccount>();

            //Big while meny
            while (loggedIn == false)
            {
                Console.WriteLine("Choose one of the following options");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create User");
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
                            Customer LoggedIn = null;
                            foreach (Customer i in BankLogic.GetCustomers())
                            {
                                if (i.SocialSecurityNumber == inputSocialSecurityNumber)
                                {
                                    LoggedIn = i;
                                }
                            }
                            //Makes so you load SocialSecurityNumber instead of the index the users where input as
                            SavingsAccount sa = LoggedIn.GetSavingsAccounts().First();
                            Console.WriteLine($"Logging in as {LoggedIn.FullName}..");
                            Thread.Sleep(1500);
                            Console.Clear();
                            Console.WriteLine($"Social Number: {LoggedIn.SocialSecurityNumber}  Name: {LoggedIn.FullName}");
                            Console.WriteLine(sa.ShowAccount());
                            Console.WriteLine("");
                            //Shows the alternatives of your options of the account you have chosen.
                            Console.WriteLine("Manage Your Account");
                            Console.WriteLine("1. Make a Deposit\n2. Make a Withdrawal\n3. Change Name\n4. Close Bank Accounts\n0. Return to Menu");
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
                                    Console.WriteLine($"Added {deposit} into account {LoggedIn.GetSavingsAccounts().First().AccountNumber} which makes it now have a total of {LoggedIn.GetSavingsAccounts().First().AccountBalance}");
                                    Thread.Sleep(1500);
                                    break;
                                case 2:
                                    //Withdrawal
                                    Console.Write("How much do you wanna withdrawal? ");
                                    int withdrawal = int.Parse(Console.ReadLine());
                                    sa.WithdrawMoney(withdrawal);
                                    Console.WriteLine($"Added {withdrawal} into account {LoggedIn.GetSavingsAccounts().First().AccountNumber} which makes it now have a total of {LoggedIn.GetSavingsAccounts().First().AccountBalance}");
                                    Thread.Sleep(1500);
                                    //Vi kan lägga in pengar men värdena sparar inte i SavingsAccount som går att återhämta
                                    break;
                                case 3:
                                    //Name Change
                                    Console.WriteLine("\nThese are the names you can change");
                                    Console.WriteLine($"1.{LoggedIn.FirstName}");
                                    Console.WriteLine($"2.{LoggedIn.LastName}");
                                    Console.WriteLine($"0. Return to Menu");
                                    Console.Write("\nWhat is your choice? ");
                                    int inputchangename = int.Parse(Console.ReadLine());
                                    if (inputchangename == 1)
                                    {
                                        Console.Write("What do you wanna change your First Name to? ");
                                        string changefirstname = Console.ReadLine();
                                        //////////////////////////////////////////////////FUNKER EJ
                                        LoggedIn.ChangeCustomerFirstName(changefirstname);
                                        Console.WriteLine($"{LoggedIn.FirstName}");
                                    }
                                    else if (inputchangename == 2)
                                    {
                                        Console.Write("What do you wanna change your Last Name to? ");
                                        string changelastname = Console.ReadLine();
                                        //////////////////////////////////////////////////FUNKER EJ
                                        LoggedIn.ChangeCustomerLastName(changelastname);
                                        Console.WriteLine($"{LoggedIn.LastName}");
                                    }
                                    Thread.Sleep(1500);
                                    break;
                                case 4:
                                    //Close Account
                                    ///////////////////////////////////////////////////foreach som kollar 
                                    Console.WriteLine("\nThese are your currently bank accounts");
                                    Console.WriteLine("1. ??");
                                    Console.WriteLine("2. ??");
                                    Console.Write("\nWhich do you wanna close? ");
                                    int inputcloseaccount = int.Parse(Console.ReadLine());
                                    Console.WriteLine($"Closed your bank account with id {"??"} into account {LoggedIn.GetSavingsAccounts().First().AccountNumber} which makes it now have a total of {LoggedIn.GetSavingsAccounts().First().AccountBalance}\n");
                                    Thread.Sleep(1500);
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
                            foreach (var item in Customers)
                            {
                                sw.WriteLine(item);
                            }
                        }
                        break;
                    case 2:
                        //Create User
                        Console.WriteLine("-----------");
                        Console.WriteLine("Firstname: ");
                        string createUserFirstName = Console.ReadLine();
                        Console.WriteLine("Lastname: ");
                        string createUserLastName = Console.ReadLine();
                        Console.WriteLine("Social Security Number: ");
                        int createUserSocialSecurityNumber = int.Parse(Console.ReadLine());
                        BankLogic.GetCustomers().Add(new Customer(createUserFirstName, createUserLastName, createUserSocialSecurityNumber));
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
