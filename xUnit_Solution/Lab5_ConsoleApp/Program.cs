using System;
using System.Collections.Generic;
using System.Text;
using Calculator;
using Lab5_Exercises;

namespace Lab5_ConsoleApp
{
    internal class Program
    {
        private static QuanLyHocVien qlHocVien = new QuanLyHocVien();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Khởi tạo một số dữ liệu mẫu cho bài 5 để tiện kiểm thử ngay
            NapDuLieuMauHocVien();

            bool exit = false;
            while (!exit)
            {
                if (!Console.IsInputRedirected)
                {
                    try { Console.Clear(); } catch { }
                }

                Console.WriteLine("=======================================================================");
                Console.WriteLine("  BÀI TẬP THỰC HÀNH KIỂM THỬ PHẦN MỀM - LAB UNIT TEST (C#)");
                Console.WriteLine("  Sinh viên: Nguyễn Trọng Bằng - MSSV: 231A290053");
                Console.WriteLine("=======================================================================");
                Console.WriteLine("  [1] Bài 1: Tính lũy thừa x^n bằng đệ quy (Power)");
                Console.WriteLine("  [2] Bài 2: Tính giá trị đa thức bậc n (Polynomial)");
                Console.WriteLine("  [3] Bài 3: Chuyển đổi cơ số 10 sang cơ số k (Radix)");
                Console.WriteLine("  [4] Bài 4: Điểm và Hình chữ nhật (Diện tích, Giao nhau)");
                Console.WriteLine("  [5] Bài 5: Quản lý học viên & Xét học bổng trung tâm gia sư");
                Console.WriteLine("  [6] Demo Calculator: Tính toán đơn giản (+, -, *, / làm tròn)");
                Console.WriteLine("  [0] Thoát chương trình");
                Console.WriteLine("=======================================================================");
                Console.Write("  => Nhập lựa chọn của bạn (0-6): ");

                string choice = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ChayBai1();
                        break;
                    case "2":
                        ChayBai2();
                        break;
                    case "3":
                        ChayBai3();
                        break;
                    case "4":
                        ChayBai4();
                        break;
                    case "5":
                        ChayBai5();
                        break;
                    case "6":
                        ChayDemoCalculator();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        continue;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

                Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu chính...");
                if (!Console.IsInputRedirected)
                {
                    try { Console.ReadKey(); } catch { }
                }
            }
        }

        #region Bài 1: Power
        static void ChayBai1()
        {
            Console.WriteLine("--- BÀI 1: TÍNH LŨY THỪA x^n BẰNG ĐỆ QUY ---");
            Console.Write("Nhập cơ số x (số thực): ");
            if (!double.TryParse(Console.ReadLine(), out double x))
            {
                Console.WriteLine("Cơ số x không hợp lệ!");
                return;
            }

            Console.Write("Nhập số mũ n (số nguyên): ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Số mũ n không hợp lệ!");
                return;
            }

