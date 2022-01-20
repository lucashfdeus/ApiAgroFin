using ApiAgroFin.Models;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos.Persistence {
    public interface IPessoasPersist {
        //PESSOAS
        Task<Pessoa[]> GetAllPessoasByNomeAsync(string nome, bool includeEndereco);
        Task<Pessoa[]> GetAllPessoasAsync( bool includeEndereco);
        Task<Pessoa> GetPessoasByIdAsync(int Pessoa_Id, bool includeEndereco);

    }
}
