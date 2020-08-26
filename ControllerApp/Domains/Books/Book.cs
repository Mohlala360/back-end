using System;

namespace ControllerApp.Domains.Books
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
