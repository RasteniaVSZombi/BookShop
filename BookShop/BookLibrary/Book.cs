using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    internal class Book
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

        // Конструктор с параметрами
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

        // Конструктор по умолчанию
        public Book()
        {
            title = string.Empty;  
            author = string.Empty; 
            id = 0;                
            genre = string.Empty;   
            pageCount = 0;     
            value = 0;            
        }

        // Метод случайной генерации данных книги
        public void GenerateRandom()
        {
            title = randomTitles[random.Next(randomTitles.Length)];      
            author = randomAuthors[random.Next(randomAuthors.Length)]; 
            genre = randomGenres[random.Next(randomGenres.Length)];    
            value = random.Next(randomValueMin, randomValueMax + 1);  
            pageCount = random.Next(randomPageCountMin, randomPageCountMax + 1);
        }
    }
}