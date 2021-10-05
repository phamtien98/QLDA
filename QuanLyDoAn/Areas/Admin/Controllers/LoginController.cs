using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyDoAn.DI.Repository;
using QuanLyDoAn.Models;
using QuanLyDoAn.DI.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace QuanLyDoAn.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IFRepository<UserAdmin> _adminRepos;
        private readonly IFUnitOfWork _unitOfWork;
        public LoginController(IFRepository<UserAdmin> adminRepos)
        {
            _adminRepos = adminRepos;
        }

        [Area("Admin")]
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("fullname") != null)
            {

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [Area("Admin")]
        [HttpPost]
        public IActionResult Login(String username, String password)
        {

            if (ModelState.IsValid)
            {
                var login = _adminRepos.TableNoTracking.Where(m => m.Password == password && m.Username == username).ToList();
                if (login.Count > 0)
                {
                    HttpContext.Session.SetString("fullname", login.FirstOrDefault().Fullname);
                    HttpContext.Session.SetInt32("id",login.FirstOrDefault().Id);
                    HttpContext.Session.SetString("role", login.FirstOrDefault().Role.ToString());
                    return RedirectToAction("Index","Home");
                }
            }
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}


