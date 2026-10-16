using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5_Exercises;

namespace Lab5_Exercises.Tests
{
    [TestClass]
    public class Bai1_PowerTests
    {
        private const double Delta = 1e-6;

        #region Kiểm thử trường hợp n = 0

        [TestMethod]
        public void TestPower_NZero_ReturnsOne()
        {
            Assert.AreEqual(1.0, Bai1_Power.Power(2.0, 0), Delta);
            Assert.AreEqual(1.0, Bai1_Power.Power(-5.0, 0), Delta);
            Assert.AreEqual(1.0, Bai1_Power.Power(10.5, 0), Delta);
            Assert.AreEqual(1.0, Bai1_Power.Power(0.0, 0), Delta);
        }

        #endregion

        #region Kiểm thử trường hợp n > 0

        [TestMethod]
        public void TestPower_NPositive_IntegerBase()
        {
            // 2^3 = 8
            Assert.AreEqual(8.0, Bai1_Power.Power(2.0, 3), Delta);
            // 3^4 = 81
            Assert.AreEqual(81.0, Bai1_Power.Power(3.0, 4), Delta);
        }

        [TestMethod]
        public void TestPower_NPositive_NegativeBase()
        {
            // (-2)^3 = -8
            Assert.AreEqual(-8.0, Bai1_Power.Power(-2.0, 3), Delta);
            // (-2)^4 = 16
            Assert.AreEqual(16.0, Bai1_Power.Power(-2.0, 4), Delta);
        }

        [TestMethod]
        public void TestPower_NPositive_DecimalBase()
        {
            // (1.5)^2 = 2.25
            Assert.AreEqual(2.25, Bai1_Power.Power(1.5, 2), Delta);
            // (0.5)^3 = 0.125
            Assert.AreEqual(0.125, Bai1_Power.Power(0.5, 3), Delta);
        }

        [TestMethod]
        public void TestPower_XIsZero_NPositive()
        {
            // 0^3 = 0
            Assert.AreEqual(0.0, Bai1_Power.Power(0.0, 3), Delta);
        }

        #endregion

        #region Kiểm thử trường hợp n < 0

        [TestMethod]
        public void TestPower_NNegative_PositiveBase()
        {
            // 2^(-1) = 0.5
            Assert.AreEqual(0.5, Bai1_Power.Power(2.0, -1), Delta);
            // 2^(-2) = 0.25
            Assert.AreEqual(0.25, Bai1_Power.Power(2.0, -2), Delta);
            // 4^(-2) = 0.0625
            Assert.AreEqual(0.0625, Bai1_Power.Power(4.0, -2), Delta);
        }

        [TestMethod]
        public void TestPower_NNegative_NegativeBase()
        {
            // (-2)^(-1) = -0.5
            Assert.AreEqual(-0.5, Bai1_Power.Power(-2.0, -1), Delta);
            // (-2)^(-2) = 0.25
            Assert.AreEqual(0.25, Bai1_Power.Power(-2.0, -2), Delta);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestPower_XIsZero_NNegative_ThrowsDivideByZeroException()
        {
            // 0^(-2) = chia cho 0 -> ngoại lệ
            Bai1_Power.Power(0.0, -2);
        }

        #endregion

        #region Data-Driven Tests cho hàm Power

        [DataTestMethod]
        [DataRow(2.0, 0, 1.0)]
        [DataRow(2.0, 1, 2.0)]
        [DataRow(2.0, 3, 8.0)]
        [DataRow(2.0, -1, 0.5)]
        [DataRow(2.0, -2, 0.25)]
        [DataRow(-3.0, 2, 9.0)]
        [DataRow(-3.0, 3, -27.0)]
        [DataRow(10.0, 2, 100.0)]
        public void TestPower_DataDriven(double x, int n, double expected)
        {
            double actual = Bai1_Power.Power(x, n);
            Assert.AreEqual(expected, actual, Delta);
        }

        #endregion

        #region Kiểm tra phát hiện lỗi code mẫu trong tài liệu đề bài

        [TestMethod]
        public void TestPower_DemonstrateBugInLabSnippet()
        {
            // Code trong tài liệu Lab in nhầm 'n * Power' thay vì 'x * Power'
            // 2^3 mong muốn là 8, nhưng code mẫu trả về 3! = 6
            double bugResult = Bai1_Power.PowerFromLabDoc(2.0, 3);
            Assert.AreNotEqual(8.0, bugResult, "Phát hiện lỗi logic trong đoạn mã in trên tài liệu đề bài");
            Assert.AreEqual(6.0, bugResult, Delta);
        }

        #endregion
    }
}
