using System;
using Lab5_Exercises;
using Xunit;

namespace Lab5_Exercises.xUnitTests
{
    public class Bai1_PowerTests
    {
        private const int Precision = 5;

        [Fact]
        public void TestPower_NZero_ReturnsOne()
        {
            Assert.Equal(1.0, Bai1_Power.Power(2.0, 0), Precision);
            Assert.Equal(1.0, Bai1_Power.Power(-5.0, 0), Precision);
            Assert.Equal(1.0, Bai1_Power.Power(10.5, 0), Precision);
            Assert.Equal(1.0, Bai1_Power.Power(0.0, 0), Precision);
        }

        [Fact]
        public void TestPower_NPositive_IntegerBase()
        {
            Assert.Equal(8.0, Bai1_Power.Power(2.0, 3), Precision);
            Assert.Equal(81.0, Bai1_Power.Power(3.0, 4), Precision);
        }

        [Fact]
        public void TestPower_NPositive_NegativeBase()
        {
            Assert.Equal(-8.0, Bai1_Power.Power(-2.0, 3), Precision);
            Assert.Equal(16.0, Bai1_Power.Power(-2.0, 4), Precision);
        }

        [Fact]
        public void TestPower_NPositive_DecimalBase()
        {
            Assert.Equal(2.25, Bai1_Power.Power(1.5, 2), Precision);
            Assert.Equal(0.125, Bai1_Power.Power(0.5, 3), Precision);
        }

        [Fact]
        public void TestPower_XIsZero_NPositive()
        {
            Assert.Equal(0.0, Bai1_Power.Power(0.0, 3), Precision);
        }

        [Fact]
        public void TestPower_NNegative_PositiveBase()
        {
            Assert.Equal(0.5, Bai1_Power.Power(2.0, -1), Precision);
            Assert.Equal(0.25, Bai1_Power.Power(2.0, -2), Precision);
            Assert.Equal(0.0625, Bai1_Power.Power(4.0, -2), Precision);
        }

        [Fact]
        public void TestPower_NNegative_NegativeBase()
        {
            Assert.Equal(-0.5, Bai1_Power.Power(-2.0, -1), Precision);
            Assert.Equal(0.25, Bai1_Power.Power(-2.0, -2), Precision);
        }

        [Fact]
        public void TestPower_XIsZero_NNegative_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => Bai1_Power.Power(0.0, -2));
        }

        [Theory]
        [InlineData(2.0, 0, 1.0)]
        [InlineData(2.0, 1, 2.0)]
        [InlineData(2.0, 3, 8.0)]
        [InlineData(2.0, -1, 0.5)]
        [InlineData(2.0, -2, 0.25)]
        [InlineData(-3.0, 2, 9.0)]
        [InlineData(-3.0, 3, -27.0)]
        [InlineData(10.0, 2, 100.0)]
        public void TestPower_Theory(double x, int n, double expected)
        {
            double actual = Bai1_Power.Power(x, n);
            Assert.Equal(expected, actual, Precision);
        }

        [Fact]
        public void TestPower_DemonstrateBugInLabSnippet()
        {
            // Kiểm tra đoạn code mẫu in trong đề bài (nhân n thay vì nhân x)
            double bugResult = Bai1_Power.PowerFromLabDoc(2.0, 3);
            Assert.NotEqual(8.0, bugResult);
            Assert.Equal(6.0, bugResult, Precision);
        }
    }
}
