using ApiAgroFin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiAgroFin.Data.Dtos {
    public class TituloDto {

        [Key]
        [Required]
        public int Titulo_Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public DateTime Titulo_Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public double Titulo_Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(3, ErrorMessage = "O nome do Estado deve ser abreviado Ex: PAG ou PEN")]
        public string Titulo_Status { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Titulo_Valor_Extenso { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Titulo_Descricao { get; set; }       
      
        public PagadorDto Pagador { get; set; }
        public RecebedorDto Recebedor { get; set; }


    }
}
