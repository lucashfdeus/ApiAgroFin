
using ApiAgroFin.Contratos;
using ApiAgroFin.Data.Dtos;
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
                    return NoContent();
                }
                return Ok(pessoas);

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pessoas. Erro: {ex.Message}");
            }


            //Forma sem o AutoMapper.
            //var pessoasRetorno = new List<PessoaDto>();

            //foreach (var pessoa in pessoas) {

            //    pessoasRetorno.Add(new PessoaDto {
            //        Pessoa_Id = pessoa.Pessoa_Id,
            //        //Pessoa_Numero_Identificador = pessoa.Pessoa_Numero_Identificador
            //        Pessoa_Nome = pessoa.Pessoa_Nome,
            //        Pessoa_Numero_Identificador = pessoa.Pessoa_Numero_Identificador,
            //        Enderecos = pessoa.Enderecos
            //    }) ; 
            //}
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {

            try {

                var pessoa = await _pessoaService.GetPessoasByIdAsync(id, true);
                if (pessoa == null) {
                    return NoContent();
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
                    return NoContent();
                }
                return Ok(pessoa);

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar pessoas. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(PessoaDto model) {

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
        public async Task<IActionResult> Put(int id, PessoaDto model) {

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
