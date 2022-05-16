using Xunit;
using Units;


namespace Tests
{
    public class SizeInByteBase2UnitTests
    {
        private const long _oneKibiByte = 1024;
        private const long _oneMebiByte = 1024 * _oneKibiByte;
        private const long _oneGibiByte = 1024 * _oneMebiByte;
        private const long _oneTebiByte = 1024 * _oneGibiByte;
        private const long _onePebiByte = 1024 * _oneTebiByte;
        private const long _oneExbiByte = 1024 * _onePebiByte;


        [Fact]
        public void TestAsGetterWithExactKibibyte()
        {
            SizeInBytes bytes = new SizeInBytes(_oneKibiByte);
            Assert.Equal(1, bytes.AsKibiBytes);
            Assert.Equal((double)_oneKibiByte / _oneMebiByte, bytes.AsMebiBytes);
            Assert.Equal((double)_oneKibiByte / _oneGibiByte, bytes.AsGibiBytes);
            Assert.Equal((double)_oneKibiByte / _oneTebiByte, bytes.AsTebiBytes);
            Assert.Equal((double)_oneKibiByte / _onePebiByte, bytes.AsPebiBytes);

        }

        [Fact]
        public void TestAsGetterWithOneAndHalfKibibyte()
        {
            long oneAndHalfKibiBytes = (long)(_oneKibiByte * 1.5);
            Assert.Equal(1536, oneAndHalfKibiBytes);

            SizeInBytes bytes = new SizeInBytes(oneAndHalfKibiBytes);
            Assert.Equal((double)oneAndHalfKibiBytes / _oneKibiByte, bytes.AsKibiBytes);
            Assert.Equal((double)oneAndHalfKibiBytes / _oneMebiByte, bytes.AsMebiBytes);
            Assert.Equal((double)oneAndHalfKibiBytes / _oneGibiByte, bytes.AsGibiBytes);
            Assert.Equal((double)oneAndHalfKibiBytes / _oneTebiByte, bytes.AsTebiBytes);
            Assert.Equal((double)oneAndHalfKibiBytes / _onePebiByte, bytes.AsPebiBytes);

        }

        [Fact]
        public void TestFromUnitsMethods()
        {
            long value = _oneKibiByte;

            Assert.Equal(value, SizeInBytes.FromKibiBytes(value).AsKibiBytes);
            Assert.Equal(value, SizeInBytes.FromMebiBytes(value).AsMebiBytes);
            Assert.Equal(value, SizeInBytes.FromGibiBytes(value).AsGibiBytes);
            Assert.Equal(value, SizeInBytes.FromTebiBytes(value).AsTebiBytes);
            Assert.Equal(value, SizeInBytes.FromPebiBytes(value).AsPebiBytes);
        }

        [Fact]
        public void TestAddUnitsMethods()
        {
            var bytes = new SizeInBytes(0);

            var addedKibi = bytes.AddKibiBytes(1);
            Assert.Equal(1, addedKibi.AsKibiBytes);

            var addedMebi = bytes.AddMebiBytes(1);
            Assert.Equal(1, addedMebi.AsMebiBytes);

            var addedGibi = bytes.AddGibiBytes(1);
            Assert.Equal(1, addedGibi.AsGibiBytes);

            var addedTebi = bytes.AddTebiBytes(1);
            Assert.Equal(1, addedTebi.AsTebiBytes);

            var addedPebi = bytes.AddPebiBytes(1);
            Assert.Equal(1, addedPebi.AsPebiBytes);
        }

        [Fact]
        public void TestToStringWhitSingleUnit()
        {
            var bytes = new SizeInBytes(0);

            var addedKibi = bytes.AddKibiBytes(1);

            Assert.Equal("1 KiB", addedKibi.ToStringWithBinaryPrefix());
            Assert.Equal("1.5 KiB", addedKibi.AddKibiBytes(0.5).ToStringWithBinaryPrefix());
            Assert.Equal("1.0 kibibyte", addedKibi.ToStringWithBinaryPrefix("F1", System.Globalization.CultureInfo.InvariantCulture, false));
            Assert.Equal("6 kibibytes", addedKibi.AddKibiBytes(5).ToStringWithBinaryPrefix("F0", System.Globalization.CultureInfo.InvariantCulture, false));

            var addedMebi = bytes.AddMebiBytes(1);
            Assert.Equal("1 MiB", addedMebi.ToStringWithBinaryPrefix());

            var addedGibi = bytes.AddGibiBytes(1);
            Assert.Equal("1 GiB", addedGibi.ToStringWithBinaryPrefix());

            var addedTebi = bytes.AddTebiBytes(1);
            Assert.Equal("1 TiB", addedTebi.ToStringWithBinaryPrefix());

            var addedPebi = bytes.AddPebiBytes(1);
            Assert.Equal("1 PiB", addedPebi.ToStringWithBinaryPrefix());
        }
    }
}