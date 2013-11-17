using System.Collections.Generic;
using System.Linq;

namespace BookSearcher
{
    public class AndCondition : IBookMatchCondition
    {
        private readonly List<IBookMatchCondition> m_conditions = 
            new List<IBookMatchCondition>();

        public AndCondition(
            params IBookMatchCondition[] conditions)
        {
            m_conditions.AddRange(conditions);
        }

        public bool IsMatch(Book book)
        {
            return m_conditions.All(condition => condition.IsMatch(book));
        }
    }
}