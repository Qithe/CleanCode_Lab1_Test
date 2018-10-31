using System;

namespace CleanCode_Lab1_Testning
{
    class Program
    {
        static void Main(string[] args)
        {
            Account YourMainAccount = new Account(500);
            Account YourBackupAccount = new Account(1000);
            var input = "";

            while (true)
            {
                
                Console.WriteLine($"Main Account: {YourMainAccount.AccountBalance} sek.");
                Console.WriteLine($"Reserve Account: {YourBackupAccount.AccountBalance} sek. ");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("Q. Quit");

                try
                {
                    input = Console.ReadLine();
                    if (input == "q") break;
                    switch (int.Parse(input))
                    {
                        case 1:
                            Console.WriteLine("State how mutch you wish to deposit");
                            YourMainAccount.DepositMoneyToAccount(double.Parse(Console.ReadLine()));
                            break;
                        case 2:
                            Console.WriteLine("State how mutch you wish to withdraw");
                            YourMainAccount.WithdrawFromAccount(double.Parse(Console.ReadLine()));
                            break;
                        case 3:
                            Console.WriteLine("State how mutch you wish to transfer");
                            YourMainAccount.TransferFromThisAccountToATargetAccount(YourBackupAccount, double.Parse(Console.ReadLine()));
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Enter a valid option");
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
