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

        public List<Book> Find(BookNameCondition nameCondition)
        {
            return m_books.Where(nameCondition.IsMatch).ToList();
        }

        public List<Book> Find(PublishInfoCondition publishInfoCondition)
        {
            return m_books.Where(publishInfoCondition.IsMatch).ToList();
        } 

        public List<Book> Find(BookNameCondition nameCondition, 
            PublishInfoCondition publishInfoCondition)
        {
            return m_books.Where(book => 
                nameCondition.IsMatch(book) 
                && publishInfoCondition.IsMatch(book)).ToList();
        } 
    }
}