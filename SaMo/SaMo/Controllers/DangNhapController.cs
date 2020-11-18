using SaMo.Models;
using SaMo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SaMo.Controllers
{
    public class DangNhapController : ApiController
    {
        private QLMONNEYEntities db = new QLMONNEYEntities();
        //[ResponseType(typeof(KhachHang))]
        public IHttpActionResult PostKhachHang(DangNhap taikhoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = from kh in db.KhachHangs
                       where kh.taiKhoan == taikhoan.taiKhoan && kh.matKhau == taikhoan.matKhau
                       select new
                       {
                           id = kh.idKhachHang,
                           hoTen = kh.idKhachHang,
                           taiKhoan = kh.taiKhoan,
                           soDuTK = kh.soDuTK,
                           gioiHan = kh.gioiHan
                       };

            if (data.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

    }
}
