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

            if (nonEmptyLines.Length % 2 != 0)
            {
                // Если формат файла нарушен, заполняем поля по умолчанию
                title = string.Empty;
                author = string.Empty;
                genre = string.Empty;
                pageCount = 0;
                value = 0;
                return;
            }

            List<string> authors = new List<string>();
            List<string> titles = new List<string>();
            for (int i = 0; i < nonEmptyLines.Length; i += 2)
            {
                authors.Add(nonEmptyLines[i].Trim());
                titles.Add(nonEmptyLines[i + 1].Trim());
            }

            // Чтение жанров
            string[] genres = File.ReadAllLines(genresFile)
                                  .Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            if (genres.Length == 0 || authors.Count == 0 || titles.Count == 0)
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
            int normalIndex = random.Next(authors.Count);

            switch (scenario)
            {
                case 0: // Обычная книга
                    author = authors[normalIndex];
                    title = titles[normalIndex];
                    break;

                case 1: // Плагиат
                    if (authors.Count < 2)
                    {
                        // Если всего одна пара, плагиат невозможен — делаем обычную книгу
                        author = authors[0];
                        title = titles[0];
                        plag = false; // не плагиат
                    }
                    else
                    {
                        int authorIndex = random.Next(authors.Count);
                        int titleIndex;
                        do
                        {
                            titleIndex = random.Next(titles.Count);
                        } while (titleIndex == authorIndex);
                        author = authors[authorIndex];
                        title = titles[titleIndex];
                        plag = true;
                    }
                    break;

                case 2: // Опечатка
                    author = authors[normalIndex];
                    title = titles[normalIndex];
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
    }
}