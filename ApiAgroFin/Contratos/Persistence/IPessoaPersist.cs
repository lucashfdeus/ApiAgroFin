using ApiAgroFin.Data.Dtos;
using ApiAgroFin.Models;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos.Persistence {
    public interface IPessoaPersist {
        //PESSOAS
        Task<Pessoa[]> GetAllPessoasByNomeAsync(string nome, bool includeEndereco=false);
        Task<Pessoa[]> GetAllPessoasAsync( bool includeEndereco=false);
        Task<Pessoa> GetPessoaByIdAsync(int pessoa_Id, bool includeEndereco=false);

    }
}
