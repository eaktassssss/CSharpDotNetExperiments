using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldKeyword
{
    public class MyCollection : IEnumerable, IEnumerator
    {
        private List<Book> books;
        int position = -1;
        public MyCollection(List<Book> books)
        {
           
            this.books = books;
         
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        public object Current
        {
            get
            {
                return books[position];
            }
        }
        public bool MoveNext()
        {
            position +=2;
            return (position < books.Count);
        }
        public void Reset()
        {
            position = -1;
        }

        
    }
}
