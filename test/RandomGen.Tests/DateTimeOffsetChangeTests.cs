using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RandomGen.Tests
{
    public class DateTimeOffsetChangeTests
    {
        [Fact]
        public void ByDaysIsInRange()
        {
            var date = DateTimeOffset.Now;

            foreach (var by in Gen.Random.Numbers.Integers(min: 1).ToEnumerable().Take(100))
            {
                var result = Gen.Change(date).By(by).Days();

                Console.WriteLine("{0} ±{1} -> {2}", date, by, result);
                Assert.InRange(result, date.AddDays(by * -1), date.AddDays(by));
            }
        }

        [Fact]
        public void ByDaysWithSeed()
        {
            var date = DateTimeOffset.Now;
            var seeds = Gen.Random.Numbers.Integers();

            foreach (var by in Gen.Random.Numbers.Integers(min: 1).ToEnumerable().Take(100))
            {
                var seed = seeds();

                var result1 = Gen.WithSeed(seed).Change(date).By(by).Days();
                var result2 = Gen.WithSeed(seed).Change(date).By(by).Days();

                Console.WriteLine("{0} - {1}", result1, result2);
                Assert.Equal(result1, result2);
            }
        }

        [Fact]
        public void ByHoursIsInRange()
        {
            var date = DateTimeOffset.Now;

            foreach (var by in Gen.Random.Numbers.Integers(min: 1).ToEnumerable().Take(100))
            {
                var result = Gen.Change(date).By(by).Hours();

                Console.WriteLine("{0} ±{1} -> {2}", date, by, result);
                Assert.InRange(result, date.AddHours(by * -1), date.AddHours(by));
            }
        }

        [Fact]
        public void ByMinutesIsInRange()
        {
            var date = DateTimeOffset.Now;

            foreach (var by in Gen.Random.Numbers.Integers(min: 1).ToEnumerable().Take(100))
            {
                var result = Gen.Change(date).By(by).Minutes();

                Console.WriteLine("{0} ±{1} -> {2}", date, by, result);
                Assert.InRange(result, date.AddMinutes(by * -1), date.AddMinutes(by));
            }
        }

        [Fact]
        public void ByMonthsIsInRange()
        {
            var date = DateTimeOffset.Now;

            foreach (var by in Gen.Random.Numbers.Integers(min: 1).ToEnumerable().Take(100))
            {
                var result = Gen.Change(date).By(by).Months();

                Console.WriteLine("{0} ±{1} -> {2}", date, by, result);
                Assert.InRange(result, date.AddMonths(by * -1), date.AddMonths(by));
            }
        }

        [Fact]
        public void ByTimeSpanIsInRange()
        {
            var date = DateTimeOffset.Now;

            foreach (var by in Gen.Random.Numbers.Integers(min: 1).ToEnumerable().Take(100))
            {
                var span = TimeSpan.FromMinutes(by);
                var result = Gen.Change(date).By(span);

                Console.WriteLine("{0} ±{1} -> {2}", date, span, result);
                Assert.InRange(result, date.AddMinutes(by * -1), date.AddMinutes(by));
            }
        }
    }
}
