using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.WK_Model.Base;

namespace Domain.WK_Model
{
    /// <summary>
    /// 支出表
    /// </summary>
    public class Disburse : UserBase
    {
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 收支类型
        /// </summary>
        public Guid BillType { get; set; }
        /// <summary>
        /// 收支时间（创建时间）
        /// </summary>
        public DateTime BillTime { get; set; }
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
    }
}
