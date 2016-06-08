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
using DLRCServiceAPI.Models;

namespace DLRCServiceAPI.Controllers
{
    public class RC_ReviewController : ApiController
    {
        private DLRCDBEntities db = new DLRCDBEntities();

        // GET: api/RC_Review
        public IHttpActionResult GetTbl_RC_Review()
        {
            return Json(db.Tbl_RC_Review.ToList());
        }

        // GET: api/RC_Review/5
        [ResponseType(typeof(Tbl_RC_Review))]
        public IHttpActionResult GetTbl_RC_Review(int id)
        {
            Tbl_RC_Review tbl_RC_Review = db.Tbl_RC_Review.Find(id);
            if (tbl_RC_Review == null)
            {
                return NotFound();
            }

            return Json(tbl_RC_Review);
        }

        // PUT: api/RC_Review/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_RC_Review(int id, Tbl_RC_Review tbl_RC_Review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_RC_Review.Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_RC_Review).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_RC_ReviewExists(id))
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

        // POST: api/RC_Review
        [ResponseType(typeof(Tbl_RC_Review))]
        public IHttpActionResult PostTbl_RC_Review(Tbl_RC_Review tbl_RC_Review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_RC_Review.Add(tbl_RC_Review);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_RC_Review.Id }, tbl_RC_Review);
        }

        // DELETE: api/RC_Review/5
        [ResponseType(typeof(Tbl_RC_Review))]
        public IHttpActionResult DeleteTbl_RC_Review(int id)
        {
            Tbl_RC_Review tbl_RC_Review = db.Tbl_RC_Review.Find(id);
            if (tbl_RC_Review == null)
            {
                return NotFound();
            }

            db.Tbl_RC_Review.Remove(tbl_RC_Review);
            db.SaveChanges();

            return Ok(tbl_RC_Review);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_RC_ReviewExists(int id)
        {
            return db.Tbl_RC_Review.Count(e => e.Id == id) > 0;
        }
    }
}