# BÁO CÁO THỰC HÀNH KIỂM THỬ PHẦN MỀM - LAB UNIT TEST (C#)

- **Họ và tên sinh viên**: Nguyễn Trọng Bằng
- **Mã số sinh viên (MSSV)**: 231A290053
- **Thư mục bài làm**: `NguyenTrongBang_231A290053_Lab5`
- **Môi trường**: Visual Studio ("VS tím") / .NET 10 / MSTest

---

## 1. Cấu trúc Solution (`NguyenTrongBang_231A290053_Lab5.sln`)

Solution bao gồm 5 project được cấu hình chuẩn mực, liên kết chặt chẽ:

| STT | Project | Loại Project | Mô tả chi tiết |
|:---:|:---|:---|:---|
| 1 | **`CalculatorApp`** | Windows Forms App | Giao diện tính toán máy tính đơn giản (Cộng, Trừ, Nhân, Chia) và lớp `Calculation.cs` xử lý logic (có làm tròn phép chia về số nguyên gần nhất) theo đúng trang 1 - 3 trong tài liệu Lab. |
| 2 | **`CalculatorTester`** | MSTest Project | Bộ kiểm thử Unit Test cho lớp `Calculation` (TestAdd, TestSub, TestMul, TestDiv, TestDivByZero, TestDivRound và Data-Driven Test với file `Data/TestData.csv`) theo đúng trang 4 - 9 trong tài liệu Lab. |
| 3 | **`Lab5_Exercises`** | Class Library | Thư viện mã nguồn hiện thực hóa toàn bộ 5 bài tập trong tài liệu: <br>- `Bai1_Power.cs`: Hàm tính $x^n$ bằng đệ quy.<br>- `Bai2_Polynomial.cs`: Lớp `Polynomial` tính giá trị đa thức bậc $n$ tại $x$.<br>- `Bai3_Radix.cs`: Lớp `Radix` đổi cơ số 10 sang cơ số $k \in [2, 16]$.<br>- `Bai4_Geometry.cs`: Lớp `Diem` và `HinhChuNhat` (tính diện tích, kiểm tra giao nhau).<br>- `Bai5_StudentManagement.cs`: Lớp `HocVien` và `QuanLyHocVien` (xét học bổng). |
| 4 | **`Lab5_Exercises.Tests`** | MSTest Project | Bộ Unit Test toàn diện cho cả 5 bài tập với tổng cộng **67 test cases** bao phủ đầy đủ các trường hợp biên, trường hợp ngoại lệ và dữ liệu thực nghiệm. |
| 5 | **`Lab5_ConsoleApp`** | Console Application | Ứng dụng Console giao diện menu tương tác bằng tiếng Việt, cho phép chạy thử nghiệm tương tác cả 5 bài tập, đặc biệt là **Bài 5 (nhập danh sách học viên và in danh sách nhận học bổng)**. |

---

## 2. Chi tiết các bài tập

### Bài 1: Tính lũy thừa $x^n$ bằng đệ quy (`Bai1_Power.cs`)
- **Đặc tả toán học**:
  $$x^n = \begin{cases} 1.0 & \text{khi } n = 0 \\ x^{n-1} \times x & \text{khi } n > 0 \\ \frac{x^{n+1}}{x} & \text{khi } n < 0 \end{cases}$$
- **Lưu ý phát hiện lỗi**: Đoạn mã minh họa in trong tài liệu đề bài có lỗi logic (`return n * Power(x, n - 1)` thay vì `return x * Power(x, n - 1)`). Nhờ Unit Test `TestPower_DemonstrateBugInLabSnippet`, bộ test phát hiện chính xác lỗi này và chứng minh tính đúng đắn của phương pháp kiểm thử phần mềm. Hàm `Power` chính thức đã được hiện thực chuẩn xác theo đặc tả.
- **Unit Test**: Kiểm tra $n = 0$, $n > 0$, $n < 0$, cơ số âm, cơ số số thập phân, ngoại lệ chia cho 0 khi $x = 0$ và $n < 0$, cùng Data-Driven test.

### Bài 2: Tính giá trị đa thức $P(x)$ (`Bai2_Polynomial.cs`)
- Nhập bậc đa thức $n$ và $n + 1$ hệ số $a_i$.
- Ném ra `ArgumentException("Invalid Data")` khi $n < 0$, danh sách hệ số `null` hoặc số lượng hệ số $\neq n + 1$.
- Phương thức `Cal(x)` tính $P(x) = \sum_{i=0}^n a_i x^i$.
- **Unit Test**: Kiểm tra toàn bộ ngoại lệ và tính toán với các bậc đa thức khác nhau, hệ số âm, $x$ âm và $x = 0$.

