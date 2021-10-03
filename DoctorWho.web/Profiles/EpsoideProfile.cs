using System;
using AutoMapper;
using EF_DoctorWho.Db;

namespace DoctorWho.web.Profiles
{
    public class EpsoideProfile : Profile
    {
        public EpsoideProfile()
        {
            CreateMap<tblEpisode, models.EpisodeForPrintingDto>()
                .ForMember
                (
                    dest => dest.EpisodeID,
                    opt => opt.MapFrom(src => src.tblEpisodeID)
                )
                .ForMember
                (
                    dest => dest.DoctorID,
                    opt => opt.MapFrom(src => src.tblDoctorID)
                )
                .ForMember
                (
                    dest => dest.AuthorID,
                    opt => opt.MapFrom(src => src.tblAuthorID)
                );

            CreateMap<models.EpisodeForCreationDto, tblEpisode>();
        }
    }
}
