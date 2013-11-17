namespace BookSearcher
{
    public class BookNameCondition : IBookMatchCondition
    {
        private readonly string m_nameFragment;

        public BookNameCondition(string nameFragment)
        {
            m_nameFragment = nameFragment == null 
                ? string.Empty 
                : nameFragment.ToLower();
        }

        public bool IsMatch(Book book)
        {
            if (string.IsNullOrEmpty(m_nameFragment))
            {
                return true;
            }

            string normalizedName = book.Name.ToLower();
            return normalizedName.Contains(m_nameFragment);
        }
    }
}