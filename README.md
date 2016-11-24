[![Build status](https://ci.appveyor.com/api/projects/status/f5gtmgmm2mkrqg1k?svg=true)](https://ci.appveyor.com/project/aliostad/randomgen)

[![NuGet](https://img.shields.io/nuget/v/Randomgen.svg?style=flat)](https://www.nuget.org/packages/RandomGen/)

RandomGen
=========

A simple random generation tool. Can create random integer, double, boolean, date, male and femals names, words, surnames and more. Also can create random values based on Normal Distribution. Can pick random items from your list - optionally from a list of items you supplied.

### Getting Started

Install the library using Nuget:

```
PM> Install-Package RandomGen
```

Use Gen.Random.xxx fluent methods to get a delegate that creates random values every time you call it.
RandomGen follows System.Random convention of excluding max value from results, ie. Gen.Random.Numbers.Integers(min: 1, max: 5) will return values { 1, 2, 3, 4 }.

#### Simple types

``` CSharp
// integers
var ints = Gen.Random.Numbers.Integers();
Console.WriteLine(ints()); // between 0 and 100

var ints2 = Gen.Random.Numbers.Integers(10, 15);
Console.WriteLine(ints2()); // between 10 and 15

// doubles
var doubles = Gen.Random.Numbers.Doubles(10D, 15D);
Console.WriteLine(doubles()); // between 10D and 15D

// booleans
var booleans = Gen.Random.Numbers.Booleans();
Console.WriteLine(booleans()); // true or false

// dates - DateTime and DateTimeOffset
var dates = Gen.Random.Time.Dates(DateTime.Now.AddYears(-1), DateTime.Now);
Console.WriteLine(date());

// Normal Distribution
var normals = Gen.Random.Numbers.Doubles().WithNormalDistribution(mean: 23.4, standardDeviation: 5.9);
Console.WriteLine(normals());

```

#### Names and words

``` CSharp
// male names
var maleNames = Gen.Random.Names.Male();
Console.WriteLine(maleNames());

// female names
var femaleNames = Gen.Random.Names.Female();
Console.WriteLine(femaleNames());

// random mix of male and female names
var firstNames = Gen.Random.Names.First();
Console.WriteLine(firstNames());

// last names
var surnames = Gen.Random.Names.Surname();
Console.WriteLine(surnames());

// full names: '<first name> <last name>'
var fullnames = Gen.Random.Names.Full();
Console.WriteLine(fullnames());

// words
var words = Gen.Random.Text.Words();
Console.WriteLine(words());

// texts
var texts = Gen.Random.Text.Length(100); // .Short(), .Long(), .VeryLong()
Console.WriteLine(texts());

// naughty strings - useful for security testing
var texts = Gen.Random.Text.Naughty();
Console.WriteLine(texts());

// countries
var countries = Gen.Random.Countries();
Console.WriteLine(countries());

// top level domains
var domains = Gen.Random.Internet.TopLevelDomains();
Console.WriteLine(domains());

// email addresses
var addresses = Gen.Random.Internet.EmailAddresses();
Console.WriteLine(addresses());

// urls
var urls = Gen.Random.Internet.Urls();
Console.WriteLine(urls());

// phone numbers using an input mask
var mobileNumbers = Gen.Random.PhoneNumbers.FromMask("+44 (0) 1xxx xxxxxx");
Console.WriteLine(mobileNumbers());

// phone numbers using a pre-defined format
var customFormats = Gen.Random.PhoneNumbers.WithFormat(NumberFormat.UKMobile);
Console.WriteLine(customFormats());

// phone numbers using a randomly selected pre-defined format
var randomFormats = Gen.Random.PhoneNumbers.WithRandomFormat();
Console.WriteLine(randomFormats());
```

#### Your custom objects


``` CSharp
// items with equal likelihood
var items = Gen.Random.Items(new [] {"A", "B", "C"});
Console.WriteLine(items()); 

// items with the likelihoods supplied
var items = Gen.Random.Items(new [] {"A", "B", "C"}, new [] {0.5, 6, 1.3});
Console.WriteLine(items()); 

// enums with equal likelihood - enum EnumType { A, B, C }
var items = Gen.Random.Enum<EnumType>();
Console.WriteLine(items()); 

// enums with the likelihoods supplied
var items = Gen.Random.Enum<EnumType>(new [] {0.5, 6, 1.3});
Console.WriteLine(items()); 

```

#### Change dates or numbers

Use Gen.Change.xxx fluent methods to get a new random value based on a value provided.
Useful when you need to randomize data set but want to keep the same order of magnitude.

``` CSharp
// dates
var date = DateTime.Now;
var newDate = Gen.Change(date).By(10).Days(); //.Minutes(), .Hours(), .Months()
Console.WriteLine(newDate); 

var date = DateTimeOffset.Now;
var newDate = Gen.Change(date).By(TimeSpan.FromSeconds(10));
Console.WriteLine(newDate); 

// numbers: ints, longs, doubles, decimals
var amount = 42;
var newAmount = Gen.Change(amount).By(10).Percent(); //.Amount()
Console.WriteLine(newAmount); 

```


#### Providing seed value

You can provide own seed value for random generator by calling WithSeed(int seed) method.
This can be useful when you need to randomize data set in a predictable way, for example during testing.

``` CSharp
var seed = 12345;
var number1 = Gen.WithSeed(seed).Random.Numbers.Integers()();
var number2 = Gen.WithSeed(seed).Random.Numbers.Integers()();
Console.WriteLine("{0} = {1}", number1, number2); 
```
