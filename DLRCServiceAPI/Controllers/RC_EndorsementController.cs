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
    public class RC_EndorsementController : ApiController
    {
        private DLRCDBEntities db = new DLRCDBEntities();

        // GET: api/RC_Endorsement
        public IHttpActionResult GetTbl_RC_Endorsement()
        {
            return Json(db.Tbl_RC_Endorsement.ToList());
        }

        // GET: api/RC_Endorsement/5
        [ResponseType(typeof(Tbl_RC_Endorsement))]
        public IHttpActionResult GetTbl_RC_Endorsement(int id)
        {
            Tbl_RC_Endorsement tbl_RC_Endorsement = db.Tbl_RC_Endorsement.Find(id);
            if (tbl_RC_Endorsement == null)
            {
                return NotFound();
            }

            return Json(tbl_RC_Endorsement);
        }

        // PUT: api/RC_Endorsement/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_RC_Endorsement(int id, Tbl_RC_Endorsement tbl_RC_Endorsement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_RC_Endorsement.Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_RC_Endorsement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_RC_EndorsementExists(id))
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

        // POST: api/RC_Endorsement
        [ResponseType(typeof(Tbl_RC_Endorsement))]
        public IHttpActionResult PostTbl_RC_Endorsement(Tbl_RC_Endorsement tbl_RC_Endorsement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_RC_Endorsement.Add(tbl_RC_Endorsement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_RC_Endorsement.Id }, tbl_RC_Endorsement);
        }

        // DELETE: api/RC_Endorsement/5
        [ResponseType(typeof(Tbl_RC_Endorsement))]
        public IHttpActionResult DeleteTbl_RC_Endorsement(int id)
        {
            Tbl_RC_Endorsement tbl_RC_Endorsement = db.Tbl_RC_Endorsement.Find(id);
            if (tbl_RC_Endorsement == null)
            {
                return NotFound();
            }

            db.Tbl_RC_Endorsement.Remove(tbl_RC_Endorsement);
            db.SaveChanges();

            return Ok(tbl_RC_Endorsement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_RC_EndorsementExists(int id)
        {
            return db.Tbl_RC_Endorsement.Count(e => e.Id == id) > 0;
        }
    }
}