### Bài 3: Đổi số cơ số 10 sang cơ số $k \in [2, 16]$ (`Bai3_Radix.cs`)
- Ném ra `ArgumentException("Incorrect Value")` khi số ban đầu âm.
- Ném ra `ArgumentException("Invalid Radix")` khi cơ số $k < 2$ hoặc $k > 16$.
- Chuyển đổi chính xác sang nhị phân (cơ số 2), bát phân (cơ số 8), thập lục phân (cơ số 16 với các ký tự A - F).
- **Unit Test**: Kiểm tra các ngoại lệ, chuyển đổi các cơ số và trường hợp biên số 0.

### Bài 4: Điểm và Hình chữ nhật (`Bai4_Geometry.cs`)
- Lớp `Diem`: lưu tọa độ hoành độ $X$ và tung độ $Y$.
- Lớp `HinhChuNhat`: xác định bởi 2 điểm (Điểm trên bên trái và Điểm dưới bên phải).
- Phương thức:
  - `TinhDienTich()`: Tính diện tích hình chữ nhật.
  - `KiemTraGiaoNhau(HinhChuNhat hcn)`: Thuật toán kiểm tra 2 bounding box giao nhau trên mặt phẳng 2D.
- **Unit Test**: Kiểm tra diện tích (hình vuông, chữ nhật, suy biến về 0), kiểm tra giao nhau (giao một phần, chứa trong nhau, tách biệt ngang/dọc, tiếp xúc cạnh mép).

### Bài 5: Quản lý học viên & Xét học bổng (`Bai5_StudentManagement.cs`)
- Thông tin học viên: Mã số, Họ tên, Quê quán, Điểm 3 môn chính.
- Kiểm tra tính hợp lệ: Mã số và Họ tên không rỗng; Điểm 3 môn phải thuộc $[0, 10]$.
- Tính điểm trung bình 3 môn.
- Tiêu chuẩn học bổng: Điểm trung bình $\ge 8.0$ và không có môn nào dưới $5.0$.
- Lớp `QuanLyHocVien`: Quản lý danh sách, kiểm tra trùng mã số, lọc danh sách học viên nhận học bổng.
- **Unit Test**: Kiểm tra tính ĐTB, điều kiện đạt, điều kiện trượt do điểm liệt $< 5.0$ (dù ĐTB cao), trường hợp chuẩn biên (đúng 8.0 và 5.0), cùng chức năng quản lý.

---

## 3. Kết quả chạy Unit Test

Tổng cộng **81/81 Test Cases đều PASSED 100%**:
- `CalculatorTester.dll`: 14 passed (100%)
- `Lab5_Exercises.Tests.dll`: 67 passed (100%)

Lệnh thực thi kiểm thử từ terminal:
```bash
dotnet test NguyenTrongBang_231A290053_Lab5.sln
```

---

## 4. Hướng dẫn mở và chạy trên Visual Studio ("VS tím")

1. **Mở dự án trong Visual Studio**:
   - Khởi động Visual Studio (icon màu tím).
   - Chọn **Open a project or solution**.
   - Chọn file `NguyenTrongBang_231A290053_Lab5.sln` trong thư mục `e:\NguyenTrongBang_231A290053_Lab5`.

2. **Chạy Unit Test trên Visual Studio**:
   - Trên thanh menu, chọn **Test** > **Test Explorer** (hoặc nhấn tổ hợp phím `Ctrl + E, T`).
   - Nhấn nút **Run All Tests In View** (biểu tượng hai mũi tên xanh tam giác) để chạy toàn bộ 81 bài test.
   - Toàn bộ các test cases sẽ hiển thị màu xanh lá cây (**Passed**).

3. **Chạy ứng dụng Console (Bài 5 & Demo các bài)**:
   - Trong cửa sổ **Solution Explorer**, click chuột phải vào project **`Lab5_ConsoleApp`**.
   - Chọn **Set as Startup Project**.
   - Nhấn phím **F5** hoặc **Ctrl + F5** để khởi chạy ứng dụng giao diện Console.

4. **Chạy ứng dụng Calculator Windows Forms**:
   - Trong cửa sổ **Solution Explorer**, click chuột phải vào project **`CalculatorApp`**.
   - Chọn **Set as Startup Project**.
   - Nhấn **F5** để mở giao diện máy tính tính toán.
