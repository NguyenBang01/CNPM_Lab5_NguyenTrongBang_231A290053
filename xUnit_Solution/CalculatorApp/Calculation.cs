using System;

namespace Calculator
{
    public class Calculation
    {
        private int a;
        private int b;

        public Calculation(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public int Execute(string CalSymbol)
        {
            int result = 0;
            switch (CalSymbol)
            {
                case "+":
                    result = this.a + this.b;
                    break;
                case "-":
                    result = this.a - this.b;
                    break;
                case "*":
                    result = this.a * this.b;
                    break;
                case "/":
                    if (this.b == 0)
                    {
                        throw new DivideByZeroException("Không thể chia cho số 0");
                    }
                    // Yêu cầu đề bài: Phép chia làm tròn về số nguyên gần nhất (1.2 -> 1, 1.5 hoặc 1.6 -> 2)
                    result = (int)Math.Round((double)this.a / this.b, MidpointRounding.AwayFromZero);
                    break;
                default:
                    throw new ArgumentException("Toán tử không hợp lệ: " + CalSymbol);
            }

            return result;
        }
    }
}
