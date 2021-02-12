using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllerApp.Interfaces;
using ControllerApp.TempModels.Books;
using ControllerApp.TempModels.UserBooks;
using Microsoft.AspNetCore.Mvc;

namespace ControllerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    [ResponseCache(Duration = 5)]
    public class BooksController : ControllerBase
    {
        private readonly IBookInterface _bookInterface;
        private readonly IUserInterface _userInterface;

        public BooksController(IBookInterface bookInterface,IUserInterface userInterface)
        {
            _bookInterface = bookInterface;
            _userInterface = userInterface;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookInterface.GetBooks();
            return Ok(books);
        }

        [HttpGet("author")]
        public IActionResult GetAuthors()
        {
            var authors = _bookInterface.GetAouthors();
            return Ok(authors);
        }

        [HttpGet("userBooks")]
        public IActionResult GetUserBooks()
        {
            var userBooks = _bookInterface.GetUserBooks();
            foreach (var userBook in userBooks)
            {
                userBook.User = _userInterface.GetUser(userBook.UserId);
                userBook.Book = _bookInterface.GetBookById(userBook.BookId);
                userBook.UserBookStates = _bookInterface.GetUserBookStates(userBook.UserBookId);
            }

            return Ok(userBooks);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody]TempBook tempBook)
        {
            if (tempBook == null)
            {
                return BadRequest("Book is null are you crazy");
            }
            var book = _bookInterface.AddBook(tempBook);
            return Ok(book);
        }

        [HttpPost("author")]
        public IActionResult AddAuthor([FromBody]TempAuthor tempAuthor)
        {
            if (tempAuthor == null)
            {
                return BadRequest("Author is null are you crazy");
            }
            var author = _bookInterface.AddAuthor(tempAuthor);
            return Ok(author);
        }

        [HttpPost("allocateBook")]
        public IActionResult AllocateBook([FromBody]TempUserBook tempUserBook)
        {
            if (tempUserBook == null)
            {
                return BadRequest("User Book is null are you crazy");
            }
            var userBook = _bookInterface.AlocateBook(tempUserBook);
            return Ok(userBook);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookInterface.GetBookById(id);
            if (book == null)
            {
                return NotFound($"Book with Id {id} was not found contact Stanley");
            }
            return Ok(book);
        }

        [HttpGet("author/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _bookInterface.GetAuthorById(id);
            if (author == null)
            {
                return NotFound($"Author with Id {id} was not found contact Stanley");
            }
            return Ok(author);
        }

        [HttpGet("userBooks/{id}")]
        public IActionResult GetUserBookById(int id)
        {
            var userBook = _bookInterface.GetUserBookById(id);
            if (userBook == null)
            {
                return NotFound($"User Book with Id {id} was not found contact Stanley");
            }
            return Ok(userBook);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody]TempBook tempBook)
        {
            if (tempBook == null)
            {
                return BadRequest("Book is null");
            }
            _bookInterface.UpdateBook(tempBook);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody]TempUserBook tempUserBook)
        {
            if (tempUserBook == null)
            {
                return BadRequest("User book is null");
            }
            _bookInterface.ReturnBook(tempUserBook.UserBookId);
            return NoContent();
        }
    }
}