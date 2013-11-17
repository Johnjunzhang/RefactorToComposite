namespace BookSearcher
{
    public class EditionCondition : IBookMatchCondition
    {
        private readonly int? m_edition;

        public EditionCondition(int? edition)
        {
            m_edition = edition;
        }

        public bool IsMatch(Book book)
        {
            if (m_edition.HasValue)
            {
                return m_edition == book.Edition;
            }

            return true;
        }
    }
}