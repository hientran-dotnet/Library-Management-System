using Library_Management_System.Models;
using Library_Management_System.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library_Management_System.Services
{
    public class UserHelper
    {

        public static string GetCurrentUsername()
        {
            string filePath = Path.Combine(uDirectory.Get_Data_Session_Directory(), "session.json");
            if(AuthService.IsUserLoggedIn())
            {
                // Lấy thông tin phiên làm việc hiện tại từ file JSON
                var sessionJson = File.ReadAllText(filePath);
                var session = JsonSerializer.Deserialize<Session>(sessionJson);
                // Trả về tên đăng nhập của người dùng
                return session?.username; // Nếu không có tên đăng nhập, trả về "Khách" 
            }
            return null;
        }

        public static string GetCurrentUserFullnam(string username)
        {
            string filePath = Path.Combine(uDirectory.Get_Data_UserInfo_Members(), "members.json");
            // Lấy danh sách thành viên từ file JSON
            var membersJson = File.ReadAllText(filePath);
            var members = JsonSerializer.Deserialize<List<Member>>(membersJson);
            // Tìm thành viên có tên đăng nhập tương ứng
            var member = members?.FirstOrDefault(m => m.username == username);
            // Trả về tên đầy đủ của thành viên hoặc "Khách" nếu không tìm thấy
            return member?.Name ?? "Khách";
        }
    }
}
