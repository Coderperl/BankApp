

using System;

namespace BankApp
{

    //● Saldo
    //● Räntesats
    //● Kontotyp(Sparkonto)
    //● Kontonummer(det kan inte finnas flera konton med samma kontonummer).

    //Man ska kunna utföra transaktioner (insättning/uttag), hämta
    //kontonummer, beräkna ränta(saldo* räntesats/100) samt presentera
    //kontot(kontonummer, saldo, kontotyp, räntesats).
    //Implementera metoder som säkerställer ovanstående krav i klassen
    //BankLogic nedan(BankLogic inkluderar förslag på metoder.Komplettera
    //dessa med fler metoder om det behövs).
  

    public class SavingsAccount 
    {
        
       
        public decimal Amount { get; private set; }
        public string AccountType { get; private set; }
        public double Interest { get; private set; }
        public int AccountNumber { get; private set; }
        public int AccountBalance { get; private set; }

        public SavingsAccount(decimal Amount,
                              string AccountType,
                              double Interest,
                              int AccountNumber,
                              int AccountBalance)
        {
            this.AccountNumber = AccountNumber;
            this.AccountType = AccountType;
            this.AccountBalance = AccountBalance;
            this.Amount = Amount;
            this.Interest = Interest;
        }

        public void DepositMoney(decimal amount)
        {
            this.Amount += amount;

            //     ● Gör en insättning på konto med kontonummer accountId som tillhör kunden pNr, returnerar true om
            //det gick bra annars false.
        }

        public bool WithdrawMoney(decimal amount)
        {
            if ((this.Amount - amount)>= 0)
            {
                this.Amount -= amount;
                return true;
                
            }
            else return false;
            //● Gör ett uttag på konto med kontonummer accountId som tillhör kunden pNr, returnerar true om det
            //gick bra annars false
        }
        public double InterestRate(int amount)
        {
            return Interest;
        }
        public decimal Balance()
        {
            return Amount;
        }

        public decimal CalculateInterest()
        {
            return (this.Amount * ((decimal)Interest) / 100);
        }

        public string ShowAccount()
        {
            return AccountNumber + "\t" + AccountType + "\t" + CalculateInterest();
        }

    }
    
    

   

}
