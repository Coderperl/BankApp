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
        private decimal Amount;
        private string AccountType = "SavingsAccount";
        private double Interest = 1;
        private int AccountNumber;

        public SavingsAccount(int AccountNumber)
        {
            this.AccountNumber = AccountNumber;
        }

        public void DepositTansaction(decimal amount)
        {
            this.Amount += amount;

            //     ● Gör en insättning på konto med kontonummer accountId som tillhör kunden pNr, returnerar true om
            //det gick bra annars false.
        }

        public bool WithdrawTransaction(decimal amount)
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
        public decimal Saldo()
        {
            return Amount;
        }

        public decimal CalculateInterest()
        {
            return (this.Amount * ((decimal)Interest) / 100);
        }
        public int GetAccountNumber()
        {
            return AccountNumber;
        }
        public string ShowAccount()
        {
            return AccountNumber + "\t" + AccountType + "\t" + CalculateInterest();
        }

    }
    
    

   

}
