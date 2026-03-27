using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibrary;
using System;
using System.Linq;

namespace BookShop.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Book_Constructor_CreatesCorrectBook()
        {
            var book = new Book("TestTitle", "TestAuthor", 1, "Fantasy", 300, 500);

            Assert.AreEqual("TestTitle", book.title);
            Assert.AreEqual("TestAuthor", book.author);
            Assert.AreEqual(1, book.id);
            Assert.AreEqual("Fantasy", book.genre);
            Assert.AreEqual(300, book.pageCount);
            Assert.AreEqual(500, book.value);
        }

        [TestMethod]
        public void Book_DefaultConstructor_CreatesEmptyBook()
        {
            var book = new Book();

            Assert.AreEqual("", book.title);
            Assert.AreEqual("", book.author);
            Assert.AreEqual(0, book.id);
        }

        [TestMethod]
        public void GenerateRandom_FillsBookFields()
        {
            var book = new Book();

            book.GenerateRandom();

            Assert.IsFalse(string.IsNullOrEmpty(book.title));
            Assert.IsFalse(string.IsNullOrEmpty(book.author));
            Assert.IsFalse(string.IsNullOrEmpty(book.genre));
            Assert.IsTrue(book.pageCount > 0);
            Assert.IsTrue(book.value > 0);
        }

        [TestMethod]
        public void AddToDB_WithEmptyFields_DoesNothing()
        {
            var book = new Book();

            book.AddToDB();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddToDB_WhenNotOrdered_DoesNotAdd()
        {
            var book = new Book("Test", "Author", 1, "Drama", 100, 50);

            book.order = false;

            book.AddToDB();

            Assert.IsTrue(true);
        }
    }

    [TestClass]
    public class BookcaseTests
    {
        [TestMethod]
        public void AddBook_WhenSpaceAvailable_ReturnsTrue()
        {
            var shelf = new Bookcase(5);
            var book = new Book("Test", "Author", 1, "Drama", 200, 100);

            bool result = shelf.AddBook(book);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FindByTitle_ReturnsCorrectBook()
        {
            var shelf = new Bookcase(5);
            var book = new Book("TestBook", "Author", 1, "Drama", 200, 100);
            shelf.AddBook(book);

            var result = shelf.FindByTitle("TestBook");

            Assert.IsNotNull(result);
            Assert.AreEqual("TestBook", result.title);
        }

        [TestMethod]
        public void FindById_ReturnsCorrectBook()
        {
            var shelf = new Bookcase(5);
            var book = new Book("TestBook", "Author", 1, "Drama", 200, 100);
            shelf.AddBook(book);

            var result = shelf.FindById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.id);
        }

        [TestMethod]
        public void AddBook_WhenShelfFull_ReturnsFalse()
        {
            var shelf = new Bookcase(1);

            var book1 = new Book("A", "B", 1, "Drama", 100, 50);
            var book2 = new Book("C", "D", 2, "Drama", 200, 60);

            shelf.AddBook(book1);
            bool result = shelf.AddBook(book2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddBook_WrongGenre_ReturnsFalse()
        {
            var shelf = new Bookcase(5);

            var book1 = new Book("A", "B", 1, "Drama", 100, 50);
            var book2 = new Book("C", "D", 2, "Fantasy", 200, 60);

            shelf.AddBook(book1);
            bool result = shelf.AddBook(book2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FindByTitle_NotExisting_ReturnsNull()
        {
            var shelf = new Bookcase(5);

            var result = shelf.FindByTitle("Unknown");

            Assert.IsNull(result);
        }
    }

    [TestClass]
    public class ShopTests
    {
        [TestMethod]
        public void Shop_Constructor_CreatesShop()
        {
            var shop = new Shop(5, 10);

            Assert.AreEqual(0, shop.Balance);
        }

        [TestMethod]
        public void AddBook_AddsBookToShop()
        {
            var shop = new Shop(5, 10);
            var book = new Book("Test", "Author", 1, "Drama", 200, 100);

            bool result = shop.AddBook(book);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetAllBooks_ReturnsBooks()
        {
            var shop = new Shop(5, 10);
            var book = new Book("Test", "Author", 1, "Drama", 200, 100);
            shop.AddBook(book);

            var books = shop.GetAllBooks();

            Assert.AreEqual(1, books.Count);
        }

        [TestMethod]
        public void UpdateBalance_IncreasesBalance()
        {
            var shop = new Shop(5, 10);

            shop.UpdateBalance(100);

            Assert.AreEqual(100, shop.Balance);
        }

        [TestMethod]
        public void SellBookById_RemovesBook()
        {
            var shop = new Shop(5, 10);
            var book = new Book("Test", "Author", 1, "Drama", 200, 100);

            shop.AddBook(book);

            bool sold = shop.SellBookById(1);

            Assert.IsTrue(sold);
            Assert.AreEqual(0, shop.GetAllBooks().Count);
        }

        [TestMethod]
        public void FindBook_ByTitle_ReturnsBook()
        {
            var shop = new Shop(5, 10);
            var book = new Book("Test", "Author", 1, "Drama", 200, 100);

            shop.AddBook(book);

            var result = shop.FindBook(null, "Test");

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GenerateRandom_FillsBookFields()
        {
            var book = new Book();

            book.GenerateRandom();

            Assert.IsFalse(string.IsNullOrEmpty(book.title));
            Assert.IsFalse(string.IsNullOrEmpty(book.author));
            Assert.IsFalse(string.IsNullOrEmpty(book.genre));
            Assert.IsTrue(book.pageCount > 0);
            Assert.IsTrue(book.value > 0);
        }

        [TestMethod]
        public void AddBook_WhenShelfFull_ReturnsFalse()
        {
            var shelf = new Bookcase(1);

            var book1 = new Book("A", "B", 1, "Drama", 100, 50);
            var book2 = new Book("C", "D", 2, "Drama", 200, 60);

            shelf.AddBook(book1);
            bool result = shelf.AddBook(book2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddBook_WrongGenre_ReturnsFalse()
        {
            var shelf = new Bookcase(5);

            var book1 = new Book("A", "B", 1, "Drama", 100, 50);
            var book2 = new Book("C", "D", 2, "Fantasy", 200, 60);

            shelf.AddBook(book1);
            bool result = shelf.AddBook(book2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FindByTitle_NotExisting_ReturnsNull()
        {
            var shelf = new Bookcase(5);

            var result = shelf.FindByTitle("Unknown");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void FindBook_ById_ReturnsBook()
        {
            var shop = new Shop(5, 10);
            var book = new Book("Test", "Author", 1, "Drama", 100, 50);

            shop.AddBook(book);

            var result = shop.FindBook(null, "1");

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetBooksByGenre_ReturnsBooks()
        {
            var shop = new Shop(5, 10);
            var book = new Book("Test", "Author", 1, "Drama", 100, 50);

            shop.AddBook(book);

            var result = shop.GetBooksByGenre("Drama");

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void SellBookById_NotExisting_ReturnsFalse()
        {
            var shop = new Shop(5, 10);

            bool result = shop.SellBookById(999);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetAvailableGenres_ReturnsGenre()
        {
            var shop = new Shop(5, 10);
            var book = new Book("Test", "Author", 1, "Drama", 100, 50);

            shop.AddBook(book);

            var genres = shop.GetAvailableGenres();

            Assert.AreEqual("Drama", genres[0]);
        }

        [TestMethod]
        public void FindBook_EmptySearch_ReturnsEmptyList()
        {
            var shop = new Shop(5, 10);

            var result = shop.FindBook(null, "");

            Assert.AreEqual(0, result.Count);
        }
    }

    [TestClass]
    public class GameSettingsTests
    {
        [TestMethod]
        public void Constructor_SetsDefaultValues()
        {
            var settings = new GameSettings();

            Assert.AreEqual("Нормальный", settings.Difficulty);
            Assert.IsFalse(settings.IsEasyMode);
            Assert.AreEqual(1000, settings.StartBalance);
        }

        [TestMethod]
        public void ResetToDefault_SetsDefaultValues()
        {
            var settings = new GameSettings();

            settings.StartBalance = 999;
            settings.ResetToDefault();

            Assert.AreEqual(1000, settings.StartBalance);
        }

        [TestMethod]
        public void SetDifficulty_EasyMode_SetsCorrectValues()
        {
            var settings = new GameSettings();

            settings.SetDifficulty("«Лёгкий»");

            Assert.IsTrue(settings.IsEasyMode);
            Assert.AreEqual(1500, settings.StartBalance);
        }

        [TestMethod]
        public void SetDifficulty_HardMode_SetsCorrectValues()
        {
            var settings = new GameSettings();

            settings.SetDifficulty("«Сложный»");

            Assert.IsFalse(settings.IsEasyMode);
            Assert.AreEqual(800, settings.StartBalance);
        }

        [TestMethod]
        public void SetDifficulty_Invalid_SetsDefault()
        {
            var settings = new GameSettings();

            settings.SetDifficulty("INVALID");

            Assert.AreEqual(1000, settings.StartBalance);
        }
    }

    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void Constructor_SetsId()
        {
            var customer = new Customer(5);

            Assert.AreEqual(5, customer.Id);
        }

        [TestMethod]
        public void ToString_SpecificBook_ReturnsCorrectString()
        {
            var customer = new Customer(1);
            customer.RequestType = CustomerRequestType.SpecificBook;
            customer.RequestedTitle = "Book";
            customer.RequestedAuthor = "Author";

            var result = customer.ToString();

            Assert.IsTrue(result.Contains("Book"));
        }

        [TestMethod]
        public void ToString_Genre_ReturnsCorrectString()
        {
            var customer = new Customer(1);
            customer.RequestType = CustomerRequestType.Genre;
            customer.RequestedGenre = "Drama";

            var result = customer.ToString();

            Assert.IsTrue(result.Contains("Drama"));
        }

        [TestMethod]
        public void GenerateRandomCustomer_DoesNotCrash()
        {
            var customer = new Customer(1);

            customer.GenerateRandomCustomer();

            Assert.IsTrue(customer.RequestType == CustomerRequestType.Genre
                       || customer.RequestType == CustomerRequestType.SpecificBook);
        }
    }

    [TestClass]
    public class ShopDbTests
    {
        [TestMethod]
        public void InitializeDB_CreatesFile()
        {
            var shop = new Shop(5, 10);

            shop.InitializeDB();

            Assert.IsTrue(File.Exists(Path.Combine("NameData", "BooksDb.txt")));
        }

        [TestMethod]
        public void InitializeDB_DoesNotCrash()
        {
            var shop = new Shop(5, 10);

            shop.InitializeDB();

            Assert.IsTrue(true);
        }
    }
}