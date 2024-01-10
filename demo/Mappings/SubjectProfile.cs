using AutoMapper;
using demo.ViewModels;
using demo.Core.Domain.Books;


namespace demo.Mappings
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectViewModel>()
                .ForMember(dst => dst.Books, opt => opt.MapFrom(x => x.BookSubjects.Select(y => y.Book).ToList()));
        }
    }
}