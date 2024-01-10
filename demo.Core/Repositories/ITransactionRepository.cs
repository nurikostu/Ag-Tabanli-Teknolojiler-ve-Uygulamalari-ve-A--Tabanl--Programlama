using demo.Core.Domain.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Core.Repositories
{
    public interface ITransactionRepository : IRepository<Issue>
    {
        IEnumerable<Issue> GetAllIssuedBooks();
        Issue GetByBookId(int bookId);
    }
}