using demo.Core.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Core.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        Member GetMemberWithIssuedBooks(int id);
    }
}
