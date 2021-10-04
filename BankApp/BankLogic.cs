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


    class BankLogic
    {
        public static void Main(string[] args)
        {

            public List<string> GetCustomers()
            {
                //● Returnerar en List<string> som innehåller en presentation av bankens alla kunder(personnummer
                //och namn)
            }


            public bool AddCustomer(string name, long pNr)
            {
                //    ● Skapar upp en ny kund med namnet name samt personnumer pNr, kunden skapas endast om det
                //inte finns någon kund med personnummer pNr.Returnerar true om kund skapades annars
                //returneras false.

                

                Console.WriteLine("Please enter your Firstname. ");
                string firstNameInput = Console.ReadLine();
                Console.WriteLine("Please enter your Lastname.");
                string lastNameInput = Console.ReadLine();
                Console.WriteLine("Please enter your Social security number");
                long pNr = long.Parse(Console.ReadLine());


            }



            public List<string> GetCustomer(long pNr)
            {
                //● Returnerar en List<string> som innehåller informationen om kunden inklusive dennes konton.
                //Första platsen i listan är förslagsvis reserverad för kundens namn och personnummer sedan följer
                //informationen om kundens konton.
            }


            //Klassdesign

            public bool ChangeCustomerName(String name, long pNr)
            {
                //● Byter namn på kund med personnummer pNr till name, returnerar true om namnet ändrades annars
                //returnerar false(om kunden inte fanns).
            }

            public List<string> RemoveCustomer(long pNr)
            {
                //● Tar bort kund med personnummer pNr ur banken, alla kundens eventuella konton tas också bort
                //och resultatet returneras.Listan som returneras ska innehålla information om alla konton som togs
                //bort, saldot som kunden får tillbaka samt vad räntan blev.
            }

            public int AddSavingsAccount(long pNr)
            {
                //    ● Skapar ett konto till kund med personnummer pNr, returnerar kontonumret som det skapade kontot
                //fick alternativt returneras –1 om inget konto skapades.
            }

            public string GetAccount(long pNr, int accountId)
            {
                //    ● Returnerar en String som innehåller presentation av kontot med kontonummer accountId som tillhör
                //kunden pNr(kontonummer, saldo, kontotyp, räntesats).
            }

            public bool Deposit(long pNr, int accountId, decimal amount)
            {
                //     ● Gör en insättning på konto med kontonummer accountId som tillhör kunden pNr, returnerar true om
                //det gick bra annars false.
            }

            public bool Withdraw(long pNr, int accountId, decimal amount)
            {
                //● Gör ett uttag på konto med kontonummer accountId som tillhör kunden pNr, returnerar true om det
                //gick bra annars false
            }


            //Klassdesign

            public string CloseAccount(long pNr, int accountId)
            {
                //● Stänger ett konto med kontonummer accountId som tillhör kunden pNr, presentation av kontots
                //saldo samt ränta på pengarna ska genereras.
            }


        }

    }
}
