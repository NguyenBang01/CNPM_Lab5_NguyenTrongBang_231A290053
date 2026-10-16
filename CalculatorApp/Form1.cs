using System;
using System.Windows.Forms;
using Calculator;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Cal(string symbol)
        {
            if (!int.TryParse(txtSo1.Text, out int a))
            {
                MessageBox.Show("Số thứ nhất không hợp lệ. Vui lòng nhập số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo1.Focus();
                return;
            }

            if (!int.TryParse(txtSo2.Text, out int b))
            {
                MessageBox.Show("Số thứ hai không hợp lệ. Vui lòng nhập số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo2.Focus();
                return;
            }

            try
            {
                Calculation cal = new Calculation(a, b);
                int result = cal.Execute(symbol);
                txtKetQua.Text = result.ToString();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Không thể chia cho số 0!", "Lỗi chia 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKetQua.Text = "Lỗi chia 0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            this.Cal("+");
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            this.Cal("-");
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            this.Cal("*");
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            this.Cal("/");
        }
    }
}
