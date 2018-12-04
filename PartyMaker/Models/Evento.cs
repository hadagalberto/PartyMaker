using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace PartyMaker.Models
{
    public class Evento
    {

        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEvento { get; set; }

        [Display(Name = "Nome do Evento")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
        [Display(Name = "Local / Endereço do Evento")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Local { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Data do Evento")]
        public DateTime DataEvento { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataModificacao { get; set; }

        public IdentityUser Usuario { get; set; }

        public List<Participante> Participantes { get; set; }
        public List<Recurso> Recursos { get; set; }

    }
}
