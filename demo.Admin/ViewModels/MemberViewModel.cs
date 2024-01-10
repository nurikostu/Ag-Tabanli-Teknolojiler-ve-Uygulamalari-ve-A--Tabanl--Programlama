using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using demo.Core.Domain.Issues;
using demo.Core.Domain.Members;

namespace demo.Admin.ViewModels 
{
    public class MemberViewModel
    {
        [DisplayName("Id")]
        public int MemberId { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [Required]
        [DisplayName("Phone")]
        public string? PhoneNumber { get; set; }

        [Required]
        [DisplayName("Member Type")]
        public MemberType MemberType { get; set; }

        public ICollection<Issue>? Issues { get; set; }
    }
}