using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomGen.Fluent;

namespace RandomGen
{
    class TimeLink : ITime
    {
        private readonly RandomLink _random;

        internal TimeLink(RandomLink random)
        {
            this._random = random;
        }

        /// <summary>
        /// Returns random date gen
        /// </summary>
        /// <param name="min">if not supplied, DateTime.MinValue is used</param>
        /// <param name="max">if not supplied, DateTime.MaxValue is used</param>
        public Func<DateTime> Dates(DateTime? min = null, DateTime? max = null)
        {
            var minDate = min.GetValueOrDefault(DateTime.MinValue);
            var maxDate = max.GetValueOrDefault(DateTime.MaxValue);

            if (minDate >= maxDate)
                throw new ArgumentOutOfRangeException("min >= max");

            var ticksSpan = maxDate.Ticks - minDate.Ticks;

            return () => new DateTime(Convert.ToInt64(minDate.Ticks + ((double)ticksSpan * _random.Numbers.Doubles().BetweenZeroAndOne()())));
        }

        /// <summary>
        /// Creates TimeSpan intervals between two optional ranges
        /// </summary>
        /// <param name="min">if null, TimeSpan.Zero</param>
        /// <param name="max">if null, 1 year is used</param>
        public Func<TimeSpan> Spans(TimeSpan? min = null, TimeSpan? max = null)
        {
            if (min >= max)
                throw new ArgumentOutOfRangeException("min >= max");

            var minSpan = min ?? TimeSpan.Zero;
            var maxSpan = max ?? TimeSpan.FromDays(365);

            return () => new TimeSpan(_random.Numbers.Longs(minSpan.Ticks, maxSpan.Ticks)());

        }

    }
}
