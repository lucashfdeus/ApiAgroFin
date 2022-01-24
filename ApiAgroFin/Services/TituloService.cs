

using ApiAgroFin.Contratos;
using ApiAgroFin.Contratos.Persistence;
using ApiAgroFin.Data.Dtos;
using ApiAgroFin.Models;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace ApiAgroFin.Services {
    public class TituloService : ITituloService {

        private readonly IGeralPersist _geralPersist;
        private readonly ITituloPersist _tituloPersist;
        private readonly IMapper _mapper;

        public TituloService(
           IGeralPersist geralPersist, ITituloPersist tituloPersist, IMapper mapper) {

            _geralPersist = geralPersist;
            _tituloPersist = tituloPersist;
            _mapper = mapper;
        }

        public async Task<TituloDto> AddTitulos(TituloDto model) {

            try {

                var titulo = _mapper.Map<Titulo>(model);

                _geralPersist.Add<Titulo>(titulo);
                if (await _geralPersist.SaveChangesAsync()) {

                    var tituloRetorno = await _tituloPersist.GetTituloByIdAsync(titulo.Id, false);

                    return _mapper.Map<TituloDto>(tituloRetorno);
                }
                return null;

            } catch (Exception ex) {

                throw new Exception(ex.Message);

            }
        }
        public async Task<TituloDto> UpdateTitulo(int tituloId, TituloDto model) {

            try {
                var titulo = await _tituloPersist.GetTituloByIdAsync(tituloId, false);
                if (titulo == null) {
                    return null;
                }

                model.Id = tituloId;

                _mapper.Map(model, titulo);

                _geralPersist.Update<Titulo>(titulo);
                if (await _geralPersist.SaveChangesAsync()) {

                    var tituloRetorno = await _tituloPersist.GetTituloByIdAsync(titulo.Id, false);

                    return _mapper.Map<TituloDto>(tituloRetorno);
                }
                return null;

            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteTitulo(int tituloId) {

            try {
                var titulo = await _tituloPersist.GetTituloByIdAsync(tituloId, false);
                if (titulo == null) {
                    throw new Exception("Titulo para delete não encontrado.");
                }

                _geralPersist.Delete<Titulo>(titulo);


                return await _geralPersist.SaveChangesAsync();

            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TituloDto[]> GetAllTitulosAsync(bool includeRecebedor = false, bool includePagador = false) {

            try {

                var titulos = await _tituloPersist.GetAllTitulosAsync(includeRecebedor, includePagador);
                if (titulos == null) {
                    return null;
                }

                var resultado = _mapper.Map<TituloDto[]>(titulos);

                return resultado;

            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TituloDto[]> GetAllTitulosByNomeAsync(string nome, bool includeRecebedor = false, bool includePagador = false) {

            try {

                var titulos = await _tituloPersist.GetAllTitulosByNomeAsync(nome, includeRecebedor, includePagador);
                if (titulos == null) {
                    return null;
                }

                var resultado = _mapper.Map<TituloDto[]>(titulos);

                return resultado;


            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TituloDto> GetTituloByIdAsync(int tituloId, bool includeRecebedor = false, bool includePagador = false) {

            try {

                var titulo = await _tituloPersist.GetTituloByIdAsync(tituloId, includeRecebedor, includePagador);
                if (titulo == null) {
                    return null;
                }

                var resultado = _mapper.Map<TituloDto>(titulo);

                return resultado;


            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

    }
}
