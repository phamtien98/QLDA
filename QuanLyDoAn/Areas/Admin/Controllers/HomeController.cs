using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyDoAn.DI.Repository;
using QuanLyDoAn.DI.UnitOfWork;
using QuanLyDoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyDoAn.Chung;
namespace QuanLyDoAn.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFRepository<GiangVien> _giangVien;
        private readonly IFRepository<Khoa> _khoa;
        private readonly IFUnitOfWork _unitOfWork;
        public HomeController (IFRepository<GiangVien> giangvien , IFUnitOfWork UnitOfWork, IFRepository<Khoa> khoa)
        {
            _khoa = khoa;
            _giangVien = giangvien;
            _unitOfWork = UnitOfWork;
        }


        
        [Area("Admin")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("fullname") == null)
            {

                return RedirectToAction("Login", "Login");
            }
            return View();
        }
    }
}
