﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class Base
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public Guid Id { get; set; }
    }
}
