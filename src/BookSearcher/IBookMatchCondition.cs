namespace BookSearcher
{
    public interface IBookMatchCondition
    {
        bool IsMatch(Book book);
    }
}