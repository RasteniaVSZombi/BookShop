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
        public bool order = false;
        public bool plag = false;
        public bool typo = false;
        Random random = new Random();  // Генератор случайных чисел

        // Диапазоны для случайной генерации
        int randomPageCountMin = 1;     // Мин. количество страниц
        int randomPageCountMax = 1000;  // Макс. количество страниц

        int randomValueMin = 100;       // Мин. стоимость
        int randomValueMax = 2000;     // Макс. стоимость

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
        /// Метод генерации случайных данных книги. Случайно выбирает один из трёх сценариев:
        /// 0 — обычная книга (автор и название соответствуют друг другу);
        /// 1 — плагиат (автор и название выбираются строго случайно из всего списка, флаг plag = true);
        /// 2 — опечатка (как обычная, но в названии один символ заменяется на другой, флаг typo = true).
        /// Жанр и числовые характеристики генерируются одинаково для всех сценариев.
        /// </summary>
        public void GenerateRandom()
        {
            // Сброс флагов
            plag = false;
            typo = false;

            string authorsTitlesFile = Path.Combine("NameData", "AuthorsTitles.txt");
            string genresFile = Path.Combine("NameData", "Genres.txt");

            // Чтение и разбор файла с парами автор-название
            var lines = File.ReadAllLines(authorsTitlesFile);
            var nonEmptyLines = lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();

            List<(string Author, string Title)> bookPairs = new List<(string Author, string Title)>();

            foreach (var line in nonEmptyLines)
            {
                // Разбиваем строку по разделителю " - "
                var parts = line.Split(new[] { " - " }, StringSplitOptions.None);

                if (parts.Length == 2)
                {
                    string author = parts[0].Trim();
                    string title = parts[1].Trim();
                    bookPairs.Add((author, title));
                }
                else
                {
                    // Если формат строки нарушен, пропускаем её
                    continue;
                }
            }
            // Чтение жанров
            string[] genres = File.ReadAllLines(genresFile)
                                  .Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            
            if (genres.Length == 0 || bookPairs.Count == 0)
            {
                // Нет данных для генерации
                title = string.Empty;
                author = string.Empty;
                genre = string.Empty;
                pageCount = 0;
                value = 0;
                return;
            }

            // Выбираем пару автор-название
            var randomPair = bookPairs[random.Next(bookPairs.Count)];
            author = randomPair.Author;
            title = randomPair.Title;

            // Жанр
            genre = genres[random.Next(genres.Length)];

            // Числовые характеристики
            value = random.Next(randomValueMin, randomValueMax + 1);
            pageCount = random.Next(randomPageCountMin, randomPageCountMax + 1);
        }

        /// <summary>
        /// Метод генерации случайных данных книги. Случайно выбирает один из трёх сценариев:
        /// 0 — обычная книга (автор и название соответствуют друг другу);
        /// 1 — плагиат (автор и название выбираются строго случайно из всего списка, флаг plag = true);
        /// 2 — опечатка (как обычная, но в названии один символ заменяется на другой, флаг typo = true).
        /// Жанр и числовые характеристики генерируются одинаково для всех сценариев.
        /// </summary>
        public void GenerateRandomBook()
        {
            // Сброс флагов
            plag = false;
            typo = false;

            string authorsTitlesFile = Path.Combine("NameData", "AuthorsTitles.txt");
            string genresFile = Path.Combine("NameData", "Genres.txt");

            // Чтение и разбор файла с парами автор-название
            var lines = File.ReadAllLines(authorsTitlesFile);
            var nonEmptyLines = lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();

            List<(string Author, string Title)> bookPairs = new List<(string Author, string Title)>();

            foreach (var line in nonEmptyLines)
            {
                // Разбиваем строку по разделителю " - "
                var parts = line.Split(new[] { " - " }, StringSplitOptions.None);

                if (parts.Length == 2)
                {
                    string author = parts[0].Trim();
                    string title = parts[1].Trim();
                    bookPairs.Add((author, title));
                }
                else
                {
                    // Если формат строки нарушен, пропускаем её
                    continue;
                }
            }
            // Чтение жанров
            string[] genres = File.ReadAllLines(genresFile)
                                  .Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            if (genres.Length == 0 || bookPairs.Count == 0)
            {
                // Нет данных для генерации
                title = string.Empty;
                author = string.Empty;
                genre = string.Empty;
                pageCount = 0;
                value = 0;
                return;
            }

            // Случайный выбор сценария (0, 1 или 2)
            int scenario = random.Next(3);

            // Выбор индекса обычной пары (может пригодиться для сценариев 0 и 2)
            int normalIndex = random.Next(bookPairs.Count);

            switch (scenario)
            {
                case 0: // Обычная книга
                    var normalPair = bookPairs[normalIndex];
                    author = normalPair.Author;
                    title = normalPair.Title;
                    break;

                case 1: // Плагиат
                    if (bookPairs.Count < 2)
                    {
                        // Если всего одна пара, плагиат невозможен — делаем обычную книгу
                        var singlePair = bookPairs[0];
                        author = singlePair.Author;
                        title = singlePair.Title;
                        plag = false; // не плагиат
                    }
                    else
                    {
                        // Выбираем случайного автора
                        int authorIndex = random.Next(bookPairs.Count);
                        string selectedAuthor = bookPairs[authorIndex].Author;

                        // Выбираем случайное название из другой пары
                        int titleIndex;
                        do
                        {
                            titleIndex = random.Next(bookPairs.Count);
                        } while (titleIndex == authorIndex);

                        author = selectedAuthor;
                        title = bookPairs[titleIndex].Title;
                        plag = true;
                    }
                    break;

                case 2: // Опечатка
                    var typoPair = bookPairs[normalIndex];
                    author = typoPair.Author;
                    title = typoPair.Title;

                    // Вносим опечатку: заменяем один случайный символ на другой (отличный от исходного)
                    if (!string.IsNullOrEmpty(title))
                    {
                        int pos = random.Next(title.Length);
                        char original = title[pos];
                        char newChar;

                        // Набор допустимых символов для замены (можно расширить)
                        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";
                        
                        do
                        {
                            newChar = chars[random.Next(chars.Length)];
                        } while (newChar == original); // Гарантируем отличие

                        // Замена символа
                        char[] charsArr = title.ToCharArray();
                        charsArr[pos] = newChar;
                        title = new string(charsArr);
                        typo = true;
                    }
                    else
                    {
                        // Если название пустое, опечатку внести нельзя — оставляем как есть, но флаг не ставим
                        typo = false;
                    }
                    break;
            }

            // Жанр
            genre = genres[random.Next(genres.Length)];

            // Числовые характеристики
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

        /// <summary>
        /// Добавляет текущую книгу в файл базы данных BooksDb.txt, если такой пары ещё нет.
        /// Формат: автор и название через табуляцию.
        /// Если поля пусты или пара уже существует, ничего не делается.
        /// </summary>
        public void AddToDB()
        {
            if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(title))
                return; // Нечего добавлять

            string booksDbFile = Path.Combine("NameData", "BooksDb.txt");
            string entryToCheck = $"{author}\t{title}";
            bool isDuplicate = false;

            try
            {
                // Проверяем существование файла
                if (File.Exists(booksDbFile))
                {
                    // Читаем все существующие записи
                    var existingEntries = File.ReadAllLines(booksDbFile);

                    // Проверяем каждую запись
                    foreach (var line in existingEntries)
                    {
                        var parts = line.Split('\t');
                        if (parts.Length != 2) continue;

                        string storedAuthor = parts[0].Trim();
                        string storedTitle = parts[1].Trim();

                        // Очищаем заголовок от номеров сиквелов
                        if (storedTitle.Contains(" ("))
                        {
                            int openBracket = storedTitle.LastIndexOf('(');
                            storedTitle = storedTitle.Substring(0, openBracket).Trim();
                        }

                        // Очищаем проверяемый заголовок
                        string cleanTitle = title;
                        if (cleanTitle.Contains(" ("))
                        {
                            int openBracket = cleanTitle.LastIndexOf('(');
                            cleanTitle = cleanTitle.Substring(0, openBracket).Trim();
                        }

                        // Проверяем совпадение
                        if (storedAuthor == author && storedTitle == cleanTitle)
                        {
                            isDuplicate = true;
                            break;
                        }
                    }
                }

                // Если дубликат не найден - добавляем запись
                if (!isDuplicate)
                {
                    // Открываем файл для добавления новой записи
                    using (var writer = new StreamWriter(booksDbFile, true))
                {
                    writer.WriteLine(entryToCheck);
                }
            }
        }
            catch (Exception ex)
            {
                // Обработка ошибок
                throw new Exception($"Ошибка при записи в БД: {ex.Message}");
            }
        }
    }
}