﻿using System;
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
        public List<SavingsAccount> Accounts { get; private set; }

        public List<SavingsAccount> GetListOfAccounts()
        {
            return Accounts;
        }
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
        public void AddSavingsAccount(long SocialSecurityNumber)
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

    }
}




