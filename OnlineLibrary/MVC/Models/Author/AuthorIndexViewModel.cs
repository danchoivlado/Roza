using ApplicationService.DTOs;

namespace MVC.Models.Author
{
    public class AuthorIndexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public bool IsAlive { get; set; }

        public AuthorIndexViewModel(AuthorDTO author)
        {
            this.Id = author.Id;
            this.Name = author.Name;
            this.IsAlive = author.IsAlive;
        }

        public AuthorIndexViewModel()
        {

        }
    }
}
