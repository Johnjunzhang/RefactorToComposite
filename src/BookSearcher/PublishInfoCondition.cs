namespace BookSearcher
{
    public class PublishInfoCondition : IBookMatchCondition
    {
        private readonly PublishDateCondition m_publishDate;
        private readonly EditionCondition m_edition;

        public PublishInfoCondition(
            PublishDateCondition publishDate, 
            EditionCondition edition)
        {
            m_publishDate = publishDate;
            m_edition = edition;
        }

        public bool IsMatch(Book book)
        {
            return m_edition.IsMatch(book) && m_publishDate.IsMatch(book);
        }
    }
}