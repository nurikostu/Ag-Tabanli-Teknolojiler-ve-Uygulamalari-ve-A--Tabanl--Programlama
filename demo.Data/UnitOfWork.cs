using demo.Core;
using demo.Core.Repositories;
using demo.Data;
using demo.Data.Repositories;



namespace demo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext Context;

        public UnitOfWork(LibraryContext context)
        {
            Context = context;
            Books = new BookRepository(Context);
            Members = new MemberRepository(Context);
            Issues = new TransactionRepository(Context);
            Authors = new AuthorRepository(Context);
            Subjects = new SubjectRepository(Context);
        }

        public IBookRepository Books { get; set; }
        public IAuthorRepository Authors { get; set; }
        public ISubjectRepository Subjects { get; set; }
        public IMemberRepository Members { get; set; }
        public ITransactionRepository Issues { get; set; }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}