using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RandomGen.Tests
{
    public class DateChangeTests
    {
        [Fact]
        public void ByDaysIsInRange()
        {
            var date = DateTime.Now;

            foreach (var by in Gen.Random.Numbers.Integers(min: 1).ToEnumerable().Take(100))
            {
                var result = Gen.Change(date).By(by).Days();

                Console.WriteLine("{0} ±{1} -> {2}", date, by, result);
                Assert.InRange(result, date.AddDays(by * -1), date.AddDays(by));
            }
        }

        [Fact]
        public void ByHoursIsInRange()
        {
            var date = DateTime.Now;

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
            var date = DateTime.Now;

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
            var date = DateTime.Now;

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
            var date = DateTime.Now;

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
