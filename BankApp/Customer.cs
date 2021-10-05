using System.Collections.Generic;

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

        public long SocialSecurityNumber { get; }
        private string firstName;
        public List<SavingsAccount> Accounts { get; set; }

        public string FullName => FirstName + " " + LastName;
        public string FirstName { get; set; }
        public string LastName { get; set; }




        public static List<SavingsAccount> GetListOfAccounts()
        {
            return listOfAccounts;
        }
        public string FullName => GetFirstName() + " " + GetLastName();
        
        public string GetFirstName()
        {
            return firstName;
        }
        public void SetFirstName(string value)
        {
            firstName = value;
        }
        public string GetLastName()
        {
            return lastname;
        }
        public void SetLastName(string value)
        {
            lastname = value;
        }
        public Customer(string FirstName, string LastName, long SocialSecurityNumber)
        {
            this.SetFirstName(FirstName);
            this.SetLastName(LastName);
            this.SocialSecurityNumber = SocialSecurityNumber;
            listOfAccounts = new();
        }
        public List<string> PrintAccounts()
        {
            List<string> tempList = new();
            foreach (var account in GetListOfAccounts())
            {
                tempList.Add(account.ShowAccount());
            }
            return tempList;
        }
    }
}




