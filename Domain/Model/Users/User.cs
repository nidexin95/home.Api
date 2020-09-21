using Domain.Model.Homes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Users
{
    public class User : Base
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        public int Phone { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        public ICollection<HomeBase> HomeBases { get; set; }
    }
}
