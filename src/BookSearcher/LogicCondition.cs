using System.Collections.Generic;

namespace BookSearcher
{
    public abstract class LogicCondition : IBookMatchCondition
    {
        private readonly List<IBookMatchCondition> m_conditions =
            new List<IBookMatchCondition>();

        protected IEnumerable<IBookMatchCondition> Conditions
        {
            get
            {
                return m_conditions;
            }
        }

        protected LogicCondition(params IBookMatchCondition[] conditions)
        {
            m_conditions.AddRange(conditions);
        }

        public abstract bool IsMatch(Book book);
    }
}