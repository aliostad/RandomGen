using System;
using System.Linq;
using RandomGen.Fluent;
using Xunit;

namespace RandomGen.Tests
{
    public class NameTests
    {
        [Fact]
        public void SeededFullnamesShouldBeConsistentlyGenerated()
        {
            //Given I have generated a full name using a seeded generator
            var surname1 = Gen.WithSeed(123).Random.Names.Full()();

            //When I regenerate another name using a similarly seeded generator
            var surname2 = Gen.WithSeed(123).Random.Names.Full()();
            //Then the generated value should be the same
            Assert.Equal(surname1, surname2);
        }
    }
}
