using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RandomGen.Tests
{
    public class DecimalChangeTests
    {
        [Fact]
        public void BePercent()
        {
            var amount = 42.42M;

            foreach (var by in Gen.Random.Numbers.Decimals(0.001M, 1000M).ToEnumerable().Take(100))
            {
                var result = Gen.Change(amount).By(by).Percent();

                Console.WriteLine("{0} ±{1}% -> {2}", amount, by, result);
                Assert.InRange(result, amount - (amount * by / 100M), amount + (amount * by / 100M));
            }
        }

        [Fact]
        public void BePercentWithSeed()
        {
            var amount = 42.42M;
            var seeds = Gen.Random.Numbers.Integers();

            foreach (var by in Gen.Random.Numbers.Decimals(0.001M, 1000M).ToEnumerable().Take(100))
            {
                var seed = seeds();
                var result1 = Gen.WithSeed(seed).Change(amount).By(by).Percent();
                var result2 = Gen.WithSeed(seed).Change(amount).By(by).Percent();

                Console.WriteLine("{0} - {1}", result1, result2);
                Assert.Equal(result1, result2);
            }
        }

        [Fact]
        public void ByAmount()
        {
            var amount = 42.42M;

            foreach (var by in Gen.Random.Numbers.Decimals(0.001M, 1000M).ToEnumerable().Take(100))
            {
                var result = Gen.Change(amount).By(by).Amount();

                Console.WriteLine("{0} ±{1} -> {2}", amount, by, result);
                Assert.InRange(result, amount - by, amount + by);
            }
        }
    }
}
