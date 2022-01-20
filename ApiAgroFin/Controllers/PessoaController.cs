using ApiAgroFin.Data;
using ApiAgroFin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiAgroFin.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase {

        private readonly AppDbContext _context;

        public PessoaController(AppDbContext context) { 
            _context = context;
        }

        public IEnumerable<Pessoa> _pessoa = new Pessoa[] {
            new Pessoa() {
                Pessoa_Id = 1,
                Pessoa_Numero_Identificador = "04703379155",
                Pessoa_Nome = "Lucas Teste"
            },
               new Pessoa() {
                Pessoa_Id = 2,
                Pessoa_Numero_Identificador = "04703379155",
                Pessoa_Nome = "Lucas Teste"
            }
        };

        [HttpGet]
        public IEnumerable<Pessoa> GetAllPessoa() {
            return _context.Pessoa;
        }

        [HttpGet("{id}")]
        public IEnumerable<Pessoa> GetByIdPessoa(int id) {
            yield return _context.Pessoa.FirstOrDefault(pessoa => pessoa.Pessoa_Id == id);
        }

    }
}
