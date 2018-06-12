using System.Web.Mvc;
using DesafioFC.Data;
using DesafioFC.Domain;

namespace DesafioFC.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioData _usuarioData;

        public UsuarioController()
        {
            _usuarioData = new UsuarioData();
        }
        public ActionResult Index()
        {
            var usuarios = _usuarioData.ListarUsuarios();
            return View(usuarios);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioData.Salvar(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Detalhes(string id)
        {
            var usuario = _usuarioData.ListarUsuario(id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        public ActionResult Alterar(string id)
        {
            var usuario = _usuarioData.ListarUsuario(id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioData.Salvar(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Excluir(string id)
        {
            var usuario = _usuarioData.ListarUsuario(id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirId(string id)
        {
            var usuario = _usuarioData.ListarUsuario(id);
            _usuarioData.Excluir(usuario);
            return RedirectToAction("Index");
        }
    }
}