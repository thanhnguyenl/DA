using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using doan.Data;
using doan.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace doan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Khachhang> _pwHasher;
        public HomeController(ApplicationDbContext context, IPasswordHasher<Khachhang> passwordHasher)
        {
            _context = context;
            _pwHasher = passwordHasher;
        }

        void GetInfo()
        {
            ViewBag.danhmuc = _context.Danhmuc.ToList();
            ViewData["solg"] = GetCartItems().Count();
            // Lấy thông tin đăng nhập
            if (HttpContext.Session.GetString("khachhang") != "")
            {
                ViewBag.khachhang = _context.Khachhang.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("khachhang"));
            }
        }
        // GET: Home
        public async Task<IActionResult> Index()
        {
            GetInfo();
            var applicationDbContext = _context.Mathang.Include(m => m.MaDmNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Index1(int id)
        {
            GetInfo();
            var applicationDbContext = _context.Mathang.Where(p => p.MaDm == id).Include(m => m.MaDmNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mathang = await _context.Mathang
                .Include(m => m.MaDmNavigation)
                .FirstOrDefaultAsync(m => m.MaMh == id);
            if (mathang == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(mathang);
        }

        // Đọc danh sách CartItem từ session
        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString("shopcart");
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        // Lưu danh sách CartItem trong giỏ hàng vào session
        void SaveCartSession(List<CartItem> list)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(list);
            session.SetString("shopcart", jsoncart);
        }

        // Xóa session giỏ hàng
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove("shopcart");
        }

        // Cho hàng vào giỏ
        public async Task<IActionResult> AddToCart(int id)
        {
            var mathang = await _context.Mathang
                .FirstOrDefaultAsync(m => m.MaMh == id);
            if (mathang == null)
            {
                return NotFound("Sản phẩm không tồn tại");
            }
            var cart = GetCartItems();
            var item = cart.Find(p => p.MatHang.MaMh == id);
            if (item != null)
            {
                item.SoLuong++;
            }
            else
            {
                cart.Add(new CartItem() { MatHang = mathang, SoLuong = 1 });
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        // Chuyển đến view xem giỏ hàng
        public IActionResult ViewCart()
        {
            GetInfo();
            return View(GetCartItems());
        }

        // Xóa một mặt hàng khỏi giỏ
        public IActionResult RemoveItem(int id)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.MatHang.MaMh == id);
            if (item != null)
            {
                cart.Remove(item);
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        // Cập nhật số lượng một mặt hàng trong giỏ
        public IActionResult UpdateItem(int id, int quantity)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.MatHang.MaMh == id);
            if (item != null)
            {
                item.SoLuong = quantity;
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        // Chuyển đến view thanh toán
        public IActionResult CheckOut()
        {
            GetInfo();
            return View(GetCartItems());
        }

        // Lưu đơn
        public async Task<IActionResult> CreateBill(int id, string email, string hoten, string dienthoai, string diachi)
        {
            // KH da dang nhap
            var kh = new Khachhang();
            if (id != 0)
            {
                kh.MaKh = id;
            }
            else // Xử lý thông tin khách hàng (trường hợp khách mới)
            {
                kh.Email = email;
                kh.Ten = hoten;
                kh.DienThoai = dienthoai;
                _context.Add(kh);
                await _context.SaveChangesAsync();
            }
            var hd = new Hoadon();
            hd.Ngay = DateTime.Now;
            hd.MaKh = kh.MaKh;

            _context.Add(hd);
            await _context.SaveChangesAsync();


            // thêm chi tiết hóa đơn
            var cart = GetCartItems();

            int thanhtien = 0;
            int tongtien = 0;
            foreach (var i in cart)
            {
                var ct = new Cthoadon();
                ct.MaHd = hd.MaHd;
                ct.MaMh = i.MatHang.MaMh;
                thanhtien = i.MatHang.GiaBan * i.SoLuong;
                tongtien += thanhtien;
                ct.DonGia = i.MatHang.GiaBan;
                ct.SoLuong = (short)i.SoLuong;
                ct.ThanhTien = thanhtien;
                _context.Add(ct);
            }
            await _context.SaveChangesAsync();

            // cập nhật tổng tiền hóa đơn
            hd.TongTien = tongtien;
            _context.Update(hd);
            await _context.SaveChangesAsync();

            // xóa giỏ hàng
            ClearCart();

            GetInfo();
            return View(hd);
        }

        //GET
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
        public IActionResult Register(string email, string matkhau, string hoten, string dienthoai)
        {
            // luu tt khach
            var kh = new Khachhang();
            kh.Email = email;
            kh.MatKhau = _pwHasher.HashPassword(kh, matkhau);
            kh.Ten = hoten;
            kh.DienThoai = dienthoai;
            _context.Add(kh);
            _context.SaveChanges();

            return RedirectToAction(nameof(Login));
        }
        [HttpPost]
        public IActionResult Login(string email, string matkhau)
        {
            var kh = _context.Khachhang.FirstOrDefault(k => k.Email == email);
            if (kh != null && _pwHasher.VerifyHashedPassword(kh, kh.MatKhau, matkhau) == PasswordVerificationResult.Success)
            {
                HttpContext.Session.SetString("khachhang", email);
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
            HttpContext.Session.SetString("khachhang", "");
            GetInfo();
            return RedirectToAction(nameof(Index));
        }
    }
}
