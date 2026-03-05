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

        // Массивы для случайной генерации данных
        string[] randomTitles = {      // Возможные названия книг
            "Война и мир",
            "Преступление и наказание",
            "Мастер и Маргарита",
            "Анна Каренина",
            "Идиот"
        };

        string[] randomAuthors = {     // Возможные авторы
            "Лев Толстой",
            "Фёдор Достоевский",
            "Михаил Булгаков",
            "Лев Толстый",
            "Джон Подсолнух"
        };

        string[] randomGenres = {      // Возможные жанры
            "Роман",
            "Драма",
            "Фантастика",
            "Классика",
            "Детектив"
        };

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
        /// Метод случайной генерации данных книги
        /// </summary>
        public void GenerateRandom()
        {
            title = randomTitles[random.Next(randomTitles.Length)];      
            author = randomAuthors[random.Next(randomAuthors.Length)]; 
            genre = randomGenres[random.Next(randomGenres.Length)];    
            value = random.Next(randomValueMin, randomValueMax + 1);  
            pageCount = random.Next(randomPageCountMin, randomPageCountMax + 1);
        }



        /// <summary>
        /// Метод для продажи книги и обновления баланса магазина
        /// </summary>
        public bool SellBook(Shop shop)
        {
            // Проверяем, что магазин не пуст
            if (shop == null)
            {
                throw new ArgumentNullException(nameof(shop), "Магазин не может быть пуст!");
            }

            // Находим шкаф с книгой
            var shelf = shop.FindShelfByGenre(this.genre);

            if (shelf != null)
            {
                // Ищем книгу в шкафу — используем точное совпадение по ID для надёжности
                var foundBook = shelf.GetAllBooks().FirstOrDefault(book => book.id == this.id);

                if (foundBook != null)
                {
                    // Обновляем баланс магазина
                    shop.UpdateBalance(this.value);
                    // Удаляем книгу из шкафа
                    shelf.books.Remove(foundBook);
                    return true;
            }
        }

        return false;
        }
    }
}