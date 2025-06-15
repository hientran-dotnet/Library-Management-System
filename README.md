# Quản lý thư viện (Library Management System)

## 📚 Giới thiệu

Đây là project ứng dụng quản lý thư viện viết bằng C# (console application), phục vụ mục đích học tập, thực hành các kiến thức về lập trình hướng đối tượng, thao tác với file, LINQ, và chuẩn bị nền tảng cho phát triển ứng dụng .NET nâng cao.

## 🏗️ Tính năng chính (Main feature)

- Quản lý sách: Thêm, sửa, xóa, tìm kiếm sách theo tên, tác giả, thể loại.
- Quản lý thành viên: Thêm, sửa, xóa thành viên.
- Quản lý mượn/trả sách: Lưu lịch sử mượn trả, kiểm soát tình trạng sách.
- Tìm kiếm, lọc, sắp xếp sách (ứng dụng LINQ).
- Lưu trữ dữ liệu ra file (text hoặc JSON).
- Giao diện người dùng dạng menu console thân thiện.

## 🛠️ Công nghệ sử dụng (Tech stack)

- Ngôn ngữ: **C#**
- .NET SDK: **.NET 8**
- IDE khuyến nghị: [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/), [Jetbrains Rider IDE](https://www.jetbrains.com/rider/)
- Kiến trúc: OOP, tách rõ Model - Service - Utils

## 🗂️ Cấu trúc thư mục dự án 

```
Library-Management-System/
│
├── Models/        # Các class dữ liệu: Book, Member, Loan, ...
├── Services/      # Logic xử lý nghiệp vụ: LibraryService, ...
├── Utils/         # Tiện ích đọc/ghi file: FileHelper, ...
├── Program.cs     # Điểm khởi động chương trình, menu chính
├── README.md
└── ...
```

## 🚀 Hướng dẫn chạy chương trình

1. **Clone repo về máy**
   ```
   git clone https://github.com/hientran-dotnet/Library-Management-System
   cd Library-Management-System
   ```

2. **Build & chạy**
   ```
   dotnet build
   dotnet run
   ```

3. **Sử dụng menu để thao tác với thư viện**

## 💡 Định hướng mở rộng

- Kết nối với SQL Server để lưu dữ liệu thay vì file
- Thêm phân quyền quản trị viên/người dùng
- Viết unit test cho các chức năng
- Xây dựng giao diện WinForms/WPF hoặc chuyển sang ASP.NET Core

## 👤 Tác giả

- Họ tên: Tran Minh Hien
- Github: [hientran-dotnet](https://github.com/hientran-dotnet)
- Linkedin: [HienTran](https://www.linkedin.com/in/tranminhhien/)

## 📄 Giấy phép

MIT License

---

> **Bạn có thể đóng góp ý kiến, gửi pull request hoặc mở issue nếu phát hiện lỗi hoặc muốn đóng góp tính năng mới!**
