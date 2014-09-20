using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    class InternetLink : IInternet
    {
        private static Lazy<string[]> _topLevelDomains = new Lazy<string[]>(GetTopLevelDomains);
        private readonly RandomLink _random;

        internal InternetLink(RandomLink random)
        {
            this._random = random;
        }

        public Func<string> TopLevelDomains()
        {
            var length = _topLevelDomains.Value.Length;
            var factory = _random.Numbers.Integers(max: length);
            
            return () => _topLevelDomains.Value[factory()];
        }

        public Func<string> EmailAddresses()
        {
            var wordFactory = _random.Text.Words();
            var domainFactory = this.TopLevelDomains();

            return () => string.Concat(wordFactory(), "@", wordFactory(), domainFactory());
        }

        public Func<string> Urls()
        {
            var schemasFactory = _random.Items(new []{"http", "https", "ftp"}, new[] { 1, 1, 0.25 });
            var hostFactory = _random.Text.Words();
            var domainFactory = this.TopLevelDomains();

            return () => string.Concat(schemasFactory(), "://", hostFactory(), domainFactory());
        }

        private static string[] GetTopLevelDomains()
        {
            return Gen.GetResourceStrings("dist.tld.txt");
        }
    }
}
