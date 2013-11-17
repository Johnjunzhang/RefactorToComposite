using System;
using Xunit;

namespace BookSearcher.Test
{
    public class BookNameConditionFacts
    {
        private static readonly Book SampleBook = new Book(
            "978-0735667457",
            "0735667454",
            "CLR via C#",
            4,
            new DateTime(2012, 12, 4),
            new[] {"testing", "C#", "programming", "windows"});

        [Fact]
        public void should_match_all_if_condition_is_empty()
        {
            var condition = new BookNameCondition(null);
            Assert.True(condition.IsMatch(SampleBook));
        }

        [Fact]
        public void should_match_random_position()
        {
            var condition = new BookNameCondition("via");
            Assert.True(condition.IsMatch(SampleBook));
        }

        [Fact]
        public void should_match_case_ignored()
        {
            var condition = new BookNameCondition("ViA");
            Assert.True(condition.IsMatch(SampleBook));
        }

        [Fact]
        public void should_return_false_if_no_substring_matched()
        {
            var condition = new BookNameCondition("XXX");
            Assert.False(condition.IsMatch(SampleBook));
        }
    }
}