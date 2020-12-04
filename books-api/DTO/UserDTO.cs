﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.DTO
{
    public class UserDTO
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
      [Required]
      [DataType(DataType.Password)]
      [StringLength(50,ErrorMessage = "Your Password id limited to {2} to {1} charactrs",MinimumLength = 6)]
        public string Password { get; set; }
    }
}
