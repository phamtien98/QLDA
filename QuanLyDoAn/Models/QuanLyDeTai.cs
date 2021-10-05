using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyDoAn.Models
{
    public partial class QuanLyDeTai
    {
        public int IdDeTai { get; set; }
        public string TenDeTai { get; set; }
        public string MoTa { get; set; }
        public string FileBaoCao { get; set; }
        public string FileMaNguon { get; set; }
        public string Msv { get; set; }
        public int IdGv { get; set; }
        public DateTime Date { get; set; }

        public virtual GiangVien IdGvNavigation { get; set; }
        public virtual UserSinhVien MsvNavigation { get; set; }
    }
}
