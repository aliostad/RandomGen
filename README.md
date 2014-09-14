RandomGen
=========

A simple random generation tool. Can create random integer, double, boolean, date, male and femals names, words and surnames. Also can create random values based on Normal Distribution. Can pick random items from your list - optionally from a list of items you supplied.

### Getting Started

Use Gen.xxx static methods to get a delegate to create random numbers every time you call it.

#### Simple types

``` CSharp
// integers
var ints = Gen.RandomIntegers();
Console.WriteLine(ints()); // between 0 and 100

var ints2 = Gen.RandomIntegers(10, 15);
Console.WriteLine(ints2()); // between 10 and 15

// doubles
var doubles = Gen.RandomDoubles(10D, 15D);
Console.WriteLine(doubles()); // between 10D and 15D

// booleans
var booleans = Gen.RandomBooleans();
Console.WriteLine(booleans()); // true or false

// dates
var dates = Gen.RandomDates(DateTime.Now.AddYears(-1), DateTime.Now);
Console.WriteLine(date());


```
