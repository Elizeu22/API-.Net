using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace CadastroVeiculo.Models
{
    public class Colaborador
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nomeColaborador { get; set; }

        [Required]
        [StringLength(50)]
        public string enderecoSolicitante { get; set; }


        public ICollection<AberturaChamado> AberturaChamado { get; set; }
    }
}
