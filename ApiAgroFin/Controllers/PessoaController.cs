using ApiAgroFin.Contratos;
using ApiAgroFin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace ApiAgroFin.Controllers {


    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase {

        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService) {

            _pessoaService = pessoaService;

        }  
        

        [HttpGet]
        public async Task<IActionResult> Get() {

            try {

                var pessoas = await _pessoaService.GetAllPessoasAsync(true);
                if(pessoas == null) {
                    return NotFound("Nenhuma pessoa encontrada.");
                }
                return Ok(pessoas);

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pessoas. Erro: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {

            try {

                var pessoa = await _pessoaService.GetPessoasByIdAsync(id, true);
                if (pessoa == null) {
                    return NotFound("Nenhuma pessoa por ID encontrada.");
                }
                return Ok(pessoa);

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pessoas. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome) {

            try {

                var pessoa = await _pessoaService.GetAllPessoasByNomeAsync(nome, true);
                if (pessoa == null) {
                    return NotFound("Nenhuma pessoa por NOME encontrada.");
                }
                return Ok(pessoa);

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pessoas. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Pessoa model) {

            try {

                var pessoa = await _pessoaService.AddPessoas(model);
                if (pessoa == null) {
                    return BadRequest("Erro ao tentar adicionar pessoa.");
                }
                return Ok(pessoa);

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pessoas. Erro: {ex.Message}");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pessoa model) {

            try {

                var pessoa = await _pessoaService.UpdatePessoa(id, model);
                if (pessoa == null) {
                    return BadRequest("Erro ao tentar atualizar pessoa.");
                }
                return Ok(pessoa);

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pessoas. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {

            try {

                return await _pessoaService.DeletePessoa(id) ?
                     Ok("Deletado") :
                     BadRequest("Pessoa não deletada.");

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar pessoa. Erro: {ex.Message}");
            }
        }


    }
}
