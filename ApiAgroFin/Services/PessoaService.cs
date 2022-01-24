using ApiAgroFin.Contratos;
using ApiAgroFin.Contratos.Persistence;
using ApiAgroFin.Data.Dtos;
using ApiAgroFin.Models;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace ApiAgroFin.Services {
    public class PessoaService : IPessoaService {

        private readonly IGeralPersist _geralPersist;
        private readonly IPessoaPersist _pessoaPersist;
        private readonly IMapper _mapper;


        public PessoaService(
            IGeralPersist geralPersist, IPessoaPersist pessoaPersist, IMapper mapper ) {

            _geralPersist = geralPersist;
            _pessoaPersist = pessoaPersist;
            _mapper = mapper;
        }

        public async Task<PessoaDto> AddPessoas(PessoaDto model) {

            try {

                var pessoa = _mapper.Map<Pessoa>(model);

                _geralPersist.Add<Pessoa>(pessoa);
                if (await _geralPersist.SaveChangesAsync()) {

                    var pessoaRetorno = await _pessoaPersist.GetPessoaByIdAsync(pessoa.Pessoa_Id, false);

                    return _mapper.Map<PessoaDto>(pessoaRetorno);
                }
                return null;

            } catch (Exception ex) {

                throw new Exception(ex.Message);

            }
        }
        public async Task<PessoaDto> UpdatePessoa(int pessoaId, PessoaDto model) {



            try {
                var pessoa = await _pessoaPersist.GetPessoaByIdAsync(pessoaId, false);
                if (pessoa == null) {
                    return null;
                }

                model.Pessoa_Id = pessoaId;

                _mapper.Map(model, pessoa);

                _geralPersist.Update<Pessoa>(pessoa);
                if (await _geralPersist.SaveChangesAsync()) {

                    var pessoaRetorno = await _pessoaPersist.GetPessoaByIdAsync(pessoa.Pessoa_Id, false);

                    return _mapper.Map<PessoaDto>(pessoaRetorno);
                }
                return null;

            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> DeletePessoa(int pessoaId) {

            try {
                var pessoa = await _pessoaPersist.GetPessoaByIdAsync(pessoaId, false);
                if (pessoa == null) {
                    throw new Exception("Pessoa para delete não encontrado.");
                }

                //_geralPersist.Delete<Pessoa>(pessoa);
                _geralPersist.Delete<Pessoa>(pessoa);


                return await _geralPersist.SaveChangesAsync();

            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PessoaDto[]> GetAllPessoasAsync(bool includeEndereco = false) {

            try {

                var pessoas = await _pessoaPersist.GetAllPessoasAsync(includeEndereco);
                if (pessoas == null) {
                    return null;
                }

                var resultado = _mapper.Map<PessoaDto[]>(pessoas);

                return resultado;

            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PessoaDto[]> GetAllPessoasByNomeAsync(string nome, bool includeEndereco = false) {

            try {

                var pessoas = await _pessoaPersist.GetAllPessoasByNomeAsync(nome, includeEndereco);
                if (pessoas == null) {
                    return null;
                }

                var resultado = _mapper.Map<PessoaDto[]>(pessoas);

                return resultado;


            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PessoaDto> GetPessoasByIdAsync(int pessoa_Id, bool includeEndereco = false) {

            try {

                var pessoa = await _pessoaPersist.GetPessoaByIdAsync(pessoa_Id, includeEndereco);
                if (pessoa == null) {
                    return null;
                }

                var resultado = _mapper.Map<PessoaDto>(pessoa);

                return resultado;


            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

    }
}
