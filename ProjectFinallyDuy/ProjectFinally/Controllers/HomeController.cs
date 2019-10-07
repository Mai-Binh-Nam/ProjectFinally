using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace ProjectFinally.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
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
        [HttpPost]
        public ActionResult RegisterAccount(ProjectFinally.Models.KhachHang khachHang)
        {
            string db = @"Data Source=.;Initial Catalog=WebsiteBanHangNam1;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(db);
            cnn.Open();
            string sql = "Insert into TAIKHOAN(email,maukhauTK,FirstName ,LastName) values(@email,@maukhauTK,@FirstName ,@LastName)";
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = sql;
            SqlParameter email = cmd.Parameters.Add("@email", SqlDbType.NChar);
            email.Value = khachHang.EmailAddress;
            SqlParameter maukhauTK = cmd.Parameters.Add("@maukhauTK", SqlDbType.NChar);
            maukhauTK.Value = khachHang.Password;
            SqlParameter FirstName = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
            FirstName.Value = khachHang.FirstName;
            SqlParameter LastName = cmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
            LastName.Value = khachHang.LastName;
            cmd.ExecuteNonQuery();
            cnn.Close();
            ModelState.AddModelError("", "Đăng nhập thành công");
            return View("Register");
        }
        [HttpPost]
        public ActionResult LoginAccount(ProjectFinally.Models.LoginKH login)
        {
            string db = @"Data Source=.;Initial Catalog=WebsiteBanHangNam1;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(db);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "select * from TAIKHOAN where email='" + login.Username + "' and maukhauTK='" + login.Password + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cnn.Close();
                return Index();
            }
            else
            {
                cnn.Close();
                return View("Login");
            }
        }
        public ActionResult ForgotpasswordAccount(ProjectFinally.Models.ForgotPassword forgot)
        {
            string db = @"Data Source=.;Initial Catalog=WebsiteBanHangNam1;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(db);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "select Email,maukhauTK from TAIKHOAN where Email='" + forgot.EnterEmail + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string email = reader["Email"].ToString();
            string pass = reader["maukhauTK"].ToString();
            //Cấu hình thông tin mail
            var mail = new SmtpClient("smtp.gmail.com", 25)
            {
                Credentials = new NetworkCredential("ndshop.vn@gmail.com", "ktdlk1721"),
                EnableSsl = true
            };
            //tạo email
            var message = new MailMessage();
            message.From = new MailAddress("ndshop.vn@gmail.com");
            message.To.Add(forgot.EnterEmail);
            message.To.Add(new MailAddress(forgot.EnterEmail));
            message.Subject = "Mật khẩu mới của bạn là: "+ pass;
            mail.Send(message);
            return View("ForgotPassword");
        }
    }
}