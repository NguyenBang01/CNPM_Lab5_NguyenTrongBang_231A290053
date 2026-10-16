using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTester
{
    [TestClass]
    public class UnitTest1
    {
        private Calculation cal = null!;

        public TestContext TestContext { get; set; } = null!;

        [TestInitialize]
        public void SetUp()
        {
            this.cal = new Calculation(10, 5);
        }

        [TestMethod]
        public void TestAddOperator()
        {
            Assert.AreEqual(cal.Execute("+"), 15);
        }

        [TestMethod]
        public void TestSubOperator()
        {
            Assert.AreEqual(cal.Execute("-"), 5);
        }

        [TestMethod]
        public void TestMulOperator()
        {
            Assert.AreEqual(cal.Execute("*"), 50);
        }

        [TestMethod]
        public void TestDivOperator()
        {
            Assert.AreEqual(cal.Execute("/"), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivByZero()
        {
            Calculation c = new Calculation(2, 0);
            c.Execute("/");
        }

        [TestMethod]
        public void TestDivRound()
        {
            Calculation c = new Calculation(5, 3);
            Assert.AreEqual(c.Execute("/"), 2);
        }

        #region Data-Driven Tests (Trang 8-9 trong tài liệu Lab)

        [DataTestMethod]
        [DataRow(3, 4, 7)]
        [DataRow(-7, 6, -1)]
        [DataRow(-3, -7, -10)]
        [DataRow(-5, 5, 0)]
        public void TestWithDataSource_DataRow(int a, int b, int expected)
        {
            Calculation c = new Calculation(a, b);
            int actual = c.Execute("+");
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetCsvRows()
        {
            string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "TestData.csv");
            if (!File.Exists(csvPath))
            {
                // Fallback nếu chạy ở thư mục project
                csvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "TestData.csv");
            }

            var lines = File.ReadAllLines(csvPath).Skip(1); // bỏ header
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(',');
                int a = int.Parse(parts[0].Trim());
                int b = int.Parse(parts[1].Trim());
                int expected = int.Parse(parts[2].Trim());
                yield return new object[] { a, b, expected };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetCsvRows), DynamicDataSourceType.Method)]
        public void TestWithDataSource(int a, int b, int expected)
        {
            Calculation c = new Calculation(a, b);
            int actual = c.Execute("+");
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
