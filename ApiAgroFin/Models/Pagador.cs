using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiAgroFin.Models  {
    public class Pagador{

        [Key]
        [Required]
        public int Pagador_Id { get; set; }

        [ForeignKey("Pessoa")]
        public int Pessoa_Id { get; set; }
    
       public Pessoa Pessoa { get; set; }









    }
}
