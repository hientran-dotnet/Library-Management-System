using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Library_Management_System.Utils
{
    public class uFileInteraction
    {
        public static void SaveUserToFile(User user)
        {
            string folderPath = uDirectory.Get_Data_Account_Directory();
            // Đảm bảo folder tồn tại
            Directory.CreateDirectory(folderPath);

            // Đường dẫn file: username.json
            string filePath = Path.Combine(folderPath, $"{user.username}.json");

            // Kiểm tra username hợp lệ trước khi lưu
            if (string.IsNullOrWhiteSpace(user.username))
                throw new ArgumentException("Username không được để trống!");

            // Serialize object user thành JSON
            string json = JsonSerializer.Serialize(user, new JsonSerializerOptions { WriteIndented = true });

            // Ghi ra file
            File.WriteAllText(filePath, json);
        }

        public static void SaveMemeberToFile(Member member)
        {
            string filePath = Path.Combine(uDirectory.Get_Data_UserInfo_Members(), "Members.json");
            List<Member> members = new List<Member>();
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                members = JsonSerializer.Deserialize<List<Member>>(json) ?? new List<Member>();
            }
            members.Add(member);
            string newJson = JsonSerializer.Serialize(members, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, newJson);
        }

        public static void SaveEmailToFile(string newEmail)
        {
            string folderPath = uDirectory.Get_Data_UserInfo_Emails_Directory();
            // Đảm bảo folder tồn tại
            Directory.CreateDirectory(folderPath);
            // Đường dẫn file: emails.json
            string filePath = Path.Combine(folderPath, "emails.json");
            // Đọc dữ liệu cũ (nếu có)
            List<string> emails;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                emails = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }
            else
            {
                emails = new List<string>();
            }

            if (!emails.Contains(newEmail, StringComparer.OrdinalIgnoreCase))
            {
                emails.Add(newEmail);
            }

            // Ghi lại ra file
            string newJson = JsonSerializer.Serialize(emails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, newJson);
        }

        public static string GetHashedPassword(string username)
        { 

            // Lấy đường dẫn đến thư mục chứa file tài khoản
            string folderPath = uDirectory.Get_Data_Account_Directory();
            // Đảm bảo thư mục tồn tại
            string file = Path.Combine(folderPath, $"{username}.json");

            if (!File.Exists(file))
            {
                throw new FileNotFoundException($"Không tìm thấy file tài khoản cho người dùng: {username}");
            }

            using JsonDocument document = JsonDocument.Parse(File.ReadAllText(file));
            JsonElement root = document.RootElement;

            // Truy cập thuộc tính hashedPassword từ JSON
            if(root.TryGetProperty("hashedPassword", out JsonElement hashedPasswordElement))
            {
                return hashedPasswordElement.GetString() ?? string.Empty; // Trả về mật khẩu đã băm hoặc chuỗi rỗng nếu không có
            }
            else
            {
                throw new Exception($"Không tìm thấy thuộc tính 'hashedPassword' trong file tài khoản: {username}");
            }
        }


        public static void SaveBookToFile(Book book)
        {
            string filePath = Path.Combine(uDirectory.Get_Data_Books_Directory(), "Books.json");
            List<Book> books = new List<Book>();
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
                }
            }
            books.Add(book);
            string newJson = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, newJson);
        }

        public static void SaveBookToFile(Book book, string filePath)
        {
            List<Book> books = new List<Book>();
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
                }
            }
            books.Add(book);
            string newJson = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, newJson);
        }
        
        public static List<Member> LoadAllMembers()
        {
            string filePath = Path.Combine(uDirectory.Get_Data_UserInfo_Members(), "Members.json");
            if (!File.Exists(filePath))
            {
                return new List<Member>(); // Trả về danh sách rỗng nếu file không tồn tại
            }

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Member>>(json) ?? new List<Member>();
        }

        public static void SaveMemberToFile(Member member, string filePath)
        {
            List<Member> members = new List<Member>();
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    members = JsonSerializer.Deserialize<List<Member>>(json) ?? new List<Member>();
                }
            }

            // Tìm thành viên với ID tương ứng
            int existingIndex = members.FindIndex(m => m.Id == member.Id);
            if (existingIndex >= 0)
            {
                // Nếu thành viên đã tồn tại, cập nhật thông tin
                members[existingIndex] = member;
            }
            else
            {
                // Nếu chưa tồn tại, thêm mới
                members.Add(member);
            }

            string newJson = JsonSerializer.Serialize(members, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, newJson);
        }
    }
    
}
