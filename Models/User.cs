using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class User
    {
        //// User properties
        //private string? username; // Tên đăng nhập
        //private string? hashPassword; // Mật khẩu
        //private string? email; // Email người dùng
        //private DateTime? createdDate; // Ngày tạo tài khoản

        //// Getters
        //public string? GetUsername() => username; // Tên đăng nhập
        //public string? GetHashPassword() => hashPassword; // Mật khẩu
        //public string? GetEmail() => email;
        //public DateTime? GetCreatedDate() => createdDate; // Ngày tạo tài khoản

        //// Setters
        //public void SetUsername(string? username) => this.username = username; // Tên đăng nhập
        //public void SetHashPassword(string? hashPassword) => this.hashPassword = hashPassword; // Mật khẩu
        //public void SetEmail(string? email) => this.email = email; // Email người dùng
        //public void SetCreatedDate(DateTime? createdDate) => this.createdDate = createdDate; // Ngày tạo tài khoản

        [JsonPropertyName("username")]
        public string? username { get; set; } // Tên đăng nhập

        [JsonPropertyName("hashedPassword")]
        public string? hashedPassword { get; set; } // Mật khẩu đã băm

        [JsonPropertyName("email")]
        public string? email { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime? createdDate { get; set; } // Ngày tạo tài khoản




    }
}
