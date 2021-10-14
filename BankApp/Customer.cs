using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    //Constructor
    public class Customer
    {
        public int SocialSecurityNumber { get; private set; }
        public string FullName => FirstName + " " + LastName;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        //public List<SavingsAccount> SavingAccounts { get; private set; }
        List<SavingsAccount> ListSavingsAccounts = new List<SavingsAccount>();

        //Returns list of accounts
        public List<SavingsAccount> GetSavingsAccounts()
        {
            return ListSavingsAccounts;
        }
        
        //Customer gets firstName, LastName, Social Security Number and Account.
        public Customer(string FirstName,
                        string LastName,
                        int SocialSecurityNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.SocialSecurityNumber = SocialSecurityNumber;
            CreateSavingsAccount();
        }

        public void PrintSavingsAccounts()
        {
            foreach (var i in ListSavingsAccounts)
            {
                Console.WriteLine(i);
            }
        }
        //public void ChangeCustomerName(int SocialSecurityNumber, string newName)
        //{
        //    foreach (Customer cust in Customers)
        //    {
        //        if (cust.SocialSecurityNumber == SocialSecurityNumber)
        //        {
        //            cust.FirstName = newName;
        //        }
        //    }
        //}

        ////If Social Security Number Matches with Customer it changes his/her name.
        //public void ChangeCustomerName(int SocialSecurityNumber, string newName, string newLastName)

        //{
        //    foreach (Customer cust in Customers)
        //    {
        //        if (cust.SocialSecurityNumber == SocialSecurityNumber)
        //        {
        //            cust.FirstName = newName;
        //            cust.LastName = newLastName;
        //        }
        //    }
        //}
        public void ChangeCustomerFirstName(string newFirstName)
        {
            FirstName = newFirstName;
        }
        public void ChangeCustomerLastName(string newLastName)
        {
            LastName = newLastName;
        }

        //Adds new Account to Customer by using Social Security Number (person Nummer) Gives every new account a new Account Number.
        //public void AddSavingsAccount()
        //{
        //    if (GetSavingsAccounts().Count == 0)
        //    {
        //        GetSavingsAccounts().Add(new SavingsAccount(3300));
        //    }
        //    else
        //    {
        //        int tempId = GetSavingsAccounts().Last().AccountNumber;
        //        GetSavingsAccounts().Add(new SavingsAccount(++tempId));
        //    }
        //}
        public void CreateSavingsAccount()
        {
            if (GetSavingsAccounts().Count == 0)
            {
                ListSavingsAccounts.Add(new SavingsAccount(3300));
            }
            else
            {
                int tempId = GetSavingsAccounts().Last().AccountNumber;
                ListSavingsAccounts.Add(new SavingsAccount(++tempId));
            }
        }


    }

}


