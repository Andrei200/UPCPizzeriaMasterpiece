﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string DocumentNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public byte? IsActive { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class UserRegistrationDTO: UserDTO
    {
        public string Password { get; set; }
    }

    public class UserLoginDTO 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
