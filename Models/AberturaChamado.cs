using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;



namespace CadastroVeiculo.Models
{
    public class AberturaChamado
    {

        [Key]
        public int id { get; set; }

        [Required]  
        [StringLength(50)]
        public string nomeSolicitante { get; set; }

        [Required]
        [StringLength(50)]
        public string enderecoSolicitante { get; set; }



        [Required]
        [StringLength(50)]
        public string cepSolicitante { get; set; }


        [Required]
        [StringLength(50)]
        public string placaVeiculo { get; set; }



        [Required]
        [StringLength(50)]
        public DateTime dataAberturaChamado { get; set; }


    }
}
