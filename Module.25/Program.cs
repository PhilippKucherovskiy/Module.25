using Module._25;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new LibraryContext())
        {
            var userRepository = new UserRepository(context);
            var bookRepository = new BookRepository(context);

            // Использование репозиториев
            
            var user = userRepository.GetById(1);
            var allUsers = userRepository.GetAll();

            var book = bookRepository.GetById(1);
            var allBooks = bookRepository.GetAll();

            var newUser = new User { Name = "Новый пользователь", Email = "newuser@example.com" };
            userRepository.Add(newUser);

            userRepository.Delete(user);

            userRepository.UpdateName(newUser.UserId, "Измененное имя");

            bookRepository.UpdateYear(book.BookId, 2023);

            //  Сохранение изменений
            context.SaveChanges();
        }

        Console.WriteLine("Данные успешно сохранены в базе данных.");
        Console.ReadLine();
    }
}