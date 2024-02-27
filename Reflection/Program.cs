
using MemorySecurity;
using System.Runtime.InteropServices;
using System.Security;

public class Program
{
    private static void Main(string[] args)
    {
        try
        {
            BankCard bankCard = new BankCard();
            bankCard.CardNo = "55555555555";
            SecureString secureString = new SecureString();
            bankCard.CardNo.ToList().ForEach(c => secureString.AppendChar(c));
            secureString.MakeReadOnly();


            IntPtr bstr = Marshal.SecureStringToBSTR(secureString);
            string cardNo=Marshal.PtrToStringAnsi(bstr);

        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        Console.ReadLine();
    }
}