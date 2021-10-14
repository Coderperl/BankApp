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

        List<Customer> ListCustomers = new List<Customer>();
        //List<SavingsAccount> ListSavingsAccounts = new List<SavingsAccount>();


        // public void PrintCustomers()
        // The method prints all the values for Customers, in the list of customers.
        public void PrintCustomers()
        {
            foreach (var i in ListCustomers)
            {
                Console.WriteLine(i);
            }
        }

        // public List<string> GetCustomer(long pNr)
        // This method fetches a customer from the list of Customers together with the values it has of its account. 
        public List<string> GetCustomer(int pNr)
        {
            Customer c = null;
            List<string> returnList = new();
            foreach (var customer in ListCustomers)
            {
                if (pNr == customer.SocialSecurityNumber)
                {
                    c = customer; // If the pNr is the same as the customers SocialSecurityNumber, customer c is created. 
                }
            }
            if (c != null) // If customer c does not exist in the returnList, it adds the FullName of customer, and its socialSecurityNumber.
            {
                returnList.Add($"{c.FullName} {c.SocialSecurityNumber}");
                foreach (SavingsAccount account in c.GetSavingsAccounts())
                {
                    returnList.Add(account.ShowAccount()); // after customer c gets its string values, it adds an account to the returnList.
                }
            }
            return returnList; // this shows the account on the console.
        }

        // public List<Customer> GetAllCustomers()
        // This method gets the list of customers, so it can be initialized in other methods. 
        public List<Customer> GetCustomers()
        {
            return ListCustomers;
        }

        // public void AddCustomer()
        // This method adds metadata to the list of customers, it adds the values to the following parameters (FirstName, LastName and SocialSecuritynumber. 
        public void AddCustomer()
        {
            ListCustomers.Add(new Customer("Rolf", "Svensson", 19900340));
            ListCustomers.Add(new Customer("Carolin", "Eriksson", 19910740));
            ListCustomers.Add(new Customer("Lisa", "Johansson", 19700340));
            ListCustomers.Add(new Customer("Sandra", "Ekman", 19800810));
            ListCustomers.Add(new Customer("Carl", "Larsson", 19550120));
        }
        public void CreateCustomer(int createSocialSecurityNumber, string createFirstName, string createLastName)
        {
            ListCustomers.Add(new Customer(createFirstName, createLastName, createSocialSecurityNumber));
        }
        // public List<string> RemoveCustomer(long pNr)
        // This method removes a designated customer from the list of customer.
        public List<string> RemoveCustomer(long pNr)
        {
            Customer c = null;
            List<string> returnList = new();
            foreach (var customer in ListCustomers)
            {
                if (pNr == customer.SocialSecurityNumber)
                {
                    c = customer;// If the pNr is the same as the customers SocialSecurityNumber, customer c is created. 
                }
            }
            if (c != null)// If customer c does not exist in the returnList, it adds the FullName of customer, and its socialSecurityNumber.
            {
                returnList.Add($"Social Number: {c.SocialSecurityNumber} - Name: {c.FullName}");
                foreach (SavingsAccount account in c.GetSavingsAccounts())
                {
                    returnList.Add(account.ShowAccount());
                }
                decimal sum = 0;
                decimal interestSum = 0;
                foreach (SavingsAccount account in c.GetSavingsAccounts())
                {
                    sum = sum + account.Balance(); // it shows the sum of the balance of the accounts.
                    interestSum = interestSum + account.CalculateInterest(); // it calculates the interest sum of the total balance of its accounts. 
                }
                string sumString = $"My total balance is: {sum}";
                string interestString = $"My total interest is: {interestSum}";
                returnList.Add(sumString);
                returnList.Add(interestString);
                c.GetSavingsAccounts().Clear(); // After it has showed the stringvalues to the list, it then removes the customer from the returnlist.
                GetCustomers().Remove(c);
            }
            return returnList;
        }
        // public void PrintAccounts()
        // This method prints the account for the list of customers. 
        public void PrintAccounts()
        {
            foreach (Customer cust in ListCustomers)
            {
                foreach (SavingsAccount account in cust.GetSavingsAccounts())
                {
                    Console.WriteLine(account.ShowAccount());
                }
            }
        }

        //Finds an account with Account Number and Closes the Account, Prints out the remaining amount and interest.
        public string RemoveSavingsAccount(int SearchResult, int AccountNumber)
        {
            Customer c = null;
            foreach (Customer customer in GetCustomers())
            {
                if (customer.SocialSecurityNumber == SearchResult) // Finds the customer whos account you want to remove.  
                {
                    c = customer;
                }
            }
            foreach (SavingsAccount Account in c.GetSavingsAccounts())
            {
                if (Account.AccountNumber == AccountNumber)
                {
                    string s = Account.ShowAccount(); // shows the Account Number, the Account Type, and the total calculated interest of the balance.    
                    c.GetSavingsAccounts().Remove(Account);// This removes the account.
                    return s;
                }
            }
            return null;
        }

        //Createing the MockData for the accounts on launch
        public void AddAccountsMetaData()
        {
            foreach (var Customer in GetCustomers())
            {
               
            }
            
        }
    }
}

