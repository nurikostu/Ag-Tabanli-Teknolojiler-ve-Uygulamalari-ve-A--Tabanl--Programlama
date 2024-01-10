using demo.Core.Domain.Books;
using demo.Core.Repositories;
using demo.Data.Repositories;
using demo.Data;
using Microsoft.EntityFrameworkCore;

namespace demo.Data.Repositories        
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context)
            : base(context)
        {
        }

        public IEnumerable<Book> GetAllWithAuthorsSubjects()
        {
            return LibraryContext.Books
                .Include(ba => ba.BookAuthors)
                    .ThenInclude(a => a.Author)
                .Include(b => b.BookSubjects)
                    .ThenInclude(s => s.Subject)
                .Include(i => i.Issue)
                .ToList();
        }

        public Book GetSingleWithAuthorsSubjects(int id)
        {
            return LibraryContext.Books
                .Where(b => b.BookId == id)
                .Include(ba => ba.BookAuthors)
                    .ThenInclude(a => a.Author)
                .Include(bs => bs.BookSubjects)
                    .ThenInclude(s => s.Subject)
                .Include(i => i.Issue)
                .FirstOrDefault();
        }

        public LibraryContext LibraryContext
        {
            get { return Context as LibraryContext; }
        }
    }
}