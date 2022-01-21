using ApiAgroFin.Data.Dtos;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos {
    public interface IPessoaService {

        Task<PessoaDto> AddPessoas(PessoaDto model);
        Task<PessoaDto> UpdatePessoa(int pessoaId, PessoaDto model);
        Task<bool> DeletePessoa(int pessoaId);

        Task<PessoaDto[]> GetAllPessoasAsync(bool includeEndereco=false);
        Task<PessoaDto[]> GetAllPessoasByNomeAsync(string nome, bool includeEndereco=false);
        Task<PessoaDto> GetPessoasByIdAsync(int pessoa_Id, bool includeEndereco=false);

    }
}
