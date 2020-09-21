using home.Api.Models.Homes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace home.Api.Models.Users
{
    public class User : Base
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public ICollection<HomeBase> HomeBases { get; set; }
    }
}
