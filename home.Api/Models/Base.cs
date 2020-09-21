using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace home.Api.Models
{
    public class Base
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 是否被注销
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 操作人Id
        /// </summary>
        public Guid OperatorId { get; set; }

    }
}
