using System;

namespace RandomGen.Fluent
{
    public enum NumberFormat
    {
        UKMobile,
        UKLandLine
    }

    public interface IPhoneNumbers
    {
        Func<string> FromMask(string mask);
        Func<string> WithFormat(NumberFormat format);
        Func<string> WithRandomFormat();
    }
}
