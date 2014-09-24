using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
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
            var schemeFactory = _random.Items(new []{"http", "https", "ftp"}, new[] { 1, 1, 0.25 });
            var hostSegments = _random.Numbers.Integers(1, 3);
            Func<string> hostFactory = () => string.Join(".", _random.Text.Words().ToEnumerable().Take(hostSegments()));

            var domainFactory = this.TopLevelDomains();

            return () => string.Concat(schemeFactory(), "://", hostFactory(), domainFactory());
        }

        private static string[] GetTopLevelDomains()
        {
            return Gen.GetResourceStrings("dist.tld.txt");
        }

        public Func<IPAddress> IPAddresses()
        {
            var parts = Gen.Random.Numbers.Integers(0, 255);

            return () => new IPAddress(new byte[] { (byte)parts(), (byte)parts(), (byte)parts(), (byte)parts() });
        }
    }
}
