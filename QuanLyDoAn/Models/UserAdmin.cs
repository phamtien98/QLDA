using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyDoAn.Models
{
    public partial class UserAdmin
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; }
    }
}
