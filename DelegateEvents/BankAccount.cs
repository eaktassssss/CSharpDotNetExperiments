using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvents
{
    public class BankAccount
    {

        public delegate void MinimumBalanceReachedHandler(BankAccount bankAccount, decimal amount);
        public decimal NewBalance { get; set; }
        public decimal Balance { get; private set; }
        public decimal InternetShoppingLimit { get; set; }
        public event MinimumBalanceReachedHandler MinimumBalanceReached;
        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
            InternetShoppingLimit = initialBalance;
        }

        public void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                NewBalance = Balance - amount;
                Console.WriteLine($"Available balance: {NewBalance} TL");

                if (NewBalance < 100)
                    OnMinimumBalanceReached(Balance);


            }
            else
                Console.WriteLine("Insufficient funds.");
        }
        public decimal Deposit(decimal balance)
        {
            return balance * 0.20m;
        }
        protected virtual void OnMinimumBalanceReached(decimal currentBalance)
        {
            MinimumBalanceReached.Invoke(this, currentBalance);
        }
    }
}
