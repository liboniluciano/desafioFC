using DesafioFC.Data;
using DesafioFC.Domain;
using System.Web.Mvc;

namespace DesafioFC.Web.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly AgendamentoData _agendamentoData;

        public AgendamentoController()
        {
            _agendamentoData = new AgendamentoData();
        }

        public ActionResult Index()
        {
            var agendamentos = _agendamentoData.ListarAgendamentos();
            return View(agendamentos);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _agendamentoData.Salvar(agendamento);
                return RedirectToAction("Index");
            }

            return View(agendamento);
        }

        public ActionResult Detalhes(string id)
        {
            var agendamento = _agendamentoData.ListarAgendamento(id);
            if (agendamento == null)
                return HttpNotFound();

            return View(agendamento);
        }

        public ActionResult Editar(string id)
        {
            var agendamento = _agendamentoData.ListarAgendamento(id);
            if (agendamento == null)
                return HttpNotFound();

            return View(agendamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _agendamentoData.Salvar(agendamento);
                return RedirectToAction("Index");
            }

            return View(agendamento);
        }

        public ActionResult Excluir(string id)
        {
            var agendamento = _agendamentoData.ListarAgendamento(id);
            if (agendamento == null)
                return HttpNotFound();

            return View(agendamento);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirAgendamento(string id)
        {
            var agendamento = _agendamentoData.ListarAgendamento(id);
            _agendamentoData.Excluir(agendamento);
            return RedirectToAction("Index");
        }
    }
}