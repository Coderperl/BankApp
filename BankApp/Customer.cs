using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{

    //Klassen Customer ska hantera följande information:
    //● Kundens namn
    //● Personnummer
    //● En lista med kundens alla konton

    //Man ska till exempel kunna ändra kundens namn samt hämta information
    //om kunden(personnummer, för- och efternamn samt hämta information om
    //kundens konton (kontonummer, saldo, kontotyp, räntesats)). Dessutom ska
    //man kunna hantera kundens konton.
    //Implementera metoder som säkerställer ovanstående krav i klassen
    //BankLogic nedan(BankLogic inkluderar förslag på metoder.Komplettera
    //dessa med fler metoder om det behövs).

    
    public class Customer 
    {

        public long SocialSecurityNumber { get; private set; }
        public string FullName => FirstName + " " + LastName;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<SavingsAccount> Accounts { get; set; }

        public List<SavingsAccount> GetListOfAccounts()
        {
            return Accounts;
        }

        public List<SavingsAccount> SavingsAccounts = new List<SavingsAccount>();
        public List<Customer> Customers = new List<Customer>();

        public Customer(string FirstName,
                        string LastName,
                        long SocialSecurityNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.SocialSecurityNumber = SocialSecurityNumber;
            this.Accounts = new();
        }

        public Customers(string FirstName,
                string LastName,
                long SocialSecurityNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.SocialSecurityNumber = SocialSecurityNumber;
            this.Accounts = new();
        }

        public void AddCustomer()
        {
            Customers.Add(new Customer("Rolf", "Svensson", 19900340 - 5436, new List<SavingsAccount>()));
            Customers.Add(new Customer("Carolin", "Eriksson", 19910740 - 5486, new List<SavingsAccount>()));
            Customers.Add(new Customer("Lisa", "Johansson", 19700340 - 6836, new List<SavingsAccount>()));
            Customers.Add(new Customer("Sandra", "Ekman", 19800890 - 5436, new List<SavingsAccount>()));
            Customers.Add(new Customer("Carl", "Larsson", 19550120 - 5439, new List<SavingsAccount>()));

        }

        public void ChangeCustomerName()
        {
            // Change string name in list
            //public List<string> GetCustomer(long pNr)
            //{
            //    //● Returnerar en List<string> som innehåller informationen om kunden inklusive dennes konton.
            //    //Första platsen i listan är förslagsvis reserverad för kundens namn och personnummer sedan följer
            //    //informationen om kundens konton.
            //}
        }

       
        public void AddSavingsAccount(long SocialSecurtyNumber)
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
           
            //● Skapa sparkonton till en befintlig kund, ett unikt kontonummer genereras
            //(första kontot får nummer 1001, nästa 1002 osv.)
        }

        //var newCustomer = new List<string>();

        //    ● Skapar upp en ny kund med namnet name samt personnumer pNr,
        //    kunden skapas endast om det
        //inte finns någon kund med personnummer pNr.Returnerar true om kund skapades annars
        //returneras false.



    }
}




