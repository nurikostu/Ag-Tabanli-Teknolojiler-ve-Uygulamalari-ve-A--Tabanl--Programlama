using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Core.Domain.Books
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string? Name { get; set; }

        public List<BookSubject>? BookSubjects { get; set; }
    }
}
