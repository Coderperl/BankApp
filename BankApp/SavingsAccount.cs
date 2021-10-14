using System;
using System.Collections.Generic;

namespace BankApp
{
    
    public class SavingsAccount
        // class SavingsAccount 
    {
        public int AccountNumber { get; private set; }
        public string AccountType { get; set; }
        public int Interest { get; set; }
        public int AccountBalance { get; set; }
        //Get och set metodes! parameters Amount, AccountType, Interest och AccountNumber
        
        public SavingsAccount(int AccountNumber)        
        {
            this.AccountNumber = AccountNumber;
            this.AccountType = "SavingsAccount";
            this.Interest = 1;
            // interest 1%
        }
       
        // The constructor in the class SavingsAccount

        public void DepositMoney(int accountBalance)
        {
            AccountBalance += accountBalance;

        }
        // Method DepositMoney takes the value type decimal with the variable name amount
        // then sets the value of ammout to the class variable Amount using this.
        // for the global scoop

        public bool WithdrawMoney(int accountBalance)
        {
            if ((AccountBalance - accountBalance) >= 0)
            {
                AccountBalance -= accountBalance;
                return true;
            }
            else return false;
           
        }
        //Method WithdrawMoney takes the value type type decimal whit the variable name amount
        //in the if statement, it takes the global scope's variable Amount and subtracts the local variable's
        //amount if it is greater than or equal to zero, it subtracts the value that amount has 
        //in the local socopet from the value in variable Amount in global
        //scoop and then puts the new value to Ammout in the global scoop
        //If the if statement cannot be implemented, the method returns false. 
        public double InterestRate()
        {
            return Interest;
        }
        // Method InterestRate return Interest

        public decimal Balance()
        {
            return AccountBalance;
        }
        // Method Balance return Amount
        public decimal CalculateInterest()
        {
            return (AccountBalance * ((decimal)Interest) / 100);
        }
        public int GetAccountNumber(int AccountNumber)
        {
            return AccountNumber;
        }
        // Method CalculateInterest Interest conveterd tom decimal /100 and then Interest
        // * Amount and then return the value.
        public string ShowAccount()
        {
            return $"Account Number: {AccountNumber}     Account Type: {AccountType}\nCurrent Balance: {AccountBalance}       Total Interest: {CalculateInterest()}";
            //return $"--Account Information--\nAccount Number: {AccountNumber}\nAccountType: {AccountType}\nTotal Balance: {AccountBalance}\nTotal interest: {CalculateInterest()}";
        }
        public override string ToString()
        {
            return string.Format($"Account Number: {AccountNumber} | Account Type: {AccountType} | Current Balance: {AccountBalance} | Total Interest: {CalculateInterest()}");
        }
    }

}
