using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyDoAn.Chung;
using QuanLyDoAn.DI.Repository;
using QuanLyDoAn.DI.UnitOfWork;
using QuanLyDoAn.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            UserSinhVien sv = new UserSinhVien();
            QuanLyDeTai detai = new QuanLyDeTai();
            var tupleModel = new Tuple<UserSinhVien,QuanLyDeTai>(sv,detai);
            List<Lop> Lop = _Lop.TableNoTracking.ToList();
            SelectList lstKhoa = new SelectList(Lop, "IdLop", "Grade");
            ViewBag.listLop = lstKhoa;
            List<GiangVien> gvhd = _giangVien.TableNoTracking.ToList();
            SelectList listGV = new SelectList(gvhd, "IdGv", "TenGv");
            ViewBag.listgv = listGV;
            return View(tupleModel);
        }
        [Area("Admin")]
        [HttpPost] 
        public async Task< IActionResult> Create (UserSinhVien sv , QuanLyDeTai detai ,IFormFile file , IFormFile file1)
        {
          
            if(ModelState.IsValid)
            {
                var data = _sinhVien.TableNoTracking.Where(m => m.Msv == sv.Msv).ToList();
                if(data.Count > 0)
                {
                    ViewBag.Message = "Trùng cmnr";
                }
                else
                {
                    _sinhVien.Insert(sv);
                    var qldt = new QuanLyDeTai();
                    {
                        qldt.IdGv = detai.IdGv;
                        qldt.Msv = sv.Msv;
                        qldt.TenDeTai = detai.TenDeTai;
                        qldt.MoTa = detai.MoTa;
                        qldt.Date = DateTime.UtcNow.Date;
                        qldt.FileBaoCao = Path.GetFileName(file.FileName);
                        qldt.FileMaNguon = Path.GetFileName(file1.FileName);
                        await Upload(file);
                        await UploadNext(file1);                   
                    }
                    _quanLyDeTai.Insert(qldt);
                    _unitOfWork.SaveChange();
                    ViewBag.Message = "Thêm Ok";
                }
            }
            return RedirectToAction("Idnex");
        }
        /// <summary>
        /// upload method
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
       
        [HttpPost]
        public async Task<bool> Upload (IFormFile file)
        {
            var filesPath = Directory.GetCurrentDirectory() + "/BaoCao";
            bool check = false;
            try
            {
                if (!System.IO.Directory.Exists(filesPath))
                {
                    Directory.CreateDirectory(filesPath);
                }

                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(filesPath, fileName);
                    using (var stream = new FileStream(filesPath, FileMode.CreateNew))
                    {
                        await file.CopyToAsync(stream);
                    }
                    check = true;
                }
            }
            catch (Exception )
            {
                throw;
            }
            return check;
        }

        [HttpPost]
        public async Task<bool> UploadNext(IFormFile file)
        {
            var filesPath = Directory.GetCurrentDirectory() + "/SourceCode";
            bool check = false;
            try
            {
                if (!System.IO.Directory.Exists(filesPath))
                {
                    Directory.CreateDirectory(filesPath);
                }

                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(filesPath, fileName);
                    using (var stream = new FileStream(filesPath, FileMode.CreateNew))
                    {
                        await file.CopyToAsync(stream);
                    }
                    check = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return check;
        }

    }
}
