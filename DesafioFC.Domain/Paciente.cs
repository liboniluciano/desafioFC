using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioFC.Domain
{
    public class Paciente
    {
        public int Id { get; set; }

        [DisplayName("Nome do Paciente")]
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [DisplayName("Número")]
        public int NumeroEndereco { get; set; }

        public string Telefone { get; set; }

        public string Rg { get; set; }
    }
}
