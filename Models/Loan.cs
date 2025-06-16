using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class Loan
    {
        // Loan properties
        private int Id; // Mã mượn sách
        private Book? Book; // Sách được mượn
        private Member? Member; // Thành viên mượn sách
        private DateTime LoanDate; // Ngày mượn sách
        private DateTime? ReturnDate; // Ngày trả sách (có thể null nếu chưa trả)
        private double? Fine; // Tiền phạt
        // Getters
        public int GetId() => Id; // Mã mượn sách
        public Book? GetBook() => Book; // Sách được mượn
        public Member? GetMember() => Member; // Thành viên mượn sách
        public DateTime GetLoanDate() => LoanDate; // Ngày mượn sách
        public DateTime? GetReturnDate() => ReturnDate; // Ngày trả sách
        public double? GetFine() => Fine; // Tiền phạt
        // Setters
        public void SetId(int id) => Id = id; // Mã mượn sách
        public void SetBook(Book? book) => Book = book; // Sách được mượn
        public void SetMember(Member? member) => Member = member; // Thành viên mượn sách
        public void SetLoanDate(DateTime loanDate) => LoanDate = loanDate; // Ngày mượn sách
        public void SetReturnDate(DateTime? returnDate) => ReturnDate = returnDate; // Ngày trả sách
        public void SetFine(double? fine) => Fine = fine; // Tiền phạt
    } 
}
