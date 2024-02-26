
using YieldKeyword;

public class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        List<Book> books = new List<Book> { new Book() { Author = "X", Title = "Y" }, new Book() { Author = "Z", Title = "C" }, new Book() { Author = "A", Title = "D" } };
        MyCollection collection = new MyCollection(books);
        foreach (var item in collection)
        {
            var book = item as Book;
            Console.WriteLine(book.Title, book.Author);
        }
        foreach (var item in SettingsWithYield())
        {
            Console.WriteLine(item.key, item.value);
        }
        Console.ReadLine();
    }
    public static IEnumerable<int> GetEvenNumbers(int max)
    {
        for (int i = 0; i <= max; i++)
        {
            if (i % 2 == 0)
                yield return i;
        }
    }
    public static IEnumerable<(string key, string value)> SettingsWithYield()
    {
        yield return ("a", "1");
        yield return ("b", "2");
        yield return ("c", "3");
    }
    public static IEnumerable<(string key, string value)> Settings()
    {
        List<(string, string)> settings = new List<(string, string)>()
            {
                ("a","1"),("b","2"),("c","3")
            };
        return settings;
    }
    public static IEnumerable<int> GetNumbersUntil(int max, int stopAt)
    {
        for (int i = 0; i <= max; i++)
        {
            if (i == stopAt)
                yield break; 
            yield return i;
        }
    }
}