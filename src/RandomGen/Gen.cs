using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RandomGen.Fluent;

namespace RandomGen
{
    public static class Gen
    {
        private static Random _random = new Random();

        public static IRandom Random { get { return new RandomLink(_random); } }

        public static IDateChange Change(DateTime date)
        {
            return new DateChangeLink(new RandomLink(_random), date);
        }

        public static IDoubleChange Change(double amount)
        {
            return new DoubleChangeLink(new RandomLink(_random), amount);
        }

        public static IDecimalChange Change(decimal amount)
        {
            return new DecimalChangeLink(new RandomLink(_random), amount);
        }

        public static ILongChange Change(long amount)
        {
            return new LongChangeLink(new RandomLink(_random), amount);
        }

        internal static string[] GetResourceStrings(string fileName)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RandomGen.Data." + fileName))
            using (var reader = new StreamReader(stream))
            {
                var list = new List<string>();
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                        list.Add(line);
                }
                return list.ToArray();
            }
        }
    }
}
