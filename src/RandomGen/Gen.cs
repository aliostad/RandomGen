using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RandomGen
{
    public static class Gen
    {

        private static Lazy<string[]> _maleNames = new Lazy<string[]>(GetMaleNames);
        private static Lazy<string[]> _femaleNames = new Lazy<string[]>(GetFemaleNames);
        private static Lazy<string[]> _sunames = new Lazy<string[]>(GetSurnames);
        private static Lazy<string[]> _words = new Lazy<string[]>(GetWords);

        private static string[] GetMaleNames()
        {
            return GetResourceStrings("dist.male.first.txt");
        }

        private static string[] GetFemaleNames()
        {
            return GetResourceStrings("dist.female.first.txt");
        }
        
        private static string[] GetSurnames()
        {
            return GetResourceStrings("dist.all.last.txt");
        }
        
        private static string[] GetWords()
        {
            return GetResourceStrings("dictionary.txt");
        }

        private static string[] GetResourceStrings(string fileName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RandomGen.Data." + fileName);
            var reader = new StreamReader(stream);
            var list = new List<string>();
            string line = null;
            while ((line = reader.ReadLine())!=null)
            {
                if(!string.IsNullOrEmpty(line))
                    list.Add(line);
            }
            return list.ToArray();
        }

        public static Func<int> RandomIntegers(int min = 0, int max = 100)
        {
            if(min >= max)
                throw new ArgumentOutOfRangeException("min >= max");
            var random = new Random();
            return () => random.Next(min, max);
        }

        public static Func<bool> RandomBooleans()
        {
            var random = new Random();
            return () => (random.NextDouble() < 0.5);
        }

        /// <summary>
        /// Returns random double gen
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static Func<double> RandomDoubles(double min = 0, double max = 1)
        {
            if (min >= max)
                throw new ArgumentOutOfRangeException("min >= max");

            var random = new Random();
            return () => min + (max - min) * random.NextDouble();
        }

        /// <summary>
        /// Returns random date gen
        /// </summary>
        /// <param name="min">if not supplied, DateTime.MinValue is used</param>
        /// <param name="max">if not supplied, DateTime.MaxValue is used</param>
        /// <returns></returns>
        public static Func<DateTime> RandomDates(DateTime? min = null, DateTime? max = null)
        {
            if (min.HasValue & max.HasValue & min >= max)
                throw new ArgumentOutOfRangeException("min >= max");

            if (!min.HasValue)
                min = DateTime.MinValue;

            if (!max.HasValue)
                max = DateTime.MaxValue;

            var random = new Random();
            return () => new DateTime( Convert.ToInt64(min.Value.Ticks + 
               ((max.Value.Ticks - min.Value.Ticks) 
                * random.NextDouble())));
        }

        /// <summary>
        /// Returns a gen that chooses randomly from a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="weights">Optional weights affecting the likelihood of an item being chosen. Same length as items</param>
        /// <returns></returns>
        public static Func<T> RandomItems<T>(IEnumerable<T> items, IEnumerable<double> weights = null)
        {
            T[] copy = items.ToArray();
            if (weights == null)
            {
                var factory = RandomIntegers(0, copy.Length);
                return () => copy[factory()];
            }
            else
            {
                var weightsCopy = weights.ToArray();
                if(weightsCopy.Length!=copy.Length)
                    throw new ArgumentException("Weights must have the same number of items as items.");
                var cumSum = new double[weightsCopy.Length];
                cumSum[0] = weightsCopy[0];
                Enumerable.Range(1, weightsCopy.Length - 1)
                    .ToList()
                    .ForEach(i => cumSum[i] = cumSum[i-1] + weightsCopy[i]);

                var factory = Gen.RandomDoubles(0, cumSum.Last());
                return () =>
                {
                    var r = factory();
                    for (int i = 0; i < cumSum.Length; i++)
                    {
                        if (cumSum[i] > r)
                            return copy[i];
                    }
                    return copy.Last();
                };
            }
        }

        /// <summary>
        /// Creates Normal Distribution according to Box Muller
        /// [Used impl according to http://stackoverflow.com/a/218600/440502]
        /// </summary>
        /// <param name="mean"></param>
        /// <param name="standardDeviation"></param>
        /// <returns></returns>
        public static Func<double> RandomWithNormalDistribution(double mean, double standardDeviation)
        {
            Random rand = new Random(); //reuse this if you are generating many
            double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            
            return () => mean + standardDeviation * randStdNormal; //random normal(mean,stdDev^2)
        }


        /// <summary>
        /// According to US Census Data
        /// http://www.census.gov/genealogy/www/data/1990surnames/names_files.html
        /// </summary>
        /// <returns></returns>
        public static Func<string> RandomFemaleNames()
        {
            var length = _femaleNames.Value.Length;
            var factory = RandomIntegers(0, length);
            return () => _femaleNames.Value[factory()];
        }

        /// <summary>
        /// According to US Census Data
        /// http://www.census.gov/genealogy/www/data/1990surnames/names_files.html
        /// </summary>
        /// <returns></returns>
        public static Func<string> RandomMaleNames()
        {
            var length = _maleNames.Value.Length;
            var factory = RandomIntegers(0, length);
            return () => _maleNames.Value[factory()];
        }

        /// <summary>
        /// According to US Census Data
        /// http://www.census.gov/genealogy/www/data/1990surnames/names_files.html
        /// </summary>
        /// <returns></returns>
        public static Func<string> RandomSurnames()
        {
            var length = _sunames.Value.Length;
            var factory = RandomIntegers(0, length);
            return () => _sunames.Value[factory()];
        }

        /// <summary>
        /// Based on 350,000 English words taken from
        /// http://www.math.sjsu.edu/~foster/dictionary.txt
        /// </summary>
        /// <returns></returns>
        public static Func<string> RandomWords()
        {
            var length = _words.Value.Length;
            var factory = RandomIntegers(0, length);
            return () => _words.Value[factory()];
        }

    }
}
