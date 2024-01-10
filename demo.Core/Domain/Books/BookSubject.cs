using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Core.Domain.Books
{
    public class BookSubject
    {
        public int BookId { get; set; }
        public Book? Book { get; set; }

        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
