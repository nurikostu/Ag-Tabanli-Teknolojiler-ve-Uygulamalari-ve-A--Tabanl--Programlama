using demo.Core.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Core.Repositories
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        IEnumerable<Subject> GetAllWithBooks();
        Subject GetSingleWithBooks(int id);
    }
}