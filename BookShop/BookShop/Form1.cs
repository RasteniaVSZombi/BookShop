using BookLibrary;
using BookStore.Logic;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BookStore.UI
{
    public partial class MainForm : Form
    {
        private Store _store;
        private readonly string _dataPath = "DataFiles"; // Папка для текстовых файлов

        public MainForm()
        {
            InitializeComponent();
            _store = new Store(5); // Максимум 5 шкафов
            UpdateBalanceLabel();
            LoadGenres();

            // Настройка стилей (User-friendly)
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblBalance.ForeColor = System.Drawing.Color.Green;
        }

        #region Вкладка "Новая книга"

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                // Чтение данных из файлов
                var titles = ReadLinesFromFile("titles.txt");
                var authors = ReadLinesFromFile("authors.txt");
                var genres = new[] { "Фантастика", "Детектив", "Роман", "Научпоп", "Фэнтези" };

                if (titles.Length == 0 || authors.Length == 0)
                {
                    MessageBox.Show("Файлы с данными не найдены или пустые!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var random = new Random();

                // Генерация базовых данных
                string rawTitle = titles[random.Next(titles.Length)];
                string author = authors[random.Next(authors.Length)];
                string genre = genres[random.Next(genres.Length)];
                int pages = random.Next(100, 1000);
                decimal price = Math.Round((decimal)(random.NextDouble() * 1000 + 100), 2);

                // Логика уникальности названия (обработка коллизий)
                string uniqueTitle = GetUniqueTitle(rawTitle);

                // Заполнение полей
                txtTitle.Text = uniqueTitle;
                txtAuthor.Text = author;
                txtGenre.Text = genre;
                txtPages.Text = pages.ToString();
                txtPrice.Text = price.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверяет существующие книги и добавляет цифру к названию при конфликте.
        /// Учитывает названия вида "Метро 2033".
        /// </summary>
        private string GetUniqueTitle(string baseTitle)
        {
            // Получаем все текущие названия из магазина (упрощенно через поиск)
            // В реальной архитектуре лучше иметь метод GetExistingTitles в Store
            // Здесь мы эмулируем проверку через попытку добавления или отдельный метод.
            // Для примера реализуем логику здесь, так как Store не хранит список всех названий явно.

            // Примечание: В идеале эту логику нужно перенести в Store.cs, но по ТЗ 
            // "В проекте Windows Forms производите только обработку входных данных".
            // Проверка на дубликат требует знания состояния магазина.
            // Сделаем проверку через попытку создания и ловлю исключения, если бы Store проверял.
            // Но так как Store проверяет место, а не имя, реализуем проверку имени здесь на основе текущих книг.

            var existingTitles = _store.GetType().GetField("_shelves", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.GetValue(_store) as System.Collections.Generic.List<Bookshelf>;

            // Упрощенная логика: просто проверяем, есть ли точное совпадение. 
            // Для полноценной реализации нужно iterating по всем книгам.
            // Чтобы не нарушать инкапсуляцию сильно, предположим, что Store вернет нам список названий.
            // Но так как мы пишем код формы, сделаем локальную проверку по текущим книгам в отображении (если бы они были загружены).
            // Для надежности реализуем простую эвристику:

            int suffix = 1;
            string finalTitle = baseTitle;

            // Эмуляция проверки (в реальном проекте добавьте метод GetBookTitles() в Store)
            // Здесь мы просто вернем название, а уникальность проверится при добавлении в Store (если там есть проверка)
            // Или мы должны проверить сами. Давайте проверим сами.

            while (IsTitleExists(finalTitle))
            {
                suffix++;
                // Проверяем, не заканчивается ли название уже на цифру, чтобы не получить "2033 2 2"
                // Но ТЗ говорит: "Если есть книга «Айсберг», то... «Айсберг 2»".
                // Если есть "Метро 2033", и мы генерируем "Метро 2033", то должно стать "Метро 2033 2".
                finalTitle = $"{baseTitle} {suffix}";
            }

            return finalTitle;
        }

        private bool IsTitleExists(string title)
        {
            // Доступ к приватным полям через рефлексию для примера, 
            // в реальном проекте добавьте публичный метод в Store
            var shelvesField = _store.GetType().GetField("_shelves", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var shelves = shelvesField?.GetValue(_store) as System.Collections.Generic.List<Bookshelf>;

            if (shelves == null) return false;

            foreach (var shelf in shelves)
            {
                foreach (var book in shelf.GetBooks())
                {
                    if (book.Title == title) return true;
                }
            }
            return false;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            // Сброс ошибок
            errorProvider1.Clear();

            // Валидация полей
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
                errorProvider1.SetError(txtTitle, "Название обязательно");
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
                errorProvider1.SetError(txtAuthor, "Автор обязателен");
            if (string.IsNullOrWhiteSpace(txtGenre.Text))
                errorProvider1.SetError(txtGenre, "Жанр обязателен");
            if (!int.TryParse(txtPages.Text, out int pages) || pages <= 0)
                errorProvider1.SetError(txtPages, "Некорректное кол-во страниц");
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                errorProvider1.SetError(txtPrice, "Некорректная цена");

            if (errorProvider1.GetError(txtTitle) != "" || errorProvider1.GetError(txtAuthor) != "" ||
                errorProvider1.GetError(txtGenre) != "" || errorProvider1.GetError(txtPages) != "" ||
                errorProvider1.GetError(txtPrice) != "")
            {
                return;
            }

            try
            {
                Book newBook = new Book(txtTitle.Text, txtAuthor.Text, txtGenre.Text, pages, price);
                _store.AddBook(newBook);

                MessageBox.Show("Книга успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очистка полей
                txtTitle.Clear(); txtAuthor.Clear(); txtGenre.Clear(); txtPages.Clear(); txtPrice.Clear();

                // Обновление списка жанров на второй вкладке
                LoadGenres();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось добавить книгу: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Вкладка "Магазин"

        private void LoadGenres()
        {
            cmbGenres.Items.Clear();
            var genres = _store.GetAvailableGenres();
            cmbGenres.Items.AddRange(genres.ToArray());
            if (cmbGenres.Items.Count > 0)
                cmbGenres.SelectedIndex = 0;
        }

        private void cmbGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGenres.SelectedItem != null)
            {
                string genre = cmbGenres.SelectedItem.ToString();
                var books = _store.GetBooksByGenre(genre);
                lstBooks.Items.Clear();
                foreach (var book in books)
                {
                    lstBooks.Items.Add(book);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Введите название или ID для поиска.");
                return;
            }

            var book = _store.FindBook(query);
            if (book != null)
            {
                lblBookInfo.Text = $"Найдено: {book.Title}\nАвтор: {book.Author}\nЦена: {book.Price}\nID: {book.Id}";
                lblBookInfo.Visible = true;
                // Сохраняем ID в Tag кнопки продать для удобства
                btnSell.Tag = book.Id;
                btnSell.Enabled = true;
            }
            else
            {
                lblBookInfo.Text = "Книга не найдена.";
                btnSell.Enabled = false;
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (btnSell.Tag != null && int.TryParse(btnSell.Tag.ToString(), out int id))
            {
                try
                {
                    if (_store.SellBook(id))
                    {
                        MessageBox.Show("Книга продана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateBalanceLabel();
                        LoadGenres(); // Обновить список (вдруг шкаф опустел)
                        cmbGenres_SelectedIndexChanged(sender, e); // Обновить список книг
                        lblBookInfo.Clear();
                        btnSell.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при продаже.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }

        private void UpdateBalanceLabel()
        {
            lblBalance.Text = $"Баланс: {_store.Balance} руб.";
        }

        #endregion

        #region Helper Methods

        private string[] ReadLinesFromFile(string fileName)
        {
            // Поиск файла в папке приложения
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _dataPath, fileName);

            // Если в папке DataFiles нет, пробуем рядом с exe
            if (!File.Exists(path))
            {
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            }

            if (File.Exists(path))
            {
                return File.ReadAllLines(path);
            }
            return Array.Empty<string>();
        }

        #endregion
    }
}