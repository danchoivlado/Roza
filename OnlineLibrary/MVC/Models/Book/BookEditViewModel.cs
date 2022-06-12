using ApplicationService.DTOs;

namespace MVC.Models.Book
{
    public class BookEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ISBN { get; set; }

        public string OnlineLink { get; set; }

        public int AuthorId { get; set; }

        public BookEditViewModel()
        {

        }

        public BookEditViewModel(BookDTO bookDTO)
        {
            this.Id = bookDTO.Id;
            this.Name = bookDTO.Name;
            this.ISBN = bookDTO.ISBN;
            this.OnlineLink = bookDTO.OnlineLink;
            this.AuthorId = bookDTO.AuthorId;
        }
    }
}
