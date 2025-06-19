using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class Session
    {
        public string? username { get; set; } // Tên đăng nhập của người dùng
        public string? CreatedDate { get; set; } // Ngày tạo phiên làm việc
        public string? SessionToken { get; set; } // Mã thông báo phiên làm việc
    }
}
