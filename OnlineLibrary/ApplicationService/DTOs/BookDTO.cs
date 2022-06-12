using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ISBN { get; set; }

        public string OnlineLink { get; set; }

        public int AuthorId { get; set; }

        public BookDTO(Book book)
        {
            this.Id = book.Id;
            this.Name = book.Name;
            this.ISBN = book.ISBN;
            this.OnlineLink = book.OnlineLink;
            this.AuthorId = book.AuthorId;
        }

        public BookDTO()
        {

        }
    }
}
