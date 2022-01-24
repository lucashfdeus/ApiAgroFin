using ApiAgroFin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAgroFin.Data.Dtos {
    public class TituloDto {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public DateTime Titulo_Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public double Titulo_Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(3, ErrorMessage = "O nome do Estado deve ser abreviado Ex: PAG ou PEN")]
        public string Titulo_Status { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Titulo_Valor_Extenso { get; set; }

        //[Required]
        //public string Titulo_Cidade { get; set; }
        //[Required]
        //public string Titulo_Estado { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Titulo_Descricao { get; set; }

        //public int PagadorId { get; set; }
        public PagadorDto Pagador { get; set; }
        //spublic int RecebedorId { get; set; }
        public RecebedorDto Recebedor { get; set; }
    }
}
