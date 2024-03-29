﻿using System.ComponentModel;

namespace demo.Admin.ViewModels
{
    public class IssueReturnViewModel
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }

        [DisplayName("Book")]
        public string? BookTitle { get; set; }

        [DisplayName("Member Name")]
        public string? MemberName { get; set; }

        [DisplayName("Member Phone")]
        public string? MemberPhone { get; set; }

        [DisplayName("Issued At")]
        public DateTime IssueDate { get; set; }

        [DisplayName("Expires At")]
        public DateTime ExpireDate { get; set; }
    }
}