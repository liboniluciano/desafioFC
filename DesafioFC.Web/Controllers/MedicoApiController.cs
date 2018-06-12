using DesafioFC.Data;
using DesafioFC.Domain;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace DesafioFC.Web.Controllers
{
    public class MedicoApiController : ApiController
    {
        private Context db = new Context();

        // GET: api/MedicoApi
        public IQueryable<Medico> GetMedicos()
        {
            return db.Medicos;
        }

        // GET: api/MedicoApi/5
        [ResponseType(typeof(Medico))]
        public IHttpActionResult GetMedico(int id)
        {
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }

        // PUT: api/MedicoApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedico(int id, Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medico.Id)
            {
                return BadRequest();
            }

            db.Entry(medico).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(id))
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

        // POST: api/MedicoApi
        [ResponseType(typeof(Medico))]
        public IHttpActionResult PostMedico(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medicos.Add(medico);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medico.Id }, medico);
        }

        // DELETE: api/MedicoApi/5
        [ResponseType(typeof(Medico))]
        public IHttpActionResult DeleteMedico(int id)
        {
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return NotFound();
            }

            db.Medicos.Remove(medico);
            db.SaveChanges();

            return Ok(medico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicoExists(int id)
        {
            return db.Medicos.Count(e => e.Id == id) > 0;
        }
    }
}