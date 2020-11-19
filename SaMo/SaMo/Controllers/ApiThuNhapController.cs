using SaMo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SaMo.Controllers
{
    public class ApiThuNhapController : ApiController
    {
        private QLMONNEYEntities1 db = new QLMONNEYEntities1();

        // GET: api/ApiThuNhap
        public IQueryable<Object> GetThuNhaps()
        {
            var thuNhapAll = db.ThuNhaps.Select(x => new { idThuNhap = x.idThuNhap, ten = x.tenThuNhap, moTa = x.moTa, icon = x.hinh });
            return thuNhapAll;
        }
    }
}
