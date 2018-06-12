using DesafioFC.Data;
using System.Web.Mvc;
using DesafioFC.Domain;

namespace DesafioFC.Web.Controllers
{
    public class PacienteController : Controller
    {

        private readonly PacienteData _pacienteData;

        public PacienteController()
        {
            _pacienteData = new PacienteData();
        }

        public ActionResult Index()
        {
            var pacientes = _pacienteData.ListarPacientes();
            return View(pacientes);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _pacienteData.Salvar(paciente);
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        public ActionResult Detalhes(string id)
        {
            var paciente = _pacienteData.ListarPaciente(id);
            if (paciente == null)
                return HttpNotFound();

            return View(paciente);
        }

        public ActionResult Alterar(string id)
        {
            var paciente = _pacienteData.ListarPaciente(id);
            if (paciente == null)
                return HttpNotFound();

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _pacienteData.Salvar(paciente);
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        public ActionResult Excluir(string id)
        {
            var paciente = _pacienteData.ListarPaciente(id);
            if (paciente == null)
                return HttpNotFound();

            return View(paciente);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirId(string id)
        {
            var paciente = _pacienteData.ListarPaciente(id);
            _pacienteData.Excluir(paciente);
            return RedirectToAction("Index");
        }
    }
}