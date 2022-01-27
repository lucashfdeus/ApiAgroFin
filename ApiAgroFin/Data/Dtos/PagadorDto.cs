using ApiAgroFin.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiAgroFin.Data.Dtos {
    public class PagadorDto {

        [JsonIgnore]
        [Key]
        [Required]
        public int Pagador_Id { get; set; }

        [ForeignKey("Pessoa")]
        public int Pessoa_Id { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Pessoa> Pessoas { get; set; }




    }
}
