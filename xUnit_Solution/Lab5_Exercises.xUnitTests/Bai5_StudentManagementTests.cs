using System;
using System.Collections.Generic;
using Lab5_Exercises;
using Xunit;

namespace Lab5_Exercises.xUnitTests
{
    public class Bai5_StudentManagementTests
    {
        private const int Precision = 2;

        [Fact]
        public void TestHocVien_ValidInfo()
        {
            var hv = new HocVien("HV01", "Nguyễn Văn A", "TP.HCM", 8.0, 8.5, 9.0);
            Assert.Equal("HV01", hv.MaSo);
            Assert.Equal("Nguyễn Văn A", hv.HoTen);
            Assert.Equal("TP.HCM", hv.QueQuan);
            Assert.Equal(8.0, hv.DiemMon1);
            Assert.Equal(8.5, hv.DiemMon2);
            Assert.Equal(9.0, hv.DiemMon3);
        }

        [Fact]
        public void TestHocVien_EmptyMaSo_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new HocVien("", "Nguyễn Văn A", "TP.HCM", 8.0, 8.0, 8.0));
        }

        [Fact]
        public void TestHocVien_EmptyHoTen_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new HocVien("HV01", "   ", "TP.HCM", 8.0, 8.0, 8.0));
        }

        [Fact]
        public void TestHocVien_NegativeScore_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new HocVien("HV01", "Nguyễn Văn A", "TP.HCM", -1.0, 8.0, 8.0));
        }

        [Fact]
        public void TestHocVien_ScoreGreaterThan10_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new HocVien("HV01", "Nguyễn Văn A", "TP.HCM", 8.0, 10.5, 8.0));
        }

        [Fact]
        public void TestHocVien_TinhDiemTrungBinh()
        {
            var hv = new HocVien("HV01", "Nguyễn Văn A", "Hà Nội", 8.0, 9.0, 7.0);
            Assert.Equal(8.0, hv.TinhDiemTrungBinh(), Precision);

            var hv2 = new HocVien("HV02", "Trần Thị B", "Đà Nẵng", 8.0, 8.0, 9.0);
            Assert.Equal(8.33, hv2.TinhDiemTrungBinh(), Precision);
        }

        [Fact]
        public void TestXetHocBong_DuDieuKien_TraVeTrue()
        {
            var hv = new HocVien("HV01", "Trần Văn Khá", "Hải Phòng", 8.0, 8.5, 9.0);
            Assert.True(hv.XetHocBong());
        }

        [Fact]
        public void TestXetHocBong_DiemChuanBien8Va5_TraVeTrue()
        {
            var hv = new HocVien("HV02", "Lê Văn Chuẩn", "Cần Thơ", 9.5, 9.5, 5.0);
            Assert.True(hv.XetHocBong());
        }

        [Fact]
        public void TestXetHocBong_DiemTBHon8_NhungCoMonDuoi5_TraVeFalse()
        {
            var hv = new HocVien("HV03", "Phạm Văn Lệch", "Nam Định", 10.0, 10.0, 4.9);
            Assert.False(hv.XetHocBong());
        }

        [Fact]
        public void TestXetHocBong_DiemTBDuoi8_KhongCoMonLiet_TraVeFalse()
        {
            var hv = new HocVien("HV04", "Võ Văn Suýt", "Bình Định", 7.9, 8.0, 8.0);
            Assert.False(hv.XetHocBong());
        }

        [Fact]
        public void TestXetHocBong_TatCaDiem10_TraVeTrue()
        {
            var hv = new HocVien("HV05", "Đỗ Thủ Khoa", "Huế", 10.0, 10.0, 10.0);
            Assert.True(hv.XetHocBong());
        }

        [Fact]
        public void TestQuanLyHocVien_ThemHocVienVaLocHocBong()
        {
            var ql = new QuanLyHocVien();

            var hv1 = new HocVien("HV01", "Nguyễn Văn A", "TP.HCM", 8.0, 8.5, 9.0);
            var hv2 = new HocVien("HV02", "Trần Văn B", "Hà Nội", 10.0, 10.0, 4.5);
            var hv3 = new HocVien("HV03", "Lê Văn C", "Đà Nẵng", 7.0, 7.0, 7.0);
            var hv4 = new HocVien("HV04", "Hoàng Thị D", "Cần Thơ", 9.0, 9.0, 9.0);

            ql.ThemHocVien(hv1);
            ql.ThemHocVien(hv2);
            ql.ThemHocVien(hv3);
            ql.ThemHocVien(hv4);

            Assert.Equal(4, ql.LayDanhSachTatCa().Count);

            var dsHocBong = ql.LayDanhSachNhanHocBong();
            Assert.Equal(2, dsHocBong.Count);
            Assert.Contains(hv1, dsHocBong);
            Assert.Contains(hv4, dsHocBong);
            Assert.DoesNotContain(hv2, dsHocBong);
            Assert.DoesNotContain(hv3, dsHocBong);
        }

        [Fact]
        public void TestQuanLyHocVien_ThemNull_ThrowsException()
        {
            var ql = new QuanLyHocVien();
            Assert.Throws<ArgumentNullException>(() => ql.ThemHocVien(null!));
        }

        [Fact]
        public void TestQuanLyHocVien_TrungMaSo_ThrowsException()
        {
            var ql = new QuanLyHocVien();
            ql.ThemHocVien(new HocVien("HV01", "Học viên 1", "TP.HCM", 8, 8, 8));
            Assert.Throws<InvalidOperationException>(() => ql.ThemHocVien(new HocVien("HV01", "Học viên trùng mã", "Hà Nội", 9, 9, 9)));
        }

        [Fact]
        public void TestQuanLyHocVien_DanhSachRong_TraVeRong()
        {
            var ql = new QuanLyHocVien();
            var ds = ql.LayDanhSachNhanHocBong();
            Assert.NotNull(ds);
            Assert.Empty(ds);
        }
    }
}
