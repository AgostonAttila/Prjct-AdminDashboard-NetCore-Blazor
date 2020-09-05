using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Fund, FundViewModel>()
                .ReverseMap();

            CreateMap<Management, ManagementViewModel>()
                .ReverseMap();
        }
    }
}
