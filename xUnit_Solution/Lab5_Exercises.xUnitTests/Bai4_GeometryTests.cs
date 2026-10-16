using System;
using Lab5_Exercises;
using Xunit;

namespace Lab5_Exercises.xUnitTests
{
    public class Bai4_GeometryTests
    {
        private const int Precision = 5;

        [Fact]
        public void TestDiem_Properties()
        {
            var d = new Diem(3.5, -4.2);
            Assert.Equal(3.5, d.X, Precision);
            Assert.Equal(-4.2, d.Y, Precision);
        }

        [Fact]
        public void TestHinhChuNhat_NullPoints_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new HinhChuNhat(null!, new Diem(1, 1)));
        }

        [Fact]
        public void TestTinhDienTich_StandardRectangle()
        {
            var hcn = new HinhChuNhat(new Diem(0, 10), new Diem(5, 0));
            Assert.Equal(50.0, hcn.TinhDienTich(), Precision);
        }

        [Fact]
        public void TestTinhDienTich_Square()
        {
            var hcn = new HinhChuNhat(new Diem(-2, 2), new Diem(2, -2));
            Assert.Equal(16.0, hcn.TinhDienTich(), Precision);
        }

        [Fact]
        public void TestTinhDienTich_ZeroDimension()
        {
            var hcn = new HinhChuNhat(new Diem(3, 10), new Diem(3, 0));
            Assert.Equal(0.0, hcn.TinhDienTich(), Precision);
        }

        [Fact]
        public void TestKiemTraGiaoNhau_Overlapping()
        {
            var hcn1 = new HinhChuNhat(new Diem(0, 10), new Diem(10, 0));
            var hcn2 = new HinhChuNhat(new Diem(5, 5), new Diem(15, -5));

            Assert.True(hcn1.KiemTraGiaoNhau(hcn2));
            Assert.True(hcn2.KiemTraGiaoNhau(hcn1));
        }

        [Fact]
        public void TestKiemTraGiaoNhau_OneInsideAnother()
        {
            var hcn1 = new HinhChuNhat(new Diem(0, 10), new Diem(10, 0));
            var hcn2 = new HinhChuNhat(new Diem(2, 8), new Diem(8, 2));

            Assert.True(hcn1.KiemTraGiaoNhau(hcn2));
            Assert.True(hcn2.KiemTraGiaoNhau(hcn1));
        }

        [Fact]
        public void TestKiemTraGiaoNhau_Disjoint_Horizontal()
        {
            var hcn1 = new HinhChuNhat(new Diem(0, 10), new Diem(5, 0));
            var hcn2 = new HinhChuNhat(new Diem(6, 10), new Diem(11, 0));

            Assert.False(hcn1.KiemTraGiaoNhau(hcn2));
            Assert.False(hcn2.KiemTraGiaoNhau(hcn1));
        }

        [Fact]
        public void TestKiemTraGiaoNhau_Disjoint_Vertical()
        {
            var hcn1 = new HinhChuNhat(new Diem(0, 10), new Diem(5, 6));
            var hcn2 = new HinhChuNhat(new Diem(0, 4), new Diem(5, 0));

            Assert.False(hcn1.KiemTraGiaoNhau(hcn2));
            Assert.False(hcn2.KiemTraGiaoNhau(hcn1));
        }

        [Fact]
        public void TestKiemTraGiaoNhau_TouchingEdges()
        {
            var hcn1 = new HinhChuNhat(new Diem(0, 10), new Diem(5, 0));
            var hcn2 = new HinhChuNhat(new Diem(5, 10), new Diem(10, 0));

            Assert.True(hcn1.KiemTraGiaoNhau(hcn2));
        }

        [Fact]
        public void TestKiemTraGiaoNhau_NullArgument_ThrowsArgumentNullException()
        {
            var hcn = new HinhChuNhat(new Diem(0, 5), new Diem(5, 0));
            Assert.Throws<ArgumentNullException>(() => hcn.KiemTraGiaoNhau(null!));
        }
    }
}
