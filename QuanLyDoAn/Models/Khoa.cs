using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyDoAn.Models
{
    public partial class Khoa
    {
        public Khoa()
        {
            GiangViens = new HashSet<GiangVien>();
        }

        public int IdKhoa { get; set; }
        public string TenKhoa { get; set; }

        public virtual ICollection<GiangVien> GiangViens { get; set; }
    }
}
