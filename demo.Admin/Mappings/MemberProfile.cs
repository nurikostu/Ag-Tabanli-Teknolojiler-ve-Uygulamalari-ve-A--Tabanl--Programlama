using AutoMapper;
using demo.Core.Domain.Members;
using demo.Admin.ViewModels;

namespace demo.Admin.Mappings
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberViewModel>();
            CreateMap<MemberViewModel, Member>();
        }
    }
}