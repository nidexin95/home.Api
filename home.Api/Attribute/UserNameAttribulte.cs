using home.Api.Dto.Dto;
using home.Api.Models.Users;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace home.Api.Attribute
{
    public class UserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dto = (UserDto)validationContext.ObjectInstance;
            if(dto.UserName == dto.PassWord)
            {
                return new ValidationResult(ErrorMessage,new[] { nameof(UserDto)});
            }
            return ValidationResult.Success;
        }
    }
}
