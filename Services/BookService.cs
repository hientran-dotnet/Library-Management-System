using Library_Management_System.Menu;
using Library_Management_System.Models;
using Library_Management_System.Utils;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library_Management_System.Services
{
    public class BookService : Book
    {
        private static List<Book> books = new List<Book>();
        private static List<Book> allBooks = new List<Book>();
        public static void AddBook()
        {
            var book = new Book();

            // Nhập thông tin sách
            while(true)
            {
                book.Id = AnsiConsole.Ask<int>("Nhập mã sách (ID):");
                if (!IsBookIdExists(book.Id))
                {
                    break; // Nếu ID chưa tồn tại, thoát khỏi vòng lặp
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Mã sách đã tồn tại. Vui lòng nhập mã khác.[/]");
                }
            }
            book.Title = AnsiConsole.Ask<string>("Nhập tên sách:");
            book.Author = AnsiConsole.Ask<string>("Nhập tác giả:");
            book.Publisher = AnsiConsole.Ask<string>("Nhập nhà xuất bản:");
            book.Year = AnsiConsole.Ask<int>("Nhập năm xuất bản:");
            book.Category = AnsiConsole.Ask<string>("Nhập thể loại sách:");
            book.IsAvailable = true; // Mặc định sách mới thêm vào có sẵn


            uFileInteraction.SaveBookToFile(book);

            // Hiển thị thông báo thành công
            MenuUtils.ShowSuccessMessage($"Đã lưu thông tin sách '{book.Title}' vào file thành công!");
        }

        public static List<Book> LoadAllBooks()
        {
            List<Book> allBooks = new List<Book>();

            string filePath = Path.Combine(uDirectory.Get_Data_Books_Directory(), "Books.json");

            string json = File.ReadAllText(filePath);

            if (!string.IsNullOrEmpty(json))
            {
                allBooks = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            }
            return allBooks;
        }

        public static void DisplayAllBooks()
        {
            allBooks = LoadAllBooks();
            if (allBooks.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]Không có sách nào trong thư viện![/]");
                return;
            }
            var table = new Table()
                .AddColumn("Mã sách")
                .AddColumn("Tên sách")
                .AddColumn("Tác giả")
                .AddColumn("Nhà xuất bản")
                .AddColumn("Năm xuất bản")
                .AddColumn("Thể loại")
                .AddColumn("Trạng thái");
            foreach (var book in allBooks)
            {
                table.AddRow(
                    book.Id.ToString(),
                    book.Title,
                    book.Author,
                    book.Publisher,
                    book.Year.ToString(),
                    book.Category,
                    book.IsAvailable ? "Có sẵn" : "Đã mượn"
                );
            }
            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("[dim]Nhấn Enter để tiếp tục...[/]");
            Console.ReadLine();
        }

        public static Book? GetBookByID(int bookId)
        {
            allBooks = LoadAllBooks();
            return allBooks.FirstOrDefault(b => b.Id == bookId);
        }

            
        
        public static void EditBook()
        { 
            string jsonString = File.ReadAllText(Path.Combine(uDirectory.Get_Data_Books_Directory(), "Books.json"));
            if (string.IsNullOrEmpty(jsonString))
            {
                AnsiConsole.MarkupLine("[red]Không có sách nào để chỉnh sửa![/]");
                return;
            }

            var books = JsonSerializer.Deserialize<List<Book>>(jsonString) ?? new List<Book>();


            int id = AnsiConsole.Ask<int>("Nhập mã sách cần chỉnh sửa:");
            var bookToUpdate = books.FirstOrDefault(b => b.Id == id);
            if(bookToUpdate == null)
            {
                AnsiConsole.MarkupLine("[red]Không tìm thấy sách với mã đã nhập![/]");
                return;
            }
            bookToUpdate.Title = AnsiConsole.Ask<string>("Nhập tên sách mới:", bookToUpdate.Title);
            bookToUpdate.Author = AnsiConsole.Ask<string>("Nhập tác giả mới:", bookToUpdate.Author);
            bookToUpdate.Publisher = AnsiConsole.Ask<string>("Nhập nhà xuất bản mới:", bookToUpdate.Publisher);
            bookToUpdate.Year = AnsiConsole.Ask<int>("Nhập năm xuất bản mới:", bookToUpdate.Year);
            bookToUpdate.Category = AnsiConsole.Ask<string>("Nhập thể loại sách mới:", bookToUpdate.Category);

            var status = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Chọn trạng thái sách:")
                    .AddChoices("Có sẵn", "Đang được mượn")
                    .HighlightStyle("green"));

            bookToUpdate.IsAvailable = status == "Có sẵn";

            var options = new JsonSerializerOptions
            {
                WriteIndented = true // Định dạng JSON đẹp
            };
            string updatedJson = JsonSerializer.Serialize(books, options);  

            File.WriteAllText(Path.Combine(uDirectory.Get_Data_Books_Directory(), "Books.json"), updatedJson);
            MenuUtils.ShowSuccessMessage($"Đã cập nhật thông tin sách '{bookToUpdate.Id}' thành công!");
        }

        public static void DeleteBook()
        {
            string filePath = Path.Combine(uDirectory.Get_Data_Books_Directory(), "Books.json");
            if (!File.Exists(filePath))
            {
                AnsiConsole.MarkupLine("[red]Không có sách nào để xóa![/]");
                return;
            }

            var json = File.ReadAllText(filePath);
            var books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();

            BookService.DisplayAllBooks();

            int idToDelete = AnsiConsole.Ask<int>("Nhập mã sách cần xóa:");

            var bookToDelete = books.FirstOrDefault(b => b.Id == idToDelete);
            if (bookToDelete == null)
            {
                AnsiConsole.MarkupLine("[red]Không tìm thấy sách với mã đã nhập![/]");
                return;
            }

            var deletedBook = books.FirstOrDefault(b => b.Id == idToDelete);

            string trashcanPath = Path.Combine(uDirectory.Get_TrashCan_Directory(), "DeletedBook.json");
            uFileInteraction.SaveBookToFile(deletedBook, trashcanPath);

            books.Remove(bookToDelete);
            string updatedJson = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, updatedJson);

            MenuUtils.ShowSuccessMessage($"Đã xóa sách '{bookToDelete.Title}' thành công!");
        }

        public static bool IsBookIdExists(int bookId)
        {
            allBooks = LoadAllBooks();
            return allBooks.Any(b => b.Id == bookId);
        }

    }
}
