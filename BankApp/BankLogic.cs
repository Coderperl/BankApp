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

        List<Customer> Customers = new List<Customer>();
        public void PrintCustomers()
        {
            foreach (var i in Customers)
            {
                Console.WriteLine(i);
            }
        }
        public void AddCustomer()
        {
            Customers.Add(new Customer("Rolf", "Svensson", 19900340 - 5436));
            Customers.Add(new Customer("Carolin", "Eriksson", 19910740 - 5486));
            Customers.Add(new Customer("Lisa", "Johansson", 19700340 - 6836));
            Customers.Add(new Customer("Sandra", "Ekman", 19800890 - 5436));
            Customers.Add(new Customer("Carl", "Larsson", 19550120 - 5439));
        }
        public void GetCustomer(List<string> Customer)
        {
            foreach (Customer cust in Customers)
            {
                Console.WriteLine(Customers.Count);
            }
        }
        public void RemoveCustomer(long pNr, List<string> Customer)
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
                foreach (SavingsAccount account in c.GetListOfAccounts())
                {
                    returnList.Add(account.ShowAccount());
                }
                
            }

        }

    }
  
}