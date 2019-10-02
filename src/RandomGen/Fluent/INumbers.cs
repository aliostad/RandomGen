using System;

namespace RandomGen.Fluent
{
    public interface INumbers : IFluentInterface
    {
        Func<byte> Bytes(byte min = byte.MinValue, byte max = byte.MaxValue);
        Func<int> Integers(int min = 0, int max = 100);
        Func<uint> UnsignedIntegers(uint min = 0, uint max = 100);
        Func<long> Longs(long min = 0, long max = 100);
        IDouble Doubles();
        Func<double> Doubles(double min, double max);
        Func<decimal> Decimals(decimal min = 0, decimal max = 1);
        Func<bool> Booleans();
    }
}
