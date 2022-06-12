using ApplicationService.DTOs;

namespace MVC.Models.Book
{
    public class BookCreateViewModel
    {
        public string Name { get; set; }

        public string ISBN { get; set; }

        public string OnlineLink { get; set; }

        public int AuthorId { get; set; }

        public BookCreateViewModel()
        {

        }

        public BookCreateViewModel(BookDTO bookDTO)
        {
            this.Name = bookDTO.Name;
            this.ISBN = bookDTO.ISBN;
            this.OnlineLink = bookDTO.OnlineLink;
            this.AuthorId = bookDTO.AuthorId;
        }
    }
}
