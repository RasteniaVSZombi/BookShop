using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary
{
    /// <summary>
    /// Класс "Книжный шкаф". Хранит книги и имеет ограниченную вместимость.
    /// </summary>
    public class Bookcase
    {
        // Список книг в шкафу
        public List<Book> books;

        // Вместимость шкафа
        public int capacity;

        // Название (жанр) шкафа
        // По умолчанию пустое, задаётся позже через интерфейс
        public string shelfName;

        /// <summary>
        /// Конструктор книжного шкафа
        /// </summary>
        /// <param name="capacity">Вместимость шкафа</param>
        public Bookcase(int capacity)
        {
            this.capacity = capacity;
            shelfName = "";          // жанр шкафа по умолчанию пустой
            books = new List<Book>(); // создаём список книг
        }

        /// <summary>
        /// Проверяет, пуст ли шкаф
        /// </summary>
        public bool IsEmpty()
        {
            return books.Count == 0;
        }

        /// <summary>
        /// Проверяет, заполнен ли шкаф
        /// </summary>
        public bool IsFull()
        {
            return books.Count >= capacity;
        }

        /// <summary>
        /// Добавляет книгу в шкаф и Базу Данных
        /// </summary>
        /// <param name="book">Книга, которую необходимо добавить</param>
        /// <returns></returns>      
        public bool AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

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
            try
            {
                // Затем записываем в БД
                book.AddToDB();
            }
            catch (Exception ex)
            {
                // Если ошибка при записи в БД - удаляем книгу из шкафа
                books.Remove(book);
                throw new Exception("Ошибка при добавлении в БД", ex);
            }

            return true;
        }

        /// <summary>
        /// Удаляет книгу из шкафа.
        /// Если шкаф стал пустым, его жанр сбрасывается.
        /// </summary>
        public bool RemoveBook(Book book)
        {
            if (book == null)
                return false;

            bool removed = books.Remove(book);

            if (removed && books.Count == 0)
                shelfName = "";

            return removed;
        }

        /// <summary>
        /// Поиск книги по названию
        /// </summary>
        /// <param name="title">Название книги</param>
        /// <returns></returns>
        public Book FindByTitle(string title)
        {
            foreach (Book book in books)
            {
                if (book.title == title)
                    return book;
            }

            return null;
        }

        /// <summary>
        /// Поиск книги по идентификационному номеру
        /// </summary>
        /// <param name="id">ивентификационный номер</param>
        /// <returns></returns>
        public Book FindById(int id)
        {
            foreach (Book book in books)
            {
                if (book.id == id)
                    return book;
            }

            return null;
        }

        /// <summary>
        /// Метод вывода книг по порядку
        /// </summary>
        /// <returns>Возвращает список книг по порядку (по названию)</returns>
        public List<Book> GetBooksOrdered()
        {
            return books.OrderBy(book => book.title).ToList();
        }

        /// <summary>
        /// Метод вывода всех книг в шкафу
        /// </summary>
        /// <returns>Возвращает все книги в шкафу</returns>
        public List<Book> GetAllBooks()
        {
            return books;
        }
    }
}