using ApiAgroFin.Models;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos.Persistence {
    public interface IEnderecoPersist {

        //ENDERECOS
        Task<Endereco[]> GetAllEnderecoByNomeAsync(string nome);
        Task<Endereco[]> GetAllEnderecoAsync(bool includeEndereco);
        Task<Endereco> GetAllEnderecoByIdAsync(int endereco_Id);


    }
}
