using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioFC.Domain
{
    public class Agendamento
    {
        public int Id { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual Medico Medico { get; set; }

        [Required(ErrorMessage = "Informe data da consulta")]
        [DisplayName("Data da Consulta")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime DataConsulta { get; set; }
    }
}
