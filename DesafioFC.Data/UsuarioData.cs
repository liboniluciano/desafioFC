using DesafioFC.Domain;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFC.Data
{
    public class UsuarioData
    {
        public Context Context { get; set; }

        public UsuarioData()
        {
            Context = new Context();
        }

        public void Salvar(Usuario usuario)
        {
            if (usuario.Id > 0)
            {
                var usuarioAlt = Context.Usuarios.First(x => x.Id == usuario.Id);
                usuarioAlt.Nome = usuario.Nome;
            }
            else
                Context.Usuarios.Add(usuario);

            Context.SaveChanges();
        }

        public IEnumerable<Usuario> ListarUsuarios()
        {
            return Context.Usuarios.ToList();
        }

        public Usuario ListarUsuario(string id)
        {
            int.TryParse(id, out var idInt);
            return Context.Usuarios.First(x => x.Id == idInt);
        }

        public void Excluir(Usuario usuario)
        {
            var usuarioEx = Context.Usuarios.First(x => x.Id == usuario.Id);
            Context.Set<Usuario>().Remove(usuarioEx);
            Context.SaveChanges();
        }
    }
}
