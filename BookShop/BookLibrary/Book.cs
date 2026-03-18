using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    /// <summary>
    /// Класс "Книга". Хранит данные книги и возможности работать с ней
    /// </summary>
    public class Book
    {
        // Поля класса Book
        public string title;      // Название книги
        public string author;     // Автор книги
        public int id;            // Уникальный идентификатор
        public string genre;      // Жанр книги
        public int pageCount;     // Количество страниц
        public float value;       // Стоимость книги
        Random random = new Random();  // Генератор случайных чисел

        // Диапазоны для случайной генерации
        int randomPageCountMin = 1;     // Мин. количество страниц
        int randomPageCountMax = 1000;  // Макс. количество страниц

        int randomValueMin = 100;       // Мин. стоимость
        int randomValueMax = 10000;     // Макс. стоимость

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="title">Название книги</param>
        /// <param name="author">Автор книги</param>
        /// <param name="id">Уникальный идентификатор</param>
        /// <param name="genre">Жанр книги</param>
        /// <param name="pageCount">Количество страниц</param>
        /// <param name="value">Стоимость книги</param>
        public Book(string title, string author, int id, string genre, int pageCount, float value)
        {
            // Инициализация каждого поля 
            this.title = title;
            this.author = author;
            this.id = id;
            this.genre = genre;
            this.pageCount = pageCount;
            this.value = value;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Book()
        {
            title = string.Empty;
            author = string.Empty;
            id = 0;
            genre = string.Empty;
            pageCount = 0;
            value = 0;
        }

        /// <summary>
        /// Метод генерации случайных данных книги. Списки названий, авторов и жанров загружаются из текстовых файлов.
        /// </summary>
        public void GenerateRandom()
        {
            string titlesFile = Path.Combine("NameData", "Titles.txt");
            string authorsFile = Path.Combine("NameData", "Authors.txt");
            string genresFile = Path.Combine("NameData", "Genres.txt");

            // Чтение строк из файлов с отбрасыванием пустых и состоящих только из пробелов
            string[] titles = File.ReadAllLines(titlesFile)
                                  .Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            string[] authors = File.ReadAllLines(authorsFile)
                                   .Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            string[] genres = File.ReadAllLines(genresFile)
                                  .Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

            // Выбор случайных элементов
            title = titles[random.Next(titles.Length)];
            author = authors[random.Next(authors.Length)];
            genre = genres[random.Next(genres.Length)];
            value = random.Next(randomValueMin, randomValueMax + 1);
            pageCount = random.Next(randomPageCountMin, randomPageCountMax + 1);
        }

        /// <summary>
        /// Метод для продажи книги и обновления баланса магазина
        /// </summary>
        public bool SellBook(Shop shop)
        {
            if (shop == null)
            {
                throw new ArgumentNullException(nameof(shop), "Магазин не может быть пуст!");
            }

            // Ищем книгу во всех шкафах магазина
            foreach (var shelf in shop.GetAllShelves())
            {
                var foundBook = shelf.FindById(this.id);

                if (foundBook != null)
                {
                    shop.UpdateBalance(this.value);
                    shelf.RemoveBook(foundBook);
                    return true;
                }
            }

            return false;
        }
    }
}