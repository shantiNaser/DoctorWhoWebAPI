using System;
using AutoMapper;
using DoctorWho.web.models;
using EF_DoctorWho.Db;

namespace DoctorWho.web.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<tblDoctor,models.DoctorForPrintingDto>()
                .ForMember
                (
                    dest => dest.DoctorID,
                    opt => opt.MapFrom(src => src.tblDoctorID)
                );
            CreateMap<DoctorForUpdatingDto, tblDoctor>();
        }
    }
}
