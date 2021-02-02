using ControllerApp.Domains.Books;
using ControllerApp.Domains.UserBooks;
using ControllerApp.TempModels.Books;
using ControllerApp.TempModels.UserBooks;
using System.Collections.Generic;

namespace ControllerApp.Interfaces
{
    public interface IBookInterface
    {
        Book AddBook(TempBook tempBook);
        Book GetBookById(int bookId);
        List<Book> GetBooks();
        void UpdateBook(TempBook tempBook);
        void DeleteBook(int bookId);

        List<Book> GetBookByAuthor(int authorId);
        Author AddAuthor(TempAuthor tempAuthor);
        Author GetAuthorById(int authorId);
        List<Author> GetAouthors();

        UserBook AlocateBook(TempUserBook tempUserBook);
        void ReturnBook(int userBookId);        
        List<UserBook> NumberOfBooksToReturn();
        List<UserBook> GetUserBooks();
            List<UserBookState> GetUserBookStates(int stateId);
        UserBook GetUserBookById(int id);
    }
}
