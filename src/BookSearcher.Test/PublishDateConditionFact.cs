using System;
using Xunit;

namespace BookSearcher.Test
{
    public class PublishDateConditionFact
    {
        private static readonly Book SampleBook1 = new Book(
            "978-0735667457",
            "0735667454",
            "CLR via C#",
            4,
            new DateTime(2012, 12, 4),
            new[] { "testing", "C#", "programming", "windows" });

        private static readonly Book SampleBook2 = new Book(
            "978-0735667458",
            "0735667458",
            "CLR via C#",
            4,
            new DateTime(2012, 11, 4),
            new[] { "testing", "C#", "programming", "windows" });

        [Fact]
        public void should_always_match_if_both_date_is_null()
        {
            var condition = new PublishDateCondition(null, null);
            Assert.True(condition.IsMatch(SampleBook1));
        }

        [Fact]
        public void should_be_a_greater_than_or_equal_to_match_if_end_is_null()
        {
            var condition = new PublishDateCondition(new DateTime(2012, 12, 1), null);
            Assert.True(condition.IsMatch(SampleBook1));
            Assert.False(condition.IsMatch(SampleBook2));
        }

        [Fact]
        public void should_be_a_smaller_than_or_equal_to_match_if_start_is_null()
        {
            var condition = new PublishDateCondition(null, new DateTime(2012, 11, 30));
            Assert.False(condition.IsMatch(SampleBook1));
            Assert.True(condition.IsMatch(SampleBook2));
        }

        [Fact]
        public void should_be_a_range_match()
        {
            var condition = new PublishDateCondition(
                new DateTime(2012, 11, 30), 
                new DateTime(2012, 12, 30));
            Assert.True(condition.IsMatch(SampleBook1));
            Assert.False(condition.IsMatch(SampleBook2));
        }
    }
}