
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class Member
    {
        //// Member properties 
        //private string? Id; // Mã thành viên
        //private string? Name; // Tên thành viên
        //private string? Email; // Email thành viên
        //private string? PhoneNumber; // Số điện thoại thành viên
        //private string? Address; // Địa chỉ thành viên

        //// Getters
        //public string? GetId() => Id; // Mã thành viên
        //public string? GetName() => Name; // Tên thành viên
        //public string? GetEmail() => Email; // Email thành viên
        //public string? GetPhoneNumber() => PhoneNumber; // Số điện thoại thành viên
        //public string? GetAddress() => Address; // Địa chỉ thành viên

        ////Setters 
        //public void SetId (string id) => Id = id; // Mã thành viên
        //public void SetName(string? name) => Name = name; // Tên thành viên
        //public void SetEmail(string? email) => Email = email; // Email thành viên
        //public void SetPhoneNumber(string? phoneNumber) => PhoneNumber = phoneNumber; // Số điện thoại thành viên
        //public void SetAddress(string? address) => Address = address; // Địa chỉ thành viên

        public string? Id { get; set; } // Mã thành viên
        public string? Name { get; set; } // Tên thành viên
        public string? Email { get; set; } // Email thành viên
        public string? PhoneNumber { get; set; } // Số điện thoại thành viên
        public string? Address { get; set; } // Địa chỉ thành viên

    }
}
