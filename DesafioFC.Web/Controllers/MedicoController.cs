using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DesafioFC.Data;
using DesafioFC.Domain;

namespace DesafioFC.Web.Controllers
{
    public class MedicoController : Controller
    {
        private readonly MedicoData _medicoData;

        public MedicoController()
        {
            _medicoData = new MedicoData();
        }

        public ActionResult Index()
        {
            var medicoApi = new MedicoApiController();
            var medicos = medicoApi.GetMedicos();
            return View(medicos);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _medicoData.Salvar(medico);
                return RedirectToAction("Index");
            }

            return View(medico);
        }

        public ActionResult Detalhes(string id)
        {
            var medico = _medicoData.ListarMedico(id);
            if (medico == null)
                return HttpNotFound();

            return View(medico);
        }

        public ActionResult Alterar(string id)
        {
            var medico = _medicoData.ListarMedico(id);
            if (medico == null)
                return HttpNotFound();

            return View(medico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _medicoData.Salvar(medico);
                return RedirectToAction("Index");
            }

            return View(medico);
        }

        public ActionResult Excluir(string id)
        {
            var medico = _medicoData.ListarMedico(id);
            if (medico == null)
                return HttpNotFound();

            return View(medico);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirId(string id)
        {
            var medico = _medicoData.ListarMedico(id);
            _medicoData.Excluir(medico);
            return RedirectToAction("Index");
        }

    }
}