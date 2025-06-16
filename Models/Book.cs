using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class Book
    {
        // Book properties
        private int Id; // Mã sách
        private string? Title; // Tiêu đề sách
        private Author? Author; // Tác giả của sách
        private string? Publisher; // Nhà xuất bản sách
        private int Year; // Năm xuất bản sách
        private string? Category; // Thể loại sách
        private bool IsAvailable; // Kiểm tra tính khả dụng của sách

        //Getters
        public int GetId() => Id; // Mã sách
        public string? GetTitle() => Title; // Tiêu đề sách
        public Author? GetAuthor() => Author; // Tác giả của sách
        public string? GetPublisher() => Publisher; // Nhà xuất bản sách
        public int GetYear() => Year; // Năm xuất bản sách
        public string? GetCategory() => Category; // Thể loại sách
        public bool GetIsAvailable() => IsAvailable; // Kiểm tra tính khả dụng của sách

        //Setters
        public void SetId(int id) => Id = id; // Mã sách
        public void SetTitle(string? title) => Title = title; // Tiêu đề sách
        public void SetAuthor(Author? author) => Author = author; // Tác giả của sách
        public void SetPublisher(string? publisher) => Publisher = publisher; // Nhà xuất bản sách
        public void SetYear(int year) => Year = year; // Năm xuất bản sách
        public void SetCategory(string? category) => Category = category; // Thể loại sách
        public void SetIsAvailable(bool isAvailable) => IsAvailable = isAvailable; // Kiểm tra tính khả dụng của sách
    }
}
