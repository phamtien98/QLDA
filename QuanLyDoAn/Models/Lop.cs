using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyDoAn.Models
{
    public partial class Lop
    {
        public Lop()
        {
            UserSinhViens = new HashSet<UserSinhVien>();
        }

        public int IdLop { get; set; }
        public string Grade { get; set; }

        public virtual ICollection<UserSinhVien> UserSinhViens { get; set; }
    }
}
