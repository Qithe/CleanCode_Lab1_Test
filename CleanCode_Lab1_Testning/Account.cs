using System;

namespace CleanCode_Lab1_Testning
{
    public class Account
    {
        public double AccountBalance { get; private set; }

        public Account(double initialBalance)
        {
            if (initialBalance<0) throw new Exception("Cant create account with negative balance");
            AccountBalance = initialBalance;
        }

        public void DepositMoneyToAccount(double amountToDeposit)
        {
            if (amountToDeposit < 0) throw new Exception("Can't debosit a negative value");
             if (double.MaxValue - amountToDeposit < this.AccountBalance) throw new Exception("Value is too high");
            Console.WriteLine($"Deposited {amountToDeposit} sek to main account");
            AccountBalance += amountToDeposit;
        }

        public void WithdrawFromAccount(double amountToWithdaw)
        {
            if (amountToWithdaw < 0) throw new Exception("Can't withdraw a negative value");
            if (amountToWithdaw > AccountBalance) throw new Exception("There is nor enough money on the account");
            Console.WriteLine($"Witdrew {amountToWithdaw} sek from main account");
            AccountBalance -= amountToWithdaw;
        }

        public bool TransferFromThisAccountToATargetAccount(Account targetAccount, double amountToTransfer)
        {
            if (targetAccount == null) return false;
            if (targetAccount == this) return false;
            if (AccountBalance < amountToTransfer) return false;
            targetAccount.AccountBalance += amountToTransfer;
            AccountBalance -= amountToTransfer;
            Console.WriteLine($"Transfered {amountToTransfer} sek from main account to reserve account");
            return true;
        }


    }   
}