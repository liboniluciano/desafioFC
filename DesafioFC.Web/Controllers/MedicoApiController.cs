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

       }
}