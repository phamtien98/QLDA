using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyDoAn.Models
{
    public partial class UserSinhVien
    {
        public UserSinhVien()
        {
            QuanLyDeTais = new HashSet<QuanLyDeTai>();
        }

        public string Msv { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public DateTime BithDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int? IdLop { get; set; }

        public virtual Lop IdLopNavigation { get; set; }
        public virtual ICollection<QuanLyDeTai> QuanLyDeTais { get; set; }
    }
}
