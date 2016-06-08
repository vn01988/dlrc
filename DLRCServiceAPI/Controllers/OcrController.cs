using DLRCServiceAPI.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace DLRCServiceAPI.Controllers
{
    public class OcrController : ApiController
    {
        private DLRCDBEntities db = new DLRCDBEntities();

        // GET: api/Ocr
        public IHttpActionResult GetTbl_Ocr()
        {
            return Json(db.Tbl_Ocr.ToList());
        }

        // GET: api/Ocr/5
        [ResponseType(typeof(Tbl_Ocr))]
        public IHttpActionResult GetTbl_Ocr(int id)
        {
            Tbl_Ocr tbl_Ocr = db.Tbl_Ocr.Find(id);
            if (tbl_Ocr == null)
            {
                return NotFound();
            }

            return Json(tbl_Ocr);
        }

        // PUT: api/Ocr/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Ocr(int id, Tbl_Ocr tbl_Ocr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Ocr.Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_Ocr).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_OcrExists(id))
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

        // POST: api/Ocr
        [ResponseType(typeof(Tbl_Ocr))]
        public IHttpActionResult PostTbl_Ocr(Tbl_Ocr tbl_Ocr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Ocr.Add(tbl_Ocr);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Ocr.Id }, tbl_Ocr);
        }

        // DELETE: api/Ocr/5
        [ResponseType(typeof(Tbl_Ocr))]
        public IHttpActionResult DeleteTbl_Ocr(int id)
        {
            Tbl_Ocr tbl_Ocr = db.Tbl_Ocr.Find(id);
            if (tbl_Ocr == null)
            {
                return NotFound();
            }

            db.Tbl_Ocr.Remove(tbl_Ocr);
            db.SaveChanges();

            return Ok(tbl_Ocr);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_OcrExists(int id)
        {
            return db.Tbl_Ocr.Count(e => e.Id == id) > 0;
        }
    }
}