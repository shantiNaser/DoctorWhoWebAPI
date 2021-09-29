using System;
using AutoMapper;

namespace DoctorWho.web.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<EF_DoctorWho.Db.tblAuthor, models.AuthorForPrintingDto>()
                .ForMember
        (
            dest => dest.AuthorID,
            opt => opt.MapFrom(src => src.tblAutorID)
        );

            CreateMap<models.AuthorForManipulatinonDto, EF_DoctorWho.Db.tblAuthor>();

        }
        
    }

}
