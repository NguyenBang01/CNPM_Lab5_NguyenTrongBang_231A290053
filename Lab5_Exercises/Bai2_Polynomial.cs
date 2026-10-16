using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5_Exercises
{
    /// <summary>
    /// Bài 2: Chương trình tính giá trị đa thức tại một giá trị x.
    /// P(x) = a0*x^0 + a1*x^1 + ... + an*x^n
    /// Nếu người dùng nhập không đủ n + 1 hệ số cho đa thức hoặc nhập n âm thì ném ra ngoại lệ ArgumentException ("Invalid Data").
    /// </summary>
    public class Polynomial
    {
        private int n;
        private List<int> a;

        public int N => n;
        public IReadOnlyList<int> A => a.AsReadOnly();

        public Polynomial(int n, List<int> a)
        {
            // Kiểm tra: n âm hoặc danh sách null hoặc số lượng hệ số khác n + 1
            if (n < 0 || a == null || a.Count != n + 1)
            {
                throw new ArgumentException("Invalid Data");
            }

            this.n = n;
            this.a = new List<int>(a);
        }

        public int Cal(double x)
        {
            int result = 0;
            for (int i = 0; i <= this.n; i++)
            {
                result += (int)(a[i] * Math.Pow(x, i));
            }

            return result;
        }
    }
}
