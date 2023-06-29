using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module._25
{
    public class UserRepository
    {
        private readonly LibraryContext _context;

        public UserRepository(LibraryContext context)
        {
            _context = context;
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void UpdateName(int userId, string newName)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                user.Name = newName;
                _context.SaveChanges();
            }
        }

        //Связь между пользователем и книгой

        public void BorrowBook(int userId, int bookId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            var book = _context.Books.FirstOrDefault(b => b.BookId == bookId);

            if (user != null && book != null)
            {
                book.User = user;
                _context.SaveChanges();
            }
        }
    }
}
