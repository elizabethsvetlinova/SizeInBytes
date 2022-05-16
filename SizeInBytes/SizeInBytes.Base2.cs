using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units;

public readonly partial struct SizeInBytes
{
    private const long _oneKibiByte = 1024;
    private const long _oneMebiByte = 1024 * _oneKibiByte;
    private const long _oneGibiByte = 1024 * _oneMebiByte;
    private const long _oneTebiByte = 1024 * _oneGibiByte;
    private const long _onePebiByte = 1024 * _oneTebiByte;
    private const long _oneExbiByte = 1024 * _onePebiByte;


    public static SizeInBytes FromKibiBytes(double value) => new SizeInBytes((long)(value * _oneKibiByte));
    public static SizeInBytes FromMebiBytes(double value) => new SizeInBytes((long)(value * _oneMebiByte));
    public static SizeInBytes FromGibiBytes(double value) => new SizeInBytes((long)(value * _oneGibiByte));
    public static SizeInBytes FromTebiBytes(double value) => new SizeInBytes((long)(value * _oneTebiByte));
    public static SizeInBytes FromPebiBytes(double value) => new SizeInBytes((long)(value * _onePebiByte));

    public SizeInBytes AddKibiBytes(double value) => new SizeInBytes((long)(value * _oneKibiByte) + _bytes);
    public SizeInBytes AddMebiBytes(double value) => new SizeInBytes((long)(value * _oneMebiByte) + _bytes);
    public SizeInBytes AddGibiBytes(double value) => new SizeInBytes((long)(value * _oneGibiByte) + _bytes);
    public SizeInBytes AddTebiBytes(double value) => new SizeInBytes((long)(value * _oneTebiByte) + _bytes);
    public SizeInBytes AddPebiBytes(double value) => new SizeInBytes((long)(value * _onePebiByte) + _bytes);

    public double AsKibiBytes => (double)_bytes / _oneKibiByte;
    public double AsMebiBytes => (double)_bytes / _oneMebiByte;
    public double AsGibiBytes => (double)_bytes / _oneGibiByte;
    public double AsTebiBytes => (double)_bytes / _oneTebiByte;
    public double AsPebiBytes => (double)_bytes / _onePebiByte;

    public string ToStringWithBinaryPrefixedShortUnitName(string? format = default, IFormatProvider? provider = default) =>
        ToStringWithBinaryPrefix(format, provider, true);

    public string ToStringWithBinaryPrefixedLongUnitName(string? format = default, IFormatProvider? provider = default) =>
        ToStringWithBinaryPrefix(format, provider, false);

    public string ToStringWithBinaryPrefix(string? format = default, IFormatProvider? provider = default, bool useShortUnitName = true)
    {
        provider = provider ?? CultureInfo.CurrentCulture;

        return _bytes switch
        {
            var b when b >= _oneExbiByte => (b / (double)_oneExbiByte).ToString(format, provider) + (useShortUnitName ? " EiB" : b == _oneExbiByte ? " exbibyte" : " exbibytes"),
            var b when b >= _onePebiByte => (b / (double)_onePebiByte).ToString(format, provider) + (useShortUnitName ? " PiB" : b == _onePebiByte ? " pebibyte" : " pebibytes"),
            var b when b >= _oneTebiByte => (b / (double)_oneTebiByte).ToString(format, provider) + (useShortUnitName ? " TiB" : b == _oneTebiByte ? " tebibyte" : " tebibytes"),
            var b when b >= _oneGibiByte => (b / (double)_oneGibiByte).ToString(format, provider) + (useShortUnitName ? " GiB" : b == _oneGibiByte ? " gibibyte" : " gibibytes"),
            var b when b >= _oneMebiByte => (b / (double)_oneMebiByte).ToString(format, provider) + (useShortUnitName ? " MiB" : b == _oneMebiByte ? " mebibyte" : " mebibytes"),
            var b when b >= _oneKibiByte => (b / (double)_oneKibiByte).ToString(format, provider) + (useShortUnitName ? " KiB" : b == _oneKibiByte ? " kibibyte" : " kibibytes"),
            var b => b.ToString(format, provider) + (useShortUnitName ? "B" : b == 1 ? " byte" : " bytes")
        };
    }
}
