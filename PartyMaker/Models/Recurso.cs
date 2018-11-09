using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PartyMaker.Models
{
    public class Recurso
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRecurso { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Nome do Recurso")]
        public string NomeRecurso { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Quantidade")]
        public float Quantidade { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Tipo do Recurso (Bebidas, Comidas, Doces)")]
        public string TipoRecurso { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataAlteracao { get; set; }

        public Evento Evento { get; set; }

    }
}
