RandomGen
=========

A simple random generation tool. Can create random integer, double, boolean, date, male and femals names, words and surnames. Also can create random values based on Normal Distribution. Can pick random items from your list - optionally from a list of items you supplied.

### Getting Started

Install the library using Nuget:

```
PM> Install-Package RandomGen
```

Use Gen.xxx static methods to get a delegate that creates random values every time you call it.

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

// Normal Distribution
var normals = Gen.RandomWithNormalDistribution(mean: 23.4, standardDeviation: 5.9);
Console.WriteLine(normals());

```

#### Names and words

``` CSharp
// male names
var maleNames = Gen.RandomMaleNames();
Console.WriteLine(maleNames());

// female names
var femaleNames = Gen.RandomFemaleNames();
Console.WriteLine(femaleNames());

// random mix of male and female names
var firstNames = Gen.RandomFirstNames();
Console.WriteLine(firstNames());

// last names
var surnames = Gen.RandomSurnames();
Console.WriteLine(surnames());

// words
var words = Gen.RandomWords();
Console.WriteLine(words());

// texts
var texts = Gen.RandomTexts(length: 100);
Console.WriteLine(texts());

```

#### Your custom objects


``` CSharp
// items with equal likelihood
var items = Gen.RandomItems(new [] {"A", "B", "C"});
Console.WriteLine(items()); 

// with the likelihoods supplied
var items = Gen.RandomItems(new [] {"A", "B", "C"}, new [] {0.5, 6, 1.3});
Console.WriteLine(items()); 


```



