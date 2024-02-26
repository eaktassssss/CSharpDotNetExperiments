using DotNetInterfaces;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Person p1 compare Person p2  , IEquatable
        Person p1 = new Person("Evren Aktaş", 29);
        Person p2 = new Person("Didem Aktaş", 28);
        var a = p1.Equals(p2);
        #endregion
        #region Sort and IComparer
        List<Player> players = new List<Player>
        {
            new Player("Alice", 5000),
            new Player("Bob", 4000),
            new Player("Charlie", 4500)
        };
        players.Sort(new PlayerScoreComparer());

        foreach (var player in players)
        {
            Console.WriteLine($"{player.Name}: {player.Score}");
        }
        #endregion
        #region Words IComparer
        List<string> words = new List<string> { "sky", "blue", "Church", "cup", "Adam", "also", "Bratislava", "bear", "snow", "carpet", "water", "volcano", "smell", "forest", "Earth" };
        words.Sort(String.CompareOrdinal);
        foreach (var word in words) { Console.WriteLine(word); }
        #endregion
        #region IComparable
        ProgrammingLanguage language1 = new ProgrammingLanguage();
        ProgrammingLanguage language2 = new ProgrammingLanguage();
        language1.CompareTo(language2);
        #endregion
        #region ICloneable
        Person p1Clone = p1.Clone() as Person;
        Person p2Clone = p2.Clone() as Person;
        #endregion
        #region ProgrammingLanguage , INotifyCollectionChanged
        ProgrammingLanguage programmingLanguage = new ProgrammingLanguage();
        programmingLanguage.PropertyChanged += ProgrammingLanguage_PropertyChanged;
        programmingLanguage.Name = "C#";
        programmingLanguage.Name = "Pascal";
        programmingLanguage.Name = "Ruby";
        #endregion
        #region IEnumerable
        var bookCollection = new BookCollection();
        bookCollection.Add(new Book("1984", "George Orwell"));
        bookCollection.Add(new Book("Brave New World", "Aldous Huxley"));
        foreach (var book in bookCollection)
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
        }
        #endregion
        Console.ReadLine();
    }
    private static void ProgrammingLanguage_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        var programmingLanguage = sender as ProgrammingLanguage;
        Console.WriteLine($" {e.PropertyName}'in değer {programmingLanguage.Name} olarak değiştirildi");

    }
}