using FluentAssertions;
using MyGamingStorage.Model;

namespace MyGamingStorage.tests;

public class UnitTest1
{
    [Fact]
    public void AddBookToBookshelf_AddsBookCorrectly()
    {
        // Arrange
        Bookshelf bookshelf = new();
        Book book = new("Carrie", "Stephen King");

        // Act
        bool result = bookshelf.AddToBookshelf(book);

        // Assert
        result.Should().BeTrue();
        int bookCount = bookshelf.getBookCount();
        bookCount.Should().Be(1);
    }

    [Fact]
    public void AddBooksToBookshelf_AddsBooksCorrectly()
    {
        // Arrange
        Bookshelf bookshelf = new();
        Book book = new("Carrie", "Stephen King");
        Book book2 = new("The Institute", "Stephen King");

        // Act
        bool result1 = bookshelf.AddToBookshelf(book);
        bool result2 = bookshelf.AddToBookshelf(book2);

        // Assert
        result1.Should().BeTrue();
        result2.Should().BeTrue();
        int bookCount = bookshelf.getBookCount();
        bookCount.Should().Be(2);
    }

    [Fact]
    public void AddRepeatedBookToBookshelf_ShouldNotAllowRepeatedBook()
    {
        // Arrange
        Bookshelf bookshelf = new();
        Book book = new("Carrie", "Stephen King");

        // Act
        bool result = bookshelf.AddToBookshelf(book);
        bool result2 = bookshelf.AddToBookshelf(book);

        // Assert
        result.Should().BeTrue();
        result2.Should().BeFalse();
        int bookCount = bookshelf.getBookCount();
        bookCount.Should().Be(1);
    }

    [Fact]
    public void UpdatingExistingBook_ShouldReturnFalse()
    {
        // Arrange
        Book book = new("Carrie", "Stephen King");

        // Act
        book.Title = "The Selfish Gene";
        book.Author = "Richard Dawkins";

        // Assert
        book.Title.Should().Be("The Selfish Gene");
        book.Author.Should().Be("Richard Dawkins");
    }

    [Fact]
    public void BorrowingBookFromBookshelf_ShouldReturnBorrowedBook()
    {
        // Arrange
        Bookshelf bookshelf = new();
        Book book = new("Carrie", "Stephen King");
        bookshelf.AddToBookshelf(book);

        // Act
        Book? borrowedBook = bookshelf.borrowBook("Carrie", "Stephen King");

        // Assert
        borrowedBook!.Title.Should().Be("Carrie");
        borrowedBook.Author.Should().Be("Stephen King");
        Book? result = bookshelf.GetBook("Carrie", "Stephen King");
        result.Should().Be(null);
        bookshelf.getBookCount().Should().Be(0);
    }

    [Fact]
    public void BorrowingNonExistingBookFromBookshelf_ShouldReturnNull()
    {
        // Arrange
        Bookshelf bookshelf = new();

        // Act
        Book? borrowedBook = bookshelf.borrowBook("Carrie", "Stephen King");

        // Assert
        borrowedBook.Should().Be(null);
    }

    [Fact]
    public void GetBookByDetails_ShoudlReturnBook()
    {
        // Arrange
        Bookshelf bookshelf = new();
        Book book = new("Carrie", "Stephen King");
        bookshelf.AddToBookshelf(book);

        // Act
        Book? result = bookshelf.GetBook("Carrie", "Stephen King");

        // Assert
        result!.Title.Should().Be("Carrie");
        result.Author.Should().Be("Stephen King");
    }

    [Fact]
    public void GetNonExistingBookByDetails_ShoudlNotReturnBook()
    {
        // Arrange
        Bookshelf bookshelf = new();

        // Act
        Book? result = bookshelf.GetBook("Carrie", "Stephen King");

        // Assert
        result.Should().BeNull();
    }
}
