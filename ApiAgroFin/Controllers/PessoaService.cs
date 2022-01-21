using ApiAgroFin.Contratos;
using ApiAgroFin.Contratos.Persistence;
using ApiAgroFin.Models;
using System;
using System.Threading.Tasks;

namespace ApiAgroFin.Controllers {
    public class PessoaService : IPessoaService {
        
        private readonly IGeralPersist _geralPersist;
        private readonly IPessoaPersist _pessoaPersist;


        public PessoaService(IGeralPersist geralPersist, IPessoaPersist pessoaPersist) {

            _pessoaPersist = pessoaPersist;
            _geralPersist = geralPersist;

        }

        public async Task<Pessoa> AddPessoas(Pessoa model) {

            try {
                _geralPersist.Add<Pessoa>(model);
                if (await _geralPersist.SaveChangesAsync()) {
                    return await _pessoaPersist.GetPessoaByIdAsync(model.Pessoa_Id, false);
                }
                return null;

            } catch (Exception ex) {

                throw new Exception(ex.Message);

            }
        }
        public async Task<Pessoa> UpdatePessoa(int pessoaId, Pessoa model) {

            try {
                var pessoa = await _pessoaPersist.GetPessoaByIdAsync(pessoaId, false);
                if (pessoa == null) {
                    return null;
                }

                model.Pessoa_Id = pessoaId;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync()) {
                    return await _pessoaPersist.GetPessoaByIdAsync(model.Pessoa_Id, false);
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

                _geralPersist.Delete<Pessoa>(pessoa);

                return await _geralPersist.SaveChangesAsync();

            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Pessoa[]> GetAllPessoasAsync(bool includeEndereco = false) {

            try {

                var pessoas = await _pessoaPersist.GetAllPessoasAsync(includeEndereco);
                if (pessoas == null) {
                    return null;
                }
                return pessoas;

            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Pessoa[]> GetAllPessoasByNomeAsync(string nome, bool includeEndereco = false) {

            try {

                var pessoas = await _pessoaPersist.GetAllPessoasByNomeAsync(nome, includeEndereco);
                if (pessoas == null) {
                    return null;
                }
                return pessoas;

            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Pessoa> GetPessoasByIdAsync(int pessoa_Id, bool includeEndereco = false) {

            try {

                var pessoas = await _pessoaPersist.GetPessoaByIdAsync(pessoa_Id, includeEndereco);
                if (pessoas == null) {
                    return null;
                }
                return pessoas;

            } catch (Exception ex) {

                throw new Exception(ex.Message);
            }
        }

    }
}
