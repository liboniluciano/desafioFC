using DesafioFC.Domain;
using System.Linq;

namespace DesafioFC.Data
{
    public class MedicoData
    {
        public Context Context { get; set; }

        public MedicoData()
        {
            Context = new Context();
        }

        public void Salvar(Medico medico)
        {
            if (medico.Id > 0)
            {
                var medicoAlt = Context.Medicos.First(x => x.Id == medico.Id);
                medicoAlt.Nome = medico.Nome;
                medicoAlt.Telefone = medico.Telefone;
                medicoAlt.Rg = medicoAlt.Rg;
            }
            else
                Context.Medicos.Add(medico);

            Context.SaveChanges();
        }

        public Medico ListarMedico(string id)
        {
            int.TryParse(id, out var idInt);
            return Context.Medicos.First(x => x.Id == idInt);
        }

        public void Excluir(Medico medico)
        {
            var medicoEx = Context.Medicos.First(x => x.Id == medico.Id);
            Context.Set<Medico>().Remove(medicoEx);
            Context.SaveChanges();
        }
    }
}
