using Library_Management_System.Services;
using Library_Management_System.Utils;
using Microsoft.VisualBasic;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Menu
{
    public class login_register_menu
    {
        public void ShowWelcomeScreen()
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

        public string ShowMainMenu()
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

        public void ShowLoginForm()
        {
            Console.Clear();
            ShowWelcomeScreen();

            // Panel đăng nhập
            var loginPanel = new Panel("")
            {
                Header = new PanelHeader("[bold blue]🔐 ĐĂNG NHẬP[/]", Justify.Center),
                Border = BoxBorder.Double,
                BorderStyle = new Style(Color.Blue)
            };

            AnsiConsole.Write(loginPanel);
            AnsiConsole.WriteLine();

            // Form đăng nhập
            var loginTable = new Table()
                .Border(TableBorder.None)
                .HideHeaders()
                .AddColumn("")
                .AddColumn("");

            AnsiConsole.Write(loginTable);

            // Input tên đăng nhập
            var username = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold yellow]👤 Tên đăng nhập:[/]")
                    .PromptStyle("green")
                    .ValidationErrorMessage("[red]Vui lòng nhập tên đăng nhập![/]")
                    .Validate(username =>
                    {
                        return username.Length >= 3 ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Tên đăng nhập phải có ít nhất 3 ký tự![/]");
                    }));

            // Input mật khẩu
            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold yellow]🔒 Mật khẩu:[/]")
                    .PromptStyle("green")
                    .Secret()
                    .ValidationErrorMessage("[red]Vui lòng nhập mật khẩu![/]")
                    .Validate(password =>
                    {
                        return password.Length >= 6 ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Mật khẩu phải có ít nhất 6 ký tự![/]");
                    }));

            AnsiConsole.WriteLine();

            // Nút xác nhận
            var confirmLogin = AnsiConsole.Confirm("[bold green]Xác nhận đăng nhập?[/]");

            if (confirmLogin)
            {
                MenuUtils.ShowLoadingAnimation("Đang xác thực...");
                // Logic xử lý đăng nhập sẽ được thêm vào đây
                MenuUtils.ShowSuccessMessage("Đăng nhập thành công!");
            }
            else
            {
                MenuUtils.ShowInfoMessage("Đăng nhập đã bị hủy.");
            }
        }

        public void ShowRegisterForm()
        {
            // Khởi tạo đối tượng User và Member 
            var user = new Models.User();
            var member = new Models.Member();


            Console.Clear();
            ShowWelcomeScreen();

            // Panel đăng ký
            var registerPanel = new Panel("")
            {
                Header = new PanelHeader("[bold green]📝 ĐĂNG KÝ TÀI KHOẢN[/]", Justify.Center),
                Border = BoxBorder.Double,
                BorderStyle = new Style(Color.Green)
            };

            AnsiConsole.Write(registerPanel);
            AnsiConsole.WriteLine();

            // Form đăng ký
            #region Form đăng ký
            var fullName = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold yellow]👤 Họ và tên:[/]")
                    .PromptStyle("green")
                    .ValidationErrorMessage("[red]Vui lòng nhập họ và tên![/]")
                    .Validate(name =>
                    {
                        return name.Length >= 2 ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Họ tên phải có ít nhất 2 ký tự![/]");
                    }));

            var username = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold yellow]🆔 Tên đăng nhập:[/]")
                    .PromptStyle("green")
                    .ValidationErrorMessage("[red]Vui lòng nhập tên đăng nhập![/]")
                    .Validate(username =>
                    {
                        //return username.Length >= 3 ? ValidationResult.Success()
                        //    : ValidationResult.Error("[red]Tên đăng nhập phải có ít nhất 3 ký tự![/]");

                        if (string.IsNullOrEmpty(username) || username.Length < 3)
                        {
                            return ValidationResult.Error("[red]Tên đăng nhập phải có ít nhất 3 ký tự![/]");
                        }
                        if (!Services.AuthService.validateUsername(username))
                        {
                            return ValidationResult.Error("[red]Tên đăng nhập đã tồn tại trong hệ thống![/]");
                        }
                        return ValidationResult.Success();
                    }));

            var email = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold yellow]📧 Email:[/]")
                    .PromptStyle("green")
                    .ValidationErrorMessage("[red]Vui lòng nhập email hợp lệ![/]")
                    .Validate(email =>
                    {
                        if (email.Contains("@") && email.Contains("."))
                        {
                            if (AuthService.validateEmail(email))
                            {
                                return ValidationResult.Error("[red]Email đã được sử dụng trong hệ thống![/]");
                            }
                        }
                        return ValidationResult.Success();
                    }));


            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold yellow]🔒 Mật khẩu:[/]")
                    .PromptStyle("green")
                    .Secret()
                    .ValidationErrorMessage("[red]Vui lòng nhập mật khẩu![/]")
                    .Validate(password =>
                    {
                        return password.Length >= 6 ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Mật khẩu phải có ít nhất 6 ký tự![/]");
                    }));

            var confirmPassword = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold yellow]🔐 Xác nhận mật khẩu:[/]")
                    .PromptStyle("green")
                    .Secret()
                    .ValidationErrorMessage("[red]Mật khẩu xác nhận không khớp![/]")
                    .Validate(confirmPwd =>
                    {
                        return confirmPwd == password ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Mật khẩu xác nhận không khớp![/]");
                    }));

            var phoneNumber = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold yellow]📱 Số điện thoại:[/]")
                    .PromptStyle("green")
                    .AllowEmpty()
                    .DefaultValue("Không có")
                    .ShowDefaultValue(true));

            // Lưu thông tin đăng ký vào đối tượng User & member
            // Lưu Member Id
            string randomMemberId = Guid.NewGuid().ToString(); // Tạo ID thành viên ngẫu nhiên
            member.Id = randomMemberId;

            // Lưu Member Name
            member.Name = fullName;

            if (AuthService.IsEmailExists(user.email))
            {
                throw new Exception("Email đã tồn tại trong hệ thống!");
            }
            // Lưu Username
            user.username = username;

            // Lưu CreatedDated
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"); // Múi giờ Hà Nội/Jakarta
            user.createdDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);

            // Lưu Email
            user.email = email;
            member.Email = email;

            // Lưu password
            string hashedPassword = AuthService.hashedPassword(password);
            user.hashedPassword = hashedPassword;

            // Lưu thông tin vào file JSON
            uFileInteraction.SaveUserToFile(user);
            uFileInteraction.SaveMemeberToFile(member);
            uFileInteraction.SaveEmailToFile(email);


            #region Phát triển sau này
            //var userRole = AnsiConsole.Prompt(
            //    new SelectionPrompt<string>()
            //        .Title("[bold yellow]👥 Vai trò:[/]")
            //        .PageSize(5)
            //        .AddChoices(new[] {
            //            "📚 Độc giả",
            //            "👨‍💼 Thủ thư",
            //            "🔧 Quản trị viên"
            //        }));
            #endregion

            #endregion

            AnsiConsole.WriteLine();

            #region Hiển thị thông tin đăng ký
            ShowRegistrationSummary(fullName, username, email, phoneNumber);

            var confirmRegister = AnsiConsole.Confirm("[bold green]Xác nhận đăng ký tài khoản?[/]");

            if (confirmRegister)
            {
                MenuUtils.ShowLoadingAnimation("Đang tạo tài khoản...");
                // Logic xử lý đăng ký sẽ được thêm vào đây
                MenuUtils.ShowSuccessMessage("Đăng ký tài khoản thành công!");
            }
            else
            {
                MenuUtils.ShowInfoMessage("Bạn đã hủy đăng ký tài khoản. Vui lòng thử lại sau.");
            }
            #endregion
        }

        private void ShowRegistrationSummary(string fullName, string username, string email, string phone)
        {
            var summaryTable = new Table()
                .Border(TableBorder.Rounded)
                .BorderColor(Color.Yellow)
                .AddColumn(new TableColumn("[bold]Thông tin[/]").Centered())
                .AddColumn(new TableColumn("[bold]Giá trị[/]").Centered());

            summaryTable.AddRow("[blue]Họ và tên[/]", fullName);
            summaryTable.AddRow("[blue]Tên đăng nhập[/]", username);
            summaryTable.AddRow("[blue]Email[/]", email);
            summaryTable.AddRow("[blue]Số điện thoại[/]", phone);

            AnsiConsole.Write(new Panel(summaryTable)
            {
                Header = new PanelHeader("[bold yellow]📋 THÔNG TIN ĐĂNG KÝ[/]"),
                Border = BoxBorder.Rounded
            });

            AnsiConsole.WriteLine();
        }


        // Method chính để chạy ứng dụng
        public void Run()
        {
            while (true)
            {
                ShowWelcomeScreen();

                var choice = ShowMainMenu();

                switch (choice)
                {
                    case "🔐 Đăng nhập":
                        ShowLoginForm();
                        break;
                    case "📝 Đăng ký tài khoản mới":
                        ShowRegisterForm();
                        break;
                    case "❌ Thoát":
                        MenuUtils.ShowGoodbyeMessage();
                        return;
                }
            }
        }
    }
}
