using AutoMapper;
using demo.Core.Domain.Books;
using demo.ViewModels;



namespace demo.Mappings
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorViewModel>()
                .ForMember(dst => dst.Books, opt => opt.MapFrom(x => x.BookAuthors.Select(y => y.Book).ToList()));
        }
    }
}
