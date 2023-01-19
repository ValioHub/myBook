using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myBook.Services;
using myBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("getAllBooks")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("getBookById/{id}")]
        public IActionResult getBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("addBookWithAuthors)")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok(); 
        }

        [HttpPut("UpdateBookById/{id}")]
        public IActionResult UpdateBookById(int id,[FromBody]BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("DeleteBookById/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
