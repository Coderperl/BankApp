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

        // public void PrintSavingsAccounts()
        // This method Prints the savingsAccount.
        public void PrintSavingsAccounts()
        {
            foreach (var i in ListSavingsAccounts)
            {
                Console.WriteLine(i);
            }
        }

        //public void ChangeCustomerFirstName(string newFirstName)
        // This changes the firstname of the customer.
        public void ChangeCustomerFirstName(string newFirstName)
        {
            FirstName = newFirstName;
        }
        //public void ChangeCustomerLastName (string newLastName)
        // This changes the LastName of the customer.
        public void ChangeCustomerLastName(string newLastName)
        {
            LastName = newLastName;
        }

        // This creates the savingsaccount for the list of customers. 
        public void CreateSavingsAccount()
        {
            if (GetSavingsAccounts().Count == 0)
            {
                ListSavingsAccounts.Add(new SavingsAccount(3300)); //Our bank has the accountnumbers baset on the Nordea Clearing Number. 
            }
            else
            {
                int tempId = GetSavingsAccounts().Last().AccountNumber;
                ListSavingsAccounts.Add(new SavingsAccount(++tempId)); // This adds +1 on 3300, to the next created savingsaccount. 
            }
        }

    }

}


