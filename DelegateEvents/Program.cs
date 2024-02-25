using DelegateEvents;

internal class Program
{
    delegate void BankOperation(decimal amount);
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount(3000);
        account.MinimumBalanceReached += IncreaseInternetShoppingLimit;
        Console.WriteLine("Total shopping amount:");
        var shoppingAmount = Convert.ToDecimal(Console.ReadLine());
        BankOperation bankOperation = account.Withdraw;
        bankOperation(shoppingAmount);
        Console.ReadLine();
    }
    private static void IncreaseInternetShoppingLimit(BankAccount bankAccount, decimal currentBalance)
    {
        var account = bankAccount as BankAccount;
        if (account != null)
        {
            account.InternetShoppingLimit += account.Deposit(account.Balance);
            Console.WriteLine($"Your online shopping limit has been increased, new limit: {account.InternetShoppingLimit} TL");
        }
    }
}