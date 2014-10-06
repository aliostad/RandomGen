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
        public static IRandom Random { get { return new RandomLink(); } }

        public static IDateChange Change(DateTime date)
        {
            return new DateChangeLink(new RandomLink(), date);
        }

        public static IDoubleChange Change(double amount)
        {
            return new DoubleChangeLink(new RandomLink(), amount);
        }

        public static IDecimalChange Change(decimal amount)
        {
            return new DecimalChangeLink(new RandomLink(), amount);
        }

        public static ILongChange Change(long amount)
        {
            return new LongChangeLink(new RandomLink(), amount);
        }

        public static IIntChange Change(int amount)
        {
            return new IntChangeLink(new RandomLink(), amount);
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

        internal static Random CreateRandom()
        {
            return new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 10));
        }
    }
}
