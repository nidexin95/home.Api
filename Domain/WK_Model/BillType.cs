using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.WK_Model.Base;

namespace Domain.WK_Model
{
    public class BillType : UserBase
    {
        /// <summary>
        /// 收支类型名称
        /// </summary>
        [StringLength(4)]
        public string Name { get; set; }
        /// <summary>
        /// 图标ID(对应MongoDB，目前MongoDB还没有做，以后再实现，目前保存相片名称)
        /// </summary>
        [StringLength(5)]
        public string IconId { get; set; }
    }
}
