using System;
using AutoMapper;
using EF_DoctorWho.Db;

namespace DoctorWho.web.Profiles
{
    public class EnemyProfile : Profile
    {
        public EnemyProfile()
        {
            CreateMap<models.EnemyForCreationDto, tblEnemy>();
               
        }
    }
}
