using ApiAgroFin.Models;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos.Persistence {
    public interface ITituloPersist {

        //TITULO
        Task<Titulo[]> GetAllTitulosAsync(bool includeRecebedor = false, bool includePagador = false);
        Task<Titulo[]> GetAllTitulosByNomeAsync(string nome, bool includeRecebedor = false, bool includePagador = false);
        Task<Titulo> GetTituloByIdAsync(int tituloId, bool includeRecebedor = false, bool includePagador = false);


    }
}
