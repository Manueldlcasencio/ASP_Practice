using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataRepository.Models;
using WebAPI.DTOs;

namespace WebAPI.Mappers
{
    public class CmsMapper : Profile
    {
        public CmsMapper()
        {
            CreateMap<CourseDTO, Course>()
                .ReverseMap(); //The reverse of the above.
        }
    }
}