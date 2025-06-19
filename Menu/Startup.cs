using Library_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Menu
{
    public class Startup
    {
        // Method chính để chạy ứng dụng
        public void Run()
        {
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
                        var choice = MenuUtils.ShowMainLibraryMenu();

                        // Xử lý lựa chọn của người dùng
                        switch (choice)
                        {
                            case "📚 Quản lý Sách":
                                MenuUtils.ShowErrorMessage("Chức năng đang phát triển");
                                break;
                            case "👥 Quản lý Thành viên":
                                MenuUtils.ShowErrorMessage("Chức năng đang phát triển !!");
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