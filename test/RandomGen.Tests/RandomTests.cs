using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RandomGen.Tests
{
    public class RandomTests
    {
        [Fact]
        public void DateIsBetweenRange()
        {
            var min = DateTime.Now.AddYears(-10);
            var max = DateTime.Now;
            var randomDates = Gen.Random.Time.Dates(min, max);

            for (int i = 0; i < 100; i++)
            {
                Assert.InRange(randomDates(), min, max);
            }
        }

        [Fact]
        public void RandomFemaleNameGeneratesNotEmpty()
        {
            var names = Gen.Random.Names.Female();
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
            var names = Gen.Random.Names.Male();
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
            var names = Gen.Random.Names.First();
            for (int i = 0; i < 100; i++)
            {
                var name = names();
                Assert.NotEmpty(name);
                Console.WriteLine(name);
            }
        }

        [Fact]
        public void RandomSurnameGeneratesNotEmpty()
        {
            var names = Gen.Random.Names.Surname();
            for (int i = 0; i < 100; i++)
            {
                var name = names();
                Assert.NotEmpty(name);
                Console.WriteLine(name);
            }
        }

        [Fact]
        public void RandomFullnameGeneratesNotEmpty()
        {
            var names = Gen.Random.Names.Full();
            for (int i = 0; i < 100; i++)
            {
                var name = names();
                Assert.NotEmpty(name);
                Assert.Contains(" ", name);
                Console.WriteLine(name);
            }
        }

        [Fact]
        public void RandomWordsGeneratesNotEmpty()
        {
            var words = Gen.Random.Text.Words();
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
            var texts = Gen.Random.Text.Length(100);
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
            var texts = Gen.Random.Countries();
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
            var items = Gen.Random.Items(new[] {"A", "B"}, new [] { 0.1, 2.0});
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
            var domains = Gen.Random.Internet.TopLevelDomains();
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
            var emailAddresses = Gen.Random.Internet.EmailAddresses();
            for (int i = 0; i < 100; i++)
            {
                var emailAddress = emailAddresses();
                Assert.NotEmpty(emailAddress);
                Assert.Contains("@", emailAddress);
                Assert.Contains(".", emailAddress);
                Console.WriteLine(emailAddress);
            }
        }

        [Fact]
        public void RandomUrlsGeneratesNotEmpty()
        {
            var urls = Gen.Random.Internet.Urls();
            for (int i = 0; i < 100; i++)
            {
                var url = urls();
                Assert.NotEmpty(url);
                Assert.Contains("://", url);
                Assert.Contains(".", url);
                Console.WriteLine(url);
            }
        }

        [Fact]
        public void RandomIPAddressesGeneratesNotEmpty()
        {
            var addresses = Gen.Random.Internet.IPAddresses();
            for (int i = 0; i < 100; i++)
            {
                var address = addresses();
                Assert.Equal(3, address.ToString().Count(x => x == '.'));
                Console.WriteLine(address.ToString());
            }
        }

        [Fact]
        public void RandomLongs()
        {
            long min = 100L;
            long max = 345345;
            var longs = Gen.Random.Numbers.Longs(min, max);
            for (int i = 0; i < 100; i++)
            {
                var l = longs();
                Assert.True(l >= min);
                Assert.True(l < max);
                Console.WriteLine(l);
            }
        }

        [Fact]
        public void RandomTimeSpans()
        {
            var min = TimeSpan.FromMilliseconds(200);
            var max = TimeSpan.FromDays(200);
            var timespans = Gen.Random.Time.Spans(min, max);

            for (int i = 0; i < 100; i++)
            {
                var ts = timespans();
                Assert.True(ts >= min);
                Assert.True(ts < max);
                Console.WriteLine(ts);
            }
        }

        [Fact]
        public void ToEnumerable()
        {
            int i = 0;
            foreach (var l in Gen.Random.Numbers.Longs().ToEnumerable())
            {
                Console.WriteLine(l);   
                if(i++>100)
                    return;
            }
            
        }

        [Fact]
        public void Booleans()
        {
            var trueCount = 0;
            var booleans = Gen.Random.Numbers.Booleans();

            for (int i = 0; i < 100; i++)
            {
                var boolean = booleans();

                if (boolean)
                    ++trueCount;

                Console.WriteLine(boolean);
            }

            Assert.InRange(trueCount, 1, 99);
        }
    }
}
