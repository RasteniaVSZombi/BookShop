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
}