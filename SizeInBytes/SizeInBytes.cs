using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units;
public readonly partial struct SizeInBytes : IEquatable<SizeInBytes>, IComparable<SizeInBytes>
{
    public static readonly SizeInBytes Zero = new SizeInBytes(0);

    private readonly long _bytes;
    public SizeInBytes(long bytes) { _bytes = bytes; }

    public static SizeInBytes operator +(SizeInBytes s1, SizeInBytes s2) => new SizeInBytes(s1._bytes + s2._bytes);
    public static SizeInBytes operator -(SizeInBytes s1, SizeInBytes s2) => new SizeInBytes(s1._bytes - s2._bytes);
    public static SizeInBytes operator ++(SizeInBytes s) => new SizeInBytes(s._bytes + 1);
    public static SizeInBytes operator --(SizeInBytes s) => new SizeInBytes(s._bytes - 1);
    public static SizeInBytes operator -(SizeInBytes s) => new SizeInBytes(-s._bytes);

    public static bool operator ==(SizeInBytes s1, SizeInBytes s2) => s1._bytes == s2._bytes;
    public static bool operator !=(SizeInBytes s1, SizeInBytes s2) => s1._bytes != s2._bytes;
    public static bool operator <(SizeInBytes s1, SizeInBytes s2) => s1._bytes < s2._bytes;
    public static bool operator <=(SizeInBytes s1, SizeInBytes s2) => s1._bytes <= s2._bytes;
    public static bool operator >(SizeInBytes s1, SizeInBytes s2) => s1._bytes > s2._bytes;
    public static bool operator >=(SizeInBytes s1, SizeInBytes s2) => s1._bytes >= s2._bytes;

    public static implicit operator SizeInBytes(long bytes) => new SizeInBytes(bytes);
    public static implicit operator SizeInBytes(int bytes) => new SizeInBytes(bytes);
    public static implicit operator long(SizeInBytes bytes) => bytes._bytes;
    public static implicit operator string(SizeInBytes bytes) => bytes.ToString();
    public static explicit operator int(SizeInBytes bytes) => (int)bytes._bytes;

    public static SizeInBytes operator +(SizeInBytes b1, long b2) => new SizeInBytes(b1._bytes + b2);
    public static SizeInBytes operator +(SizeInBytes b1, int b2) => new SizeInBytes(b1._bytes + b2);
    public static SizeInBytes operator -(SizeInBytes b1, long b2) => new SizeInBytes(b1._bytes - b2);
    public static SizeInBytes operator -(SizeInBytes b1, int b2) => new SizeInBytes(b1._bytes - b2);
    public static bool operator ==(SizeInBytes b1, int bytes) => b1._bytes == bytes;
    public static bool operator !=(SizeInBytes b1, int bytes) => b1._bytes != bytes;

    public int CompareTo(SizeInBytes other) => _bytes.CompareTo(other._bytes);

    public bool Equals(SizeInBytes other) => _bytes.Equals(other._bytes);

    public override int GetHashCode() => _bytes.GetHashCode();


    public SizeInBytes Add(SizeInBytes bs) => new SizeInBytes(_bytes + bs._bytes);

    public SizeInBytes AddBytes(long value) => new SizeInBytes(_bytes + value);


    public override bool Equals(object? obj) => obj is SizeInBytes other && Equals(other);

    public override string ToString() =>
        ToStringWithDecimalPrefix("0.##");

    public string ToString(string? format) =>
        ToStringWithDecimalPrefix(format);

    public string ToString(IFormatProvider? provider) =>
        ToStringWithDecimalPrefix(provider: provider);

    public string ToString(string? format, IFormatProvider? provider) =>
        ToStringWithDecimalPrefix(format, provider);

    public string ToString(string? format, IFormatProvider? provider, bool useBinaryUnitNamePrefix)
    {
        return useBinaryUnitNamePrefix
            ? ToStringWithBinaryPrefix(format, provider)
            : ToStringWithDecimalPrefix(format, provider);
    }

    public string ToString(string? format, IFormatProvider? provider, bool useBinaryUnitNamePrefix, bool useShortUnitName)
    {
        return useBinaryUnitNamePrefix
            ? ToStringWithBinaryPrefix(format, provider, useShortUnitName)
            : ToStringWithDecimalPrefix(format, provider, useShortUnitName);

    }
}
