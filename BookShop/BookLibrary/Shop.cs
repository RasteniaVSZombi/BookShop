using BookLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookLibrary
{
    /// <summary>
    /// Класс, представляющий магазин с системой хранения книг в шкафах
    /// </summary>
    public class Shop
    {
        // Максимальное количество шкафов в магазине - нельзя изменить после инициализации
        private readonly int _maxShelves;

        //Количество книг в каждой полке магазина - нельзя изменить после инициализации
        private readonly int _ShelfCapacity;

        // Список шкафов в магазине
        private List<Bookcase> _shelves;

        // Баланс магазина
        private static float _balance;

        /// <summary>
        /// Конструктор магазина
        /// </summary>
        /// <param name="maxShelves">Максимальное количество шкафов</param>
        /// <param name="ShelfCapacity"></param>
        public Shop(int maxShelves, int ShelfCapacity)
        {
            if (maxShelves <= 0)
                throw new ArgumentException("Количество шкафов должно быть положительным");

            _maxShelves = maxShelves;
            _shelves = new List<Bookcase>();
            _balance = 0f;
            _ShelfCapacity = ShelfCapacity;
        }

        /// <summary>
        /// Получить текущий баланс магазина
        /// </summary>
        public float Balance
        {
            get => _balance;//получение текущего значения приватного поля без прямого обращения к нему
        }

        /// <summary>
        /// Найти шкаф по жанру
        /// </summary>
        /// <param name="genre">Жанр для поиска</param>
        /// <returns>Шкаф с указанным жанром или null</returns>
        public Bookcase FindShelfByGenre(string genre)
        {
            return _shelves.FirstOrDefault(shelf => shelf.shelfName == genre);
        }

        /// <summary>
        /// Обновить баланс магазина
        /// </summary>
        /// <param name="amount">Сумма для добавления</param>
        public void UpdateBalance(float amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Сумма не может быть отрицательной");
            }

            _balance += amount;
        }

        /// <summary>
        /// Получить все книги в магазине
        /// </summary>
        /// <returns>Список всех книг</returns>
        public List<Book> GetAllBooks()
        {
            var allBooks = new List<Book>();
            foreach (var shelf in _shelves)
            {
                allBooks.AddRange(shelf.GetAllBooks());
            }
            return allBooks;
        }

        /// <summary>
        /// Получить все книги в виде строковых представлений
        /// </summary>
        /// <returns>Список строк с информацией о книгах в формате «Автор — Название (Жанр)»</returns>
        public List<string> GetAllBooksAsString()
        {
            var allBooks = new List<string>();
            foreach (var shelf in _shelves)
            {
                var booksInShelf = shelf.GetBooksOrdered();
                foreach (var book in booksInShelf)
                {
                    //Автор - "Название" (Жанр) #ID
                    allBooks.Add($"{book.author} - «{book.title}» ({book.genre}) #{book.id}");
                }
        }
        return allBooks;
        }

        
        /// <summary>
        /// Получить книги указанного жанра в виде строковых представлений
        /// </summary>
        /// <param name="genre">Название жанра для фильтрации</param>
        /// <returns>Список строк с информацией о книгах заданного жанра</returns>
        public List<string> GetBooksByGenre(string genre)
        {
            // Проверяем корректность входных данных
            if (string.IsNullOrEmpty(genre))
            {
                return new List<string>(); // Возвращаем пустой список, если жанр не указан
            }

            List<string> booksByGenre = new List<string>();

            // Ищем шкаф с указанным жанром
            var shelf = FindShelfByGenre(genre);
    
            if (shelf == null)
            {
                return booksByGenre; // Если шкаф не найден, возвращаем пустой список
            }

            // Получаем все книги из шкафа
            var booksInShelf = shelf.GetBooksOrdered();

            // Формируем строковые представления для каждой книги
            foreach (var book in booksInShelf)
            {
                booksByGenre.Add($"{book.author} - «{book.title}» ({book.genre}) #{book.id}");
            }

            return booksByGenre;
        }

        /// <summary>
        /// Метод для добавления книги в магазин
        /// </summary>
        public bool AddBook(Book book)
        {
            // Ищем существующий шкаф с нужным жанром
            var shelf = FindShelfByGenre(book.genre);

            if (shelf != null)
            {
                // Пытаемся добавить книгу в найденный шкаф
                if (shelf.AddBook(book))
                {
                    return true;
                }
                else
                {
                    // Если не удалось добавить (нет места), выбрасываем исключение
                    throw new Exception("Нет места в шкафу для данной книги");
                }
            }

            // Если шкафа нет, проверяем возможность создания нового
            if (_shelves.Count < _maxShelves)
            {
                // Создаем новый шкаф с вместимостью по умолчанию
                var newShelf = new Bookcase(_ShelfCapacity); // Вместимость: _ShelfCapacity книг
                newShelf.shelfName = book.genre;
                _shelves.Add(newShelf);

                // Добавляем книгу в новый шкаф
                if (newShelf.AddBook(book))
                {
                    return true;
                }
                else
                {
                    // Если что-то пошло не так при добавлении в новый шкаф
                    throw new Exception("Ошибка при добавлении книги в новый шкаф");
                }
            }
            else
            {
                // Если превышено максимальное количество шкафов
                throw new Exception("Превышено максимальное количество шкафов в магазине");
            }
        }


        /// <summary>
        /// Получить список всех доступных жанров в магазине (жанры, представленные в шкафах)
        /// </summary>
        /// <returns>Список уникальных жанров, отсортированный по алфавиту</returns>
        public List<string> GetAvailableGenres()
        {
            var genres = new HashSet<string>();

            foreach (var shelf in _shelves)
            {
                if (!string.IsNullOrEmpty(shelf.shelfName))
                {
                    genres.Add(shelf.shelfName);
                }
            }

            // Преобразуем в список и сортируем по алфавиту
            var sortedGenres = genres.ToList();
            sortedGenres.Sort();

            return sortedGenres;
        }



        /// <summary>
        /// Найти книги по названию или ID. Если жанр указан — ищет в шкафу этого жанра,
        /// если не указан — во всём магазине. Сначала ищет по названию, затем (если не найдено) — по ID.
        /// </summary>
        /// <param name="genre">Жанр для поиска (может быть null или пустой)</param>
        /// <param name="searchTerm">Название или ID книги для поиска</param>
        /// <returns>Список найденных книг (может быть пустым, если книги не найдены)</returns>
        public List<Book> FindBook(string genre, string searchTerm)
        {
            // Проверяем корректность входных данных
            if (string.IsNullOrEmpty(searchTerm))
            {
                return new List<Book>(); // Возвращаем пустой список, если поисковый запрос пуст
            }

            List<Book> result = new List<Book>();
            Bookcase shelf = null;

            // Определяем область поиска в зависимости от наличия жанра
            if (string.IsNullOrEmpty(genre))
            {
                // Ищем во всём магазине — перебираем все шкафы
                foreach (var currentShelf in _shelves)
                {
                    // Шаг 1: поиск по точному названию в текущем шкафу
                    Book foundByTitle = currentShelf.FindByTitle(searchTerm);
                    if (foundByTitle != null)
                    {
                        result.Add(foundByTitle);
                        return result; // Возвращаем сразу при нахождении — точное совпадение
                    }

                    // Шаг 2: если по названию не нашли, ищем по ID в текущем шкафу
                    if (int.TryParse(searchTerm, out int bookId))
                    {
                        Book foundById = currentShelf.FindById(bookId);
                        if (foundById != null)
                        {
                            result.Add(foundById);
                        }
                    }
                }
            }
            else
                {
                    // Ищем только в указанном жанре
                    shelf = FindShelfByGenre(genre);
                    if (shelf == null)
                    {
                        return new List<Book>(); // Шкаф с таким жанром не найден — возвращаем пустой список
                    }

                    // Шаг 1: поиск по точному названию в указанном шкафу
                    Book foundByTitle = shelf.FindByTitle(searchTerm);
                    if (foundByTitle != null)
                    {
                        result.Add(foundByTitle);
                        return result;
                    }

                    // Шаг 2: если по названию не нашли, ищем по ID в указанном шкафу
                    if (int.TryParse(searchTerm, out int bookId))
                    {
                        Book foundById = shelf.FindById(bookId);
                        if (foundById != null)
                        {
                            result.Add(foundById);
                        }
                    }
                }

                return result;
            }

        /// <summary>
        /// Метод продажи книги по ID
        /// </summary>
        /// <param name="bookId">ID книги для продажи</param>
        /// <returns>True при удачной продаже, False при неудаче</returns>
        public bool SellBookById(int bookId)
        {
            var bookToSell = FindBook(null, bookId.ToString()).FirstOrDefault();

            if (bookToSell != null)
            {
                // Удаляем книгу через её метод
                bool sold = bookToSell.SellBook(this);

                if (sold)
                {
                    // После продажи проверяем и удаляем пустые шкафы
                    RemoveEmptyShelves();
                }

                return sold;
            }

            return false;
        }

        /// <summary>
        /// Удаляет все шкафы, в которых нет книг
        /// </summary>
        private void RemoveEmptyShelves()
        {
            // Создаём список жанров пустых шкафов
            var emptyShelves = new List<string>();

            foreach (var shelf in _shelves)
            {
                if (shelf.GetAllBooks().Count == 0)
                {
                    emptyShelves.Add(shelf.shelfName);
                }
            }

            // Удаляем пустые шкафы из коллекции
            foreach (var genre in emptyShelves)
            {
                _shelves.RemoveAll(shelf => shelf.shelfName == genre);
            }
        }

    }
}
