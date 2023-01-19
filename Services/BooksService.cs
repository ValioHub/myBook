using myBook.Data;
using myBook.Models;
using myBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBook.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                Rate = book.Rate,
                Genre = book.Genre,
                PublisherId = book.PublisherId,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
            foreach (var id in book.AuthorIds)
            {
                var _bookAuthor = new BookAuthor()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.BooksAuthors.Add(_bookAuthor);
                _context.SaveChanges();
            }
        }
        public List<Book> GetAllBooks()
        {
            var allBooks = _context.Books.ToList();
            return allBooks;
        }
        public Book GetBookById(int bookId)
        {
            var book = _context.Books.FirstOrDefault(n=>n.Id==bookId);
            return book;
        }
        public Book UpdateBookById(int bookId,BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
                _context.SaveChanges();
            }

            return _book;
        }
        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
