using Spectre.Console;
using System;
using System.Collections.Generic;
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

                    System.Threading.Thread.Sleep(2000); // Mô phỏng thời gian xử lý
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
            AnsiConsole.Write("[dim]Nhấn Enter để tiếp tục...[/]");
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
            AnsiConsole.Write("[dim]Nhấn Enter để tiếp tục...[/]");
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
            AnsiConsole.Write("[dim]Nhấn Enter để tiếp tục...[/]");
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
    }
}
