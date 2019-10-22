﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectFinally.DAO
{
    public class Login
    {
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ!")]
        public string EmailAddress { get; set; }
        [MinLength(8, ErrorMessage = "Mật khẩu phải có ít nhất 8 kí tự. Hãy nhập lại!")]
        public string Password { get; set; }
    }
}