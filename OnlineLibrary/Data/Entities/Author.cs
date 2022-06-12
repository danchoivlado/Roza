using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public bool IsAlive { get; set; }

        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public virtual ICollection<Book> Books { get; set; }

    }
}
