using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary
{

    // Класс "Книжный шкаф".
    // Хранит книги и имеет ограниченную вместимость.
    internal class Bookcase
    {
        // Список книг в шкафу
        private List<Book> books;

        // Вместимость шкафа
        public int capacity;

        // Название (жанр) шкафа
        // По умолчанию пустое, задаётся позже через интерфейс
        public string shelfName;

        // Конструктор книжного шкафа
        public Bookcase(int capacity)
        {
            this.capacity = capacity;
            shelfName = "";          // жанр шкафа по умолчанию пустой
            books = new List<Book>(); // создаём список книг
        }

        // Добавляет книгу в шкаф
        public bool AddBook(Book book)
        {
            // Проверка вместимости
            if (books.Count >= capacity)
                return false;

            // Если шкаф пустой — назначаем жанр шкафа
            if (shelfName == "")
                shelfName = book.genre;

            // Проверяем совпадение жанра
            if (book.genre != shelfName)
                return false;

            books.Add(book);
            return true;
        }

        // Поиск книги по названию
        public Book FindByTitle(string title)
        {
            foreach (Book book in books)
            {
                if (book.title == title)
                    return book;
            }

            return null;
        }

        // Поиск книги по идентификационному номеру
        public Book FindById(int id)
        {
            foreach (Book book in books)
            {
                if (book.id == id)
                    return book;
            }

            return null;
        }

        // Возвращает список книг по порядку (по названию)
        public List<Book> GetBooksOrdered()
        {
            return books.OrderBy(book => book.title).ToList();
        }

        // Возвращает все книги в шкафу
        public List<Book> GetAllBooks()
        {
            return books;
        }
    }
}