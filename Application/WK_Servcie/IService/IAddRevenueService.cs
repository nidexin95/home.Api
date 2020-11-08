using System;
using Application.Core;
using Domain.WK_Dto.RevenueDto;
using Domain.WK_Model;

namespace Application.WK_Servcie.IService
{
    public interface IAddRevenueService : IBaseAppService<Revenue,AddRevenueDto,Guid>
    {

    }
}
