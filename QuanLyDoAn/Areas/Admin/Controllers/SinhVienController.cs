using Microsoft.AspNetCore.Mvc;
using QuanLyDoAn.Chung;
using QuanLyDoAn.DI.Repository;
using QuanLyDoAn.DI.UnitOfWork;
using QuanLyDoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyDoAn.Areas.Admin.Controllers
{
    public class SinhVienController : Controller
    {

        private readonly IFRepository<UserSinhVien> _sinhVien;
        private readonly IFRepository<GiangVien> _giangVien;
        private readonly IFRepository<Lop> _Lop;
        private readonly IFUnitOfWork _unitOfWork;
        private readonly IFRepository<QuanLyDeTai> _quanLyDeTai;
        public SinhVienController (IFRepository<UserSinhVien> sinhVien , IFUnitOfWork unitOfWork, IFRepository<Lop> Lop, IFRepository<QuanLyDeTai> quanlydetai,IFRepository<GiangVien> giangvien)
        {
            _sinhVien = sinhVien;
            _Lop = Lop;
            _giangVien = giangvien;
            _quanLyDeTai = quanlydetai;
            _unitOfWork = unitOfWork;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            SinhVienModel sinhvienModel = new SinhVienModel();
            var sinhvien = _sinhVien.TableNoTracking.ToList();
            var giangvien = _giangVien.TableNoTracking.ToList();
            var lop = _Lop.TableNoTracking.ToList();
            var detai = _quanLyDeTai.TableNoTracking.ToList();
            var ketqua = from qldt in detai
                         join gv in giangvien on qldt.IdGv equals gv.IdGv
                         join sv in sinhvien on qldt.Msv equals sv.Msv
                         join l in lop on sv.IdLop equals l.IdLop
                         select new SinhVienModel { msv = sv.Msv, name = sv.Fullname, grade = l.Grade, giangVienHuongDan = gv.TenGv, deTai = qldt.TenDeTai };
            ViewBag.Sinhvien = ketqua.ToList();
            return View(ketqua);
        }
        [Area("Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Area("Admin")]
        [HttpPost] 
        public IActionResult Create (UserSinhVien sv , QuanLyDeTai detai)
        {
            
            return RedirectToAction("Idnex");
        }
    }
}
