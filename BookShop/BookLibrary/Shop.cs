using BookLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// Найти все шкафы по жанру
        /// </summary>
        public List<Bookcase> FindShelvesByGenre(string genre)
        {
            return _shelves
                .Where(shelf => shelf.shelfName == genre)
                .ToList();
        }

        /// <summary>
        /// Обновить баланс магазина
        /// </summary>
        /// <param name="amount">Сумма для изменения баланса</param>
        public void UpdateBalance(float amount)
        {
            if (amount > _balance && amount < 0)
            {
                throw new ArgumentException("Недостаточно средств для операции");
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
        public List<string> GetBooksByGenre(string genre)
        {
            if (string.IsNullOrEmpty(genre))
            {
                return new List<string>();
            }

            List<string> booksByGenre = new List<string>();

            // Ищем все шкафы с указанным жанром
            var shelves = FindShelvesByGenre(genre);

            foreach (var shelf in shelves)
            {
                var booksInShelf = shelf.GetBooksOrdered();

                foreach (var book in booksInShelf)
                {
                    booksByGenre.Add($"{book.author} - «{book.title}» ({book.genre}) #{book.id}");
                }
            }

            return booksByGenre;
        }

        /// <summary>
        /// Метод для добавления книги в магазин
        /// </summary>
        public bool AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Книга не может быть пустой");

            // Ищем все шкафы нужного жанра
            var genreShelves = FindShelvesByGenre(book.genre);

            // Пробуем добавить книгу в любой шкаф этого жанра, где есть место
            foreach (var shelf in genreShelves)
            {
                if (!shelf.IsFull())
                {
                    return shelf.AddBook(book);
                }
            }

            // Если шкафы этого жанра есть, но все заполнены — ищем пустой шкаф
            if (genreShelves.Count > 0)
            {
                // Ищем пустой шкаф среди всех
                var emptyShelf1 = _shelves.FirstOrDefault(shelf => shelf.IsEmpty());

                if (emptyShelf1 != null)
                {
                    return emptyShelf1.AddBook(book);
                }

                // Если пустого нет, проверяем возможность добавления нового шкафа
                if (_shelves.Count < _maxShelves)
                {
                    var newShelf = new Bookcase(_ShelfCapacity);
                    _shelves.Add(newShelf);
                    return newShelf.AddBook(book);
                }
                else
                {
                    throw new Exception("Нет места в существующих шкафах и превышено максимальное количество шкафов");
                }
            }

            // Если шкафов этого жанра нет, пробуем найти пустой шкаф
            var emptyShelf = _shelves.FirstOrDefault(shelf => shelf.IsEmpty());

            if (emptyShelf != null)
            {
                return emptyShelf.AddBook(book);
            }

            // Если пустого шкафа нет, создаём новый
            if (_shelves.Count < _maxShelves)
            {
                var newShelf = new Bookcase(_ShelfCapacity);
                _shelves.Add(newShelf);
                return newShelf.AddBook(book);
            }

            // Если ничего не получилось
            throw new Exception("Превышено максимальное количество шкафов в магазине");
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
        /// Найти книги по названию или ID. Если жанр указан — ищет во всех шкафах этого жанра,
        /// если не указан — во всём магазине.
        /// </summary>
        public List<Book> FindBook(string genre, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return new List<Book>();
            }

            List<Book> result = new List<Book>();
            List<Bookcase> shelvesToSearch = new List<Bookcase>();

            if (string.IsNullOrEmpty(genre))
            {
                shelvesToSearch = _shelves;
            }
            else
            {
                shelvesToSearch = FindShelvesByGenre(genre);
            }

            foreach (var shelf in shelvesToSearch)
            {
                // Сначала ищем по названию
                Book foundByTitle = shelf.FindByTitle(searchTerm);
                if (foundByTitle != null)
                {
                    result.Add(foundByTitle);
                    return result;
                }

                // Потом ищем по ID
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

                return sold;
            }

            return false;
        }

        /// <summary>
        /// Возвращает все шкафы магазина
        /// </summary>
        public List<Bookcase> GetAllShelves()
        {
            return new List<Bookcase>(_shelves);
        }


        /// <summary>
        /// Инициализирует файл базы данных BooksDb.txt, записывая в него все пары автор-название 
        /// из исходного файла AuthorsTitles.txt. Формат: автор и название через табуляцию, каждая пара на новой строке.
        /// </summary>
        public void InitializeDB()
        {
            string authorsTitlesFile = Path.Combine("NameData", "AuthorsTitles.txt");
            string booksDbFile = Path.Combine("NameData", "BooksDb.txt");

            // Если исходного файла нет, создаём пустой файл базы данных
            if (!File.Exists(authorsTitlesFile))
            {
                File.WriteAllText(booksDbFile, string.Empty);
                return;
            }

            var lines = File.ReadAllLines(authorsTitlesFile);
            var nonEmptyLines = lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();

            // Обработка данных в формате "Автор - Название"
            List<(string Author, string Title)> bookPairs = new List<(string Author, string Title)>();

            foreach (var line in nonEmptyLines)
            {
                var parts = line.Split(new[] { " - " }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    string author = parts[0].Trim();
                    string title = parts[1].Trim();
                    bookPairs.Add((author, title));
                }
            }

            // Перезапись файла с парами в формате "автор\tназвание"
            using (var writer = new StreamWriter(booksDbFile, false))
            {
                    foreach (var pair in bookPairs)
                    {
                        writer.WriteLine($"{pair.Author}\t{pair.Title}");
                    }
            }
        }
    }
}
