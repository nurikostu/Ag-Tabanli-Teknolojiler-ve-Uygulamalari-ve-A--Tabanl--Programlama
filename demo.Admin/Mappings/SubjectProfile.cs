﻿using AutoMapper;
using demo.Core.Domain.Books;
using demo.Admin.ViewModels;

namespace demo.Admin.Mappings
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectViewModel>()
                .ForMember(dst => dst.Books, opt => opt.MapFrom(x => x.BookSubjects.Select(y => y.Book).ToList()));
            CreateMap<SubjectViewModel, Subject>();
        }
    }
}