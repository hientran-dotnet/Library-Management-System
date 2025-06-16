using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class Author
    {
        // Author properties
        private int Id; // Mã tác giả
        private string? Name; // Tên tác giả
        private string? Bio; // Tiểu sử tác giả

        // Getters 
        public int GetId() => Id; // Mã tác giả
        public string? GetName() => Name; // Tên tác giả
        public string? GetBio() => Bio; // Tiểu sử tác giả

        // Setters
        public void SetId(int id) => Id = id; // Mã tác giả
        public void SetName(string? name) => Name = name; // Tên tác giả
        public void SetBio(string? bio) => Bio = bio; // Tiểu sử tác giả
    }
}
