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

    //public static bool AddCustomer(string name, long pNr)
    //{
    //    ● Skapar upp en ny kund med namnet name samt personnumer pNr, kunden skapas endast om det
    //inte finns någon kund med personnummer pNr.Returnerar true om kund skapades annars
    //returneras false.

    //var newCustomer = new List<string>();
    public class Customer : BankLogic
    {

        public long SocialSecurityNumber { get; private set; }
        public string FullName => FirstName + " " + LastName;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private List<SavingsAccount> Accounts { get; set; }
        




        public List<SavingsAccount> GetListOfAccounts()
        {
            return Accounts;
        }

        public Customer(string FirstName,
                        string LastName,
                        long SocialSecurityNumber)

        {

            this.FirstName = FirstName;
            this.LastName = LastName;
            this.SocialSecurityNumber = SocialSecurityNumber;
            Accounts = new();

        }

        //public int AddSavingsAccount(long pNr)
        //● Skapar ett konto till kund med personnummer pNr, returnerar kontonumret som det skapade kontot
        //fick alternativt returneras –1 om inget konto skapades.

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

            //Man ska till exempel kunna ändra kundens namn samt hämta information
            //om kunden(personnummer, för- och efternamn samt hämta information om
            //kundens konton (kontonummer, saldo, kontotyp, räntesats)). Dessutom ska
            //man kunna hantera kundens konton.
            //Implementera metoder som säkerställer ovanstående krav i klassen
            //BankLogic nedan(BankLogic inkluderar förslag på metoder.Komplettera
            //dessa med fler metoder om det behövs).

            
        }


       
        //    ● Skapar upp en ny kund med namnet name samt personnumer pNr,
        //    kunden skapas endast om det
        //inte finns någon kund med personnummer pNr.Returnerar true om kund skapades annars
        //returneras false.

            //var newCustomer = new List<string>();

       
    }
}




