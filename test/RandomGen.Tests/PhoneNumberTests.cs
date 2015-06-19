using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomGen.Fluent;
using Xunit;
using Xunit.Extensions;

namespace RandomGen.Tests
{
    public class PhoneNumberTests
    {
        [Fact]
        public void PhoneNumberFromSimpleMask()
        {
            var number = Gen.Random.PhoneNumbers.FromMask("ABC")();
            Assert.Equal("ABC", number);
        }

        [Fact]
        public void PhoneNumberFromMask()
        {
            var randomNumbers = Gen.Random.PhoneNumbers.FromMask("+44 (0) 1xxx xxxxxx");

            for (int i = 0; i < 100; i++)
            {
                var number = randomNumbers();

                Console.WriteLine(number);
                Assert.True(number.StartsWith("+44 (0) 1"));
                Assert.False(number.Contains('x'));
                Assert.Equal(19, number.Length);
            }
        }

        [Theory]
        [InlineData(NumberFormat.UKLandLine, 12, "01")]
        [InlineData(NumberFormat.UKMobile, 12, "07")]
        public void PhoneNumberFromFormat(NumberFormat format, int length, string startsWith)
        {
            var randomNumbers = Gen.Random.PhoneNumbers.WithFormat(format);

            for (int i = 0; i < 100; i++)
            {
                var number = randomNumbers();

                Console.WriteLine(number);
                Assert.Equal(length, number.Length);
                Assert.True(number.StartsWith(startsWith));
            }
        }

        [Fact]
        public void PhoneNumberRandom()
        {
            var randomNumbers = Gen.Random.PhoneNumbers.WithRandomFormat();

            for (int i = 0; i < 100; i++)
            {
                var number = randomNumbers();

                Console.WriteLine(number);
                Assert.Equal(12, number.Length);
                Assert.True(number.StartsWith("07") || number.StartsWith("01"));
            }
        }
    }
}
