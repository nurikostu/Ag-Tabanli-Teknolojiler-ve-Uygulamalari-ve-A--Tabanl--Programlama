using demo.Core.Repositories;

namespace demo.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        IMemberRepository Members { get; }
        ITransactionRepository Issues { get; }
        IAuthorRepository Authors { get; }
        ISubjectRepository Subjects { get; }
        int Save();
    }
}