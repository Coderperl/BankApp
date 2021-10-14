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
            string dataText = "data.txt";

            BankLogic.AddAccountsMetaData();

            //Loading our lists
            List<Customer> Customers = BankLogic.GetAllCustomers();
            List<SavingsAccount> SavingsAccounts = new List<SavingsAccount>();

            //Big while meny
            while (loggedIn == false)
            {
                Console.WriteLine("Choose one of the following options");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create User");
                Console.WriteLine("3. XML Test");
                Console.WriteLine("4. Exit");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--Users and their accounts--");
                        //prints our currently users and their accounts though method PrintSavingsAccounts();
                        foreach (Customer i in BankLogic.GetAllCustomers())
                        {
                            long index = i.SocialSecurityNumber;
                            Console.WriteLine($"Social Number: {i.SocialSecurityNumber}  Name: {i.FirstName} {i.LastName}");
                            i.PrintSavingsAccounts();
                            Console.WriteLine("");
                        }
                        //What user you wanna login as
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
                        //Makes so you load SocialSecurityNumber instead of the index the users where input as
                        SavingsAccount sa = LoggedIn.GetListOfAccounts().First();
                        Console.WriteLine($"Logging in as {LoggedIn.FullName}..");
                        Thread.Sleep(1500);
                        Console.Clear();
                        Console.WriteLine($"Social Number: {LoggedIn.SocialSecurityNumber}  Name: {LoggedIn.FullName}");
                        Console.WriteLine(sa.ShowAccount());
                        Console.WriteLine("");
                        //Shows the alternatives of your options of the account you have chosen.
                        Console.WriteLine("Manage Your Account");
                        Console.WriteLine("1. Make a Deposit\n2. Make a Withdrawal\n3. Change Name\n4. Close Bank Accounts\n5. Return to Menu");
                        Console.Write("\nWhat is your choice? ");
                        userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            //Actual account choices meny
                            case "1":
                                //Deposit
                                Console.Write("How much do you wanna deposit? ");
                                int deposit = int.Parse(Console.ReadLine());
                                sa.DepositMoney(deposit);
                                Thread.Sleep(1500);
                                Console.Clear();
                                Console.WriteLine($"Added {deposit} into account {LoggedIn.GetListOfAccounts().First().AccountNumber} which makes it now have a total of {LoggedIn.GetListOfAccounts().First().AccountBalance}\n");
                                break;
                            case "2":
                                //Withdrawal
                                Console.Write("How much do you wanna withdrawal? ");
                                int withdrawal = int.Parse(Console.ReadLine());
                                sa.WithdrawMoney(withdrawal);
                                Thread.Sleep(1500);
                                Console.Clear();
                                Console.WriteLine($"Added {withdrawal} into account {LoggedIn.GetListOfAccounts().First().AccountNumber} which makes it now have a total of {LoggedIn.GetListOfAccounts().First().AccountBalance}\n");
                                //Vi kan lägga in pengar men värdena sparar inte i SavingsAccount som går att återhämta
                                break;
                            case "3":
                                //Name Change
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
                                //Close Account
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
                        //Creates users in a textfile
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
                    case "2":
                        //Create User
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
                        string testIndex = Console.ReadLine();
                        if (testIndex == "1")
                        {
                            /////////////////////////////////////////////
                            //Testing loading addToFileCustomers from XML file
                            var addToFileCustomers = new XElement("Customers",
                                                     new XElement("Customer",
                                                        new XElement("SocialSecurityNumber", "252525"),
                                                        new XElement("FirstName", "Philip1"),
                                                        new XElement("LastName", "Hero1"),
                                                        new XElement("FullName", "Philip1 Hero1")),
                                                     new XElement("Customer",
                                                        new XElement("SocialSecurityNumber", "2525251"),
                                                        new XElement("FirstName", "Philip2"),
                                                        new XElement("LastName", "Hero2"),
                                                        new XElement("FullName", "Philip2 Hero2")),
                                                     new XElement("Customer",
                                                        new XElement("SocialSecurityNumber", "2525252"),
                                                        new XElement("FirstName", "Philip3"),
                                                        new XElement("LastName", "Hero3"),
                                                        new XElement("FullName", "Philip3 Hero3")),
                                                     new XElement("Customer",
                                                        new XElement("SocialSecurityNumber", "2525253"),
                                                        new XElement("FirstName", "Philip4"),
                                                        new XElement("LastName", "Hero4"),
                                                        new XElement("FullName", "Philip4 Hero4")));

                            File.WriteAllText(@"C:\Users\PhilipHero\Source\Repos\BankApp2\BankApp\Customers.xml", addToFileCustomers.ToString());

                            /////////////////////////////////////////////
                            //Testing loading savingsAccountsData from XML file
                            var addToFileSavingsAccounts = new XElement("SavingsAccounts",
                                         new XElement("SavingsAccount",
                                            new XElement("AccountNumber", 1000),
                                            new XElement("AccountType", "Saving Account"),
                                            new XElement("AccountBalance", 100),
                                            new XElement("Interest", 1)),
                                         new XElement("SavingsAccount",
                                            new XElement("AccountNumber", 1001),
                                            new XElement("AccountType", "Saving Account"),
                                            new XElement("AccountBalance", 100),
                                            new XElement("Interest", 1)),
                                         new XElement("SavingsAccount",
                                            new XElement("AccountNumber", 1001),
                                            new XElement("AccountType", "Saving Account"),
                                            new XElement("AccountBalance", 100),
                                            new XElement("Interest", 1)),
                                         new XElement("SavingsAccount",
                                            new XElement("AccountNumber", 1002),
                                            new XElement("AccountType", "Saving Account"),
                                            new XElement("AccountBalance", 100),
                                            new XElement("Interest", 1)));

                            File.WriteAllText(@"C:\Users\PhilipHero\Source\Repos\BankApp2\BankApp\SavingsAccounts.xml", addToFileSavingsAccounts.ToString());

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
                                    Console.WriteLine($"SocialSecurityNumber: {item.Value}\n");
                                }
                            }
                            /////////////////////////////////////////////
                            //Testing loading savingsAccountsData from XML file
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
                                    Console.WriteLine($"AccountNumber: {item.Value}\n");
                                }
                            }
                        }
                        break;
                    case "4":
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
