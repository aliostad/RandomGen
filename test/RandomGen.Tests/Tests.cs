using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RandomGen.Tests
{
    public class Tests
    {

        [Fact]
        public void DateIsBetweenRange()
        {
            var min = DateTime.Now.AddYears(-10);
            var max = DateTime.Now;
            var randomDates = Gen.RandomDates(min, max);

            for (int i = 0; i < 100; i++)
            {
                Assert.InRange(randomDates(), min, max);
            }
        }

        [Fact]
        public void RandomFemaleNameGeneratesNotEmpty()
        {
            var names = Gen.RandomFemaleNames();
            for (int i = 0; i < 100; i++)
            {
                var name = names();
                Assert.NotEmpty(name);
                Console.WriteLine(name);
            }
        }

        [Fact]
        public void RandomMaleNameGeneratesNotEmpty()
        {
            var names = Gen.RandomMaleNames();
            for (int i = 0; i < 100; i++)
            {
                var name = names();
                Assert.NotEmpty(name);
                Console.WriteLine(name);
            }
        }

        [Fact]
        public void RandomFirstNameGeneratesNotEmpty()
        {
            var names = Gen.RandomFirstNames();
            for (int i = 0; i < 100; i++)
            {
                var name = names();
                Assert.NotEmpty(name);
                Console.WriteLine(name);
            }
        }

        [Fact]
        public void RandomSurameGeneratesNotEmpty()
        {
            var names = Gen.RandomSurnames();
            for (int i = 0; i < 100; i++)
            {
                var name = names();
                Assert.NotEmpty(name);
                Console.WriteLine(name);
            }
        }

        [Fact]
        public void RandomWordsGeneratesNotEmpty()
        {
            var words = Gen.RandomWords();
            for (int i = 0; i < 100; i++)
            {
                var word = words();
                Assert.NotEmpty(word);
                Console.WriteLine(word);
            }
        }

        [Fact]
        public void RandomTextsGeneratesNotEmpty()
        {
            var texts = Gen.RandomTexts(100);
            for (int i = 0; i < 100; i++)
            {
                var text = texts();
                Assert.NotEmpty(text);
                Assert.Equal(100, text.Length);
                Console.WriteLine(text);
            }
        }

        [Fact]
        public void RandomCountriesGeneratesNotEmpty()
        {
            var texts = Gen.RandomCountries();
            for (int i = 0; i < 100; i++)
            {
                var text = texts();
                Assert.NotEmpty(text);
                Console.WriteLine(text);
            }
        }

        [Fact]
        public void ListLikelihoodWeightsWorks()
        {
            var items = Gen.RandomItems(new[] {"A", "B"}, new [] { 0.1, 2.0});
            for (int i = 0; i < 100; i++)
            {
                var item = items();
                Assert.NotEmpty(item);
                Console.WriteLine(item);
            }
        }

        [Fact]
        public void RandomTopLevelDomainsGeneratesNotEmpty()
        {
            var domains = Gen.RandomTopLevelDomains();
            for (int i = 0; i < 100; i++)
            {
                var domain = domains();
                Assert.NotEmpty(domain);
                Console.WriteLine(domain);
            }
        }

        [Fact]
        public void RandomEmailAddressesGeneratesNotEmpty()
        {
            var emailAddresses = Gen.RandomEmailAddresses();
            for (int i = 0; i < 100; i++)
            {
                var emailAddress = emailAddresses();
                Assert.NotEmpty(emailAddress);
                Assert.Contains("@", emailAddress);
                Assert.Contains(".", emailAddress);
                Console.WriteLine(emailAddress);
            }
        }
    }
}
