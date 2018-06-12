using DesafioFC.Domain;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFC.Data
{
    public class PacienteData
    {
        public Context Context { get; set; }

        public PacienteData()
        {
            Context = new Context();
        }

        public void Salvar(Paciente paciente)
        {
            if (paciente.Id > 0)
            {
                var pacienteAlt = Context.Pacientes.First(x => x.Id == paciente.Id);
                pacienteAlt.Nome = paciente.Nome;
                pacienteAlt.DataNascimento = paciente.DataNascimento;
                pacienteAlt.Endereco = paciente.Endereco;
                pacienteAlt.NumeroEndereco = paciente.NumeroEndereco;
                pacienteAlt.Telefone = paciente.Telefone;
                pacienteAlt.Rg = paciente.Rg;
            }
            else
                Context.Pacientes.Add(paciente);

            Context.SaveChanges();
        }

        public IEnumerable<Paciente> ListarPacientes()
        {
            return Context.Pacientes.ToList();
        }

        public Paciente ListarPaciente(string id)
        {
            int.TryParse(id, out var idInt);
            return Context.Pacientes.First(x => x.Id == idInt);
        }

        public void Excluir(Paciente paciente)
        {
            var pacienteEx = Context.Pacientes.First(x => x.Id == paciente.Id);
            Context.Set<Paciente>().Remove(pacienteEx);
            Context.SaveChanges();
        }
    }
}
