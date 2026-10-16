using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5_Exercises;

namespace Lab5_Exercises.Tests
{
    [TestClass]
    public class Bai4_GeometryTests
    {
        private const double Delta = 1e-6;

        #region Kiểm thử lớp Diem và khởi tạo HinhChuNhat

        [TestMethod]
        public void TestDiem_Properties()
        {
            var d = new Diem(3.5, -4.2);
            Assert.AreEqual(3.5, d.X, Delta);
            Assert.AreEqual(-4.2, d.Y, Delta);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHinhChuNhat_NullPoints_ThrowsArgumentNullException()
        {
            new HinhChuNhat(null!, new Diem(1, 1));
        }

        #endregion

        #region Kiểm thử tính diện tích hình chữ nhật

        [TestMethod]
        public void TestTinhDienTich_StandardRectangle()
        {
            // Điểm trên bên trái (0, 10), điểm dưới bên phải (5, 0) -> Rộng 5, Cao 10 -> Diện tích 50
            var hcn = new HinhChuNhat(new Diem(0, 10), new Diem(5, 0));
            Assert.AreEqual(50.0, hcn.TinhDienTich(), Delta);
        }

        [TestMethod]
        public void TestTinhDienTich_Square()
        {
            // Điểm (-2, 2) đến (2, -2) -> Rộng 4, Cao 4 -> Diện tích 16
            var hcn = new HinhChuNhat(new Diem(-2, 2), new Diem(2, -2));
            Assert.AreEqual(16.0, hcn.TinhDienTich(), Delta);
        }

        [TestMethod]
        public void TestTinhDienTich_ZeroDimension()
        {
            // Đoạn thẳng (rộng = 0)
            var hcn = new HinhChuNhat(new Diem(3, 10), new Diem(3, 0));
            Assert.AreEqual(0.0, hcn.TinhDienTich(), Delta);
        }

        #endregion

        #region Kiểm thử hai hình chữ nhật giao nhau

        [TestMethod]
        public void TestKiemTraGiaoNhau_Overlapping()
        {
            // HCN 1: (0, 10) -> (10, 0)
            // HCN 2: (5, 5) -> (15, -5) -> Giao nhau tại [5, 10] x [0, 5]
            var hcn1 = new HinhChuNhat(new Diem(0, 10), new Diem(10, 0));
            var hcn2 = new HinhChuNhat(new Diem(5, 5), new Diem(15, -5));

            Assert.IsTrue(hcn1.KiemTraGiaoNhau(hcn2));
            Assert.IsTrue(hcn2.KiemTraGiaoNhau(hcn1));
        }

        [TestMethod]
        public void TestKiemTraGiaoNhau_OneInsideAnother()
        {
            // HCN 2 nằm lọt bên trong HCN 1
            var hcn1 = new HinhChuNhat(new Diem(0, 10), new Diem(10, 0));
            var hcn2 = new HinhChuNhat(new Diem(2, 8), new Diem(8, 2));

            Assert.IsTrue(hcn1.KiemTraGiaoNhau(hcn2));
            Assert.IsTrue(hcn2.KiemTraGiaoNhau(hcn1));
        }

        [TestMethod]
        public void TestKiemTraGiaoNhau_Disjoint_Horizontal()
        {
            // HCN 1: X từ 0 đến 5
            // HCN 2: X từ 6 đến 11 -> Không giao nhau theo chiều ngang
            var hcn1 = new HinhChuNhat(new Diem(0, 10), new Diem(5, 0));
            var hcn2 = new HinhChuNhat(new Diem(6, 10), new Diem(11, 0));

            Assert.IsFalse(hcn1.KiemTraGiaoNhau(hcn2));
            Assert.IsFalse(hcn2.KiemTraGiaoNhau(hcn1));
        }

        [TestMethod]
        public void TestKiemTraGiaoNhau_Disjoint_Vertical()
        {
            // HCN 1: Y từ 6 đến 10
            // HCN 2: Y từ 0 đến 4 -> Không giao nhau theo chiều dọc
            var hcn1 = new HinhChuNhat(new Diem(0, 10), new Diem(5, 6));
            var hcn2 = new HinhChuNhat(new Diem(0, 4), new Diem(5, 0));

            Assert.IsFalse(hcn1.KiemTraGiaoNhau(hcn2));
            Assert.IsFalse(hcn2.KiemTraGiaoNhau(hcn1));
        }

        [TestMethod]
        public void TestKiemTraGiaoNhau_TouchingEdges()
        {
            // HCN 1: (0, 10) -> (5, 0)
            // HCN 2: (5, 10) -> (10, 0) -> Tiếp xúc mép X = 5
            var hcn1 = new HinhChuNhat(new Diem(0, 10), new Diem(5, 0));
            var hcn2 = new HinhChuNhat(new Diem(5, 10), new Diem(10, 0));

            Assert.IsTrue(hcn1.KiemTraGiaoNhau(hcn2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestKiemTraGiaoNhau_NullArgument_ThrowsArgumentNullException()
        {
            var hcn = new HinhChuNhat(new Diem(0, 5), new Diem(5, 0));
            hcn.KiemTraGiaoNhau(null!);
        }

        #endregion
    }
}
