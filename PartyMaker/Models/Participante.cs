using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartyMaker.Models
{
    public class Participante
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdParticipante { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "E-mail do Participante")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
        [ScaffoldColumn(false)]
        public string HashCode { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataAdicionado { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataAlterado { get; set; }

        public Evento Evento { get; set; }
        public Recurso Recurso { get; set; }
    }
}
