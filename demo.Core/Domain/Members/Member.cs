using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using demo.Core.Domain.Issues;


namespace demo.Core.Domain.Members
{
    public class Member
    {
        public int MemberId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public MemberType MemberType { get; set; }

        public ICollection<Issue>? Issues { get; set; }
    }
}
