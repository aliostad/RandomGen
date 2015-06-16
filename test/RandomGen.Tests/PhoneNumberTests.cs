using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomGen.Fluent;
using Xunit;

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
            var number = Gen.Random.PhoneNumbers.FromMask("+44 (0) 1xxx xxxxxx")();
            Assert.True(number.StartsWith("+44 (0) 1"));
            Assert.False(number.Contains('x'));
            Assert.Equal(19, number.Length);
        }

        [Fact]
        public void PhoneNumberFromFormat()
        {
            var mobileNumber = Gen.Random.PhoneNumbers.WithFormat(NumberFormat.UKMobile)();
            Assert.Equal(12, mobileNumber.Length);
            Assert.True(mobileNumber.StartsWith("07"));

            var landlineNumber = Gen.Random.PhoneNumbers.WithFormat(NumberFormat.UKLandLine)();
            Assert.Equal(12, landlineNumber.Length);
            Assert.True(landlineNumber.StartsWith("01"));
        }

        [Fact]
        public void PhoneNumberRandom()
        {
            var mobileNumber = Gen.Random.PhoneNumbers.WithRandomFormat()();
            Assert.Equal(12, mobileNumber.Length);
            Assert.True(mobileNumber.StartsWith("07") || mobileNumber.StartsWith("01"));
        }

    }
}
