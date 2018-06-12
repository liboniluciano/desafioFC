using DesafioFC.Domain;
using System.Data.Entity;

namespace DesafioFC.Data
{
    public class Context : DbContext
    {
        public Context() : base("desafioFC")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
