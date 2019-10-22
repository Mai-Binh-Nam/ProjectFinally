﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using ProjectFinally.DAO;
using ProjectFinally.Models;
using PagedList;
using System.Net.Mail;
using System.Net;

namespace ProjectFinally.Controllers
{
    public class HomeController : Controller
    {
        WebsiteBanHangEntities db = new WebsiteBanHangEntities();
        public ActionResult Index()
        {
            //var model = db.sanphams.ToList();
            return View();
        }
        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }
        public ActionResult Register()
        {
            return View("Register");
        }
        public PartialViewResult Product_Show(int? id, int? pageIndex)
        {
            var items = new List<sanpham>();
            int _pageIndex = pageIndex ?? 1;
            if (id == null)
            {
                items = db.sanphams.ToList();
            }
            else
            {
                items = (from i in db.sanphams
                         where i.id == id
                         select i).ToList();
            }

            return PartialView(items.OrderBy(m=>m.id).ToPagedList(_pageIndex, 9));
        }
        [HttpPost]
        public ActionResult Submit_Register(Register taiKhoan)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=WebsiteBanHang;Integrated Security=True");
            if (ModelState.IsValid)
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandText = "Insert into TKUser (FirstName,LastName,EmailAddress,Password) values(@FirstName,@LastName,@EmailAddress,@Password)";
                    SqlParameter firstname = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                    firstname.Value = taiKhoan.FirstName;
                    SqlParameter lastname = cmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
                    lastname.Value = taiKhoan.LastName;
                    SqlParameter email = cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                    email.Value = taiKhoan.EmailAddress;
                    SqlParameter matkhauTK = cmd.Parameters.Add("@Password", SqlDbType.VarChar);
                    matkhauTK.Value = taiKhoan.Password;

                    cmd.ExecuteNonQuery();
                    ModelState.AddModelError("", "Đăng ký thành công!");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Đăng ký không thành công! Vui lòng đang ký lại");
                    ModelState.AddModelError("", ex);

                }
                finally
                {
                    cnn.Close();
                }
            }
            return View("Register");
            }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Submit_Login(Login taiKhoan)

        {

            if (ModelState.IsValid)
            {
                var resulf = db.TKUsers.Where(p => p.EmailAddress == taiKhoan.EmailAddress && p.Password == taiKhoan.Password);
                if (resulf.Count() == 0)
                {
                    ModelState.AddModelError("", "Sai mật khẩu hoặc tên đăng nhập!");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("login");
        }
        public ActionResult Product_Detail()
        {
            return View();
        }
     
    }
}