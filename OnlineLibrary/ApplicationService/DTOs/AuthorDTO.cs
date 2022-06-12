using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAlive { get; set; }

        public virtual List<Book> Books { get; set; }
        public AuthorDTO()
        {
        }

        public AuthorDTO(Author author)
        {
            this.Id = author.Id;
            this.Name = author.Name;
            this.IsAlive = author.IsAlive;
            this.Books = author.Books.ToList();
        }
    }
}
