using ApiAgroFin.Data.Dtos;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos {
    public interface ITituloService {

        Task<TituloDto> AddTitulos(TituloDto model);
        Task<TituloDto> UpdateTitulo(int tituloId, TituloDto model);
        Task<bool> DeleteTitulo(int tituloId);

        Task<TituloDto[]> GetAllTitulosAsync(bool includeRecebedor = false, bool includePagador = false);
        Task<TituloDto[]> GetAllTitulosByNomeAsync(string nome, bool includeRecebedor = false, bool includePagador = false);
        Task<TituloDto> GetTituloByIdAsync(int tituloId, bool includeRecebedor = false, bool includePagador = false);
    }
}
