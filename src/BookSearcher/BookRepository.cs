using System.Collections.Generic;
using System.Linq;

namespace BookSearcher
{
    public class BookRepository
    {
        private readonly HashSet<Book> m_books = new HashSet<Book>();

        public void Add(Book book)
        {
            m_books.Add(book);
        }

        public List<Book> Find(IBookMatchCondition condition)
        {
            return m_books.Where(condition.IsMatch).ToList();
        }
    }
}