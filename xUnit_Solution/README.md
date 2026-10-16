# BÁO CÁO BÀI TẬP KIỂM THỬ PHẦN MỀM (PHIÊN BẢN xUNIT + WINDOWS FORMS APP)

- **Sinh viên**: Nguyễn Trọng Bằng
- **Mã số sinh viên (MSSV)**: 231A290053
- **Nền tảng**: .NET 10 (Hiện đại, KHÔNG dùng .NET Framework cũ)
- **Framework kiểm thử**: **xUnit** (`xunit 2.9.3`, `xunit.runner.visualstudio`)

---

## 1. Cấu trúc Solution (`NguyenTrongBang_231A290053_Lab5_xUnit.sln`)

Solution bao gồm 5 project được cấu hình chuẩn:

| STT | Project | Loại Project | Vai trò |
|:---:|:---|:---|:---|
| 1 | **`CalculatorApp`** | Windows Forms App (.NET 10) | Giao diện tính toán máy tính Windows Forms hiện đại và lớp xử lý `Calculation.cs` (có làm tròn phép chia về số nguyên gần nhất). |
| 2 | **`CalculatorTester.xUnit`** | xUnit Test Project (.NET 10) | Bộ kiểm thử xUnit cho `Calculation` (`[Fact]`, `[Theory]`, `[InlineData]` và đọc file `TestData.csv`). |
| 3 | **`Lab5_Exercises`** | Class Library (.NET 10) | Thư viện mã nguồn hiện thực toàn bộ 5 bài tập trong giáo trình: `Bai1_Power.cs`, `Bai2_Polynomial.cs`, `Bai3_Radix.cs`, `Bai4_Geometry.cs`, `Bai5_StudentManagement.cs`. |
| 4 | **`Lab5_Exercises.xUnitTests`** | xUnit Test Project (.NET 10) | Bộ kiểm thử xUnit gồm **69 test cases** bao phủ toàn bộ 5 bài tập. |
| 5 | **`Lab5_ConsoleApp`** | Console App (.NET 10) | Giao diện Console menu tương tác để kiểm thử và nhập danh sách học viên xét học bổng (Bài 5). |

---

## 2. Các cú pháp đặc trưng của xUnit được áp dụng

| Tính năng kiểm thử | Cú pháp trong MSTest | Cú pháp trong xUnit |
|:---|:---|:---|
| Đánh dấu phương thức test | `[TestMethod]` | `[Fact]` |
| Kiểm thử theo tham số (Data-Driven) | `[DataTestMethod]` + `[DataRow]` | `[Theory]` + `[InlineData]` |
| Nguồn dữ liệu từ phương thức / file | `[DynamicData]` | `[MemberData]` |
| So sánh bằng | `Assert.AreEqual(expected, actual)` | `Assert.Equal(expected, actual)` |
| So sánh khác | `Assert.AreNotEqual(notExpected, actual)` | `Assert.NotEqual(notExpected, actual)` |
| Kiểm tra ngoại lệ | `Assert.ThrowsException<T>(...)` hoặc `[ExpectedException]` | `Assert.Throws<T>(() => ...)` |
| Kiểm tra tập hợp chứa phần tử | `CollectionAssert.Contains(...)` | `Assert.Contains(item, collection)` |
| Kiểm tra tập hợp rỗng | `Assert.AreEqual(0, list.Count)` | `Assert.Empty(collection)` |
| Khởi tạo trước mỗi test | `[TestInitialize]` | Hàm khởi tạo của Class (Constructor) |

---

## 3. Kết quả kiểm thử Unit Test

Tổng cộng **83/83 Test Cases xUnit PASSED 100%**:
- `CalculatorTester.xUnit.dll`: 14 passed
- `Lab5_Exercises.xUnitTests.dll`: 69 passed

---

## 4. Hướng dẫn mở và chạy trong Visual Studio ("VS tím")

1. Khởi động Visual Studio (icon màu tím).
2. Chọn **Open a project or solution**, duyệt đến file `NguyenTrongBang_231A290053_Lab5_xUnit.sln`.
3. Mở cửa sổ **Test Explorer** (`Ctrl + E, T`) và nhấn biểu tượng **Run All Tests** để chạy 83 bài test xUnit.
4. Để chạy ứng dụng Windows Forms: Chuột phải vào `CalculatorApp` -> **Set as Startup Project** -> nhấn **F5**.
5. Để chạy ứng dụng Console quản lý học viên: Chuột phải vào `Lab5_ConsoleApp` -> **Set as Startup Project** -> nhấn **F5**.
