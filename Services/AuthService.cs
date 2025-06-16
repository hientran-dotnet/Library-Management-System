using Konscious.Security.Cryptography;
using Library_Management_System.Menu;
using Library_Management_System.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library_Management_System.Services
{
    public class AuthService
    {
        public static bool validateUsername(string username)
        {
            // đường dẫn tới folder chứa file tài khoản
            string accountDirectory = Utils.uDirectory.Get_Data_Account_Directory();
            //Console.WriteLine($"Đường dẫn tới folder chứa file: {accountDirectory}");

            if(!Directory.Exists(accountDirectory))
            {
                //Console.WriteLine("Thư mục tài khoản không tồn tại.");
                MenuUtils.ShowErrorMessage("Thư mục tài khoản không tồn tại. Vui lòng kiểm tra lại cấu hình hệ thống.");
                return false; // Thư mục tài khoản không tồn tại
            }

            // Lấy toàn bộ file trong thư mục tài khoản
            var allUsernameFile = Directory.GetFiles(accountDirectory);

            //Console.WriteLine("Các file có trong thư mục: ");
            foreach (string file in allUsernameFile)
            {
                // Lấy tên file mà không có phần mở rộng
                string existingUsername = Path.GetFileNameWithoutExtension(file);
                if(string.Equals(existingUsername, username, StringComparison.OrdinalIgnoreCase))
                {
                    //Console.WriteLine($"Tên đăng nhập '{username}' đã tồn tại trong hệ thống.");
                    //MenuUtils.ShowErrorMessage($"Tên đăng nhập '{username}' đã tồn tại trong hệ thống.");
                    return false; // Tên đăng nhập đã tồn tại
                }
            }

            return true; // Tên đăng nhập hợp lệ, chưa tồn tại trong hệ thống
        }
        public static bool validateEmail(string? email)
        {
            // đường dẫn tới folder chứa file tài khoản
            string emailDirectory = Utils.uDirectory.Get_Data_UserInfo_Emails_Directory();
            //Console.WriteLine(emailDirectory);

            var json = File.ReadAllText(emailDirectory + "\\emails.json");
            var emailList = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();

            // So sánh không phân biệt hoa thường
            return emailList.Exists(e => string.Equals(e, email, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsEmailExists(string email)
        {
            string emailFile = Path.Combine(uDirectory.Get_Data_UserInfo_Emails_Directory(), "emails.json");
            if (!File.Exists(emailFile)) return false;
            var json = File.ReadAllText(emailFile);
            var emailList = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            return emailList.Exists(e => string.Equals(e, email, StringComparison.OrdinalIgnoreCase));
        }

        public static string hashedPassword(string? password)
        {
            // Tạo salt ngẫu nhiên (16 bytes là đủ mạnh)
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Khởi tạo Argon2id
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 4, // số luồng CPU dùng (nên là số core máy)
                Iterations = 4,          // số vòng lặp (tăng lên cho bảo mật hơn, giảm nếu cần tốc độ)
                MemorySize = 65536       // bộ nhớ RAM dùng (đơn vị KB, ở đây là 64MB)
            };

            byte[] hash = argon2.GetBytes(32); // lấy 32 bytes hash

            // Lưu salt + hash thành dạng base64, phân tách bởi dấu ':'
            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Tách salt và hash từ chuỗi lưu trong file
            var parts = hashedPassword.Split(':');
            if (parts.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] hashToCompare = Convert.FromBase64String(parts[1]);

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 4,
                Iterations = 4,
                MemorySize = 65536
            };

            byte[] hash = argon2.GetBytes(32);

            // So sánh hash vừa tạo với hash lưu trong file
            return CryptographicOperations.FixedTimeEquals(hash, hashToCompare);
        }
    }
}
