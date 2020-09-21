using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using home.Api.Attribute;

namespace home.Api.Dto.Dto
{
    [UserName(ErrorMessage =("用户名称不能和密码一样"))]
    public class UserDto : IValidatableObject
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        [DisplayName("电话号码")]
        [Required(ErrorMessage = ("{0}不能为空"))]
        [MaxLength(length: 12, ErrorMessage = ("{0}的长度不能大于{1}"))]
        public string Phone { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = ("{0}不能为空"))]
        [DisplayName("用户名")]
        [MaxLength(length: 100, ErrorMessage = ("{0}的长度不能大于{1}"))]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = ("{0}不能为空"))]
        [DisplayName("密码")]
        public string PassWord { get; set; }

        /// <summary>
        /// 自定义验证规则
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UserName == PassWord)
            {
                yield return new ValidationResult("用户名不能和密码重复!",new[] { nameof(UserDto)});
            }
        }
    }
}
