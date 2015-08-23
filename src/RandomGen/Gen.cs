using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RandomGen.Fluent;
using System.Web.Script.Serialization;

namespace RandomGen
{
    public static class Gen
    {
        public static IRandom Random { get { return new RandomLink(new GenLink()); } }

        public static IDateChange Change(DateTime date)
        {
            return new DateChangeLink(new GenLink(), date);
        }

        public static IDateTimeOffsetChange Change(DateTimeOffset date)
        {
            return new DateTimeOffsetChangeLink(new GenLink(), date);
        }

        public static IDoubleChange Change(double amount)
        {
            return new DoubleChangeLink(new GenLink(), amount);
        }

        public static IDecimalChange Change(decimal amount)
        {
            return new DecimalChangeLink(new GenLink(), amount);
        }

        public static ILongChange Change(long amount)
        {
            return new LongChangeLink(new GenLink(), amount);
        }

        public static IIntChange Change(int amount)
        {
            return new IntChangeLink(new GenLink(), amount);
        }

        public static IGen WithSeed(int seed)
        {
            return new GenLink(seed);
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

        internal static string[] GetResourceJson(string fileName)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RandomGen.Data." + fileName))
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();

                var js = new JavaScriptSerializer();
                List<string> list = js.Deserialize<List<string>>(content);

                return list.ToArray();
            }
        }

        internal static int CreateRandomSeed()
        {
            return BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 10);
        }
    }
}
