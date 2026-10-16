using System;

namespace Lab5_Exercises
{
    /// <summary>
    /// Lớp Diem trong không gian 2 chiều (hoành độ X và tung độ Y).
    /// </summary>
    public class Diem
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Diem(double x = 0, double y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString() => $"({X}, {Y})";
    }

    /// <summary>
    /// Bài 4: Lớp HinhChuNhat xác định bởi điểm trên bên trái và điểm dưới bên phải.
    /// Có 2 phương thức:
    /// 1. Tính diện tích hình chữ nhật.
    /// 2. Kiểm tra hai hình chữ nhật có giao nhau hay không?
    /// </summary>
    public class HinhChuNhat
    {
        public Diem DiemTrenBenTrai { get; set; }
        public Diem DiemDuoiBenPhai { get; set; }

        public HinhChuNhat(Diem diemTrenBenTrai, Diem diemDuoiBenPhai)
        {
            if (diemTrenBenTrai == null || diemDuoiBenPhai == null)
            {
                throw new ArgumentNullException("Tọa độ điểm không được null");
            }

            this.DiemTrenBenTrai = diemTrenBenTrai;
            this.DiemDuoiBenPhai = diemDuoiBenPhai;
        }

        public double ChieuRong => Math.Abs(DiemDuoiBenPhai.X - DiemTrenBenTrai.X);
        public double ChieuCao => Math.Abs(DiemTrenBenTrai.Y - DiemDuoiBenPhai.Y);

        /// <summary>
        /// Tính diện tích hình chữ nhật = Chiều rộng * Chiều cao.
        /// </summary>
        public double TinhDienTich()
        {
            return ChieuRong * ChieuCao;
        }

        /// <summary>
        /// Kiểm tra hai hình chữ nhật có giao nhau hay không.
        /// </summary>
        public bool KiemTraGiaoNhau(HinhChuNhat hcn)
        {
            if (hcn == null)
            {
                throw new ArgumentNullException(nameof(hcn), "Hình chữ nhật so sánh không được null");
            }

            double left1 = Math.Min(DiemTrenBenTrai.X, DiemDuoiBenPhai.X);
            double right1 = Math.Max(DiemTrenBenTrai.X, DiemDuoiBenPhai.X);
            double bottom1 = Math.Min(DiemTrenBenTrai.Y, DiemDuoiBenPhai.Y);
            double top1 = Math.Max(DiemTrenBenTrai.Y, DiemDuoiBenPhai.Y);

            double left2 = Math.Min(hcn.DiemTrenBenTrai.X, hcn.DiemDuoiBenPhai.X);
            double right2 = Math.Max(hcn.DiemTrenBenTrai.X, hcn.DiemDuoiBenPhai.X);
            double bottom2 = Math.Min(hcn.DiemTrenBenTrai.Y, hcn.DiemDuoiBenPhai.Y);
            double top2 = Math.Max(hcn.DiemTrenBenTrai.Y, hcn.DiemDuoiBenPhai.Y);

            // Hai hình chữ nhật không giao nhau khi nằm tách biệt hoàn toàn về phía trái, phải, trên hoặc dưới
            if (right1 < left2 || right2 < left1 || top1 < bottom2 || top2 < bottom1)
            {
                return false;
            }

            return true;
        }
    }
}
