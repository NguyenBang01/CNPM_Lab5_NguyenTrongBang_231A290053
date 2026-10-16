using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5_Exercises;

namespace Lab5_Exercises.Tests
{
    [TestClass]
    public class Bai3_RadixTests
    {
        #region Kiểm thử ngoại lệ đầu vào

        [TestMethod]
        public void TestConstructor_NegativeNumber_ThrowsArgumentException()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                new Radix(-1);
            });
            Assert.AreEqual("Incorrect Value", ex.Message);
        }

        [TestMethod]
        public void TestConvert_RadixLessThan2_ThrowsArgumentException()
        {
            var r = new Radix(10);
            var ex1 = Assert.ThrowsException<ArgumentException>(() => r.ConvertDecimalToAnother(1));
            Assert.AreEqual("Invalid Radix", ex1.Message);

            var ex0 = Assert.ThrowsException<ArgumentException>(() => r.ConvertDecimalToAnother(0));
            Assert.AreEqual("Invalid Radix", ex0.Message);

            var exNeg = Assert.ThrowsException<ArgumentException>(() => r.ConvertDecimalToAnother(-5));
            Assert.AreEqual("Invalid Radix", exNeg.Message);
        }

        [TestMethod]
        public void TestConvert_RadixGreaterThan16_ThrowsArgumentException()
        {
            var r = new Radix(10);
            var ex = Assert.ThrowsException<ArgumentException>(() => r.ConvertDecimalToAnother(17));
            Assert.AreEqual("Invalid Radix", ex.Message);
        }

        #endregion

        #region Kiểm thử chuyển đổi cơ số 2 (Nhị phân)

        [TestMethod]
        public void TestConvert_DecimalToBinary_DefaultRadix()
        {
            var r = new Radix(10);
            Assert.AreEqual("1010", r.ConvertDecimalToAnother());
        }

        [TestMethod]
        public void TestConvert_DecimalToBinary_Explicit()
        {
            var r1 = new Radix(13);
            Assert.AreEqual("1101", r1.ConvertDecimalToAnother(2));

            var r2 = new Radix(1);
            Assert.AreEqual("1", r2.ConvertDecimalToAnother(2));

            var r3 = new Radix(16);
            Assert.AreEqual("10000", r3.ConvertDecimalToAnother(2));
        }

        #endregion

        #region Kiểm thử chuyển đổi cơ số 8 (Bát phân)

        [TestMethod]
        public void TestConvert_DecimalToOctal()
        {
            var r1 = new Radix(10);
            Assert.AreEqual("12", r1.ConvertDecimalToAnother(8));

            var r2 = new Radix(64);
            Assert.AreEqual("100", r2.ConvertDecimalToAnother(8));

            var r3 = new Radix(83);
            Assert.AreEqual("123", r3.ConvertDecimalToAnother(8));
        }

        #endregion

        #region Kiểm thử chuyển đổi cơ số 16 (Thập lục phân - Hex)

        [TestMethod]
        public void TestConvert_DecimalToHex()
        {
            // Kiểm tra các ký tự A -> F
            Assert.AreEqual("A", new Radix(10).ConvertDecimalToAnother(16));
            Assert.AreEqual("B", new Radix(11).ConvertDecimalToAnother(16));
            Assert.AreEqual("C", new Radix(12).ConvertDecimalToAnother(16));
            Assert.AreEqual("D", new Radix(13).ConvertDecimalToAnother(16));
            Assert.AreEqual("E", new Radix(14).ConvertDecimalToAnother(16));
            Assert.AreEqual("F", new Radix(15).ConvertDecimalToAnother(16));

            // Số lớn hơn
            Assert.AreEqual("10", new Radix(16).ConvertDecimalToAnother(16));
            Assert.AreEqual("FF", new Radix(255).ConvertDecimalToAnother(16));
            Assert.AreEqual("100", new Radix(256).ConvertDecimalToAnother(16));
            Assert.AreEqual("ABC", new Radix(2748).ConvertDecimalToAnother(16));
        }

        #endregion

        #region Kiểm thử trường hợp biên số 0

        [TestMethod]
        public void TestConvert_Zero()
        {
            var r = new Radix(0);
            Assert.AreEqual("0", r.ConvertDecimalToAnother(2));
            Assert.AreEqual("0", r.ConvertDecimalToAnother(8));
            Assert.AreEqual("0", r.ConvertDecimalToAnother(16));
        }

        #endregion

        #region Data-Driven Tests cho hàm đổi cơ số

        [DataTestMethod]
        [DataRow(10, 2, "1010")]
        [DataRow(15, 2, "1111")]
        [DataRow(10, 8, "12")]
        [DataRow(64, 8, "100")]
        [DataRow(1234, 10, "1234")]
        [DataRow(255, 16, "FF")]
        [DataRow(26, 16, "1A")]
        public void TestConvert_DataDriven(int number, int radix, string expected)
        {
            var r = new Radix(number);
            Assert.AreEqual(expected, r.ConvertDecimalToAnother(radix));
        }

        #endregion
    }
}
