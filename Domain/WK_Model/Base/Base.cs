using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.WK_Model.Base
{
    public class Base
    {
        [Key]
        public Guid Id { get; set; }
    }
}
