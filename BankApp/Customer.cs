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

        public long SocialSecurityNumber { get; private set; }
        private string firstName;
        public static List<SavingsAccount> Accounts { get; private set; }

        public string FullName => FirstName + " " + LastName;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }




        public static List<SavingsAccount> GetListOfAccounts()
        {
            return Accounts;
        }
        
        public Customer(string FirstName, string LastName, long SocialSecurityNumber)
        {
            this.FirstName  = FirstName;
            this.LastName = LastName;
            this.SocialSecurityNumber = SocialSecurityNumber;
            Accounts.Add(new SavingsAccount(123));
        }

        //Denna behövs inte
        //public List<string> PrintAccounts()
        //{
        //    List<string> tempList = new();
        //    foreach (var account in GetListOfAccounts())
        //    {
        //        tempList.Add(account.ShowAccount());
        //    }
        //    return tempList;
        //}

        public void AddSavingsAccount()
        {
            //Random som skapar kontonummer

            //For-loopar som kollar att kontunumret inte existerar
            //Enklast är att köra en while-loop som loopar så länge kontonumret existerar
            //Se pseudokod under

            //While

            //For i < längd på list
            //If Accnumber == list[index].Accnumber
            //Sätt validKonto bool falsk
            //Breaka ur loopen

            //Else
            //Sätt validKonto som true och fortsätt loopa


            //If validKonto = falskt: Generera nytt accountnumber och försök igen

            //Annars: Lägg till nytt sparkonto
        }
        public override string ToString()
        {
            return string.Format($"");
        }
    }
}




