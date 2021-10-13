using System;

namespace BankApp
{
    
    public class SavingsAccount
        // class SavingsAccount 
    {
        public decimal Amount { get; private set; }
        public string AccountType { get; private set; }
        public double Interest { get; private set; }
        public int AccountNumber { get; private set; }
        //Get och set metodes! parameters Amount, AccountType, Interest och AccountNumber
        public SavingsAccount(int AccountNumber)        
        { 
            this.AccountNumber = AccountNumber;
            AccountType = "SavingsAccount";
            Interest = 1;
            // interest 1%
        }
        // The constructor in the class SavingsAccount

        public void DepositMoney(decimal amount)
        {
            this.Amount += amount;

        }
        // Method DepositMoney takes the value type decimal with the variable name amount
        // then sets the value of ammout to the class variable Amount using this.
        // for the global scoop

        public bool WithdrawMoney(decimal amount)
        {
            if ((this.Amount - amount)>= 0)
            {
                this.Amount -= amount;
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
            return Amount;
        }
        // Method Balance return Amount
        public decimal CalculateInterest()
        {
            return (this.Amount * ((decimal)Interest) / 100);
        }
        // Method CalculateInterest Interest conveterd tom decimal /100 and then Interest
        // * Amount and then return the value.
        public string ShowAccount()
        {
            return $"--Account Information--\nAccount Number: {AccountNumber}\nAccountType: {AccountType}\nTotal Balance: {Balance()}\nTotal interest: {CalculateInterest()}";
        }
    } // Method ShowAccount return AccountNumber, AccountType, Balance and CalculateInterest 
}
