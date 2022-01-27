using ApiAgroFin.Models;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos.Persistence {
    public interface IRecebedorPersist {

        //RECEBEDOR
        Task<Recebedor[]> GetAllRecebedoresAsync(bool includePessoa);
        Task<Recebedor> GetAllRecebedorByIdAsync(int pessoa_Id);
    }
}
