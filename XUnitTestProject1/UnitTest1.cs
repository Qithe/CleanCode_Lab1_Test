using Xunit;
using CleanCode_Lab1_Testning;
using System;

namespace XUnitTestProject1
{
    public class AccountTests
    {
        [Fact]
        public void Account_InitalBalanceIsPositve_Return()
        {
            Assert.Equal(1000, new Account(1000).AccountBalance);
        }

        [Fact]
        public void Account_InitalBalanceIsPositve_ThrowExeption()
        {
            Assert.Throws<Exception>(() => new Account(-1000));
        }

        [Fact]
        public void Deposit_InputPosetive_Return()
        {
            var account = new Account(2000);
            account.DepositMoneyToAccount(1000);
            Assert.Equal(3000, account.AccountBalance);
        }

        [Fact]
        public void Deposit_InputNegative_ThrowExeption()
        {
            var account = new Account(2000);
            Assert.Throws<Exception>(() => account.DepositMoneyToAccount(-1000));
        }

        [Fact]
        public void Deposit_InputTooMutch_ThrowExeption()
        {
            var account = new Account(2000);
            Assert.Throws<Exception>(() => account.DepositMoneyToAccount(account.AccountBalance + double.MaxValue));
        }

        [Fact]
        public void WithdrawFromAccount_InputPosetive_Return()
        {
            var account = new Account(2000);
            account.WithdrawFromAccount(1000);
            Assert.Equal(1000, account.AccountBalance);
        }

        [Fact]
        public void WithdrawFromAccount_InputNegative_ThrowExeption()
        {
            var account = new Account(2000);
            Assert.Throws<Exception>(() => account.WithdrawFromAccount(-1000));
        }

        [Fact]
        public void WithdrawFromAccount_InputGreaterThanBalance_ThrowExeption()
        {
            var account = new Account(2000);
            Assert.Throws<Exception>(
                () => account.WithdrawFromAccount(3000)
                );
        }

        [Fact]
        public void TransferFromThisAccountToATargetAccount_IsAlowed_ReturnsTrue()
        {
            var account = new Account(2000);
            Assert.True(account.TransferFromThisAccountToATargetAccount(new Account(1000), 1000));
        }

        [Fact]
        public void TransferFromThisAccountToATargetAccount_TargetAccountIsNull_ReturnsFalse()
        {
            var account = new Account(2000);
            Assert.False(account.TransferFromThisAccountToATargetAccount(null, 1000));
        }

        [Fact]
        public void TransferFromThisAccountToATargetAccount_TargetAccountIsSelf_ReturnsFalse()
        {
            var account = new Account(2000);
            Assert.False(account.TransferFromThisAccountToATargetAccount(account, 1000));
        }

        [Fact]
        public void TransferFromThisAccountToATargetAccount_TransferValueIsGreaterThanBalance_ReturnsFalse()
        {
            var account = new Account(2000);
            Assert.False(account.TransferFromThisAccountToATargetAccount(new Account(1000), 3000));
        }
    }
}
