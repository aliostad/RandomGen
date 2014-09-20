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
