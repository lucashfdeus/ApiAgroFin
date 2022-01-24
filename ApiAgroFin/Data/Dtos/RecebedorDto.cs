using ApiAgroFin.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAgroFin.Data.Dtos {
    public class RecebedorDto {

        [Key]
        [Required]
        public int Id { get; set; }
        public int Pessoa_Id { get; set; }
        public Pessoa Pessoa { get; set; }
      //  public virtual IEnumerable<TituloDto> ListaTilulosRecebedor { get; set; }

    }
}
