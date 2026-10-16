using System;

namespace Lab5_Exercises
{
    /// <summary>
    /// Bài 1: Cho hàm tính x^n bằng đệ quy, trong đó x là số thực và n là số nguyên bất kỳ.
    /// Đặc tả yêu cầu:
    /// x^n = 1                      nếu n = 0
    /// x^n = x^(n-1) * x            nếu n > 0
    /// x^n = (x^(n+1)) / x          nếu n < 0
    /// </summary>
    public static class Bai1_Power
    {
        /// <summary>
        /// Hàm tính x^n theo đúng đặc tả yêu cầu toán học của đề bài.
        /// (Lưu ý: Đoạn code trong tài liệu Lab có lỗi in ấn 'return n * Power(x, n - 1)'
        /// thay vì 'x * Power(x, n - 1)'. Hàm này hiện thực hóa đúng đặc tả x^n).
        /// </summary>
        public static double Power(double x, int n)
        {
            if (n == 0)
            {
                return 1.0;
            }
            else if (n > 0)
            {
                return x * Power(x, n - 1);
            }
            else // n < 0
            {
                if (x == 0.0)
                {
                    throw new DivideByZeroException("Không thể chia cho 0 khi n < 0");
                }
                return Power(x, n + 1) / x;
            }
        }

        /// <summary>
        /// Hàm giữ nguyên đoạn code minh họa trong đề bài (chứa lỗi nhân n thay vì nhân x)
        /// phục vụ mục đích kiểm thử và phát hiện lỗi bằng Unit Test.
        /// </summary>
        public static double PowerFromLabDoc(double x, int n)
        {
            if (n == 0)
                return 1.0;
            else if (n > 0)
                return n * PowerFromLabDoc(x, n - 1);
            else
                return PowerFromLabDoc(x, n + 1) / x;
        }
    }
}
