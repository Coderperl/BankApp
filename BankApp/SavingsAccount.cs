using System;
using System.Collections.Generic;

namespace BankApp
{
    //? Saldo
    //? Räntesats
    //? Kontotyp(Sparkonto)
    //? Kontonummer(det kan inte finnas flera konton med samma kontonummer).

    //Man ska kunna utföra transaktioner (insättning/uttag), hämta
    //kontonummer, beräkna ränta(saldo* räntesats/100) samt presentera
    //kontot(kontonummer, saldo, kontotyp, räntesats).
    //Implementera metoder som säkerställer ovanstående krav i klassen
    //BankLogic nedan(BankLogic inkluderar förslag på metoder.Komplettera
    //dessa med fler metoder om det behövs).

    public class SavingsAccount
    {
        public int AccountNumber { get; private set; }
        public int AccountNumberParent { get; private set; }
        public int AccountBalance { get; private set; }
        public string AccountType { get; private set; }
        public double Interest { get; private set; }

        //List<SavingsAccount> SavingAccounts = new List<SavingsAccount>();
        public SavingsAccount()
        {

        }
        public SavingsAccount(
            int accountNumber,
            int accountNumberParent,
            int accountBalance,
            string accountType,
            double interest)
        {
            AccountNumber = accountNumber;
            AccountNumberParent = accountNumberParent;
            AccountBalance = accountBalance;
            AccountType = "Saving Account";
            Interest = 1;
        }

        public int DepositMoney(int accountNumber, int accountBalance)
        {
            return AccountBalance + accountBalance;

            //     ? Gör en insättning på konto med kontonummer accountId som tillhör kunden pNr, returnerar true om
            //det gick bra annars false.
        }

        public bool WithdrawMoney(int accountBalance)
        {
            if ((AccountBalance - accountBalance) >= 0)
            {
                AccountBalance -= accountBalance;
                return true;
            }
            else return false;
            //? Gör ett uttag på konto med kontonummer accountId som tillhör kunden pNr, returnerar true om det
            //gick bra annars false
        }

        public double InterestRate(double interest)
        {
            return Interest;
        }

        public decimal ShowAccountBalance(int accountBalance)
        {
            return AccountBalance;
        }

        public decimal CalculateInterest()
        {
            return (AccountBalance * ((decimal)Interest) / 100);
        }
        public int GetAccountNumber(int accountNumber)
        {
            return AccountNumber;
        }
        public string ShowAccount()
        {
            return $"-- Account Info-- Account Number: {AccountNumber}\nAccountType: {AccountType} - Total Balance: {AccountBalance}\nTotal interest: {CalculateInterest()}";
            //return $"--Account Information--\nAccount Number: {AccountNumber}\nAccountType: {AccountType}\nTotal Balance: {AccountBalance}\nTotal interest: {CalculateInterest()}";
        }
        public override string ToString()
        {
            return string.Format($"-- Account Info-- Account Number: {AccountNumber} - AccountType: {AccountType} - Total Balance: {AccountBalance} - Total interest: {CalculateInterest()}");
        }
    }
}
