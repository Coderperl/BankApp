using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
   

    public class BankLogic
    {
        // public BankLogic() 
        // This is our constructor for the class Banklogic. When the Console App starts, it automatically creates a list of customers.
        public BankLogic()
        {
            AddCustomer();
            
        }

        List<Customer> Customers = new List<Customer>();
        
        // public void PrintCustomers()
        // The method prints all the values for Customers, in the list of customers.
        public void PrintCustomers()
        {
            foreach (var i in Customers)
            {
                Console.WriteLine(i);
            }
        }
        // public List<Customer> GetAllCustomers()
        // This method gets the list of customers, so it can be initialized in other methods. 
        public List<Customer> GetAllCustomers()
        {
            return Customers;
        }

        // public void AddCustomer()
        // This method adds metadata to the list of customers, it adds the values to the following parameters (FirstName, LastName and SocialSecuritynumber. 
        public void AddCustomer()
        {
            Customers.Add(new Customer("Rolf", "Svensson", 19900340));
            Customers.Add(new Customer("Carolin", "Eriksson", 19910740));
            Customers.Add(new Customer("Lisa", "Johansson", 19700340));
            Customers.Add(new Customer("Sandra", "Ekman", 19800810));
            Customers.Add(new Customer("Carl", "Larsson", 19550120));
        }

        // public List<string> GetCustomer(long pNr)
        // This method fetches a customer from the list of Customers together with the values it has of its account. 
        public List<string> GetCustomer(int pNr)
        {
            Customer c = null;
            List<string> returnList = new();
            foreach (var customer in Customers)
            {
                if (pNr == customer.SocialSecurityNumber)
                {
                    c = customer; // If the pNr is the same as the customers SocialSecurityNumber, customer c is created. 
                }
            }

            if (c != null) // If customer c does not exist in the returnList, it adds the FullName of customer, and its socialSecurityNumber.
            {
                returnList.Add($"{c.FullName} {c.SocialSecurityNumber}");
                foreach (SavingsAccount account in c.GetListOfAccounts())
                {
                    returnList.Add(account.ShowAccount()); // after customer c gets its string values, it adds an account to the returnList.
                }
            }
            return returnList; // this shows the account on the console.
        }

        // public List<string> RemoveCustomer(long pNr)
        // This method removes a customer from the BankApp, all its accounts and then returns a list of information, which contains
        // the accounts that were removed, the balance of the account, and calculates the interest of the total balance of the account. 
        public List<string> RemoveCustomer(long pNr)
        {
            Customer c = null;
            List<string> returnList = new();
            foreach (var customer in Customers)
            {
                if (pNr == customer.SocialSecurityNumber)
                {
                    c = customer;// If the pNr is the same as the customers SocialSecurityNumber, customer c is created. 
                }
            }

            if (c != null)// If customer c does not exist in the returnList, it adds the FullName of customer, and its socialSecurityNumber.
            {

                returnList.Add($"{c.FullName} {c.SocialSecurityNumber}");
                foreach (SavingsAccount account in c.GetListOfAccounts())
                {
                    returnList.Add(account.ShowAccount());
                }
                decimal sum = 0;
                decimal interestSum = 0;
                foreach (SavingsAccount account in c.GetListOfAccounts())
                {
                    sum = sum + account.Balance(); // it shows the sum of the balance of the accounts.
                    interestSum = interestSum + account.CalculateInterest(); // it calculates the interest sum of the total balance of its accounts. 
                }
                string sumString = $"My total sum is : {sum}.";
                string interestString = $"My total interest is : {interestSum}.";

                returnList.Add(sumString);
                returnList.Add(interestString);
                c.GetListOfAccounts().Clear(); // After it has showed the stringvalues to the list, it then removes the customer from the returnlist. 
            }
            return returnList;
        }
        // public string CloseAccount(long pNr, int AccountNumber, Customer customer)
        // This method closes an account to a specific customer. 
        public List<string> CloseAccount(Customer customer, int AccountNumber)
        {
            return customer.CloseAccount(AccountNumber);

        }
        public void PrintAccounts()
        {
            foreach (Customer cust in Customers)
            {
                foreach (SavingsAccount account in cust.GetListOfAccounts())
                {
                    Console.WriteLine(account.ShowAccount());
                }
            }
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

    }
}

