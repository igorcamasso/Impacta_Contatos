using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppLogin.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [StringLength(250), MaxLength(250), DisplayName("Nome do Evento")]
        public string Nome { get; set; }

        [DisplayName("Data e Hora")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTimeOffset DataHora { get; set; }

        [DisplayName("Endereço")]
        [StringLength(500), MaxLength(500)]
        public string Endereco { get; set; }

        [DisplayName("Descrição do evento")]
        public string Descricao { get; set; }
    }
}
