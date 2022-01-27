using ApiAgroFin.Data;
using ApiAgroFin.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos.Persistence.PagadorPersistence {
    public class PagadorPersistence : IPagadorPersist {

        private readonly AppDbContext _context;

        public async Task<Pagador[]> GetAllPagadoresAsync(bool includePessoa = false) {
            IQueryable<Pagador> query = _context.Pagador
                   .Include(p => p.Pagador_Id);

            return await query.ToArrayAsync();
        }

        public async Task<Pagador> GetAllPagadorByIdAsync(int pessoa_Id) {

            IQueryable<Pagador> query = _context.Pagador
              .Include(p => p.Pagador_Id);

            query = query.OrderBy(p => p.Pagador_Id)
                 .Where(e => e.Pagador_Id == e.Pagador_Id);


            return await query.FirstOrDefaultAsync();
        }

    }
}
