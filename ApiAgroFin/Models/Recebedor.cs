using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAgroFin.Models {
    public class Recebedor {

        [Key]
        [Required]
        public int Id { get; set; }
       // public int Pessoa_Id { get; set; }     
        public Pessoa Pessoa { get; set; }
        public virtual IEnumerable<Titulo> ListaTilulosRecebedor { get; set; }


    }
}
