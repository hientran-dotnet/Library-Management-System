using Library_Management_System.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Menu
{
    public class MenuUtils
    {

        public static void ShowLoadingAnimation(string message)
        {
            AnsiConsole.Status()
                .Start(message, ctx =>
                {
                    ctx.Spinner(Spinner.Known.Star);
                    ctx.SpinnerStyle(Style.Parse("green"));

                    Random random = new Random();
                    Thread.Sleep(random.Next(1000, 2000)); // Mô phỏng thời gian xử lý
                });
        }

        public static void ShowSuccessMessage(string message)
        {
            AnsiConsole.Write(
                new Panel($"[bold green]✅ {message}[/]")
                {
                    Border = BoxBorder.Rounded,
                    BorderStyle = new Style(Color.Green),
                    Header = new PanelHeader("[green]THÀNH CÔNG[/]")
                });

            AnsiConsole.WriteLine();
            AnsiConsole.Markup("[dim]Nhấn Enter để tiếp tục...[/]");
            Console.ReadLine();
        }

        public static void ShowErrorMessage(string message)
        {
            AnsiConsole.Write(
                new Panel($"[bold red]❌ {message}[/]")
                {
                    Border = BoxBorder.Rounded,
                    BorderStyle = new Style(Color.Red),
                    Header = new PanelHeader("[red]LỖI[/]")
                });

            AnsiConsole.WriteLine();
            AnsiConsole.Markup("[dim]Nhấn Enter để tiếp tục...[/]");
            Console.ReadLine();
        }

        public static void ShowInfoMessage(string message)
        {
            AnsiConsole.Write(
                new Panel($"[bold blue]ℹ️ {message}[/]")
                {
                    Border = BoxBorder.Rounded,
                    BorderStyle = new Style(Color.Blue),
                    Header = new PanelHeader("[blue]THÔNG BÁO[/]")
                });

            AnsiConsole.WriteLine();
            AnsiConsole.Markup("[dim]Nhấn Enter để tiếp tục...[/]");
            Console.ReadLine();
        }

        public static void ShowGoodbyeMessage()
        {
            Console.Clear();

            var goodbyePanel = new Panel(
                Align.Center(
                    new Markup("[bold yellow]📚 Cảm ơn bạn đã sử dụng Hệ thống Quản lý Thư viện! 📚[/]\n\n" +
                              "[dim]Hẹn gặp lại bạn lần sau![/]")
                ))
            {
                Border = BoxBorder.Double,
                BorderStyle = new Style(Color.Yellow)
            };

            AnsiConsole.Write(goodbyePanel);
            AnsiConsole.WriteLine();
        }

        public static string ShowLoginMenu()
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold cyan]Vui lòng chọn một tùy chọn:[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Di chuyển lên xuống để xem thêm tùy chọn)[/]")
                    .AddChoices(new[] {
                        "🔐 Đăng nhập",
                        "📝 Đăng ký tài khoản mới",
                        "❌ Thoát"
                    }));

            return choice;
        }

        public static void ShowWelcomeScreen()
        {
            Console.Clear();

            // Tạo banner chào mừng
            var rule = new Rule("[blue]📚 HỆ THỐNG QUẢN LÝ THƯ VIỆN 📚[/]")
            {
                Style = Style.Parse("blue"),
                Justification = Justify.Center
            };
            AnsiConsole.Write(rule);

            AnsiConsole.WriteLine();

            // Panel chào mừng
            var welcomePanel = new Panel(
                "[bold yellow]Chào mừng đến với Hệ thống Quản lý Thư viện![/]\n\n" +
                "[dim]Một hệ thống hiện đại để quản lý sách, độc giả và các hoạt động thư viện.[/]")
            {
                Header = new PanelHeader("[green]WELCOME[/]", Justify.Center),
                Border = BoxBorder.Rounded,
                BorderStyle = new Style(Color.Green)
            };

            AnsiConsole.Write(welcomePanel);
            AnsiConsole.WriteLine();
        }

        // Menu chính sau khi đăng nhập
        public static string ShowMainLibraryMenu()
        {
            Console.Clear();
            string userName = UserHelper.GetCurrentUsername();
            string fullName = UserHelper.GetCurrentUserFullnam(userName);
            // Hiển thị thông tin người dùng
            var userInfoPanel = new Panel(
                $"[bold green]👤 Xin chào: {fullName}[/]\n" +
                //$"[dim]Vai trò: {userRole}[/]\n" +
                $"[dim]Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm}[/]")
            {
                Header = new PanelHeader("[blue]THÔNG TIN NGƯỜI DÙNG[/]", Justify.Center),
                Border = BoxBorder.Rounded,
                BorderStyle = new Style(Color.Blue)
            };

            AnsiConsole.Write(userInfoPanel);
            AnsiConsole.WriteLine();

            // Menu chính
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold cyan]═══ MENU CHÍNH - HỆ THỐNG QUẢN LÝ THƯ VIỆN ═══[/]")
                    .PageSize(12)
                    .MoreChoicesText("[grey](Di chuyển lên xuống để xem thêm tùy chọn)[/]")
                    .AddChoices(new[] {
                        "📚 Quản lý Sách",
                        "👥 Quản lý Thành viên",
                        "📖 Quản lý Mượn/Trả sách",
                        "🔍 Tìm kiếm & Lọc sách",
                        "📊 Báo cáo & Thống kê",
                        "⚙️ Cài đặt hệ thống",
                        "🚪 Đăng xuất",
                        "❌ Thoát"
                    }));

            return choice;
        }
    }
}
