using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class GiangVienController : Controller
    {
        private readonly IFRepository<GiangVien> _giangVien;
        private readonly IFRepository<Khoa> _khoa;
        private readonly IFUnitOfWork _unitOfWork;
        public GiangVienController(IFRepository<GiangVien> giangvien, IFUnitOfWork UnitOfWork, IFRepository<Khoa> khoa)
        {
            _khoa = khoa;
            _giangVien = giangvien;
            _unitOfWork = UnitOfWork;
        }



        [Area("Admin")]
        public IActionResult Index()
        {
            GiangVienModel gz = new GiangVienModel();
            var _dataGiangVien = _giangVien.TableNoTracking.ToList();
            var _dataKhoa = _khoa.TableNoTracking.ToList();
            var ketqua = from gv in _dataGiangVien
                         join k in _dataKhoa on gv.IdKhoa equals k.IdKhoa
                         select new GiangVienModel { id= gv.IdGv, name = gv.TenGv, mail = gv.Email, phone = gv.Phone, Khoa = k.TenKhoa };
            if (HttpContext.Session.GetString("fullname") == null)
            {

                return RedirectToAction("Login", "Login");
            }
            return View(ketqua);
        }
        [Area("Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            List<Khoa> khoa = _khoa.TableNoTracking.ToList();
            SelectList lstKhoa = new SelectList(khoa, "IdKhoa", "TenKhoa");
            ViewBag.list = lstKhoa;
            return View();
        }
        [Area("Admin")]
        [HttpPost]
        public IActionResult Create(GiangVien giangvien)
        {
            if(ModelState.IsValid)
            {
                var data = _giangVien.TableNoTracking.Where(m => m.Email == giangvien.Email || m.Phone == giangvien.Phone).ToList();
                if(data.Count >0 )
                {
                    return Content("Trùng cmnr");
                }
                else
                {
                    var model = new GiangVien();
                    {
                        model.TenGv = giangvien.TenGv;
                        model.IdKhoa = giangvien.IdKhoa;
                        model.Email = giangvien.Email;
                        model.Phone = giangvien.Phone;
                    }
                    _giangVien.Insert(model);
                    _unitOfWork.SaveChange();
                }
            }
            return RedirectToAction("Index");
        }

        [Area("admin")]
        public ActionResult Delete(int? id)
        {
            var data =_giangVien.TableNoTracking.Where(m => m.IdGv == id).ToList();
            return View(data);
        }
        [Area("Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleteGiangVien = _giangVien.TableNoTracking.Where(m => m.IdGv == id).FirstOrDefault();
            if(deleteGiangVien == null)
                return BadRequest("Danh mục không tồn tại !");

            _giangVien.Delete(deleteGiangVien);
            _unitOfWork.SaveChange();
            return RedirectToAction("Index", "GiangVien");
    
        }
    }
}
