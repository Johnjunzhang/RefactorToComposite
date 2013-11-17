using System;
using Xunit;

namespace BookSearcher.Test
{
    public class EditionConditionFact
    {
        private static readonly Book SampleBook = new Book(
            "978-0735667457",
            "0735667454",
            "CLR via C#",
            4,
            new DateTime(2012, 12, 4),
            new[] { "testing", "C#", "programming", "windows" });

        [Fact]
        public void should_always_return_true_if_null_is_specified()
        {
            var condition = new EditionCondition(null);
            Assert.True(condition.IsMatch(SampleBook));
        }

        [Fact]
        public void should_match_if_edition_is_the_same()
        {
            var condition = new EditionCondition(4);
            Assert.True(condition.IsMatch(SampleBook));
        }

        [Fact]
        public void should_not_match_if_edition_is_different()
        {
            var condition = new EditionCondition(2);
            Assert.False(condition.IsMatch(SampleBook));
        }
    }
}