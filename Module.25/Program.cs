using Module._25;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new LibraryContext())
        {
            // Создание пользователей
            var user1 = new User { Name = "Иван", Email = "ivan@gmail.com" };
            var user2 = new User { Name = "Анна", Email = "anna@example.com" };
            context.Users.AddRange(user1, user2);

            // Создание книг
            var book1 = new Book { Title = "Война и мир", Year = 1869 };
            var book2 = new Book { Title = "Преступление и наказание", Year = 1866 };
            context.Books.AddRange(book1, book2);

            //  Сохранение изменений
            context.SaveChanges();
        }

        Console.WriteLine("Данные успешно сохранены в базе данных.");
        Console.ReadLine();
    }
}