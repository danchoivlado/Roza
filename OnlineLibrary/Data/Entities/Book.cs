using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }

        public string ISBN { get; set; }

        public string OnlineLink { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
