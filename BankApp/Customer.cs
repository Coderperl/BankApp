using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    //Klassen Customer ska hantera följande information:
    //? Kundens namn
    //? Personnummer
    //? En lista med kundens alla konton

    //Man ska till exempel kunna ändra kundens namn samt hämta information
    //om kunden(personnummer, för- och efternamn samt hämta information om
    //kundens konton (kontonummer, saldo, kontotyp, räntesats)). Dessutom ska
    //man kunna hantera kundens konton.
    //Implementera metoder som säkerställer ovanstående krav i klassen
    //BankLogic nedan(BankLogic inkluderar förslag på metoder.Komplettera
    //dessa med fler metoder om det behövs).

    public class Customer
    {
        public int SocialSecurityNumber { get; private set; }
        public string FullName => FirstName + " " + LastName;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        //public List<SavingsAccount> SavingAccounts { get; private set; }
        List<SavingsAccount> SavingsAccounts = new List<SavingsAccount>();

        public List<SavingsAccount> GetListOfAccounts()
        {
            return SavingsAccounts;
        }

        public List<Customer> Customers = new List<Customer>();

        public Customer(
            int socialSecurityNumber,
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }
        public void PrintSavingsAccounts()
        {
            foreach (var i in SavingsAccounts)
            {
                Console.WriteLine(i);
            }
        }
        public void ChangeCustomerName(long SocialSecurityNumber, string newName)
        {
            foreach (Customer cust in Customers)
            {
                if (cust.SocialSecurityNumber == SocialSecurityNumber)
                {
                    cust.FirstName = newName;
                }
            }
        }

        public void AddSavingsAccount(int SocialSecurityNumber)
        {
            if (GetListOfAccounts().Count == 0)
            {

                int tempId = 1000;
                GetListOfAccounts().Add(new SavingsAccount(++tempId, SocialSecurityNumber, 0, "hej", 1));
                //Console.WriteLine($"TEST TEST {SocialSecurityNumber}");
            }
            else
            {
                int tempId = GetListOfAccounts().Last().AccountNumber;
                GetListOfAccounts().Add(new SavingsAccount(++tempId, SocialSecurityNumber, 0, "Saving Account", 1));
                //Console.WriteLine($"TEST TEST {SocialSecurityNumber}");
            }
        }


    }
}




