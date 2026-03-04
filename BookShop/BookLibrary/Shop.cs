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
        /// Добавить новый шкаф в магазин
        /// </summary>
        /// <param name="shelf">Шкаф для добавления</param>
        /// <returns>true, если шкаф добавлен успешно</returns>
        public bool AddShelf(Bookcase shelf)
        {
            if (_shelves.Count >= _maxShelves)
            {
                throw new InvalidOperationException("Превышено максимальное количество шкафов в магазине");
            }

            if (shelf == null)
            {
                throw new ArgumentNullException(nameof(shelf));
            }

            _shelves.Add(shelf);
            return true;
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
        /// Очистить все шкафы в магазине
        /// </summary>
        public void ClearAllShelves()
        {
            _shelves.Clear();
        }

        /// <summary>
        /// Получить количество свободных мест в конкретном шкафу
        /// </summary>
        /// <param name="shelfIndex">Индекс шкафа в коллекции (начиная с 0)</param>
        /// <returns>Количество свободных мест в указанном шкафу</returns>
        public int GetFreeSpaceInShelf(int shelfIndex)
        {
            // Проверяем корректность индекса
            if (shelfIndex < 0 || shelfIndex >= _shelves.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(shelfIndex), "Индекс шкафа выходит за пределы допустимого диапазона");
            }

            // Получаем конкретный шкаф
            var shelf = _shelves[shelfIndex];

            // Вычисляем свободное место
            return shelf.capacity - shelf.books.Count;
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
    }
}
