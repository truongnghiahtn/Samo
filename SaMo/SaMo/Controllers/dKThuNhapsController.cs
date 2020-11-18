using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SaMo.Models;

namespace SaMo.Controllers
{
    public class dKThuNhapsController : ApiController
    {
        private QLMONNEYEntities db = new QLMONNEYEntities();


        // GET: api/dKThuNhaps/5
        [ResponseType(typeof(dKThuNhap))]
        public IHttpActionResult GetdKThuNhap(int id)
        {
            var dKThuNhap = from dktn in db.dKThuNhaps
                            join tn in db.ThuNhaps on dktn.idThuNhap equals tn.idThuNhap
                            where dktn.idDKThuNhap == id
                            select new
                            {
                                id = dktn.idDKThuNhap,
                                ten = tn.tenThuNhap,
                                hinhAnh = tn.hinh,
                                tien = dktn.tien,
                                loai = tn.moTa,
                                moTa = dktn.moTa,
                                NgayTao = (DateTime)dktn.ngayTao,
                                NgayTaoString = dktn.ngayTao.ToString()
                            };
            if (dKThuNhap == null)
            {
                return NotFound();
            }

            return Ok(dKThuNhap);
        }


        // PUT: api/dKThuNhaps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutdKThuNhap(int id, dKThuNhap dKThuNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dKThuNhap.idDKThuNhap)
            {
                return BadRequest();
            }

            db.Entry(dKThuNhap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dKThuNhapExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/dKThuNhaps
        [ResponseType(typeof(dKThuNhap))]
        public IHttpActionResult PostdKThuNhap(dKThuNhap dKThuNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.dKThuNhaps.Add(dKThuNhap);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dKThuNhap.idDKThuNhap }, dKThuNhap);
        }

        // DELETE: api/dKThuNhaps/5
        [ResponseType(typeof(dKThuNhap))]
        public IHttpActionResult DeletedKThuNhap(int id)
        {
            dKThuNhap dKThuNhap = db.dKThuNhaps.Find(id);
            if (dKThuNhap == null)
            {
                return NotFound();
            }

            db.dKThuNhaps.Remove(dKThuNhap);
            db.SaveChanges();

            return Ok(dKThuNhap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool dKThuNhapExists(int id)
        {
            return db.dKThuNhaps.Count(e => e.idDKThuNhap == id) > 0;
        }
    }
}