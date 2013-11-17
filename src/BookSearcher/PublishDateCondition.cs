using System;

namespace BookSearcher
{
    public class PublishDateCondition : IBookMatchCondition
    {
        private readonly DateTime? m_startInclusive;
        private readonly DateTime? m_endInclusive;

        public PublishDateCondition(
            DateTime? startInclusive, DateTime? endInclusive)
        {
            m_startInclusive = startInclusive;
            m_endInclusive = endInclusive;
        }

        public bool IsMatch(Book book)
        {
            if (m_startInclusive.HasValue && m_endInclusive.HasValue)
            {
                return book.PublishDate >= m_startInclusive 
                    && book.PublishDate <= m_endInclusive;
            }

            if (m_startInclusive.HasValue)
            {
                return book.PublishDate >= m_startInclusive;
            }

            if (m_endInclusive.HasValue)
            {
                return book.PublishDate <= m_endInclusive;
            }

            return true;
        }
    }
}