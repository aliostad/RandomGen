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
            var factory = _random.Numbers.Doubles().BetweenZeroAndOne();

            return () => new DateTime(Convert.ToInt64(minDate.Ticks + ((double)ticksSpan * factory())));
        }

        /// <summary>
        /// Returns random datetimeoffset gen
        /// </summary>
        /// <param name="min">if not supplied, DateTimeOffset.MinValue is used</param>
        /// <param name="max">if not supplied, DateTimeOffset.MaxValue is used</param>
        public Func<DateTimeOffset> Dates(DateTimeOffset? min = null, DateTimeOffset? max = null)
        {
            var minDate = min.GetValueOrDefault(DateTimeOffset.MinValue);
            var maxDate = max.GetValueOrDefault(DateTimeOffset.MaxValue);

            if (minDate >= maxDate)
                throw new ArgumentOutOfRangeException("min >= max");

            var ticksSpan = maxDate.Ticks - minDate.Ticks;
            var factory = _random.Numbers.Doubles().BetweenZeroAndOne();

            return () => new DateTimeOffset(Convert.ToInt64(minDate.Ticks + ((double)ticksSpan * factory())), minDate.Offset);
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
            var factory = _random.Numbers.Longs(minSpan.Ticks, maxSpan.Ticks);

            return () => new TimeSpan(factory());
        }
    }
}
