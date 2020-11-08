using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WK_Dto.RevenueDto
{
    public class AddRevenueDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 收入类型
        /// </summary>
        public Guid BillTypeId { get; set; }
        /// <summary>
        /// 收入时间
        /// </summary>
        public DateTime RevenueDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
