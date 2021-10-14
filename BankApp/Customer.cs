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
        List<SavingsAccount> SavingsAccounts = new List<SavingsAccount>();

        //Returns list of accounts
        public List<SavingsAccount> GetListOfAccounts()
        {
            return SavingsAccounts;
        }

        //Adds new Customer to Customers list
        public List<Customer> Customers = new List<Customer>();
        
        //Customer gets firstName, LastName, Social Security Number and Account.
        public Customer(string FirstName,
                        string LastName,
                        int SocialSecurityNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.SocialSecurityNumber = SocialSecurityNumber;
        }
        public void PrintSavingsAccounts()
        {
            foreach (var i in SavingsAccounts)
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
            foreach (Customer cust in Customers)
            {
                if (cust.SocialSecurityNumber == SocialSecurityNumber)
                {
                    cust.FirstName = newFirstName;
                }
            }
        }
        public void ChangeCustomerLastName(string newLastName)
        {
            foreach (Customer cust in Customers)
            {
                if (cust.SocialSecurityNumber == SocialSecurityNumber)
                {
                    cust.FirstName = newLastName;
                }
            }
        }

        //Adds new Account to Customer by using Social Security Number (person Nummer) Gives every new account a new Account Number.
        public void AddSavingsAccount()
        {
            if (GetListOfAccounts().Count == 0)
            {
                GetListOfAccounts().Add(new SavingsAccount(1001));
            }
            else
            {
                int tempId = GetListOfAccounts().Last().AccountNumber;
                GetListOfAccounts().Add(new SavingsAccount(++tempId));
            }
        }
        //Finds a account with Account Number and Closes the Account, Prints out the remaining amount and interest.
        public List<string> CloseAccount(int AccountNumber)
        {
            foreach (var item in SavingsAccounts)
            {
                if (item.AccountNumber == AccountNumber)
                {
                    List<string> ClosedAccount = new List<string>();
                    ClosedAccount.Add($"{item.ShowAccount()}");
                    SavingsAccounts.Remove(item);
                    //ClosedAccount[0] för saldo
                    //ClosedAccount[1] för ränta
                    return ClosedAccount;
                }
            }
            return null;
        }
    }

}


