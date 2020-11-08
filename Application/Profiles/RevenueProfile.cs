using Domain.WK_Model;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.WK_Dto.RevenueDto;
using AutoMapper;

namespace Application.Profiles
{
    public class RevenueProfile : Profile
    {
        public RevenueProfile()
        {
            CreateMap<Revenue, AddRevenueDto>()
                .ForMember(dest => dest.RevenueDate,
                    opt => opt.MapFrom(src => new DateTime(src.Year,src.Month,src.Day)));
            CreateMap<AddRevenueDto, Revenue>()
                .ForMember(dest => dest.Year,
                    opt => opt.MapFrom(src => src.RevenueDate.Year))
                .ForMember(dest => dest.Month,
                    opt => opt.MapFrom(src => src.RevenueDate.Month))
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.RevenueDate.Day));
        }
    }
}
