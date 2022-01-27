using ApiAgroFin.Data;
using ApiAgroFin.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos.Persistence.RecebedorPersistence {
    public class RecebedorPersistence : IRecebedorPersist {

        private readonly AppDbContext _context;
        
        public async Task<Recebedor[]> GetAllRecebedoresAsync(bool includePessoa) {
            IQueryable<Recebedor> query = _context.Recebedor
                 .Include(p => p.Recebedor_Id);

            return await query.ToArrayAsync();
        }

        public async Task<Recebedor> GetAllRecebedorByIdAsync(int pessoa_Id) {

            IQueryable<Recebedor> query = _context.Recebedor
             .Include(p => p.Recebedor_Id);

            query = query.OrderBy(p => p.Recebedor_Id)
                 .Where(e => e.Recebedor_Id == e.Recebedor_Id);

            return await query.FirstOrDefaultAsync();

        }

    }
}
