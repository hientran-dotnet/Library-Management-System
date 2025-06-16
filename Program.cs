using Library_Management_System.Menu;

namespace Library_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Đảm bảo hiển thị tiếng Việt đúng
            try
            {
                var app = new login_register_menu();
                app.Run();

            }
            catch(Exception ex)
            {
                // In ra thông báo lỗi
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                // Có thể thêm xử lý lỗi khác nếu cần
            }
            finally
            {
                // Thực hiện các công việc dọn dẹp nếu cần thiết
                Console.WriteLine("Kết thúc chương trình. Nhấn phím bất kỳ để thoát.");
                Console.ReadKey();
            }
        }
    }
}
