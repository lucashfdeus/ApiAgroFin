using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAgroFin.Models {
    public class Pagador{

        [Key]
        [Required]
        public int Id { get; set; }
       //public int Pessoa_Id { get; set; }
        public Pessoa Pessoa { get; set; }

        public virtual IEnumerable<Titulo> ListaTilulosPagador { get; set; }







    }
}
