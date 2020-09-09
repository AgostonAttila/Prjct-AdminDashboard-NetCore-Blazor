using Application.DTOs;
using Application.Features.Funds.Commands.CreateFund;
using Application.Features.Funds.Queries.GetAllFunds;
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
            CreateMap<Fund, GetAllFundsViewModel>().ReverseMap();
            CreateMap<CreateFundCommand, Fund>();
            CreateMap<GetAllFundsQuery, GetAllFundsParameter>();
        }
    }
}
