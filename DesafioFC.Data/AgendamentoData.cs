using DesafioFC.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DesafioFC.Data
{
    public class AgendamentoData
    {
        public Context Context { get; set; }

        public AgendamentoData()
        {
            Context = new Context();
        }

        public void Salvar(Agendamento agendamento)
        {
            if (agendamento.Id > 0)
            {
                var agendamentoAlt = Context.Agendamentos.First(x => x.Id == agendamento.Id);
                agendamentoAlt.DataConsulta = agendamento.DataConsulta;
                agendamentoAlt.Medico = Context.Medicos.ToList().First(x => x.Id == agendamento.Medico.Id);
                agendamentoAlt.Paciente = Context.Pacientes.ToList().First(x => x.Id == agendamento.Paciente.Id);
            }
            else
            {
                //Vincula consulta com paciente
                agendamento.Paciente = Context.Pacientes.ToList().FirstOrDefault(x => x.Id == agendamento.Paciente.Id);
                //Vincula consulta com médico
                agendamento.Medico = Context.Medicos.ToList().First(x => x.Id == agendamento.Medico.Id);
                Context.Agendamentos.Add(agendamento);
            }
            Context.SaveChanges();
        }

        public IEnumerable<Agendamento> ListarAgendamentos()
        {
            return Context.Agendamentos.Include(x => x.Medico).Include(x => x.Paciente).ToList();
        }

        public Agendamento ListarAgendamento(string id)
        {
            int.TryParse(id, out var idInt);
            return Context.Agendamentos.Include(x => x.Medico).Include(x => x.Paciente).First(x => x.Id == idInt);
        }

        public void Excluir(Agendamento agendamento)
        {
            var agendamentoEx = Context.Agendamentos.First(x => x.Id == agendamento.Id);
            Context.Set<Agendamento>().Remove(agendamentoEx);
            Context.SaveChanges();
        }
    }
}
