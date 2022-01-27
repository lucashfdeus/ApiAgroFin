using ApiAgroFin.Models;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos.Persistence {
    public interface IPagadorPersist {

        //PAGADOR
        Task<Pagador[]> GetAllPagadoresAsync(bool includePessoa);
        Task<Pagador> GetAllPagadorByIdAsync(int pessoa_Id);

    }
}
