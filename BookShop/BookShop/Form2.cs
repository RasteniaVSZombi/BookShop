using BookLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookShop
{
    /// <summary>
    /// Главная форма приложения "Книжный магазин".
    /// Обеспечивает полное функционирование приложения
    /// Логика вынесена в отдельную библиотеку.
    /// </summary>
    public partial class MainForm : Form
    {
        private Shop _store;

        // Свободные ID, доступные для повторного использования (хранятся в отсортированном виде)
        private SortedSet<int> _availableIds = new SortedSet<int>();

        // Следующий новый ID (если нет свободных)
        private int _nextId = 1;

        /// <summary>
        /// Конструктор формы. Инициализирует компоненты и настраивает стили
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _store = new Shop(3, 5); // Максимум 3 шкафа по 5 книг
            UpdateBalanceLabel();
            LoadGenres();

            // Настройка стилей (User-friendly)
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblBalance.ForeColor = System.Drawing.Color.Green;
        }

        #region Вкладка "Новая книга"

        /// <summary>
        /// Кнопка Случайная генерация
        /// </summary>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                book.GenerateRandom();

                string rawTitle = book.title;
                // Логика уникальности названия (обработка коллизий)
                string uniqueTitle = GetUniqueTitle(rawTitle);

                // Заполнение полей
                txtTitle.Text = uniqueTitle;
                txtAuthor.Text = book.author;
                txtGenre.Text = book.genre;
                txtPages.Text = book.pageCount.ToString();
                txtPrice.Text = book.value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверяет существующие книги и добавляет цифру к названию при конфликте.
        /// </summary>
        private string GetUniqueTitle(string baseTitle)
        {
            // Получаем все текущие названия из магазина 
            var existingTitles = _store.GetAllBooks();

            int suffix = 1;
            string finalTitle = baseTitle;

            while (IsTitleExists(finalTitle))
            {
                suffix++;
                // Проверяем, не заканчивается ли название уже на цифру, чтобы не получить "2033 2 2"
                finalTitle = $"{baseTitle} {suffix}";
            }

            return finalTitle;
        }

        /// <summary>
        /// Функция проверки существования книги (для проверки уникальности имени)
        /// </summary>
        private bool IsTitleExists(string title)
        {
            var shelves = _store.GetAllBooks();

            if (shelves == null) return false;

            foreach (var book in shelves)
            {
                if (book.title == title) return true;
            }
            return false;
        }

        /// <summary>
        /// Кнопка Добавить книгу
        /// </summary>
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
            if (!float.TryParse(txtPrice.Text, out float price) || price <= 0)
                errorProvider1.SetError(txtPrice, "Некорректная цена");

            if (errorProvider1.GetError(txtTitle) != "" || errorProvider1.GetError(txtAuthor) != "" ||
                errorProvider1.GetError(txtGenre) != "" || errorProvider1.GetError(txtPages) != "" ||
                errorProvider1.GetError(txtPrice) != "")
            {
                return;
            }

            try
            {
                // Получаем следующий доступный ID
                int newId = GetNextAvailableId();


                Book newBook = new Book(txtTitle.Text, txtAuthor.Text, newId, txtGenre.Text, pages, price);
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

        /// <summary>
        /// Метод обновления списка жанров в ComboBox на второй вкладке
        /// </summary>
        private void LoadGenres()
        {
            cmbGeneres.Items.Clear();

            // Добавляем опцию «Все жанры» в начало списка
            cmbGeneres.Items.Add("Все жанры");

            var genres = _store.GetAvailableGenres();
            cmbGeneres.Items.AddRange(genres.ToArray());
            if (cmbGeneres.Items.Count > 0)
                cmbGeneres.SelectedIndex = 0;


        }

        /// <summary>
        /// Метод вывода книг в listBox на 2 вкладке при изменении значения ComboBox
        /// </summary>
        private void cmbGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGeneres.SelectedItem != null)
            {
                string genre = cmbGeneres.SelectedItem.ToString();

                if (genre == "Все жанры")
                {
                    var books = _store.GetAllBooksAsString();
                    lstBooks.Items.Clear();
                    foreach (var book in books)
                    {
                        lstBooks.Items.Add(book);
                    }
                }
                else
                {
                    lstBooks.Items.Clear();
                    lstBooks.Items.Add(genre);
                    var books = _store.GetBooksByGenre(genre);
                    lstBooks.Items.Clear();
                    foreach (var book in books)
                    {
                        lstBooks.Items.Add(book);
                    }
                }
            }
        }

        /// <summary>
        /// Кнопка поиска книги по названию или ID
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Введите название или ID для поиска.");
                return;
            }

            string selectgenre = cmbGeneres.SelectedItem.ToString();

            if (selectgenre == "Все жанры")
                selectgenre = null;

            var books = _store.FindBook(selectgenre, search);

            var book = books.FirstOrDefault();
            if (book != null)
            {
                lblBookInfo.Text = $"Найдено: {book.title}\nАвтор: {book.author}\nЖанр: {book.genre}\nЦена: {book.value}\nID: {book.id}";
                lblBookInfo.Visible = true;
                // Сохраняем ID в Tag кнопки продать для удобства
                btnSell.Tag = book.id;
                btnSell.Enabled = true;
            }
            else
            {
                lblBookInfo.Text = "Книга не найдена.";
                btnSell.Enabled = false;
            }
        }

        /// <summary>
        /// Кнопка продажи книги
        /// </summary>
        private void btnSell_Click(object sender, EventArgs e)
        {
            if (btnSell.Tag != null && int.TryParse(btnSell.Tag.ToString(), out int id))
            {
                try
                {
                    bool sold = _store.SellBookById(id);

                    if (sold)
                    {
                        _availableIds.Add(id);

                        MessageBox.Show("Книга продана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateBalanceLabel();
                        LoadGenres();
                        cmbGenres_SelectedIndexChanged(sender, e);
                        lblBookInfo.Text = "";
                        btnSell.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Книга не найдена или ошибка при продаже.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Некорректный ID книги.");
            }
        }

        /// <summary>
        /// Метод обновления label баланса
        /// </summary>
        private void UpdateBalanceLabel()
        {
            lblBalance.Text = $"Баланс: {_store.Balance} руб.";
        }


        #endregion


        #region Дополнительные методы_помощники

        /// <summary>
        /// Метод проверки следующего допустимого индекса
        /// </summary>
        /// <returns>Минимальный свободный id из доступных или следующий id при отсутствии свободных</returns>
        int GetNextAvailableId()
        {
            if (_availableIds.Count > 0)
            {
                // Берём минимальный свободный ID
                int id = _availableIds.Min;
                _availableIds.Remove(id);
                return id;
            }
            else
            {
                // Нет свободных — выдаём следующий по счёту
                return _nextId++;
            }
        }
        #endregion
    }
}
