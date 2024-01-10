using demo.Core.Domain.Members;
using demo.Core.Repositories;
using demo.Data.Repositories;
using demo.Data;
using Microsoft.EntityFrameworkCore;

namespace demo.Data.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(LibraryContext context)
            : base(context)
        {
        }
            
        public Member GetMemberWithIssuedBooks(int id)
        {
            return LibraryContext.Members
                .Include(m => m.Issues)
                    .ThenInclude(b => b.Book)
                .SingleOrDefault(m => m.MemberId == id);
        }

        public LibraryContext LibraryContext
        {
            get { return Context as LibraryContext; }
        }
    }
}