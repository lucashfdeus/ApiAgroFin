using ApiAgroFin.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiAgroFin.Data.Dtos {
    public class EnderecoDto {

        [Key]
        [Required]
        public int Endereco_Id { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string Endereco_Logradouro { get; set; }
        public int Endereco_Numero { get; set; }
        public string Endereco_Complemento { get; set; }

        [Required(ErrorMessage = "O campo Cep é obrigatório")]
        public string Endereco_Cep { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string Endereco_Bairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        public string Endereco_Cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        [StringLength(2, ErrorMessage = "O nome do Estado deve ser abreviado Ex: GO")]
        public string Endereco_Estado { get; set; }

        public PessoaDto Pessoa { get; set; }

    }
}
