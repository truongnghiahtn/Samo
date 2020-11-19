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
    public class ApiDkController : ApiController
    {
        private QLMONNEYEntities1 db = new QLMONNEYEntities1();
        //[ResponseType(typeof(dKChiPhi))]
        public IHttpActionResult GetdK(int id)
        {
            

            var dkThuNhap = from dktn in db.dKThuNhaps
                            join tn in db.ThuNhaps on dktn.idThuNhap equals tn.idThuNhap
                            where dktn.idKhachHang == id
                            select new DetailDk()
                            {
                                id = dktn.idDKThuNhap,
                                ten = tn.tenThuNhap,
                                hinhAnh = tn.hinh,
                                tien = dktn.tien,
                                loai = tn.moTa,
                                NgayTao = (DateTime)dktn.ngayTao,
                                NgayTaoString = dktn.ngayTao.ToString()
                            };
            var dkChiPhi = from dkcp in db.dKChiPhis
                           join cp in db.ChiPhis on dkcp.idChiPhi equals cp.idChiPhi
                           where dkcp.idKhachHang == id
                           select new DetailDk()
                           {
                               id = dkcp.idDKChiPhi,
                               ten = cp.tenChiPhi,
                               hinhAnh = cp.hinh,
                               tien = dkcp.tien,
                               loai = cp.moTa,
                               NgayTao = (DateTime)dkcp.ngayTao,
                               NgayTaoString = dkcp.ngayTao.ToString()
                           };
            List<DetailDk> mylist = new List<DetailDk>();
            mylist.AddRange(dkThuNhap);
            mylist.AddRange(dkChiPhi);
            if (mylist.Count() == 0)
            {
                return NotFound();
            }
            var test = mylist.Select(x => x.NgayTao.Date).Distinct();

            var dk = test.Select(x => new DangKy() { NgayTao = x.Date,
                NoiDung=mylist.Where(y=>y.NgayTao >x.Date &&y.NgayTao<=x.Date.AddDays(1)).Select(n=>new DetailDk()
                {
                    id = n.id,
                    ten = n.ten,
                    hinhAnh = n.hinhAnh,
                    tien = n.tien,
                    loai = n.loai,
                    NgayTao = n.NgayTao,
                    NgayTaoString = n.NgayTaoString
                }).ToList()
            });

            var sortdate = dk.OrderByDescending(x => x.NgayTao).Reverse();
            return Ok(sortdate);
        }
    }
}
