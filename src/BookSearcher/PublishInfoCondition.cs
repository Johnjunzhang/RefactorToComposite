namespace BookSearcher
{
    public class PublishInfoCondition : AndCondition
    {
        public PublishInfoCondition(
            PublishDateCondition publishDate, 
            EditionCondition edition)
            : base(publishDate, edition)
        {
        }
    }
}