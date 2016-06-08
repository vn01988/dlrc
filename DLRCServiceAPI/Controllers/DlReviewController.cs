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
    public class DlReviewController : ApiController
    {
        private DLRCDBEntities db = new DLRCDBEntities();

        // GET: api/DlReview
        public IHttpActionResult GetTbl_Dl_Review()
        {
            return Json(db.Tbl_Dl_Review.ToList());
        }

        // GET: api/DlReview/5
        [ResponseType(typeof(Tbl_Dl_Review))]
        public IHttpActionResult GetTbl_Dl_Review(int id)
        {
            Tbl_Dl_Review tbl_Dl_Review = db.Tbl_Dl_Review.Find(id);
            if (tbl_Dl_Review == null)
            {
                return NotFound();
            }

            return Json(tbl_Dl_Review);
        }

        // PUT: api/DlReview/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Dl_Review(int id, Tbl_Dl_Review tbl_Dl_Review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Dl_Review.Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_Dl_Review).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_Dl_ReviewExists(id))
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

        // POST: api/DlReview
        [ResponseType(typeof(Tbl_Dl_Review))]
        public IHttpActionResult PostTbl_Dl_Review(Tbl_Dl_Review tbl_Dl_Review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Dl_Review.Add(tbl_Dl_Review);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Dl_Review.Id }, tbl_Dl_Review);
        }

        // DELETE: api/DlReview/5
        [ResponseType(typeof(Tbl_Dl_Review))]
        public IHttpActionResult DeleteTbl_Dl_Review(int id)
        {
            Tbl_Dl_Review tbl_Dl_Review = db.Tbl_Dl_Review.Find(id);
            if (tbl_Dl_Review == null)
            {
                return NotFound();
            }

            db.Tbl_Dl_Review.Remove(tbl_Dl_Review);
            db.SaveChanges();

            return Ok(tbl_Dl_Review);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_Dl_ReviewExists(int id)
        {
            return db.Tbl_Dl_Review.Count(e => e.Id == id) > 0;
        }
    }
}