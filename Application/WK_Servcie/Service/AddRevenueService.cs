using System;
using System.Collections.Generic;
using System.Text;
using Application.Core;
using Application.WK_Servcie.IService;
using AutoMapper;
using Domain.Core;
using Domain.WK_Dto.RevenueDto;
using Domain.WK_Model;
using Infrastructure.EntityFrameWorkCore.SQLServer;

namespace Application.WK_Servcie.Service
{
    public class AddRevenueService : BaseAppService<Revenue,AddRevenueDto,Guid>,IAddRevenueService
    {
        public IMapper Mapper { get; }
        private readonly WkBillContext _wkBillContext;

        public AddRevenueService(WkBillContext wkBillContext, IMapper mapper) : base(null, wkBillContext, mapper)
        {
            Mapper = mapper;
            _wkBillContext = wkBillContext;
        }
    }
}
