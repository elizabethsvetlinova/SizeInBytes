using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units;

public readonly partial struct SizeInBytes
{
    private const long _oneKiloByte = 1000;
    private const long _oneMegaByte = 1000 * _oneKiloByte;
    private const long _oneGigaByte = 1000 * _oneMegaByte;
    private const long _oneTeraByte = 1000 * _oneGigaByte;
    private const long _onePetaByte = 1000 * _oneTeraByte;
    private const long _oneExaByte = 1000 * _onePetaByte;

    public static SizeInBytes FromKiloBytes(double value) => new SizeInBytes((long)(value * _oneKiloByte));

    public static SizeInBytes FromMegaBytes(double value) => new SizeInBytes((long)(value * _oneMegaByte));

    public static SizeInBytes FromGigaBytes(double value) => new SizeInBytes((long)(value * _oneGigaByte));

    public static SizeInBytes FromTeraBytes(double value) => new SizeInBytes((long)(value * _oneTeraByte));

    public static SizeInBytes FromPetaBytes(double value) => new SizeInBytes((long)(value * _onePetaByte));

    public SizeInBytes AddKiloBytes(double value) => new SizeInBytes((long)(value * _oneKiloByte) + _bytes);

    public SizeInBytes AddMegaBytes(double value) => new SizeInBytes((long)(value * _oneMegaByte) + _bytes);

    public SizeInBytes AddGigaBytes(double value) => new SizeInBytes((long)(value * _oneGigaByte) + _bytes);

    public SizeInBytes AddTeraBytes(double value) => new SizeInBytes((long)(value * _oneTeraByte) + _bytes);

    public SizeInBytes AddPetaBytes(double value) => new SizeInBytes((long)(value * _onePetaByte) + _bytes);

    public double AsKiloBytes => (double)_bytes / _oneKiloByte;

    public double AsMegaBytes => (double)_bytes / _oneMegaByte;

    public double AsGigaBytes => (double)_bytes / _oneGigaByte;

    public double AsTeraBytes => (double)_bytes / _oneTeraByte;

    public double AsPetaBytes => (double)_bytes / _onePetaByte;

    public string ToStringWithDecimalPrefix(string? format = null, IFormatProvider? provider = null, bool useShortUnitName = true)
    {
        provider ??= CultureInfo.CurrentCulture;

        return _bytes switch
        {
            var b when b >= _oneExaByte => (b / (double)_oneExaByte).ToString(format, provider) + (useShortUnitName ? " EB" : b == _oneExaByte ? " exabyte" : " exabytes"),
            var b when b >= _onePetaByte => (b / (double)_onePetaByte).ToString(format, provider) + (useShortUnitName ? " PB" : b == _onePetaByte ? " petabyte" : " petabytes"),
            var b when b >= _oneTeraByte => (b / (double)_oneTeraByte).ToString(format, provider) + (useShortUnitName ? " TB" : b == _oneTeraByte ? " terabyte" : " terabytes"),
            var b when b >= _oneGigaByte => (b / (double)_oneGigaByte).ToString(format, provider) + (useShortUnitName ? " GB" : b == _oneGigaByte ? " gigabyte" : " gigabytes"),
            var b when b >= _oneMegaByte => (b / (double)_oneMegaByte).ToString(format, provider) + (useShortUnitName ? " MB" : b == _oneMegaByte ? " megabyte" : " megabytes"),
            var b when b >= _oneKiloByte => (b / (double)_oneKiloByte).ToString(format, provider) + (useShortUnitName ? " kB" : b == _oneKiloByte ? " kilobyte" : " kilobytes"),
            var b => b.ToString(format, provider) + (useShortUnitName ? " B" : b == 1 ? " byte" : " bytes")
        };
    }
}
