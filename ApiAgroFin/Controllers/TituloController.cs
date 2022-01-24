using ApiAgroFin.Contratos;
using ApiAgroFin.Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiAgroFin.Controllers {


    [ApiController]
    [Route("[controller]")]
    public class TituloController : ControllerBase {

        private readonly ITituloService _tituloService;

        public TituloController(ITituloService tituloService) {
            _tituloService = tituloService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {

            try {

                var titulos = await _tituloService.GetAllTitulosAsync(true);
                if (titulos == null) {
                    return NoContent();
                }
                return Ok(titulos);

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar titulos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {

            try {

                var titulo = await _tituloService.GetTituloByIdAsync(id, true);
                if (titulo == null) {
                    return NoContent();
                }
                return Ok(titulo);

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar titulos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{descricao}/descricao")]
        public async Task<IActionResult> GetByNome(string descricao) {

            try {

                var titulo = await _tituloService.GetAllTitulosByNomeAsync(descricao, true);
                if (titulo == null) {
                    return NoContent();
                }
                return Ok(titulo);

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar titulos. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(TituloDto model) {

            try {

                var titulo = await _tituloService.AddTitulos(model);
                if (titulo == null) {
                    return BadRequest("Erro ao tentar adicionar Titulo.");
                }
                return Ok(titulo);

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Titulos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TituloDto model) {

            try {

                var titulo = await _tituloService.UpdateTitulo(id, model);
                if (titulo == null) {
                    return BadRequest("Erro ao tentar atualizar Titulo.");
                }
                return Ok(titulo);

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Titulos. Erro: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {

            try {

                return await _tituloService.DeleteTitulo(id) ?
                     Ok("Deletado") :
                     BadRequest("Titulo não deletada.");

            } catch (Exception ex) {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar Titulo. Erro: {ex.Message}");
            }
        }

    }
}
