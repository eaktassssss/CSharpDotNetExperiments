using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetInterfaces
{
    public class BookCollection : IEnumerable<Book>
    {
        private List<Book> _books = new List<Book>();

        public void Add(Book book)
        {
            _books.Add(book);
        }
        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in _books)
            {
                yield return book;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
