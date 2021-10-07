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

    }
    //static List<string> GetCustomers()
    //{
    //    // Foreach customer in List
    //    //● Returnerar en List<string> som innehåller en presentation av bankens alla kunder(personnummer
    //    //och namn)
    //}

   
    
   
    ////Klassdesign

    //public bool ChangeCustomerName(String name, long pNr)
    //{
    //    //● Byter namn på kund med personnummer pNr till name, returnerar true om namnet ändrades annars
    //    //returnerar false(om kunden inte fanns).
    //}

    //public List<string> RemoveCustomer(long pNr)
    //{
    //    //● Tar bort kund med personnummer pNr ur banken, alla kundens eventuella konton tas också bort
    //    //och resultatet returneras.Listan som returneras ska innehålla information om alla konton som togs
    //    //bort, saldot som kunden får tillbaka samt vad räntan blev.
    //}


    //public static string GetAccount(long pNr, int accountId)
    //{
    //    //    ● Returnerar en String som innehåller presentation av kontot med kontonummer accountId som tillhör
    //    //kunden pNr(kontonummer, saldo, kontotyp, räntesats).
    //}




    ////Klassdesign

    //public string CloseAccount(long pNr, int accountId)
    //{
    //    //● Stänger ett konto med kontonummer accountId som tillhör kunden pNr, presentation av kontots
    //    //saldo samt ränta på pengarna ska genereras.
    //}
}