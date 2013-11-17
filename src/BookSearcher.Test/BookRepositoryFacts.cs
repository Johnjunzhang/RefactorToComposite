using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BookSearcher.Test
{
    public class BookRepositoryFacts
    {
        [Fact]
        public void should_search_by_name()
        {
            var repository = CreateRepository();
            List<Book> result = repository.Find(new BookNameCondition("Windows"));
            AssertSearchResult(new[] { "978-0735662780", "978-1617291081" }, result);
        }

        [Fact]
        public void should_search_by_publish_info()
        {
            var repository = CreateRepository();
            var publishInfoCondition = (IBookMatchCondition) new AndCondition(new PublishDateCondition(
                new DateTime(2012, 11, 1),
                new DateTime(2012, 12, 31)), new EditionCondition(1));
            List<Book> result = repository.Find(publishInfoCondition);

            AssertSearchResult(new[] { "978-1617291081" }, result);
        }

        [Fact]
        public void should_search_by_name_and_publish_info()
        {
            var repository = CreateRepository();
            var publishInfoCondition = (IBookMatchCondition) new AndCondition(new PublishDateCondition(
                new DateTime(2012, 11, 1),
                new DateTime(2012, 12, 31)), new EditionCondition(1));
            var nameCondition = new BookNameCondition("PowerShell");
            List<Book> result = repository.Find(new AndCondition(nameCondition, publishInfoCondition));

            AssertSearchResult(new[] { "978-1617291081" }, result);
        }

        private static BookRepository CreateRepository()
        {
            var repository = new BookRepository();
            repository.Add(new Book("978-0735667457",
                "0735667454",
                "CLR via C#",
                4,
                new DateTime(2012, 12, 4),
                new[] {"testing", "C#", "programming", "windows"}));
            repository.Add(new Book("978-0735662780",
                "0735662789",
                "Inside Windows Debugging",
                1,
                new DateTime(2012, 5, 21),
                new[] {"debugging", "logic", "compiler", "windows"}));
            repository.Add(new Book("978-1617291081",
                "1617291080",
                "Learn Windows PowerShell 3 in a Month of Lunches",
                1,
                new DateTime(2012, 11, 22),
                new[] {"C", "C++", "network", "administration", "windows"}));
            return repository;
        }

        private static void AssertSearchResult(
            string[] desiredIsbns, List<Book> searchResult)
        {
            Assert.Equal(desiredIsbns.Length, searchResult.Count);
            Assert.True(searchResult.All(book => desiredIsbns.Contains(book.Isbn)));
        }
    }
}