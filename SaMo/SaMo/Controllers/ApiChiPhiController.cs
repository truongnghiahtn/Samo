using SaMo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SaMo.Controllers
{
    public class ApiChiPhiController : ApiController
    {
        private QLMONNEYEntities1 db = new QLMONNEYEntities1();

        // GET: api/ApiThuNhap
        public IQueryable<Object> GetThuNhaps()
        {
            var ChiPhiAll = db.ChiPhis.Select(x => new { idChiPhi = x.idChiPhi, ten = x.tenChiPhi, moTa = x.moTa, icon = x.hinh });
            return ChiPhiAll;
        }
    }
}
