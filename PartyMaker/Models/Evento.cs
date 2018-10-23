using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PartyMaker.Models;

namespace Churras.Models
{
    public class Evento
    {

        [Key]
        [ScaffoldColumn(false)]
        public int IdEvento { get; set; }

        [Display(Name = "Nome do Evento")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
        [Display(Name = "Local / Endereço do Evento")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Local { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Data do Evento")]
        public DateTime DataEvento { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataModificacao { get; set; }

        public Usuario Usuario { get; set; }

        public List<Participante> Participantes { get; set; }
        public List<Recurso> Recursos { get; set; }

    }
}
