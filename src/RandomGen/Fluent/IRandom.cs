using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGen.Fluent
{
    public interface IRandom : IFluentInterface
    {
        INumbers Numbers { get; }
        INames Names { get; }
        ITime Time { get; }
        IText Text { get; }
        IInternet Internet { get; }
        IPhoneNumbers PhoneNumbers { get; }

        /// <summary>
        /// Returns a gen that chooses randomly from a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="weights">Optional weights affecting the likelihood of an item being chosen. Same length as items</param>
        Func<T> Items<T>(IEnumerable<T> items, IEnumerable<double> weights);

        /// <summary>
        /// Returns a gen that chooses randomly with equal weight for each item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        Func<T> Items<T>(params T[] items);

        /// <summary>
        /// Returns a gen that chooses randomly from an Enum values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="weights">Optional weights affecting the likelihood of a value being chosen. Same length as Enum values</param>
        Func<T> Enum<T>(IEnumerable<double> weights = null) where T : struct, IConvertible;

        /// <summary>
        /// Generates random country names
        /// Based on System.Globalisation
        /// </summary>
        Func<string> Countries();
    }
}
