using DLRCServiceAPI.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace DLRCServiceAPI.Controllers
{
    public class DLEndorsementController : ApiController
    {
        private DLRCDBEntities db = new DLRCDBEntities();

        // GET: api/DLEndorsement
        public IHttpActionResult GetTbl_DL_Endorsement()
        {
            return Json(db.Tbl_DL_Endorsement.ToList());
        }

        // GET: api/DLEndorsement/5
        [ResponseType(typeof(Tbl_DL_Endorsement))]
        public IHttpActionResult GetTbl_DL_Endorsement(int id)
        {
            Tbl_DL_Endorsement tbl_DL_Endorsement = db.Tbl_DL_Endorsement.Find(id);
            if (tbl_DL_Endorsement == null)
            {
                return NotFound();
            }

            return Json(tbl_DL_Endorsement);
        }

        // PUT: api/DLEndorsement/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_DL_Endorsement(int id, Tbl_DL_Endorsement tbl_DL_Endorsement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_DL_Endorsement.Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_DL_Endorsement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_DL_EndorsementExists(id))
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

        // POST: api/DLEndorsement
        [ResponseType(typeof(Tbl_DL_Endorsement))]
        public IHttpActionResult PostTbl_DL_Endorsement(Tbl_DL_Endorsement tbl_DL_Endorsement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_DL_Endorsement.Add(tbl_DL_Endorsement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_DL_Endorsement.Id }, tbl_DL_Endorsement);
        }

        // DELETE: api/DLEndorsement/5
        [ResponseType(typeof(Tbl_DL_Endorsement))]
        public IHttpActionResult DeleteTbl_DL_Endorsement(int id)
        {
            Tbl_DL_Endorsement tbl_DL_Endorsement = db.Tbl_DL_Endorsement.Find(id);
            if (tbl_DL_Endorsement == null)
            {
                return NotFound();
            }

            db.Tbl_DL_Endorsement.Remove(tbl_DL_Endorsement);
            db.SaveChanges();

            return Ok(tbl_DL_Endorsement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_DL_EndorsementExists(int id)
        {
            return db.Tbl_DL_Endorsement.Count(e => e.Id == id) > 0;
        }
    }
}