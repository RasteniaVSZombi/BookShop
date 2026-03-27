using BookLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

        private GameSettings _gameSettings;

        // Свободные ID, доступные для повторного использования (хранятся в отсортированном виде)
        private SortedSet<int> _availableIds = new SortedSet<int>();

        // Следующий новый ID (если нет свободных)
        private int _nextId = 1;

        public int _nextCustomerId = 1; // Следующий ID покупателя

        //Сколько времени прошло в секундах
        private int _elapsedTime = 0;

        //Флаг видимости вкладки "Поставки"
        private bool IsPageDeliveriesVisible = false;

        private List<Book> _orderedBooks = new List<Book>(); // Список заказанных книг
        private List<Book> _pendingDeliveries = new List<Book>(); // Список поставок

        private List<Customer> _customersQueue = new List<Customer>(); // Очередь покупателей
        private int _unhappyCustomersCount = 0; // Счётчик недовольных покупателей

        private Random _random = new Random(); // Генератор случайных чисел

        /// <summary>
        /// Конструктор формы. Инициализирует компоненты и настраивает стили
        /// </summary>
        public MainForm(GameSettings sourceSettings)
        {
            InitializeComponent();
            _store = new Shop(3, 5); // Максимум 3 шкафа по 5 книг

            _store.InitializeDB();

            _gameSettings = sourceSettings;

            _store.UpdateBalance(_gameSettings.StartBalance);
            UpdateBalanceLabel();

            LoadGenres();

            // Инициализируем список поставок
            UpdateDeliveriesList();

            tabControlMain.TabPages.Remove(tabPageDeliveries);

            // Настройка таймеров
            //Таймер доставки заказанной книги
            _deliveryTimer.Interval = (int)(_gameSettings.OrderDeliveryTime * 1000);//в миллисекундах
            _deliveryTimer.Tick += DeliveryTimer_Tick;

            //Таймер прибытия случайной книги
            _timerRandomBooks.Interval = (int)(_gameSettings.RandomBookTime * 1000); // в миллисекундах
            _timerRandomBooks.Tick += RandomBooksTimer_Tick;
            _timerRandomBooks.Start(); // запускаем таймер при старте

            //Таймер игрового времени
            _gameTimer.Interval = 1000; // интервал в 1 секунду
            _gameTimer.Tick += GameTimer_Tick;
            _gameTimer.Start(); // запускаем таймер при старте

            //Таймер прихода покупателя
            _customerTimer.Interval = (int)(_gameSettings.CustomerTime * 1000);//Интервал в 1 секунду
            _customerTimer.Tick += CustomerTimer_Tick;
            _customerTimer.Start();//запускаем таймер при старте

            UpdateCustomersUI();

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

                // Заполнение полей
                txtTitle.Text = book.title;
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
        private string GetUniqueTitle(string baseTitle, string author)
        {
            // Получаем все текущие книги из магазина
            var allBooks = _store.GetAllBooks();

            // Проверяем, есть ли книга с таким же автором и названием
            var existingBook = allBooks.FirstOrDefault(b =>
                b.author.Equals(author, StringComparison.OrdinalIgnoreCase) &&
                b.title.Equals(baseTitle, StringComparison.OrdinalIgnoreCase));

            // Если базового названия нет в списке — возвращаем его как уникальное
            if (!IsTitleExists(baseTitle, author))
            {
                return baseTitle;
            }

            int suffix = 1;
            string finalTitle;

            do
            {
                suffix++;
                finalTitle = $"{baseTitle} ({suffix})";
            }
            while (IsTitleExists(finalTitle, author));

            return finalTitle;
        }

        /// <summary>
        /// Функция проверки существования книги (для проверки уникальности имени)
        /// </summary>
        private bool IsTitleExists(string title, string author)
        {
            var shelves = _store.GetAllBooks();

            if (shelves == null) return false;

            foreach (var book in shelves)
            {
                if (book.title == title && book.author == author) return true;
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
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                errorProvider1.SetError(txtPrice, "Некорректная цена");

            if (errorProvider1.GetError(txtTitle) != "" || errorProvider1.GetError(txtAuthor) != "" ||
                errorProvider1.GetError(txtGenre) != "" || errorProvider1.GetError(txtPages) != "" ||
                errorProvider1.GetError(txtPrice) != "")
            {
                return;
            }

            // Проверяем достаточно ли средств на балансе
            if (_store.Balance < price)
            {
                MessageBox.Show("Недостаточно средств для заказа книги!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                string title = txtTitle.Text.Trim();
                bool hasNumberSuffix = false;

                // Проверяем, что строка заканчивается на ) и имеет длину минимум 3 символа
                if (title.EndsWith(")") && title.Length > 2)
                {
                    int lastOpenBracketIndex = title.LastIndexOf('(');

                    // Проверяем, что открывающая скобка есть и находится перед закрывающей
                    if (lastOpenBracketIndex > 0 && lastOpenBracketIndex < title.Length - 2)
                    {
                        // Извлекаем содержимое между скобками
                        string content = title.Substring(lastOpenBracketIndex + 1, title.Length - lastOpenBracketIndex - 2);

                        // Проверяем, что содержимое — это число
                        if (int.TryParse(content, out int number))
                        {
                            hasNumberSuffix = true;

                            DialogResult result = MessageBox.Show(
                                "Название заканчивается на (число). Хотите удалить этот суффикс автоматически?",
                                "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (result == DialogResult.No)
                            {
                                errorProvider1.SetError(txtTitle, "Уберите суффикс (число) из названия");
                                return;
                            }

                            // Удаляем часть от открывающей скобки до конца
                            title = title.Substring(0, lastOpenBracketIndex).Trim();
                        }
                    }
                }

                // Создаем книгу для заказа
                Book orderedBook = new Book(title, txtAuthor.Text, 0, txtGenre.Text, pages, price);
                orderedBook.order = true;

                // Добавляем в список заказанных
                _orderedBooks.Add(orderedBook);

                // Снимаем стоимость сразу
                _store.UpdateBalance(-price);
                UpdateBalanceLabel();

                // Запускаем таймер доставки
                _deliveryTimer.Start();

                MessageBox.Show("Книга успешно заказана! Ожидайте доставки...", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очищаем поля
                txtTitle.Clear();
                txtAuthor.Clear();
                txtGenre.Clear();
                txtPages.Clear();
                txtPrice.Clear();
            }
            catch (Exception ex)
            {
                // Возвращаем деньги при ошибке
                _store.UpdateBalance(price);
                UpdateBalanceLabel();
                MessageBox.Show($"Не удалось заказать книгу: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод обработки таймера доставки заказанных книг
        private void DeliveryTimer_Tick(object sender, EventArgs e)
        {
            if (_orderedBooks.Count > 0)
            {
                Book deliveredBook = _orderedBooks[0];
                _orderedBooks.RemoveAt(0);

                // Добавляем в список ожидающих проверок
                _pendingDeliveries.Add(deliveredBook);
                UpdateDeliveriesList();
            }
            else
            {
                _deliveryTimer.Stop();
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

            // Добавляем опцию "Все жанры" в начало списка
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
        /// Метод поиска книги при нажатии на неё в ListBox
        /// </summary>
        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, что выбран какой‑то элемент
            if (lstBooks.SelectedIndex == -1)
            {
                btnSell.Enabled = false;
                return;
            }

            // Получаем текст выбранного элемента (Автор - "Название" (Жанр) #ID)
            string selectedItem = lstBooks.SelectedItem.ToString();

            // Извлекаем ID из строки (ищем шаблон #123 в конце строки)
            int bookId = ExtractIdFromListBoxItem(selectedItem);
            if (bookId <= 0)
            {
                MessageBox.Show("Не удалось определить ID книги из выбранного элемента.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblBookInfo.Text = "Книга не найдена.";
                btnSell.Enabled = false;
                return;
            }

            string selectgenre = cmbGeneres.SelectedItem.ToString();

            if (selectgenre == "Все жанры")
                selectgenre = null;

            // Ищем книгу по ID в хранилище
            var book = _store.FindBook(selectgenre, bookId.ToString()).FirstOrDefault();

            if (book != null)
            {
                //Показываем информацию о книге
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

            // Проверяем баланс и вызываем EndGame при необходимости
            if (_store.Balance < 0)
            {
                MessageBox.Show("Баланс достиг нуля! Игра окончена.", "Игра завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);//Откладка
                EndGame(false);
            }
        }


        #endregion

        #region Вкладка "Поставки"

        /// <summary>
        /// Метод вывода информации о доставках книг 
        /// </summary>
        private void UpdateDeliveriesList()
        {
            lstDeliveries.Items.Clear();
            bool hasItems = false;

            foreach (var book in _pendingDeliveries)
            {
                lstDeliveries.Items.Add($"{book.author} - «{book.title}» ({book.genre})");
                hasItems = true;
            }

            // Проверяем наличие элементов и скрываем вкладку при необходимости
            if (hasItems && !IsPageDeliveriesVisible)
            {
                tabControlMain.TabPages.Add(tabPageDeliveries);
                IsPageDeliveriesVisible = true;
            }

            if (!hasItems && IsPageDeliveriesVisible)
            {
                tabControlMain.TabPages.Remove(tabPageDeliveries);
                IsPageDeliveriesVisible = false;
            }
        }

        /// <summary>
        /// Метод поиска книги при нажатии на неё в ListBox
        /// </summary>
        private void lstDeliveries_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, что выбран какой-то элемент
            if (lstDeliveries.SelectedIndex == -1) return;

            // Получаем текст выбранного элемента (Автор - «Название» (Жанр) #ID)
            string selectedItem = lstDeliveries.SelectedItem.ToString();

            // Извлекаем Автора и Название из строки (ищем шаблоны)
            string book_author = ExtractAuthorFromListBoxItem(selectedItem);
            string book_title = ExtractTitleFromListBoxItem(selectedItem);

            if (book_author == string.Empty || book_title == string.Empty)
            {
                MessageBox.Show("Не удалось определить автора или название из выбранного элемента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblDeliveryInfo.Text = "Доставка не найдена.";
                lblOrderedMark.Visible = false;
                return;
            }

            // Ищем книгу в списке ожидаемых доставок
            var deliveryBook = _pendingDeliveries.FirstOrDefault(b => b.author == book_author && b.title == book_title);

            if (deliveryBook != null)
            {
                // Показываем информацию о доставке
                lblDeliveryInfo.Text = $"Доставка: {deliveryBook.title}\nАвтор: {deliveryBook.author}\nЖанр: {deliveryBook.genre}\nЦена: {deliveryBook.value}\n";
                if (deliveryBook.order)
                {
                    lblOrderedMark.Visible = true;
                    rbNormal.Visible = false;
                    rbPlagiat.Visible = false;
                    rbTypo.Visible = false;
                }
                else
                {
                    lblOrderedMark.Visible = false;
                    rbNormal.Visible = true;
                    rbPlagiat.Visible = true;
                    rbTypo.Visible = true;
                }
            }
            else
            {
                lblDeliveryInfo.Text = "Доставка не найдена.";
                lblOrderedMark.Visible = false;
                rbNormal.Visible = false;
                rbPlagiat.Visible = false;
                rbTypo.Visible = false;
            }
        }

        /// <summary>
        /// Кнопка принятия книги
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли книга в списке поставок
            if (lstDeliveries.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите книгу из списка поставок!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Получаем выбранную строку
            string selectedItem = lstDeliveries.SelectedItem.ToString();

            string author = ExtractAuthorFromListBoxItem(selectedItem);
            string title = ExtractTitleFromListBoxItem(selectedItem);

            try
            {
                // Ищем книгу в списке поставок
                Book foundBook = _pendingDeliveries.Find(b => b.author == author && b.title == title);

                if (foundBook == null)
                {
                    MessageBox.Show("Книга не найдена в поставках!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int newId = GetNextAvailableId();

                // Удаляем из списка поставок
                _pendingDeliveries.Remove(foundBook);
                lstDeliveries.Items.Remove(selectedItem);

                Book bookToAdd = new Book(GetUniqueTitle(foundBook.title, foundBook.author), foundBook.author, newId, foundBook.genre, foundBook.pageCount, foundBook.value);

                // Проверяем флаг заказа
                if (foundBook.order)
                {
                    bookToAdd.order = true;

                    // Для заказанной книги просто добавляем в магазин
                    if (_store.AddBook(bookToAdd))
                    {
                        MessageBox.Show("Книга успешно принята в магазин!",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        UpdateDeliveriesList();
                        lblDeliveryInfo.Text = "";
                        lblOrderedMark.Visible = false;
                    }
                    else
                    {
                        // Если не удалось добавить, возвращаем в поставки
                        _pendingDeliveries.Add(foundBook);
                        lstDeliveries.Items.Add(selectedItem);
                        MessageBox.Show("Не удалось добавить книгу в магазин",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // Для обычной книги сначала проверяем баланс
                    if (_store.Balance < bookToAdd.value)
                    {
                        MessageBox.Show("Недостаточно средств для покупки книги!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // Возвращаем книгу в поставки
                        _pendingDeliveries.Add(foundBook);
                        lstDeliveries.Items.Add(selectedItem);
                        return;
                    }

                    // Снимаем стоимость с баланса
                    _store.UpdateBalance(-bookToAdd.value);
                    UpdateBalanceLabel();

                    // Добавляем в магазин
                    if (_store.AddBook(bookToAdd))
                    {
                        if (foundBook.plag || foundBook.typo)//Если с ошибкой
                        {
                            MessageBox.Show($"Обнаружена ошибка! Взимается штраф {_gameSettings.Penalty}! Книга успешно принята в магазин!",
                                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            _store.UpdateBalance(-_gameSettings.Penalty);
                            UpdateBalanceLabel();
                        }
                        else
                            MessageBox.Show("Книга успешно принята в магазин!",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lblDeliveryInfo.Text = "";
                        rbNormal.Visible = false;
                        rbPlagiat.Visible = false;
                        rbTypo.Visible = false;
                        UpdateDeliveriesList();
                    }
                    else
                    {
                        // Если не удалось добавить - возвращаем деньги
                        _store.UpdateBalance(bookToAdd.value);
                        UpdateBalanceLabel();

                        // Возвращаем книгу в поставки
                        _pendingDeliveries.Add(foundBook);
                        lstDeliveries.Items.Add(selectedItem);
                        UpdateDeliveriesList();
                        MessageBox.Show("Не удалось добавить книгу в магазин",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Обновляем интерфейс
                LoadGenres();
                cmbGenres_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}",
                    "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Кнопка отмены книги
        /// </summary>
        private void btnReject_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли книга в списке поставок
            if (lstDeliveries.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите книгу из списка поставок!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Получаем выбранную строку
            string selectedItem = lstDeliveries.SelectedItem.ToString();

            string author = ExtractAuthorFromListBoxItem(selectedItem);
            string title = ExtractTitleFromListBoxItem(selectedItem);

            try
            {
                // Ищем книгу в списке поставок
                Book foundBook = _pendingDeliveries.Find(b =>
                    b.author == author && b.title == title);

                if (foundBook == null)
                {
                    MessageBox.Show("Книга не найдена в поставках!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Проверяем тип книги
                if (foundBook.order)
                {
                    // Заказная книга - просто удаляем без возврата денег
                    _pendingDeliveries.Remove(foundBook);

                    MessageBox.Show("Заказанная книга успешно отклонена!",
                                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UpdateDeliveriesList();
                    lblDeliveryInfo.Text = "";
                    lblOrderedMark.Visible = false;
                }
                else
                {
                    // Случайная книга
                    if (!foundBook.plag && !foundBook.typo)
                    {
                        // Правильная книга - просто удаляем
                        _pendingDeliveries.Remove(foundBook);

                        MessageBox.Show("Книга успешно отклонена!",
                                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lblDeliveryInfo.Text = "";
                        rbNormal.Visible = false;
                        rbPlagiat.Visible = false;
                        rbTypo.Visible = false;
                        UpdateDeliveriesList();
                    }

                    else
                    {
                        // Книга с ошибкой
                        int bonus = 0;

                        if (rbNormal.Checked) // Обычный отказ без выбора ошибки
                        {
                            bonus = _gameSettings.Bonus1;
                        }
                        else if (rbPlagiat.Checked)
                        {
                            if (foundBook.plag)//Правильно указан плагиат
                            {
                                bonus = _gameSettings.Bonus2;
                            }
                            else
                            {
                                bonus = _gameSettings.Bonus1;
                            }
                        }
                        else if (rbTypo.Checked)
                        {
                            if (foundBook.typo)//Правильно указана опечатка
                            {
                                bonus = _gameSettings.Bonus3;
                            }
                            else
                            {
                                bonus = _gameSettings.Bonus1;
                            }
                        }

                        // Обновляем баланс
                        _store.UpdateBalance(bonus);
                        UpdateBalanceLabel();

                        // Удаляем книгу
                        _pendingDeliveries.Remove(foundBook);

                        MessageBox.Show($"Книга успешно отклонена! Начислено {bonus} за обнаружение ошибки!",
                                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lblDeliveryInfo.Text = "";
                        rbNormal.Visible = false;
                        rbPlagiat.Visible = false;
                        rbTypo.Visible = false;
                        UpdateDeliveriesList();

                    }
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}",
                    "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод обработки таймера появления случайной книги
        /// </summary>
        private void RandomBooksTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Book randomBook = new Book();
                randomBook.GenerateRandomBook();
                _pendingDeliveries.Add(randomBook);

                UpdateDeliveriesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации случайных книг: {ex.Message}",
                    "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Вкладка "Покупатели"

        /// <summary>
        /// Метод обработки таймера прихода покупателя
        /// </summary>
        private void CustomerTimer_Tick(object sender, EventArgs e)
        {
            Customer customer = new Customer(_nextCustomerId++);
            customer.GenerateRandomCustomer();
            _customersQueue.Add(customer);

            UpdateCustomersUI();
            CheckQueueLimit();
        }

        /// <summary>
        /// Метод обновления интерфейса "Покупатели"
        /// </summary>
        private void UpdateCustomersUI()
        {
            lstCustomers.Items.Clear();

            if (_customersQueue.Count == 0)
            {
                lstCustomers.Items.Add("У Вас пока нет ни одного покупателя");
                lblCustomerRequest.Text = "Требование покупателя:";
                lblSellPrice.Text = "Цена книги: 0 руб.";
                lblMaxPrice.Text = "Максимальная цена: 0 руб.";
                lblMaxPrice.Visible = false;
                lblSellPrice.Visible = false;
            }
            else
            {
                foreach (var customer in _customersQueue)
                {
                    lstCustomers.Items.Add(customer);
                }
            }

            lblQueueInfo.Text = $"Очередь: {_customersQueue.Count} / {_gameSettings.MaxQueueSize}";
            lblUnhappyCount.Text = _unhappyCustomersCount.ToString();
        }

        /// <summary>
        /// Метод вывода информации о покупателе при выборе в ListBox
        /// </summary>
        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItem is not Customer customer)
                return;

            if (customer.RequestType == CustomerRequestType.SpecificBook)
            {
                lblCustomerRequest.Text = $"Требование покупателя:\n{customer.RequestedTitle} — {customer.RequestedAuthor}";
            }
            else
            {
                lblCustomerRequest.Text = $"Требование покупателя:\nлюбая книга жанра {customer.RequestedGenre}";
            }
        }

        /// <summary>
        /// Кнопка нахождения книги для продажи покупателю
        /// </summary>
        private void btnFindBook_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItem is not Customer customer)
            {
                MessageBox.Show("Сначала выберите покупателя.");
                return;
            }

            var allBooks = _store.GetAllBooks();
            Book foundBook = null;

            if (customer.RequestType == CustomerRequestType.SpecificBook)
            {
                foundBook = allBooks.FirstOrDefault(b =>
                    b.title.Equals(customer.RequestedTitle, StringComparison.OrdinalIgnoreCase) &&
                    b.author.Equals(customer.RequestedAuthor, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                foundBook = allBooks.FirstOrDefault(b =>
                    b.genre.Equals(customer.RequestedGenre, StringComparison.OrdinalIgnoreCase));
            }

            if (foundBook == null)
            {
                txtCustomerSearch.Text = "Книга не найдена";
                return;
            }

            decimal MaxPrice = (decimal)foundBook.value * 1.15m;

            lblSellPrice.Visible = true;
            txtCustomerSearch.Text = $"{foundBook.author} — {foundBook.title} #{foundBook.id}";
            lblSellPrice.Text = $"Цена книги: {foundBook.value:F2}";
            lblMaxPrice.Text = $"Максимальная цена: {MaxPrice:F2} руб.";
            lblMaxPrice.Visible = _gameSettings.IsEasyMode;
        }

        /// <summary>
        /// Метод изъятия книги из SearchBox
        /// </summary>
        /// <returns>найденная по id книга</returns>
        private Book FindBookFromSearchBox()
        {
            string text = txtCustomerSearch.Text;

            if (string.IsNullOrWhiteSpace(text) || !text.Contains("#"))
                return null;

            int hashIndex = text.LastIndexOf('#');
            string idPart = text.Substring(hashIndex + 1).Trim();

            if (!int.TryParse(idPart, out int id))
                return null;

            return _store.GetAllBooks().FirstOrDefault(b => b.id == id);
        }

        /// <summary>
        /// Метод проверки соответствия книги желанию покупателя
        /// </summary>
        /// <param name="customer">покупатель</param>
        /// <param name="book">книга для продажи</param>
        /// <returns>True при соответствии пожеланиям</returns>
        private bool IsBookSuitable(Customer customer, Book book)
        {
            if (customer.RequestType == CustomerRequestType.SpecificBook)
            {
                return book.title.Equals(customer.RequestedTitle, StringComparison.OrdinalIgnoreCase)
                    && book.author.Equals(customer.RequestedAuthor, StringComparison.OrdinalIgnoreCase);
            }

            return book.genre.Equals(customer.RequestedGenre, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Метод проверки стоимости книги желанию покупателя
        /// </summary>
        /// <param name="customer">покупатель</param>
        /// <param name="book">книга</param>
        /// <param name="sellPrice">стоимость книги</param>
        /// <returns>True если покупатель готов купить книгу по такой стоимости</returns>
        private bool IsPriceAllowed(Customer customer, Book book, decimal sellPrice)
        {
            decimal MaxPrice = (decimal)book.value * 1.15m;//Цена с наценкой 15% - максимальная стоимость книги

            return sellPrice <= MaxPrice;
        }

        /// <summary>
        /// Кнопка продажи книги покупателю
        /// </summary>
        private void btnSellToCustomer_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItem is not Customer customer)
            {
                MessageBox.Show("Выберите покупателя.");
                return;
            }

            var book = FindBookFromSearchBox();

            if (book == null)
            {
                MessageBox.Show("Сначала найдите подходящую книгу.");
                return;
            }

            if (!decimal.TryParse(txtSellPrice.Text, out decimal enteredPrice) || enteredPrice <= 0)
            {
                MessageBox.Show("Введите корректную цену.");
                return;
            }

            if (!IsPriceAllowed(customer, book, enteredPrice))
            {
                MakeCustomerUnhappy(customer, "Покупатель отказался: цена слишком высокая.");
                return;
            }

            if (!IsBookSuitable(customer, book))
            {
                MakeCustomerUnhappy(customer, "Покупатель отказался: книга не подходит.");
                return;
            }

            bool sold = _store.SellBookById(book.id);
            if (!sold)
            {
                MessageBox.Show("Не удалось продать книгу.");
                return;
            }

            //Обновляем баланс
            _store.UpdateBalance(enteredPrice);
            UpdateBalanceLabel();

            _customersQueue.Remove(customer);

            txtCustomerSearch.Clear();
            txtSellPrice.Clear();

            LoadGenres();
            cmbGenres_SelectedIndexChanged(sender, e);
            UpdateCustomersUI();

            MessageBox.Show("Книга успешно продана покупателю.");
        }

        /// <summary>
        /// Метод обработки недовольного покупателя
        /// </summary>
        /// <param name="customer">покупатель</param>
        /// <param name="message">сообщение - причина недовольности</param>
        private void MakeCustomerUnhappy(Customer customer, string message)
        {
            _unhappyCustomersCount++;
            _customersQueue.Remove(customer);

            txtCustomerSearch.Clear();
            txtSellPrice.Clear();

            UpdateCustomersUI();
            CheckUnhappyLimit();

            MessageBox.Show(message);
        }

        /// <summary>
        /// Кнопка отказа покупателю
        /// </summary>
        private void btnRefuseCustomer_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItem is not Customer customer)
            {
                MessageBox.Show("Выберите покупателя.");
                return;
            }

            MakeCustomerUnhappy(customer, "Вы отказали покупателю в продаже.");
        }

        /// <summary>
        /// Метод проверки очереди
        /// </summary>
        private void CheckQueueLimit()
        {
            if (_customersQueue.Count >= _gameSettings.MaxQueueSize)
            {
                _customerTimer.Stop();
                MessageBox.Show("Очередь покупателей стала слишком большой. Вы проиграли.");
                EndGame(false);
            }
        }

        /// <summary>
        /// Метод проверки количества неудовлетворённых покупателей
        /// </summary>
        private void CheckUnhappyLimit()
        {
            if (_unhappyCustomersCount >= _gameSettings.MaxUnhappyCustomers)
            {
                _customerTimer.Stop();
                MessageBox.Show("Слишком много неудовлетворённых покупателей. Вы проиграли.");
                EndGame(false);
            }
        }

        #endregion Покупатели

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

        /// <summary>
        /// Вспомогательный метод для извлечения ID из конца строки элемента ListBox
        /// Ожидаемый формат: "Автор — «Название» (Жанр) #123"
        /// </summary>
        private int ExtractIdFromListBoxItem(string itemText)
        {
            if (string.IsNullOrEmpty(itemText))
                return -1;

            // Ищем символ # с конца строки
            int hashIndex = itemText.LastIndexOf('#');
            if (hashIndex == -1)
                return -1; // Символ # не найден

            // Проверяем, что после # идут только цифры до самого конца строки
            string idCandidate = itemText.Substring(hashIndex + 1);

            // Убеждаемся, что оставшаяся часть состоит только из цифр и не пуста
            if (string.IsNullOrEmpty(idCandidate) || !idCandidate.All(char.IsDigit))
                return -1;

            // Пытаемся распарсить число
            if (int.TryParse(idCandidate, out int id))
            {
                return id;
            }

            return -1;
        }

        /// <summary>
        /// Метод для извлечения автора из строки элемента ListBox
        /// Ожидаемый формат: "Автор — «Название» (Жанр) #123"
        /// </summary>
        private string ExtractAuthorFromListBoxItem(string itemText)
        {
            if (string.IsNullOrEmpty(itemText))
                return string.Empty;

            // Ищем разделитель " - "
            int dashIndex = itemText.IndexOf(" - ");
            if (dashIndex == -1)
                return string.Empty;

            // Возвращаем часть строки до разделителя
            return itemText.Substring(0, dashIndex).Trim();
        }

        /// <summary>
        /// Метод для извлечения названия из строки элемента ListBox
        /// Ожидаемый формат: "Автор - «Название» (Жанр) #123"
        /// </summary>
        private string ExtractTitleFromListBoxItem(string itemText)
        {
            if (string.IsNullOrEmpty(itemText))
                return string.Empty;

            // Ищем шаблон "Автор - «Название» (Жанр) #ID"
            int authorEndIndex = itemText.IndexOf(" - ");
            if (authorEndIndex == -1)
                return string.Empty;

            // Ищем начало названия (после кавычки)
            int titleStartIndex = itemText.IndexOf('«');//Alt + 0171
            if (titleStartIndex == -1)
                return string.Empty;

            // Ищем конец названия (перед последней кавычкой)
            int titleEndIndex = itemText.LastIndexOf('»');//Alt + 0187
            if (titleEndIndex == -1 || titleEndIndex <= titleStartIndex)
                return string.Empty;

            // Извлекаем название с учетом всех скобок внутри
            string title = itemText.Substring(titleStartIndex + 1, titleEndIndex - titleStartIndex - 1).Trim();

            return title;
        }

        /// <summary>
        /// Метод остановки таймеров при закрытии формы
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Останавливаем все таймеры при закрытии формы
            _deliveryTimer.Stop();
            _timerRandomBooks.Stop();
            _gameTimer.Stop();
            _customerTimer.Stop();
            base.OnFormClosing(e);
        }

        /// <summary>
        /// Метод обработки таймера игрового времени
        /// </summary>
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            _elapsedTime++;

            if (_elapsedTime >= _gameSettings.GameDayTime)
            {
                EndGame(true);
            }
        }

        /// <summary>
        /// Метод обработки завершения игры
        /// </summary>
        /// <param name="isWinner">True если победа (закончился игровой день), false - если проигрыш</param>
        private void EndGame(bool isWinner)
        {
            _deliveryTimer.Stop();
            _timerRandomBooks.Stop();
            _gameTimer.Stop();
            _customerTimer.Stop();
            MessageBox.Show("Конец игры!", "Игра завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);//Откладка

            // Создаём форму завершения игры с передачей параметров
            FormEndGame endGameForm = new FormEndGame(_gameSettings, isWinner, _elapsedTime, _store, _unhappyCustomersCount, _customersQueue.Count);

            this.Hide();//Скрываем текущую форму

            // Открываем новую форму в модальном режиме
            endGameForm.ShowDialog();

            // Закрываем текущую форму после того, как FormEndGame будет закрыта
            this.Close();

        }

        #endregion

    }
}
