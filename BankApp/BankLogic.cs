using System;
using System.Collections.Generic;


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
            AddCustomer();
            PrintCustomers();
            GetAllCustomers();
            
        }

        List<Customer> Customers = new List<Customer>();
        public void PrintCustomers()
        {
            foreach (var i in Customers)
            {
                Console.WriteLine(i);
            }
        }
        public List<Customer> GetAllCustomers()
        {
            return Customers;
        }
        public void AddCustomer()
        {
            Customers.Add(new Customer("Rolf", "Svensson", 19900340));
            Customers.Add(new Customer("Carolin", "Eriksson", 19910740));
            Customers.Add(new Customer("Lisa", "Johansson", 19700340));
            Customers.Add(new Customer("Sandra", "Ekman", 19800810));
            Customers.Add(new Customer("Carl", "Larsson", 19550120));
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
            //    //● Tar bort kund med personnummer pNr ur banken, alla kundens eventuella konton tas också bort
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
                foreach (SavingsAccount account in c.GetListOfAccounts())
                {
                    returnList.Add(account.ShowAccount()); 
                }
                decimal sum = 0;
                decimal interestSum = 0;

                foreach (SavingsAccount account in c.GetListOfAccounts())
                {
                    sum = sum + account.Balance();
                    interestSum = interestSum + account.CalculateInterest(); 
                }
                string sumString = $"My total sum is : {sum}.";
                string interestString = $"My total interest is : {interestSum}.";

                returnList.Add(sumString);
                returnList.Add(interestString);
                c.GetListOfAccounts().Clear();
            }

            return returnList;
            
        }

    }
  
}