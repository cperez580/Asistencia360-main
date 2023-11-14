﻿namespace BackEnd.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string IdNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }
    }
}
