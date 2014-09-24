using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RandomGen.Fluent
{
    public interface IInternet : IFluentInterface
    {
        /// <summary>
        /// Generates random top level domains
        /// Based on http://www.iana.org/domains/root/db
        /// </summary>
        Func<string> TopLevelDomains();

        /// <summary>
        /// Generates random email addresses
        /// </summary>
        Func<string> EmailAddresses();

        Func<string> Urls();

        Func<IPAddress> IPAddresses();
    }
}
