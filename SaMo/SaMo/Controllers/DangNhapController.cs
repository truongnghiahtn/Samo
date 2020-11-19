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
        private QLMONNEYEntities1 db = new QLMONNEYEntities1();
        //[ResponseType(typeof(KhachHang))]
        public IHttpActionResult PostKhachHang(DangNhap taikhoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chiPhi = from kh in db.KhachHangs
                         join dkcp in db.dKChiPhis on kh.idKhachHang equals dkcp.idKhachHang
                         where kh.taiKhoan == taikhoan.taiKhoan && kh.matKhau == taikhoan.matKhau
                         select new
                         {
                             tongChiPhi = dkcp.tien,

                         };
            decimal chiPhis;
            decimal thuNhaps;
            if (chiPhi.Count() > 0)
            {
                chiPhis = chiPhi.Sum(x => x.tongChiPhi);
            }
            else
            {
                chiPhis = 0;
            }

            var thuNhap = from kh in db.KhachHangs
                          join dktn in db.dKThuNhaps on kh.idKhachHang equals dktn.idKhachHang
                          where kh.taiKhoan == taikhoan.taiKhoan && kh.matKhau == taikhoan.matKhau
                          select new
                          {
                              tongThuNhap = dktn.tien,
                          };
            if (thuNhap.Count() > 0)
            {
                thuNhaps = thuNhap.Sum(x => x.tongThuNhap);
            }
            else
            {
                thuNhaps = 0;
            }



            var data = from kh in db.KhachHangs
                       where kh.taiKhoan == taikhoan.taiKhoan && kh.matKhau == taikhoan.matKhau
                       select new user
                       {
                           id = kh.idKhachHang,
                           hoTen = kh.hoTen,
                           taiKhoan = kh.taiKhoan,
                           soDuTK = (decimal)kh.soDuTK,
                           gioiHan = (decimal)kh.gioiHan,
                           tongChiPhi=chiPhis,
                           tongThuNhap=thuNhaps
                   
                       };
            user kq = new user();
          
            if (data.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                foreach (user item in data)
                {
                    kq = item;
                    break;
                }
            }
            return Ok(kq);

        }

    }
}
