using demo.Core.Domain.Books;
using demo.Core.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Core.Domain.Issues
{
    public class Issue
    {
        public int IssueId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public int MemberId { get; set; }
        public Member? Member { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
