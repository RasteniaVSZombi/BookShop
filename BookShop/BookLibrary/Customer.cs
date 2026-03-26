using System;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace BookLibrary
{
    /// <summary>
    /// Типы запросов, которые может сделать покупатель
    /// </summary>
    public enum CustomerRequestType
    {
        SpecificBook,
        Genre
    }

    /// <summary>
    /// Класс "Покупатель" - Хранит данные о покупателе и методы работы с ним
    /// </summary>
    public class Customer
    {

        private Random random = new Random(); // Генератор случайных чисел

        public int Id { get; set; }//Id покупателя
        public CustomerRequestType RequestType { get; set; }//вид запроса покупателя

        public string RequestedTitle { get; set; } = "";//запрашиваемое название книги
        public string RequestedAuthor { get; set; } = "";//запрашиваемый автор книги
        public string RequestedGenre { get; set; } = "";//запрашиваемый жанр книги

        /// <summary>
        /// Метод вывода информации о покупателе
        /// </summary>
        /// <returns>Строку с информацией о покупателе</returns>
        public override string ToString()
        {
            if (RequestType == CustomerRequestType.SpecificBook)
                return $"#{Id}: {RequestedTitle} — {RequestedAuthor}";

            return $"#{Id}: любая книга жанра {RequestedGenre}";
        }

        /// <summary>
        /// Конструктор Покупателя
        /// </summary>
        public Customer(int CustomerId)
        {
            this.Id = CustomerId;
            this.RequestedAuthor = "";
            this.RequestedTitle = "";
            this.RequestedGenre = "";
        }

        /// <summary>
        /// Функция загрузки книг из "Базы Данных" для запроса покупателя
        /// </summary>
        /// <returns></returns>
        private List<(string Author, string Title)> LoadBooksFromDatabase()
        {
            List<(string Author, string Title)> books = new List<(string Author, string Title)>();

            string path = Path.Combine("NameData", "BooksDb.txt");

            if (!File.Exists(path))
                return books;

            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split('\t');

                if (parts.Length != 2)
                    continue;

                string author = parts[0].Trim();
                string title = parts[1].Trim();

                if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(title))
                    continue;

                books.Add((author, title));
            }

            return books;
        }

        /// <summary>
        /// Метод создания запроса покупателя
        /// </summary>
        public void GenerateRandomCustomer()
        {
            var dbBooks = LoadBooksFromDatabase();
            bool wantsSpecificBook = random.Next(2) == 0;

            //Если запрос - определённая книга
            if (wantsSpecificBook && dbBooks.Count > 0)
            {
                var randomPair = dbBooks[random.Next(dbBooks.Count)];
                RequestType = CustomerRequestType.SpecificBook;
                RequestedTitle = randomPair.Title;
                RequestedAuthor = randomPair.Author;
                RequestedGenre = "";
                return;
            }

            //Если запрос - определённый жанр
            string genresFile = Path.Combine("NameData", "Genres.txt");
            string[] genres = File.ReadAllLines(genresFile).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            string randomGenre = genres[random.Next(genres.Length)];

            RequestType = CustomerRequestType.Genre;
            RequestedGenre = randomGenre;
            return;
        }

    }
}