using System;
using Lab5_Exercises;
using Xunit;

namespace Lab5_Exercises.xUnitTests
{
    public class Bai3_RadixTests
    {
        [Fact]
        public void TestConstructor_NegativeNumber_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Radix(-1));
            Assert.Equal("Incorrect Value", ex.Message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-5)]
        public void TestConvert_RadixLessThan2_ThrowsArgumentException(int radix)
        {
            var r = new Radix(10);
            var ex = Assert.Throws<ArgumentException>(() => r.ConvertDecimalToAnother(radix));
            Assert.Equal("Invalid Radix", ex.Message);
        }

        [Fact]
        public void TestConvert_RadixGreaterThan16_ThrowsArgumentException()
        {
            var r = new Radix(10);
            var ex = Assert.Throws<ArgumentException>(() => r.ConvertDecimalToAnother(17));
            Assert.Equal("Invalid Radix", ex.Message);
        }

        [Fact]
        public void TestConvert_DecimalToBinary_DefaultRadix()
        {
            var r = new Radix(10);
            Assert.Equal("1010", r.ConvertDecimalToAnother());
        }

        [Fact]
        public void TestConvert_DecimalToBinary_Explicit()
        {
            Assert.Equal("1101", new Radix(13).ConvertDecimalToAnother(2));
            Assert.Equal("1", new Radix(1).ConvertDecimalToAnother(2));
            Assert.Equal("10000", new Radix(16).ConvertDecimalToAnother(2));
        }

        [Fact]
        public void TestConvert_DecimalToOctal()
        {
            Assert.Equal("12", new Radix(10).ConvertDecimalToAnother(8));
            Assert.Equal("100", new Radix(64).ConvertDecimalToAnother(8));
            Assert.Equal("123", new Radix(83).ConvertDecimalToAnother(8));
        }

        [Fact]
        public void TestConvert_DecimalToHex()
        {
            Assert.Equal("A", new Radix(10).ConvertDecimalToAnother(16));
            Assert.Equal("B", new Radix(11).ConvertDecimalToAnother(16));
            Assert.Equal("C", new Radix(12).ConvertDecimalToAnother(16));
            Assert.Equal("D", new Radix(13).ConvertDecimalToAnother(16));
            Assert.Equal("E", new Radix(14).ConvertDecimalToAnother(16));
            Assert.Equal("F", new Radix(15).ConvertDecimalToAnother(16));

            Assert.Equal("10", new Radix(16).ConvertDecimalToAnother(16));
            Assert.Equal("FF", new Radix(255).ConvertDecimalToAnother(16));
            Assert.Equal("100", new Radix(256).ConvertDecimalToAnother(16));
            Assert.Equal("ABC", new Radix(2748).ConvertDecimalToAnother(16));
        }

        [Fact]
        public void TestConvert_Zero()
        {
            var r = new Radix(0);
            Assert.Equal("0", r.ConvertDecimalToAnother(2));
            Assert.Equal("0", r.ConvertDecimalToAnother(8));
            Assert.Equal("0", r.ConvertDecimalToAnother(16));
        }

        [Theory]
        [InlineData(10, 2, "1010")]
        [InlineData(15, 2, "1111")]
        [InlineData(10, 8, "12")]
        [InlineData(64, 8, "100")]
        [InlineData(1234, 10, "1234")]
        [InlineData(255, 16, "FF")]
        [InlineData(26, 16, "1A")]
        public void TestConvert_DataDriven(int number, int radix, string expected)
        {
            var r = new Radix(number);
            Assert.Equal(expected, r.ConvertDecimalToAnother(radix));
        }
    }
}
