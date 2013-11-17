using System;
using System.Collections.Generic;

namespace BookSearcher
{
    public class Book : IEquatable<Book>
    {
        private string m_isbn;
        private readonly HashSet<string> m_tags = new HashSet<string>();
        private string m_isbn10;

        public Book(
            string isbn, 
            string isbn10, 
            string name, 
            int edition,
            DateTime publishDate, 
            IEnumerable<string> tags)
        {
            Isbn10 = isbn10;
            PublishDate = publishDate;
            Edition = edition;
            Name = name;
            Isbn = isbn;
            Tags = tags;
        }

        public string Isbn
        {
            get { return m_isbn; }
            private set
            {
                m_isbn = NormalizeIsbn(value);
            }
        }

        public string Isbn10
        {
            get { return m_isbn10; }
            private set { m_isbn10 = NormalizeIsbn(value); }
        }

        public string Name { get; private set; }

        public IEnumerable<string> Tags
        {
            get { return m_tags; }
            private set 
            {
                if (value == null)
                {
                    return;
                }

                foreach (string tag in value)
                {
                    m_tags.Add(tag.Trim());
                }
            }
        }

        public int Edition { get; private set; }

        public DateTime PublishDate { get; private set; }

        public bool Equals(Book other)
        {
            return other != null && Isbn.Equals(other.Isbn);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((Book) obj);
        }

        public override int GetHashCode()
        {
            return Isbn.GetHashCode();
        }

        private static string NormalizeIsbn(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string trimmed = value.Trim();

            if (trimmed.Length == 0)
            {
                throw new AggregateException("ISBN is required.");
            }

            return trimmed.ToUpper();
        }
    }
}