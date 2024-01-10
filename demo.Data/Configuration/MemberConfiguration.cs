using demo.Core.Domain.Members;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Data.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");
            builder.HasKey(m => m.MemberId);
            builder.Property(m => m.FirstName).IsRequired();
            builder.Property(m => m.LastName).IsRequired();
            builder.Property(m => m.PhoneNumber).IsRequired();
        }
    }
}
