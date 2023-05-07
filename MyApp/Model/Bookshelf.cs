namespace MyGamingStorage.Model
{
    public class Bookshelf
    {
        // creating a var that will be a list of objects (book type) called _books (convention for private variables).
        private List<Book> _books;


        public Bookshelf()
        {
            _books = new List<Book>();
        }


        public bool AddToBookshelf(Book book)
        {
            //foreach (Book existingBook in _books)
            //{
            //    if (existingBook.Title == book.Title && existingBook.Author == existingBook.Author)
            //        return false;
            //}
            //_books.Add(book);
            //return true;

            var existingBook = GetBook(book.Title, book.Author);
            if (existingBook is not null)
                return false;
            _books.Add(book);
            return true;
        }


        public int getBookCount()
        {
            return _books.Count;
        }

        public Book? borrowBook(string title, string author)
        {
            var book = GetBook(title, author);
            if (book is not null)
            {
                _books.Remove(book);
            }
            return book;
        }

        public Book? GetBook(string title, string author)
        {
            foreach (Book existingBook in _books)
            {
                if (existingBook.Title == title && existingBook.Author == author)
                {
                    return existingBook;
                }
            }
            return null;
        }
    }
}