            try
            {
                double ketQua = Bai1_Power.Power(x, n);
                Console.WriteLine($"\nKết quả {x}^{n} = {ketQua}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nLỗi: {ex.Message}");
            }
        }
        #endregion

        #region Bài 2: Polynomial
        static void ChayBai2()
        {
            Console.WriteLine("--- BÀI 2: TÍNH GIÁ TRỊ ĐA THỨC P(x) BẬC n ---");
            Console.Write("Nhập bậc đa thức n: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Bậc n không hợp lệ!");
                return;
            }

            List<int> heSo = new List<int>();
            Console.WriteLine($"Nhập {n + 1} hệ số (từ a0 đến a{n}):");
            for (int i = 0; i <= n; i++)
            {
                Console.Write($"  a[{i}]: ");
                if (int.TryParse(Console.ReadLine(), out int a))
                {
                    heSo.Add(a);
                }
                else
                {
                    Console.WriteLine("Hệ số không hợp lệ!");
                    return;
                }
            }

            Console.Write("Nhập giá trị x: ");
            if (!double.TryParse(Console.ReadLine(), out double x))
            {
                Console.WriteLine("Giá trị x không hợp lệ!");
                return;
            }

            try
            {
                Polynomial p = new Polynomial(n, heSo);
                int ketQua = p.Cal(x);
                Console.WriteLine($"\nGiá trị đa thức P({x}) = {ketQua}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nLỗi: {ex.Message}");
            }
        }
        #endregion

        #region Bài 3: Radix
        static void ChayBai3()
        {
            Console.WriteLine("--- BÀI 3: CHUYỂN ĐỔI SỐ NGUYÊN DƯƠNG CƠ SỐ 10 SANG CƠ SỐ k (2..16) ---");
            Console.Write("Nhập số nguyên cơ số 10 (>= 0): ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Số không hợp lệ!");
                return;
            }

            Console.Write("Nhập cơ số k cần chuyển đổi (2 đến 16): ");
            if (!int.TryParse(Console.ReadLine(), out int radix))
            {
                Console.WriteLine("Cơ số k không hợp lệ!");
                return;
            }

            try
            {
                Radix r = new Radix(number);
                string ketQua = r.ConvertDecimalToAnother(radix);
                Console.WriteLine($"\nSố {number} ở cơ số {radix} là: {ketQua}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nLỗi: {ex.Message}");
            }
        }
        #endregion

        #region Bài 4: Geometry
        static void ChayBai4()
        {
            Console.WriteLine("--- BÀI 4: ĐIỂM VÀ HÌNH CHỮ NHẬT ---");
            Console.WriteLine("Nhập tọa độ Hình chữ nhật 1:");
            Console.Write("  Điểm trên bên trái - X1: ");
            double.TryParse(Console.ReadLine(), out double x1);
            Console.Write("  Điểm trên bên trái - Y1: ");
            double.TryParse(Console.ReadLine(), out double y1);
            Console.Write("  Điểm dưới bên phải - X2: ");
            double.TryParse(Console.ReadLine(), out double x2);
            Console.Write("  Điểm dưới bên phải - Y2: ");
            double.TryParse(Console.ReadLine(), out double y2);

            HinhChuNhat hcn1 = new HinhChuNhat(new Diem(x1, y1), new Diem(x2, y2));
            Console.WriteLine($"=> Diện tích Hình chữ nhật 1: {hcn1.TinhDienTich()}");

            Console.WriteLine("\nNhập tọa độ Hình chữ nhật 2 (để kiểm tra giao nhau):");
            Console.Write("  Điểm trên bên trái - X3: ");
            double.TryParse(Console.ReadLine(), out double x3);
            Console.Write("  Điểm trên bên trái - Y3: ");
            double.TryParse(Console.ReadLine(), out double y3);
            Console.Write("  Điểm dưới bên phải - X4: ");
            double.TryParse(Console.ReadLine(), out double x4);
            Console.Write("  Điểm dưới bên phải - Y4: ");
            double.TryParse(Console.ReadLine(), out double y4);

            HinhChuNhat hcn2 = new HinhChuNhat(new Diem(x3, y3), new Diem(x4, y4));
            Console.WriteLine($"=> Diện tích Hình chữ nhật 2: {hcn2.TinhDienTich()}");

            bool giaoNhau = hcn1.KiemTraGiaoNhau(hcn2);
            Console.WriteLine($"=> Hai hình chữ nhật có giao nhau không? {(giaoNhau ? "CÓ GIAO NHAU" : "KHÔNG GIAO NHAU")}");
        }
        #endregion

        #region Bài 5: Quản lý học viên
        static void ChayBai5()
        {
            Console.WriteLine("--- BÀI 5: QUẢN LÝ HỌC VIÊN TRUNG TÂM GIA SƯ & XÉT HỌC BỔNG ---");
            Console.WriteLine("  [1] Xem danh sách tất cả học viên");
            Console.WriteLine("  [2] Xem danh sách học viên nhận học bổng");
            Console.WriteLine("  [3] Thêm học viên mới");
            Console.Write("Chọn chức năng: ");
            string subChoice = Console.ReadLine()?.Trim() ?? "";

            switch (subChoice)
            {
                case "1":
                    HienThiDanhSachHocVien(qlHocVien.LayDanhSachTatCa(), "DANH SÁCH TẤT CẢ HỌC VIÊN");
                    break;
                case "2":
                    var dsHb = qlHocVien.LayDanhSachNhanHocBong();
                    HienThiDanhSachHocVien(dsHb, "DANH SÁCH HỌC VIÊN ĐẠT HỌC BỔNG (ĐTB >= 8.0 & KHÔNG CÓ MÔN < 5.0)");
                    break;
                case "3":
                    ThemHocVienMoi();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        }

        static void HienThiDanhSachHocVien(IReadOnlyList<HocVien> ds, string tieuDe)
        {
            Console.WriteLine($"\n=== {tieuDe} (Tổng số: {ds.Count}) ===");
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sách trống!");
                return;
            }

            Console.WriteLine("{0,-8} | {1,-20} | {2,-15} | {3,6} | {4,6} | {5,6} | {6,6} | {7,-10}",
                "Mã SV", "Họ và Tên", "Quê quán", "Môn 1", "Môn 2", "Môn 3", "ĐTB", "Học bổng");
            Console.WriteLine(new string('-', 95));

            foreach (var hv in ds)
            {
                Console.WriteLine("{0,-8} | {1,-20} | {2,-15} | {3,6:F1} | {4,6:F1} | {5,6:F1} | {6,6:F2} | {7,-10}",
                    hv.MaSo, hv.HoTen, hv.QueQuan, hv.DiemMon1, hv.DiemMon2, hv.DiemMon3, hv.TinhDiemTrungBinh(),
                    hv.XetHocBong() ? "ĐẠT" : "Không");
            }
        }

        static void ThemHocVienMoi()
        {
            try
            {
                Console.WriteLine("\n--- THÊM HỌC VIÊN MỚI ---");
                Console.Write("Mã học viên: ");
                string maSo = Console.ReadLine()?.Trim() ?? "";

                Console.Write("Họ và tên: ");
                string hoTen = Console.ReadLine()?.Trim() ?? "";

                Console.Write("Quê quán: ");
                string queQuan = Console.ReadLine()?.Trim() ?? "";

                Console.Write("Điểm môn 1 (0-10): ");
                double m1 = double.Parse(Console.ReadLine()!);

                Console.Write("Điểm môn 2 (0-10): ");
                double m2 = double.Parse(Console.ReadLine()!);

                Console.Write("Điểm môn 3 (0-10): ");
                double m3 = double.Parse(Console.ReadLine()!);

                var hv = new HocVien(maSo, hoTen, queQuan, m1, m2, m3);
                qlHocVien.ThemHocVien(hv);
                Console.WriteLine($"\nThêm học viên '{hoTen}' thành công!");
                Console.WriteLine($"Điểm TB: {hv.TinhDiemTrungBinh()} | Nhận học bổng: {(hv.XetHocBong() ? "CÓ" : "KHÔNG")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nLỗi: {ex.Message}");
            }
        }

        static void NapDuLieuMauHocVien()
        {
            qlHocVien.ThemHocVien(new HocVien("HV01", "Nguyễn Văn An", "Hà Nội", 8.5, 9.0, 8.0));
            qlHocVien.ThemHocVien(new HocVien("HV02", "Trần Thị Bình", "TP.HCM", 9.0, 9.5, 4.5)); // ĐTB cao nhưng môn 3 < 5
            qlHocVien.ThemHocVien(new HocVien("HV03", "Lê Hoàng Cường", "Đà Nẵng", 7.5, 7.5, 8.0)); // ĐTB < 8
            qlHocVien.ThemHocVien(new HocVien("HV04", "Phạm Thu Dung", "Cần Thơ", 9.5, 8.5, 9.0));
            qlHocVien.ThemHocVien(new HocVien("HV05", "Võ Minh Đức", "Hải Phòng", 8.0, 8.0, 8.0));
        }
        #endregion

        #region Demo Calculator
        static void ChayDemoCalculator()
        {
            Console.WriteLine("--- DEMO LỚP CALCULATION (CÓ LÀM TRÒN KẾT QUẢ PHÉP CHIA) ---");
            Console.Write("Nhập số thứ nhất (a): ");
            int.TryParse(Console.ReadLine(), out int a);
            Console.Write("Nhập số thứ hai (b): ");
            int.TryParse(Console.ReadLine(), out int b);

            Calculation cal = new Calculation(a, b);
            Console.WriteLine($"Cộng (+)  : {cal.Execute("+")}");
            Console.WriteLine($"Trừ (-)   : {cal.Execute("-")}");
            Console.WriteLine($"Nhân (*)  : {cal.Execute("*")}");
            try
            {
                Console.WriteLine($"Chia (/) [Làm tròn]: {cal.Execute("/")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chia (/)  : Lỗi - {ex.Message}");
            }
        }
        #endregion
    }
}
