using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5_Exercises;

namespace Lab5_Exercises.Tests
{
    [TestClass]
    public class Bai2_PolynomialTests
    {
        #region Kiểm thử ngoại lệ hợp lệ/không hợp lệ đầu vào

        [TestMethod]
        public void TestConstructor_NegativeN_ThrowsArgumentException()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                new Polynomial(-1, new List<int>());
            });
            Assert.AreEqual("Invalid Data", ex.Message);
        }

        [TestMethod]
        public void TestConstructor_NotEnoughCoefficients_ThrowsArgumentException()
        {
            // Bậc n = 2 cần 3 hệ số, chỉ truyền 2 hệ số
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                new Polynomial(2, new List<int> { 1, 2 });
            });
            Assert.AreEqual("Invalid Data", ex.Message);
        }

        [TestMethod]
        public void TestConstructor_TooManyCoefficients_ThrowsArgumentException()
        {
            // Bậc n = 1 cần 2 hệ số, truyền 3 hệ số
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                new Polynomial(1, new List<int> { 1, 2, 3 });
            });
            Assert.AreEqual("Invalid Data", ex.Message);
        }

        [TestMethod]
        public void TestConstructor_NullList_ThrowsArgumentException()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                new Polynomial(1, null!);
            });
            Assert.AreEqual("Invalid Data", ex.Message);
        }

        [TestMethod]
        public void TestConstructor_ValidData_CreatesObjectSuccessfully()
        {
            var p = new Polynomial(2, new List<int> { 1, 2, 3 });
            Assert.IsNotNull(p);
            Assert.AreEqual(2, p.N);
            Assert.AreEqual(3, p.A.Count);
        }

        #endregion

        #region Kiểm thử phương thức Cal(double x)

        [TestMethod]
        public void TestCal_DegreeZero()
        {
            // P(x) = 7
            var p = new Polynomial(0, new List<int> { 7 });
            Assert.AreEqual(7, p.Cal(0));
            Assert.AreEqual(7, p.Cal(5));
            Assert.AreEqual(7, p.Cal(-3));
        }

        [TestMethod]
        public void TestCal_DegreeOne()
        {
            // P(x) = 2 + 3x
            var p = new Polynomial(1, new List<int> { 2, 3 });
            // P(4) = 2 + 12 = 14
            Assert.AreEqual(14, p.Cal(4));
            // P(0) = 2
            Assert.AreEqual(2, p.Cal(0));
            // P(-2) = 2 - 6 = -4
            Assert.AreEqual(-4, p.Cal(-2));
        }

        [TestMethod]
        public void TestCal_DegreeTwo()
        {
            // P(x) = 1 + 2x + 3x^2
            var p = new Polynomial(2, new List<int> { 1, 2, 3 });
            // P(2) = 1 + 4 + 12 = 17
            Assert.AreEqual(17, p.Cal(2));
            // P(-2) = 1 - 4 + 12 = 9
            Assert.AreEqual(9, p.Cal(-2));
        }

        [TestMethod]
        public void TestCal_NegativeCoefficients()
        {
            // P(x) = -5 + 0x + 2x^2 - 1x^3
            var p = new Polynomial(3, new List<int> { -5, 0, 2, -1 });
            // P(2) = -5 + 0 + 8 - 8 = -5
            Assert.AreEqual(-5, p.Cal(2));
            // P(-1) = -5 + 0 + 2 - (-1) = -2
            Assert.AreEqual(-2, p.Cal(-1));
        }

        #endregion
    }
}
