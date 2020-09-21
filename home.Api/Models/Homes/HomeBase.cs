using home.Api.Models.Enum;
using home.Api.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace home.Api.Models.Homes
{
    /// <summary>
    /// 房屋基本情况
    /// </summary>
    public class HomeBase:Base
    {
        /// <summary>
        /// 发布人ID
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        public string CommunityName { get; set; }
        /// <summary>
        /// 室
        /// </summary>
        public int Room { get; set; }
        /// <summary>
        /// 厅
        /// </summary>
        public int Office { get; set; }
        /// <summary>
        /// 卫
        /// </summary>
        public int Wei { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public double Area { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        public int Floor { get; set; }
        /// <summary>
        /// 总楼层
        /// </summary>
        public int TotalFloor { get; set; }
        /// <summary>
        /// 电梯
        /// </summary>
        public bool Elevator { get; set; }
        /// <summary>
        /// 房屋朝向
        /// </summary>
        public HouseOrientation HouseOrientation { get; set; }
        public User User { get; set; }
    }
}
