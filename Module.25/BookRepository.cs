using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module._25
{
    public class BookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public Book GetById(int bookId)
        {
            return _context.Books.FirstOrDefault(b => b.BookId == bookId);
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void UpdateYear(int bookId, int newYear)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                book.Year = newYear;
                _context.SaveChanges();
            }
        }

        //Связь между книгой и пользователем

        public void AssignUser(int bookId, int userId)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == bookId);
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (book != null && user != null)
            {
                book.User = user;
                _context.SaveChanges();
            }
        }

        //Список книг по жанру между годами
        public List<Book> GetBooksByGenreAndYearRange(string genre, int startYear, int endYear)
        {
            return _context.Books
                .Where(b => b.Genre == genre && b.Year >= startYear && b.Year <= endYear)
                .ToList();
        }

        //Количество книг автора в библиотеке
        public int GetBookCountByAuthor(string author)
        {
            return _context.Books.Count(b => b.Author == author);
        }

        //Количество книг жанра в библиотеке
        public int GetBookCountByGenre(string genre)
        {
            return _context.Books.Count(b => b.Genre == genre);
        }

        //Булевый флаг наличие автора с названием
        public bool HasBookByAuthorAndTitle(string author, string title)
        {
            return _context.Books.Any(b => b.Author == author && b.Title == title);
        }

        //Проверить, взята ли определенная книга определенным пользователем
        public bool IsBookBorrowedByUser(int bookId, int userId)
        {
            return _context.Books.Any(b => b.BookId == bookId && b.User != null && b.User.UserId == userId);
        }

        //Получить последнюю вышедшую книгу
        public Book GetLatestBook()
        {
            return _context.Books.OrderByDescending(b => b.Year).FirstOrDefault();
        }

        //Список книг отсортированный по названию
        public List<Book> GetAllBooksSortedByTitle()
        {
            return _context.Books.OrderBy(b => b.Title).ToList();
        }

        //Список книг в порядке убывания года выхода
        public List<Book> GetAllBooksSortedByYearDescending()
        {
            return _context.Books.OrderByDescending(b => b.Year).ToList();
        }









    }
}
