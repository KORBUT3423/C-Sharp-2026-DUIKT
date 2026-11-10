using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    // Книга: назва, автор, унікальний ідентифікатор і стан доступності.
    public class Book
    {
        public int Id { get; }
        public string Title { get; }
        public string Author { get; }

        // Змінювати стан може лише бібліотека (через internal-методи).
        public bool IsAvailable { get; private set; } = true;

        public Book(int id, string title, string author)
        {
            if (id <= 0)
                throw new ArgumentException("Ідентифікатор книги має бути додатним.");
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Назва книги не може бути порожньою.");
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Автор книги не може бути порожнім.");

            Id = id;
            Title = title;
            Author = author;
        }

        internal void MarkAsRented() => IsAvailable = false;
        internal void MarkAsReturned() => IsAvailable = true;

        public override string ToString()
        {
            string status = IsAvailable ? "доступна" : "в оренді";
            return $"[{Id}] «{Title}» — {Author} ({status})";
        }
    }

    // Користувач: ідентифікатор, ім'я та список орендованих книг.
    public class User
    {
        private readonly List<Book> _rentedBooks = new List<Book>();

        public int Id { get; }
        public string Name { get; }

        // Назовні список доступний лише для читання.
        public IReadOnlyList<Book> RentedBooks => _rentedBooks.AsReadOnly();

        public User(int id, string name)
        {
            if (id <= 0)
                throw new ArgumentException("Ідентифікатор користувача має бути додатним.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ім'я користувача не може бути порожнім.");

            Id = id;
            Name = name;
        }

        public bool HasBook(Book book) => _rentedBooks.Contains(book);

        internal void AddRentedBook(Book book) => _rentedBooks.Add(book);
        internal void RemoveRentedBook(Book book) => _rentedBooks.Remove(book);

        public override string ToString()
        {
            string books = _rentedBooks.Count == 0
                ? "немає орендованих книг"
                : string.Join(", ", _rentedBooks.Select(b => $"«{b.Title}»"));
            return $"[{Id}] {Name}: {books}";
        }
    }

    // Бібліотека: зберігає книги й користувачів, керує видачею та поверненням.
    public class Library
    {
        private readonly Dictionary<int, Book> _books = new Dictionary<int, Book>();
        private readonly Dictionary<int, User> _users = new Dictionary<int, User>();

        public bool AddBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("Помилка: книга не може бути null.");
                return false;
            }
            if (_books.ContainsKey(book.Id))
            {
                Console.WriteLine($"Помилка: книга з ID {book.Id} вже існує.");
                return false;
            }
            _books.Add(book.Id, book);
            Console.WriteLine($"Додано книгу: «{book.Title}» (ID {book.Id}).");
            return true;
        }

        public bool AddUser(User user)
        {
            if (user == null)
            {
                Console.WriteLine("Помилка: користувач не може бути null.");
                return false;
            }
            if (_users.ContainsKey(user.Id))
            {
                Console.WriteLine($"Помилка: користувач з ID {user.Id} вже існує.");
                return false;
            }
            _users.Add(user.Id, user);
            Console.WriteLine($"Додано користувача: {user.Name} (ID {user.Id}).");
            return true;
        }

        public bool IsBookAvailable(int bookId)
        {
            return _books.TryGetValue(bookId, out Book book) && book.IsAvailable;
        }

        public bool RentBook(int userId, int bookId)
        {
            if (!_users.TryGetValue(userId, out User user))
            {
                Console.WriteLine($"Помилка: користувача з ID {userId} не знайдено.");
                return false;
            }
            if (!_books.TryGetValue(bookId, out Book book))
            {
                Console.WriteLine($"Помилка: книгу з ID {bookId} не знайдено.");
                return false;
            }
            if (!book.IsAvailable)
            {
                Console.WriteLine($"Помилка: книга «{book.Title}» вже перебуває в оренді.");
                return false;
            }

            book.MarkAsRented();
            user.AddRentedBook(book);
            Console.WriteLine($"Успіх: {user.Name} взяв(ла) книгу «{book.Title}».");
            return true;
        }

        public bool ReturnBook(int userId, int bookId)
        {
            if (!_users.TryGetValue(userId, out User user))
            {
                Console.WriteLine($"Помилка: користувача з ID {userId} не знайдено.");
                return false;
            }
            if (!_books.TryGetValue(bookId, out Book book))
            {
                Console.WriteLine($"Помилка: книгу з ID {bookId} не знайдено.");
                return false;
            }
            if (!user.HasBook(book))
            {
                Console.WriteLine($"Помилка: {user.Name} не орендував(ла) книгу «{book.Title}».");
                return false;
            }

            user.RemoveRentedBook(book);
            book.MarkAsReturned();
            Console.WriteLine($"Успіх: {user.Name} повернув(ла) книгу «{book.Title}».");
            return true;
        }

        public void PrintAllBooks()
        {
            PrintBooks("Усі книги", _books.Values);
        }

        public void PrintAvailableBooks()
        {
            PrintBooks("Доступні книги", _books.Values.Where(b => b.IsAvailable));
        }

        public void PrintRentedBooks()
        {
            Console.WriteLine("\n=== Книги в оренді ===");
            bool any = false;
            foreach (User user in _users.Values)
            {
                foreach (Book book in user.RentedBooks)
                {
                    Console.WriteLine($"  {book} — у користувача {user.Name}");
                    any = true;
                }
            }
            if (!any)
                Console.WriteLine("  (немає)");
        }

        public void PrintAllUsers()
        {
            Console.WriteLine("\n=== Користувачі ===");
            if (_users.Count == 0)
            {
                Console.WriteLine("  (немає)");
                return;
            }
            foreach (User user in _users.Values)
                Console.WriteLine($"  {user}");
        }

        private static void PrintBooks(string header, IEnumerable<Book> books)
        {
            Console.WriteLine($"\n=== {header} ===");
            bool any = false;
            foreach (Book book in books)
            {
                Console.WriteLine($"  {book}");
                any = true;
            }
            if (!any)
                Console.WriteLine("  (немає)");
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Library library = new Library();

            // Початкове наповнення
            Console.WriteLine("--- Початкове наповнення ---");
            library.AddBook(new Book(1, "Кобзар", "Тарас Шевченко"));
            library.AddBook(new Book(2, "Лісова пісня", "Леся Українка"));
            library.AddBook(new Book(3, "Тіні забутих предків", "Михайло Коцюбинський"));
            library.AddBook(new Book(4, "Захар Беркут", "Іван Франко"));

            library.AddUser(new User(1, "Олена"));
            library.AddUser(new User(2, "Андрій"));

            // 1. Перегляд доступних книг
            library.PrintAvailableBooks();

            // 2. Видача книги користувачеві
            Console.WriteLine("\n--- Видача книги ---");
            library.RentBook(1, 2);

            // 3. Спроба повторно видати вже орендовану книгу
            Console.WriteLine("\n--- Спроба повторної видачі ---");
            library.RentBook(2, 2);

            // Додатково: перевірка інших помилок
            Console.WriteLine("\n--- Інші перевірки ---");
            library.RentBook(2, 99);    // неіснуюча книга
            library.ReturnBook(2, 2);   // повернення книги, яку користувач не брав

            library.PrintRentedBooks();
            library.PrintAllUsers();

            // 4. Повернення книги
            Console.WriteLine("\n--- Повернення книги ---");
            library.ReturnBook(1, 2);

            // 5. Повторна перевірка доступності
            Console.WriteLine("\n--- Перевірка доступності ---");
            string status = library.IsBookAvailable(2) ? "доступна" : "недоступна";
            Console.WriteLine($"Книга з ID 2 зараз {status}.");

            library.PrintAllBooks();
            library.PrintAllUsers();
        }
    }
}
