using Library_Management_System.Menu;
using Library_Management_System.Services;
using Library_Management_System.Utils;
using System.Net.Security;

namespace Library_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Đảm bảo hiển thị tiếng Việt đúng


            var app = new Startup();
            app.Run();
        }
    }
}
