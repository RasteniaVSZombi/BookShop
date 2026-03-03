using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    internal class Book
    {
        public string title;
        public string author;
        public int id;
        public string genre;
        public int pageCount;
        public float value;
        Random random = new Random();


        string[] randomTitles = {
            "Война и мир",
            "Преступление и наказание",
            "Мастер и Маргарита",
            "Анна Каренина",
            "Идиот"
        };

        string[] randomAuthors = {
            "Лев Толстой",
            "Фёдор Достоевский",
            "Михаил Булгаков",
            "Лев Толстый",
            "Джон Подсолнух"
        };

        string[] randomGenres = {
            "Роман",
            "Драма",
            "Фантастика",
            "Классика",
            "Детектив"
        };

        int randomPageCountMin = 1;
        int randomPageCountMax = 1000;

        int randomValueMin = 100;
        int randomValueMax = 10000;


        public Book(string title, string author, int id, string genre, int pageCount, float value)
        {
            this.title = title;
            this.author = author;
            this.id = id;
            this.genre = genre;
            this.pageCount = pageCount;
            this.value = value;
        }

        public Book()
        {
            title = string.Empty;
            author = string.Empty;
            id = 0;
            genre = string.Empty;
            pageCount = 0;
            value = 0;
        }

        public void GenerateRandom()
        {
            title = randomTitles[random.Next(randomTitles.Length)];
            author = randomAuthors[random.Next(randomAuthors.Length)];
            genre = randomGenres[random.Next(randomGenres.Length)];
            value = random.Next(randomValueMin, randomValueMax+1);
            pageCount = random.Next(randomPageCountMin, randomPageCountMax + 1);
        }
    }
}
