using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyDoAn.Models
{
    public partial class GiangVien
    {
        public GiangVien()
        {
            QuanLyDeTais = new HashSet<QuanLyDeTai>();
        }

        public int IdGv { get; set; }
        public string TenGv { get; set; }
        public int IdKhoa { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        public virtual Khoa IdKhoaNavigation { get; set; }
        public virtual ICollection<QuanLyDeTai> QuanLyDeTais { get; set; }
    }
}
