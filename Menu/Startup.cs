using Library_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.Models;

namespace Library_Management_System.Menu
{
    public class Startup
    {
        // Method chính để chạy ứng dụng
        public void Run()
        {
            // Khởi tạo biến choice để lưu lựa chọn của người dùng
            var choice = string.Empty;
            while (true)
            {
                // Hiển thị màn hình chào mừng
                MenuUtils.ShowWelcomeScreen();

                // Kiểm tra xem người dùng đã đăng nhập hay chưa
                if (AuthService.IsUserLoggedIn())
                {
                    while (true)
                    {
                        // Nếu đã đăng nhập, hiển thị menu chính của thư viện
                        choice = MenuUtils.ShowMainLibraryMenu();
                        // Xử lý lựa chọn của người dùng
                        switch (choice)
                        {
                            case "📚 Quản lý Sách":
                                while (true)
                                {
                                    choice = MenuUtils.ShowBookManagementMenu();
                                    switch(choice)
                                    {
                                        case "➕ Thêm sách mới":
                                            BookService.AddBook(); // Gọi phương thức thêm sách mới
                                            break;
                                        case "✏️ Sửa thông tin sách":
                                            BookService.DisplayAllBooks(); // Hiển thị danh sách sách để sửa
                                            BookService.EditBook(); // Gọi phương thức sửa thông tin sách
                                            break;
                                        case "🗑️ Xóa sách":
                                            BookService.DeleteBook();
                                            break;

                                        case "📋 Danh sách tất cả sách":
                                            BookService.DisplayAllBooks(); // Hiển thị danh sách tất cả sách
                                            break;
                                        //case "🔍 Tìm kiếm sách theo tên":
                                        //case "👨‍💼 Tìm kiếm sách theo tác giả":
                                        //case "📂 Tìm kiếm sách theo thể loại":
                                        //case "📊 Thống kê sách theo thể loại":
                                        //case "📈 Sách được mượn nhiều nhất":
                                        case "🔙 Quay lại menu chính":
                                                break; // Quay lại menu chính
                                    }
                                    if(choice == "🔙 Quay lại menu chính")
                                        break; // Thoát vòng lặp quản lý sách
                                }
                                break;
                            case "👥 Quản lý Thành viên":
                                while (true)
                                {
                                    choice = MenuUtils.ShowMemberManagementMenu();
                                    switch (choice)
                                    {
                                        case "➕ Thêm thành viên mới":
                                            MemberService.addNewMember(); // Gọi phương thức thêm thành viên mới
                                            break;
                                        case "✏️ Sửa thông tin thành viên":
                                            // MemberService.EditMember(); // Gọi phương thức sửa thông tin thành viên
                                             // Hiển thị danh sách thành viên để sửa
                                            MemberService.EditMember();
                                            break;
                                        case "🗑️ Xóa thành viên":
                                            // MemberService.DeleteMember(); // Gọi phương thức xóa thành viên
                                            MemberService.DeleteMember();   
                                            break;
                                        case "📋 Danh sách tất cả thành viên":
                                            // MemberService.DisplayAllMembers(); // Hiển thị danh sách tất cả thành viên
                                            break;
                                        //case "🔍 Tìm kiếm thành viên":
                                        //case "📊 Thống kê thành viên theo loại":
                                        //case "⚠️ Thành viên có sách quá hạn":
                                        //case "🏆 Thành viên tích cực nhất":
                                        //case "📧 Gửi thông báo cho thành viên":
                                        case "🔙 Quay lại menu chính":
                                                break; // Quay lại menu chính
                                    }
                                    if(choice == "🔙 Quay lại menu chính")
                                        break; // Thoát vòng lặp quản lý thành viên
                                }
                                break;
                            case "📖 Quản lý Mượn/Trả sách":
                                MenuUtils.ShowErrorMessage("Chức năng đang phát triển !!");
                                break;
                            case "🔍 Tìm kiếm & Lọc sách":
                                MenuUtils.ShowErrorMessage("Chức năng đang phát triển !!");
                                break;
                            case "📊 Báo cáo & Thống kê":
                                MenuUtils.ShowErrorMessage("Chức năng đang phát triển !!");
                                break;
                            case "⚙️ Cài đặt hệ thống":
                                MenuUtils.ShowErrorMessage("Chức năng đang phát triển !!");
                                break;
                            case "🚪 Đăng xuất":
                                AuthService.ClearSession(); // Xóa phiên đăng nhập
                                MenuUtils.ShowWelcomeScreen();
                                break;
                            case "❌ Thoát":
                                MenuUtils.ShowGoodbyeMessage();
                                return;

                        }
                        if (!AuthService.IsUserLoggedIn())
                            break;
                    }

                }

                // Nếu chưa đăng nhập, hiển thị menu đăng nhập
                var option = MenuUtils.ShowLoginMenu();
                switch (option)
                {
                    case "🔐 Đăng nhập":
                        login_register_menu.ShowLoginForm();
                        break;
                    case "📝 Đăng ký tài khoản mới":
                        login_register_menu.ShowRegisterForm();
                        break;
                    case "❌ Thoát":
                        MenuUtils.ShowGoodbyeMessage();
                        return;

                }
            }
        }
    }
}