using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAgroFin.Models {
    public class Recebedor {

        [Key]
        [Required]
        public int Recebedor_Id { get; set; }

        [ForeignKey("Pessoa")]
        public int Pessoa_Id { get; set; }
        public Pessoa Pessoa { get; set; }





    }
}
