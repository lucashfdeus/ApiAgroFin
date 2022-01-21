using ApiAgroFin.Models;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos {
    public interface IPessoaService {

        Task<Pessoa> AddPessoas(Pessoa model);
        Task<Pessoa> UpdatePessoa(int pessoaId, Pessoa model);
        Task<bool> DeletePessoa(int pessoaId);

        Task<Pessoa[]> GetAllPessoasAsync(bool includeEndereco=false);
        Task<Pessoa[]> GetAllPessoasByNomeAsync(string nome, bool includeEndereco=false);
        Task<Pessoa> GetPessoasByIdAsync(int pessoa_Id, bool includeEndereco=false);

    }
}
