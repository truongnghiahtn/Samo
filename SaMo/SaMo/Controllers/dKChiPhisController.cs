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
    public class dKChiPhisController : ApiController
    {
        private QLMONNEYEntities1 db = new QLMONNEYEntities1();



        // GET: api/dKChiPhis/5
        [ResponseType(typeof(dKChiPhi))]
        public IHttpActionResult GetdKChiPhi(int id)
        {
            var dkChiPhi = from dkcp in db.dKChiPhis
                           join cp in db.ChiPhis on dkcp.idChiPhi equals cp.idChiPhi
                           where dkcp.idDKChiPhi == id
                           select new
                           {
                               id = dkcp.idDKChiPhi,
                               ten = cp.tenChiPhi,
                               hinhAnh = cp.hinh,
                               tien = dkcp.tien,
                               loai = cp.moTa,
                               moTa = dkcp.moTa,
                               NgayTao = (DateTime)dkcp.ngayTao,
                               NgayTaoString = dkcp.ngayTao.ToString()
                           };
            if (dkChiPhi == null)
            {
                return NotFound();
            }

            return Ok(dkChiPhi);
        }

        // PUT: api/dKChiPhis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutdKChiPhi(int id, dKChiPhi dKChiPhi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dKChiPhi.idDKChiPhi)
            {
                return BadRequest();
            }

            db.Entry(dKChiPhi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dKChiPhiExists(id))
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

        // POST: api/dKChiPhis
        [ResponseType(typeof(dKChiPhi))]
        public IHttpActionResult PostdKChiPhi(dKChiPhi dKChiPhi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.dKChiPhis.Add(dKChiPhi);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dKChiPhi.idDKChiPhi }, dKChiPhi);
        }

        // DELETE: api/dKChiPhis/5
        [ResponseType(typeof(dKChiPhi))]
        public IHttpActionResult DeletedKChiPhi(int id)
        {
            dKChiPhi dKChiPhi = db.dKChiPhis.Find(id);
            if (dKChiPhi == null)
            {
                return NotFound();
            }

            db.dKChiPhis.Remove(dKChiPhi);
            db.SaveChanges();

            return Ok(dKChiPhi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool dKChiPhiExists(int id)
        {
            return db.dKChiPhis.Count(e => e.idDKChiPhi == id) > 0;
        }
    }
}