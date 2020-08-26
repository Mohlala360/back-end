using System;

namespace ControllerApp.TempModels.Books
{    
    public class TempBook
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public TempAuthor Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
