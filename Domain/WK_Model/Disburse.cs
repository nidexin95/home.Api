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
        [Required]
        public decimal Money { get; set; }
        /// <summary>
        /// 收支类型
        /// </summary>
        [Required]
        public Guid BillType { get; set; }
        /// <summary>
        /// 收支时间（创建时间）
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime BillTime { get; set; }
        /// <summary>
        /// 收支指定的年份
        /// </summary>
        [Required]
        public int Year { get; set; }
        /// <summary>
        /// 收支指定的月份
        /// </summary>
        [Required]
        public int Month { get; set; }
        /// <summary>
        /// 收支指定的天
        /// </summary>
        public int? Day { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200)]
        public string Remark { get; set; }
    }
}
