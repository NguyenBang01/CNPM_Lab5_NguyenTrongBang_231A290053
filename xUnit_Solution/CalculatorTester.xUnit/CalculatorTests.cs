using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Calculator;
using Xunit;

namespace CalculatorTester.xUnit
{
    public class CalculatorTests
    {
        private readonly Calculation cal;

        public CalculatorTests()
        {
            // Tương đương [TestInitialize] trong MSTest
            this.cal = new Calculation(10, 5);
        }

        [Fact]
        public void TestAddOperator()
        {
            Assert.Equal(15, cal.Execute("+"));
        }

        [Fact]
        public void TestSubOperator()
        {
            Assert.Equal(5, cal.Execute("-"));
        }

        [Fact]
        public void TestMulOperator()
        {
            Assert.Equal(50, cal.Execute("*"));
        }

        [Fact]
        public void TestDivOperator()
        {
            Assert.Equal(2, cal.Execute("/"));
        }

        [Fact]
        public void TestDivByZero()
        {
            Calculation c = new Calculation(2, 0);
            Assert.Throws<DivideByZeroException>(() => c.Execute("/"));
        }

        [Fact]
        public void TestDivRound()
        {
            // Kiểm tra làm tròn kết quả phép chia: 5/3 = 1.666... -> làm tròn thành 2
            Calculation c = new Calculation(5, 3);
            Assert.Equal(2, c.Execute("/"));
        }

        #region Data-Driven Tests với xUnit ([Theory] + [InlineData] & [MemberData])

        [Theory]
        [InlineData(3, 4, 7)]
        [InlineData(-7, 6, -1)]
        [InlineData(-3, -7, -10)]
        [InlineData(-5, 5, 0)]
        public void TestWithDataSource_InlineData(int a, int b, int expected)
        {
            Calculation c = new Calculation(a, b);
            int actual = c.Execute("+");
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetCsvRows()
        {
            string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "TestData.csv");
            if (!File.Exists(csvPath))
            {
                csvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "TestData.csv");
            }

            var lines = File.ReadAllLines(csvPath).Skip(1);
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

        [Theory]
        [MemberData(nameof(GetCsvRows))]
        public void TestWithDataSource_FromCsv(int a, int b, int expected)
        {
            Calculation c = new Calculation(a, b);
            int actual = c.Execute("+");
            Assert.Equal(expected, actual);
        }

        #endregion
    }
}
