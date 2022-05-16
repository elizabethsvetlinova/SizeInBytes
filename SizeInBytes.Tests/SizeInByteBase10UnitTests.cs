using Xunit;
using Units;

namespace Tests
{
    public class SizeInByteBase10UnitTests
    {

        private const long _oneKiloByte = 1000;
        private const long _oneMegaByte = 1000 * _oneKiloByte;
        private const long _oneGigaByte = 1000 * _oneMegaByte;
        private const long _oneTeraByte = 1000 * _oneGigaByte;
        private const long _onePetaByte = 1000 * _oneTeraByte;
        private const long _oneExaByte = 1000 * _onePetaByte;

        [Fact]
        public void TestAsGetterWithExactKilobyte()
        {
            SizeInBytes bytes = new SizeInBytes(_oneKiloByte);
            Assert.Equal(1, bytes.AsKiloBytes);
            Assert.Equal((double)_oneKiloByte / _oneMegaByte, bytes.AsMegaBytes);
            Assert.Equal((double)_oneKiloByte / _oneGigaByte, bytes.AsGigaBytes);
            Assert.Equal((double)_oneKiloByte / _oneTeraByte, bytes.AsTeraBytes);
            Assert.Equal((double)_oneKiloByte / _onePetaByte, bytes.AsPetaBytes);

        }

        [Fact]
        public void TestAsGetterWithOneAndHalfKilobyte()
        {
            long oneAndHalfKiloBytes = (long)(_oneKiloByte * 1.5);
            Assert.Equal(1500, oneAndHalfKiloBytes);

            SizeInBytes bytes = new SizeInBytes(oneAndHalfKiloBytes);
            Assert.Equal((double)oneAndHalfKiloBytes / _oneKiloByte, bytes.AsKiloBytes);
            Assert.Equal((double)oneAndHalfKiloBytes / _oneMegaByte, bytes.AsMegaBytes);
            Assert.Equal((double)oneAndHalfKiloBytes / _oneGigaByte, bytes.AsGigaBytes);
            Assert.Equal((double)oneAndHalfKiloBytes / _oneTeraByte, bytes.AsTeraBytes);
            Assert.Equal((double)oneAndHalfKiloBytes / _onePetaByte, bytes.AsPetaBytes);

        }

        [Fact]
        public void TestFromUnitsMethods()
        {
            long value = _oneKiloByte;

            Assert.Equal(value, SizeInBytes.FromKiloBytes(value).AsKiloBytes);
            Assert.Equal(value, SizeInBytes.FromMegaBytes(value).AsMegaBytes);
            Assert.Equal(value, SizeInBytes.FromGigaBytes(value).AsGigaBytes);
            Assert.Equal(value, SizeInBytes.FromTeraBytes(value).AsTeraBytes);
            Assert.Equal(value, SizeInBytes.FromPetaBytes(value).AsPetaBytes);
        }

        [Fact]
        public void TestAddUnitsMethods()
        {
            var bytes = new SizeInBytes(0);

            var addedKilo = bytes.AddKiloBytes(1);
            Assert.Equal(1, addedKilo.AsKiloBytes);

            var addedMega = bytes.AddMegaBytes(1);
            Assert.Equal(1, addedMega.AsMegaBytes);

            var addedGiga = bytes.AddGigaBytes(1);
            Assert.Equal(1, addedGiga.AsGigaBytes);

            var addedTera = bytes.AddTeraBytes(1);
            Assert.Equal(1, addedTera.AsTeraBytes);

            var addedPeta = bytes.AddPetaBytes(1);
            Assert.Equal(1, addedPeta.AsPetaBytes);
        }

        [Fact]
        public void TestToStringWhitSingleUnit()
        {
            var bytes = new SizeInBytes(0);

            var addedKilo = bytes.AddKiloBytes(1);

            Assert.Equal("1 kB", addedKilo.ToStringWithDecimalPrefix());
            Assert.Equal("1.5 kB", addedKilo.AddKiloBytes(0.5).ToStringWithDecimalPrefix());
            Assert.Equal("1.0 kilobyte", addedKilo.ToStringWithDecimalPrefix("F1", System.Globalization.CultureInfo.InvariantCulture, false));
            Assert.Equal("6 kilobytes", addedKilo.AddKiloBytes(5).ToStringWithDecimalPrefix("F0", System.Globalization.CultureInfo.InvariantCulture, false));

            var addedMega = bytes.AddMegaBytes(1);
            Assert.Equal("1 MB", addedMega.ToStringWithDecimalPrefix());

            var addedGiga = bytes.AddGigaBytes(1);
            Assert.Equal("1 GB", addedGiga.ToStringWithDecimalPrefix());

            var addedTera = bytes.AddTeraBytes(1);
            Assert.Equal("1 TB", addedTera.ToStringWithDecimalPrefix());

            var addedPeta = bytes.AddPetaBytes(1);
            Assert.Equal("1 PB", addedPeta.ToStringWithDecimalPrefix());
        }
    }
}