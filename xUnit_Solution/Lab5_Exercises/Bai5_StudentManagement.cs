using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5_Exercises
{
    /// <summary>
    /// Lớp biểu diễn thông tin một học viên tại trung tâm gia sư.
    /// </summary>
    public class HocVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public string QueQuan { get; set; }
        public double DiemMon1 { get; set; }
        public double DiemMon2 { get; set; }
        public double DiemMon3 { get; set; }

        public HocVien(string maSo, string hoTen, string queQuan, double diemMon1, double diemMon2, double diemMon3)
        {
            if (string.IsNullOrWhiteSpace(maSo))
                throw new ArgumentException("Mã số học viên không được để trống", nameof(maSo));

            if (string.IsNullOrWhiteSpace(hoTen))
                throw new ArgumentException("Họ tên học viên không được để trống", nameof(hoTen));

            KiemTraDiemHopLe(diemMon1, nameof(diemMon1));
            KiemTraDiemHopLe(diemMon2, nameof(diemMon2));
            KiemTraDiemHopLe(diemMon3, nameof(diemMon3));

            this.MaSo = maSo.Trim();
            this.HoTen = hoTen.Trim();
            this.QueQuan = queQuan?.Trim() ?? string.Empty;
            this.DiemMon1 = diemMon1;
            this.DiemMon2 = diemMon2;
            this.DiemMon3 = diemMon3;
        }

        private static void KiemTraDiemHopLe(double diem, string tenThamSo)
        {
            if (diem < 0.0 || diem > 10.0)
            {
                throw new ArgumentOutOfRangeException(tenThamSo, "Điểm phải nằm trong thang điểm từ 0 đến 10");
            }
        }

        /// <summary>
        /// Tính điểm trung bình của ba môn học chính (làm tròn 2 chữ số thập phân).
        /// </summary>
        public double TinhDiemTrungBinh()
        {
            return Math.Round((DiemMon1 + DiemMon2 + DiemMon3) / 3.0, 2);
        }

        /// <summary>
        /// Đánh giá học viên có đạt tiêu chuẩn nhận học bổng hay không.
        /// Tiêu chuẩn:
        /// - Điểm trung bình ba môn học chính từ 8.0 trở lên.
        /// - Không có môn nào trong ba môn chính điểm dưới 5.0.
        /// </summary>
        public bool XetHocBong()
        {
            double dtb = (DiemMon1 + DiemMon2 + DiemMon3) / 3.0;
            // Làm tròn nhẹ sai số số thực để tránh 7.999999999999999
            bool dtbDat = Math.Round(dtb, 6) >= 8.0;
            bool khongLiet = DiemMon1 >= 5.0 && DiemMon2 >= 5.0 && DiemMon3 >= 5.0;

            return dtbDat && khongLiet;
        }

        public override string ToString()
        {
            return $"[{MaSo}] {HoTen} - Quê quán: {QueQuan} | Điểm: {DiemMon1:F1}, {DiemMon2:F1}, {DiemMon3:F1} | ĐTB: {TinhDiemTrungBinh():F2} | Học bổng: {(XetHocBong() ? "Có" : "Không")}";
        }
    }

    /// <summary>
    /// Lớp quản lý danh sách học viên và xét trao học bổng khuyến khích.
    /// </summary>
    public class QuanLyHocVien
    {
        private readonly List<HocVien> danhSachHocVien = new List<HocVien>();

        public IReadOnlyList<HocVien> LayDanhSachTatCa()
        {
            return danhSachHocVien.AsReadOnly();
        }

        /// <summary>
        /// Thêm học viên vào danh sách.
        /// </summary>
        public void ThemHocVien(HocVien hv)
        {
            if (hv == null)
            {
                throw new ArgumentNullException(nameof(hv), "Học viên không được null");
            }

            if (danhSachHocVien.Any(x => x.MaSo.Equals(hv.MaSo, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Mã số học viên '{hv.MaSo}' đã tồn tại trong hệ thống");
            }

            danhSachHocVien.Add(hv);
        }

        /// <summary>
        /// Lọc và trả về danh sách các học viên thỏa mãn điều kiện nhận học bổng khuyến khích.
        /// </summary>
        public List<HocVien> LayDanhSachNhanHocBong()
        {
            return danhSachHocVien.Where(hv => hv.XetHocBong()).ToList();
        }

        public void XoaTatCa()
        {
            danhSachHocVien.Clear();
        }
    }
}
