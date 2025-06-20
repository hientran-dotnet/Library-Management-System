using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class Book
    {
        public int Id { set; get; } // Mã sách
        public string? Title { set; get; } // Tiêu đề sách
        public string? Author { set; get; } // Tác giả của sách
        public string? Publisher { set; get; } // Nhà xuất bản sách
        public int Year { set; get; } // Năm xuất bản sách  
        public string? Category { set; get; } // Thể loại sách
        public bool IsAvailable { set; get; } // Kiểm tra tính khả dụng của sách

    }
}
