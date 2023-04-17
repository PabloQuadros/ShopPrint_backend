﻿using ShopPrint.Domain.Validation.Shared;
using ShopPrint.Domain.Validation.User;
using ShopPrint.Domain.Validation.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ShopPrint.Domain.Entities
{
    public class User
    {
        public string? Id { get; set; }
        [NameValidation]
        public string? UserName { get; set; }
        [UserEmailValidation]
        public string? Email { get; set; }
        [PasswordValidation]
        public string? Password { get; set; }
        [UserPhoneNumberValidation]
        public string? PhoneNumber { get; set; }
        [UserRoleValidation]
        public string? Role { get; set; }

    }
}
