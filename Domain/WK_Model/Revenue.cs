using System;
using System.ComponentModel.DataAnnotations;
using Domain.WK_Model.Base;

namespace Domain.WK_Model
{
    /// <summary>
    /// 收入表
    /// </summary>
    public class Revenue : UserBase
    {
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 收支类型
        /// </summary>
        public Guid BillTypeId { get; set; }
        /// <summary>
        /// 收支时间（创建时间）
        /// </summary>
        public DateTime BillTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 收支指定的年份
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 收支指定的月份
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 收支指定的天
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200)]
        public string Remark { get; set; }

        public BillType BillType { get; set; }
    }
}
