

using OperatorOverloading;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Vector
        Vector v1 = new Vector { X = 1, Y = 2 };
        Vector v2 = new Vector { X = 3, Y = 4 };
        Vector total = v1 + v2;
        Console.WriteLine(total);
        #endregion
        #region Date
        Date d1 = new Date { Year = 2020, Month = 1, Day = 1 };
        Date d2 = new Date { Year = 2021, Month = 1, Day = 1 };
        bool result = d1 < d2;
        Console.WriteLine(result);
        Console.ReadLine();
        #endregion
    }
}