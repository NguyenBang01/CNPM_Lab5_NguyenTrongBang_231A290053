using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5_Exercises;

namespace Lab5_Exercises.Tests
{
    [TestClass]
    public class Bai5_StudentManagementTests
    {
        private const double Delta = 1e-2;

        #region Kiểm thử khởi tạo và validate đối tượng HocVien

        [TestMethod]
        public void TestHocVien_ValidInfo()
        {
            var hv = new HocVien("HV01", "Nguyễn Văn A", "TP.HCM", 8.0, 8.5, 9.0);
            Assert.AreEqual("HV01", hv.MaSo);
            Assert.AreEqual("Nguyễn Văn A", hv.HoTen);
            Assert.AreEqual("TP.HCM", hv.QueQuan);
            Assert.AreEqual(8.0, hv.DiemMon1);
            Assert.AreEqual(8.5, hv.DiemMon2);
            Assert.AreEqual(9.0, hv.DiemMon3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHocVien_EmptyMaSo_ThrowsArgumentException()
        {
            new HocVien("", "Nguyễn Văn A", "TP.HCM", 8.0, 8.0, 8.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHocVien_EmptyHoTen_ThrowsArgumentException()
        {
            new HocVien("HV01", "   ", "TP.HCM", 8.0, 8.0, 8.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestHocVien_NegativeScore_ThrowsArgumentOutOfRangeException()
        {
            new HocVien("HV01", "Nguyễn Văn A", "TP.HCM", -1.0, 8.0, 8.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestHocVien_ScoreGreaterThan10_ThrowsArgumentOutOfRangeException()
        {
            new HocVien("HV01", "Nguyễn Văn A", "TP.HCM", 8.0, 10.5, 8.0);
        }

        #endregion

        #region Kiểm thử tính điểm trung bình

        [TestMethod]
        public void TestHocVien_TinhDiemTrungBinh()
        {
            var hv = new HocVien("HV01", "Nguyễn Văn A", "Hà Nội", 8.0, 9.0, 7.0);
            // (8 + 9 + 7) / 3 = 8.0
            Assert.AreEqual(8.0, hv.TinhDiemTrungBinh(), Delta);

            var hv2 = new HocVien("HV02", "Trần Thị B", "Đà Nẵng", 8.0, 8.0, 9.0);
            // (8 + 8 + 9) / 3 = 8.33
            Assert.AreEqual(8.33, hv2.TinhDiemTrungBinh(), Delta);
        }

        #endregion

        #region Kiểm thử quy tắc xét học bổng khuyến khích

        [TestMethod]
        public void TestXetHocBong_DuDieuKien_TraVeTrue()
        {
            // ĐTB = 8.5 >= 8.0 và cả 3 môn >= 5.0 -> Đạt
            var hv = new HocVien("HV01", "Trần Văn Khá", "Hải Phòng", 8.0, 8.5, 9.0);
            Assert.IsTrue(hv.XetHocBong());
        }

        [TestMethod]
        public void TestXetHocBong_DiemChuanBien8Va5_TraVeTrue()
        {
            // 9.5 + 9.5 + 5.0 = 24.0 -> ĐTB = 8.0 và môn thấp nhất bằng đúng 5.0 -> Đạt
            var hv = new HocVien("HV02", "Lê Văn Chuẩn", "Cần Thơ", 9.5, 9.5, 5.0);
            Assert.IsTrue(hv.XetHocBong());
        }

        [TestMethod]
        public void TestXetHocBong_DiemTBHon8_NhungCoMonDuoi5_TraVeFalse()
        {
            // 10.0 + 10.0 + 4.9 = 24.9 -> ĐTB = 8.30 >= 8.0, nhưng môn 3 bị điểm 4.9 (< 5.0) -> Không đạt
            var hv = new HocVien("HV03", "Phạm Văn Lệch", "Nam Định", 10.0, 10.0, 4.9);
            Assert.IsFalse(hv.XetHocBong());
        }

        [TestMethod]
        public void TestXetHocBong_DiemTBDuoi8_KhongCoMonLiet_TraVeFalse()
        {
            // 7.9 + 8.0 + 8.0 = 23.9 -> ĐTB = 7.97 < 8.0 -> Không đạt
            var hv = new HocVien("HV04", "Võ Văn Suýt", "Bình Định", 7.9, 8.0, 8.0);
            Assert.IsFalse(hv.XetHocBong());
        }

        [TestMethod]
        public void TestXetHocBong_TatCaDiem10_TraVeTrue()
        {
            var hv = new HocVien("HV05", "Đỗ Thủ Khoa", "Huế", 10.0, 10.0, 10.0);
            Assert.IsTrue(hv.XetHocBong());
        }

        #endregion

        #region Kiểm thử lớp QuanLyHocVien

        [TestMethod]
        public void TestQuanLyHocVien_ThemHocVienVaLocHocBong()
        {
            var ql = new QuanLyHocVien();

            // HV1: Đạt học bổng (ĐTB 8.5)
            var hv1 = new HocVien("HV01", "Nguyễn Văn A", "TP.HCM", 8.0, 8.5, 9.0);
            // HV2: Liệt môn (ĐTB 8.3 nhưng điểm 4.5) -> Không đạt
            var hv2 = new HocVien("HV02", "Trần Văn B", "Hà Nội", 10.0, 10.0, 4.5);
            // HV3: ĐTB thấp (ĐTB 7.0) -> Không đạt
            var hv3 = new HocVien("HV03", "Lê Văn C", "Đà Nẵng", 7.0, 7.0, 7.0);
            // HV4: Đạt học bổng (ĐTB 9.0)
            var hv4 = new HocVien("HV04", "Hoàng Thị D", "Cần Thơ", 9.0, 9.0, 9.0);

            ql.ThemHocVien(hv1);
            ql.ThemHocVien(hv2);
            ql.ThemHocVien(hv3);
            ql.ThemHocVien(hv4);

            Assert.AreEqual(4, ql.LayDanhSachTatCa().Count);

            var dsHocBong = ql.LayDanhSachNhanHocBong();
            Assert.AreEqual(2, dsHocBong.Count);
            CollectionAssert.Contains(dsHocBong, hv1);
            CollectionAssert.Contains(dsHocBong, hv4);
            CollectionAssert.DoesNotContain(dsHocBong, hv2);
            CollectionAssert.DoesNotContain(dsHocBong, hv3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestQuanLyHocVien_ThemNull_ThrowsException()
        {
            var ql = new QuanLyHocVien();
            ql.ThemHocVien(null!);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestQuanLyHocVien_TrungMaSo_ThrowsException()
        {
            var ql = new QuanLyHocVien();
            ql.ThemHocVien(new HocVien("HV01", "Học viên 1", "TP.HCM", 8, 8, 8));
            ql.ThemHocVien(new HocVien("HV01", "Học viên trùng mã", "Hà Nội", 9, 9, 9));
        }

        [TestMethod]
        public void TestQuanLyHocVien_DanhSachRong_TraVeRong()
        {
            var ql = new QuanLyHocVien();
            var ds = ql.LayDanhSachNhanHocBong();
            Assert.IsNotNull(ds);
            Assert.AreEqual(0, ds.Count);
        }

        #endregion
    }
}
