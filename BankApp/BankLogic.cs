using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    //    BankLogic
    //Klassen BankLogic ska innehålla en lista med alla inlagda kunder.Klassen
    //ska innehålla ett antal publika metoder som hanterar kunder och dess
    //konton(se ovan). Du kommer troligtvis att skapa ett antal hjälpmetoder,
    //privata metoder, men de publika metoderna som ska finnas i BankLogic är
    //följande:

    public class BankLogic
    {


        public BankLogic()
        {
            AddCustomersMetaData();
            AddAccountsMetaData();

            //PrintCustomers();
            //GetAllCustomers();
        }
        List<Customer> Customers = new List<Customer>();
        List<SavingsAccount> SavingsAccounts = new List<SavingsAccount>();
        public int CreateAccNum()
        {

            //foreach (var cust in Customers)
            //{
            //    foreach (var acc in cust.GetListOfAccounts())
            //    {
            //        SavingsAccounts.Add(acc);
            //    }
            //}

            var lastAcc = SavingsAccounts.Last();
            return lastAcc.AccountNumber;

        }
        public void PrintCustomers()
        {
            foreach (var i in Customers)
            {
                Console.WriteLine(i);
            }
        }
        public void PrintAccounts()
        {
            foreach (var i in SavingsAccounts)
            {
                Console.WriteLine(i);
            }
        }
        public List<Customer> GetAllCustomers()
        {
            return Customers;
        }
        public List<SavingsAccount> GetAllAccounts()
        {
            return SavingsAccounts;
        }

        public void AddCustomersMetaData()
        {
            Customers.Add(new Customer(0, "Rolf", "Svensson"));
            Customers.Add(new Customer(19910740, "Carolin", "Eriksson"));
            Customers.Add(new Customer(19700340, "Lisa", "Johansson"));
            Customers.Add(new Customer(19800810, "Sandra", "Ekman"));
            Customers.Add(new Customer(19550120, "Carl", "Larsson"));
        }
        public void AddAccountsMetaData()
        {
            foreach (var Customer in GetAllCustomers())
            {
                Customer.AddSavingsAccount();
            }

            //SavingsAccounts.Add(new SavingsAccount(1000, 0, 9999999, "ADMIN KONTO", 1));
            //SavingsAccounts.Add(new SavingsAccount(1001, 19910740, 0, "Saving Account Metadata", 1));
            //SavingsAccounts.Add(new SavingsAccount(1002, 19700340, 0, "Saving Account Metadata", 1));
            //SavingsAccounts.Add(new SavingsAccount(1003, 19800810, 0, "Saving Account Metadata", 1));
            //SavingsAccounts.Add(new SavingsAccount(1004, 19550120, 0, "Saving Account Metadata", 1));
        }
        public List<string> GetCustomer(long pNr)
        {
            Customer c = null;
            List<string> returnList = new();
            foreach (var customer in Customers)
            {
                if (pNr == customer.SocialSecurityNumber)
                {
                    c = customer;
                }
            }

            if (c != null)
            {
                returnList.Add($"{c.FullName} {c.SocialSecurityNumber}");
                foreach (SavingsAccount account in c.GetListOfAccounts())
                {
                    returnList.Add(account.ShowAccount());
                }
            }
            return returnList;
        }

        public List<string> RemoveCustomer(long pNr)
        {
            //    //? Tar bort kund med personnummer pNr ur banken, alla kundens eventuella konton tas också bort
            //    //och resultatet returneras.Listan som returneras ska innehålla information om alla konton som togs
            //    //bort, saldot som kunden får tillbaka samt vad räntan blev.
            Customer c = null;
            List<string> returnList = new();
            foreach (var customer in Customers)
            {
                if (pNr == customer.SocialSecurityNumber)
                {
                    c = customer;
                }
            }

            if (c != null)
            {
                returnList.Add($"{c.FullName} {c.SocialSecurityNumber}");
                foreach (SavingsAccount AccountNumber in c.GetListOfAccounts())
                {
                    returnList.Add(AccountNumber.ShowAccount());
                }
                decimal sum = 0;
                decimal interestSum = 0;
                foreach (SavingsAccount AccountNumber in c.GetListOfAccounts())
                {
                    sum = sum + AccountNumber.AccountBalance;
                    interestSum = interestSum + AccountNumber.CalculateInterest();
                }
                //string sumString = $"My total sum is : {sum}.";
                //string interestString = $"My total interest is : {interestSum}.";

                //returnList.Add(sumString);
                //returnList.Add(interestString);
                c.GetListOfAccounts().Clear();
            }
            return returnList;
        }
    }
}