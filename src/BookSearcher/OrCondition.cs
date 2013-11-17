using System.Linq;

namespace BookSearcher
{
    public class OrCondition : LogicCondition
    {
        public OrCondition(params IBookMatchCondition[] conditions)
            : base(conditions)
        {
        }

        public override bool IsMatch(Book book)
        {
            return Conditions.Any(condition => condition.IsMatch(book));
        }
    }
}