using ApplicationService.DTOs;

namespace MVC.Models.Book
{
    public class BookIndexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ISBN { get; set; }

        public string OnlineLink { get; set; }

        public string AuthorName { get; set; }

        public BookIndexViewModel()
        {

        }

        public BookIndexViewModel(BookDTO bookDTO, string authorName)
        {
            this.Id = bookDTO.Id;
            this.Name = bookDTO.Name;
            this.ISBN = bookDTO.ISBN;
            this.OnlineLink = bookDTO.OnlineLink;
            this.AuthorName = authorName;
        }

    }
}
