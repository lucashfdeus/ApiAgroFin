using ApiAgroFin.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiAgroFin.Data.Dtos {
    public class PessoaDto {

        [Key]
        [Required]
        public int Pessoa_Id { get; set; }

        [Required(ErrorMessage = "O campo Numero Identificador é obrigatório!")]

        public string Pessoa_Numero_Identificador { get; set; }
        [Required(ErrorMessage = "O campo Numero Nome é obrigatório!")]
        public string Pessoa_Nome { get; set; }

        // public virtual Endereco PessoaEndereco { get; set; }
        // public int Pessoa_Endereco_I { get; set; }
       public virtual IEnumerable<EnderecoDto> Enderecos { get; set; }

    }
}
