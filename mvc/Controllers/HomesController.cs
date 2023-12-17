using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace mvc.Controllers
{
    public class HomesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Homes
        void GetInfo()
        {
            // Lấy thông tin đăng nhập
            if (HttpContext.Session.GetString("nhanvien") != "")
            {
                ViewBag.nhanvien = _context.Nhanvien.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("nhanvien"));
            }
        }

        public async Task<IActionResult> Index()
        {
            GetInfo();
            return View(await _context.Chucvu.ToListAsync());
        }

        public IActionResult Login()
        {
            GetInfo();
            return View();
        }

        //GET
        public IActionResult Register()
        {
            GetInfo();
            return View();
        }

        [HttpPost]
        public IActionResult Register(string email, in  string matkhau,  string hoten, string dienthoai)
        {
            // luu tt khach
            var nv = new Nhanvien();
            var cv = new Chucvu();
            nv.Email = email;
            nv.MatKhau = matkhau;
            nv.Ten = hoten;
            nv.DienThoai = dienthoai;
            _context.Add(nv);
            _context.SaveChanges();

            return RedirectToAction(nameof(Login));
        }
        [HttpPost]
        public IActionResult Login(string email, string matkhau)
        {
            var nv = _context.Nhanvien.FirstOrDefault(k => k.Email == email);
            if (nv != null &&  matkhau == nv.MatKhau)
            {
                HttpContext.Session.SetString("nhanvien", email);
                return RedirectToAction(nameof(Customer));
            }
            // chuyen ve login
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Customer()
        {
            GetInfo();
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("nhanvien", "");
            GetInfo();
            return RedirectToAction(nameof(Index));
        }
    }
}