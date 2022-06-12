using ApplicationService.DTOs;


namespace MVC.Models.Author
{
    public class AuthorDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public bool IsAlive { get; set; }

        public List<Data.Entities.Book> Books { get; set; }

        public AuthorDetailsViewModel(AuthorDTO author)
        {
            this.Id = author.Id;
            this.Name = author.Name;
            this.IsAlive = author.IsAlive;
            this.Books = author.Books.ToList();
        }

        public AuthorDetailsViewModel()
        {

        }
    }
}
