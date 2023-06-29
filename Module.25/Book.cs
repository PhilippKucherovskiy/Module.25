using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module._25
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public User User { get; set; }  // Книга на руки
        // Автор и жанр
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
