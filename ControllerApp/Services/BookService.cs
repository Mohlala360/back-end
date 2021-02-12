using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ControllerApp.Domains.Books;
using ControllerApp.Domains.UserBooks;
using ControllerApp.Interfaces;
using ControllerApp.TempModels.Books;
using ControllerApp.TempModels.UserBooks;

namespace ControllerApp.Services
{
    public class BookService : IBookInterface
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public BookService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public Author AddAuthor(TempAuthor tempAuthor)
        {
            var author = new Author
            {
                AuthorName = tempAuthor.Name,
                AuthorSurname = tempAuthor.Surname
            };

            _databaseContext.Authors.Add(author);
            _databaseContext.SaveChanges();
            return author;
        }

        public Book AddBook(TempBook tempBook)
        {
            var book = new Book
            {
                Title = tempBook.Title,
                PublishDate = tempBook.PublishDate,
                AuthorId = tempBook.AuthorId
            };

            _databaseContext.Books.Add(book);
            _databaseContext.SaveChanges();
            return book;
        }

        public UserBook AlocateBook(TempUserBook tempUserBook)
        {
            var userBook = new UserBook
            {
                UserId = tempUserBook.UserId,
                BookId = tempUserBook.BookId
            };

            _databaseContext.UserBooks.Add(userBook);
            _databaseContext.SaveChanges();

            var userBookState = new UserBookState
            {
                UserBookId = userBook.UserBookId,
                UserBookStatusId = (int)UserBookStatuses.Alocate
            };

            userBookState.UserBookStateDateUpdated = DateTime.Now;

            _databaseContext.UserBookStates.Add(userBookState);
            _databaseContext.SaveChanges();

            return userBook;
        }

        public void DeleteBook(int bookId)
        {
            var book = GetBookById(bookId);
            _databaseContext.Books.Remove(book);
            _databaseContext.SaveChanges();
        }

        public List<Author> GetAouthors()
        {
            return _databaseContext.Authors.ToList();
        }

        public Author GetAuthorById(int authorId)
        {
            return _databaseContext.Authors.Find(authorId);
        }

        public List<Book> GetBookByAuthor(int authorId)
        {
            return _databaseContext.Books.Where(b => b.AuthorId == authorId).ToList();
        }

        public Book GetBookById(int bookId)
        {
            return _databaseContext.Books.Find(bookId);
        }

        public List<Book> GetBooks()
        {
            return _databaseContext.Books.ToList();
        }

        public UserBook GetUserBookById(int id)
        {
            return _databaseContext.UserBooks.Find(id);
        }

        public List<UserBook> GetUserBooks()
        {
            return _databaseContext.UserBooks.ToList();
        }

        public List<UserBookState> GetUserBookStates(int stateId)
        {
            return _databaseContext.UserBookStates.Where(u => u.UserBookId == stateId).ToList();
        }        
        
       public List<UserBook> NumberOfBooksToReturn()
        {
            return
                _databaseContext.UserBooks.Where(b => b.UserBookStates
                .OrderByDescending(s => s.UserBookStatusId)
                .FirstOrDefault().UserBookStatusId == (int)UserBookStatuses.Alocate)
                .ToList();
        }

        public void ReturnBook(int userBookId)
        {
            var userBook = _databaseContext.UserBooks.Find(userBookId);

            var userBookState = new UserBookState
            {
                UserBookId = userBook.UserBookId,
                UserBookStatusId = (int)UserBookStatuses.Return
            };

            userBookState.UserBookStateDateUpdated = DateTime.Now;

            _databaseContext.UserBookStates.Add(userBookState);
            _databaseContext.SaveChanges();
        }

        public void UpdateBook(TempBook tempBook)
        {
            var book = _databaseContext.Books.Find(tempBook.BookId);

            book.AuthorId = tempBook.AuthorId;
            book.Title = tempBook.Title;
            book.PublishDate = tempBook.PublishDate;
        }
    }
}
