using System;
using System.Collections.Generic;
using Lab5_Exercises;
using Xunit;

namespace Lab5_Exercises.xUnitTests
{
    public class Bai2_PolynomialTests
    {
        [Fact]
        public void TestConstructor_NegativeN_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Polynomial(-1, new List<int>()));
            Assert.Equal("Invalid Data", ex.Message);
        }

        [Fact]
        public void TestConstructor_NotEnoughCoefficients_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Polynomial(2, new List<int> { 1, 2 }));
            Assert.Equal("Invalid Data", ex.Message);
        }

        [Fact]
        public void TestConstructor_TooManyCoefficients_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Polynomial(1, new List<int> { 1, 2, 3 }));
            Assert.Equal("Invalid Data", ex.Message);
        }

        [Fact]
        public void TestConstructor_NullList_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Polynomial(1, null!));
            Assert.Equal("Invalid Data", ex.Message);
        }

        [Fact]
        public void TestConstructor_ValidData_CreatesObjectSuccessfully()
        {
            var p = new Polynomial(2, new List<int> { 1, 2, 3 });
            Assert.NotNull(p);
            Assert.Equal(2, p.N);
            Assert.Equal(3, p.A.Count);
        }

        [Fact]
        public void TestCal_DegreeZero()
        {
            var p = new Polynomial(0, new List<int> { 7 });
            Assert.Equal(7, p.Cal(0));
            Assert.Equal(7, p.Cal(5));
            Assert.Equal(7, p.Cal(-3));
        }

        [Fact]
        public void TestCal_DegreeOne()
        {
            var p = new Polynomial(1, new List<int> { 2, 3 });
            Assert.Equal(14, p.Cal(4));
            Assert.Equal(2, p.Cal(0));
            Assert.Equal(-4, p.Cal(-2));
        }

        [Fact]
        public void TestCal_DegreeTwo()
        {
            var p = new Polynomial(2, new List<int> { 1, 2, 3 });
            Assert.Equal(17, p.Cal(2));
            Assert.Equal(9, p.Cal(-2));
        }

        [Fact]
        public void TestCal_NegativeCoefficients()
        {
            var p = new Polynomial(3, new List<int> { -5, 0, 2, -1 });
            Assert.Equal(-5, p.Cal(2));
            Assert.Equal(-2, p.Cal(-1));
        }
    }
}
