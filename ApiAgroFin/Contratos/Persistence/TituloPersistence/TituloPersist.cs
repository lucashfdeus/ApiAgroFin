using ApiAgroFin.Data;
using ApiAgroFin.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace ApiAgroFin.Contratos.Persistence.TituloPersistence {

    public class TituloPersist : ITituloPersist {
                
          private readonly AppDbContext _context;

        public TituloPersist(AppDbContext context) {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }



        public async Task<Titulo[]> GetAllTitulosAsync(bool includeRecebedor = false, bool includePagador = false) {
            IQueryable<Titulo> query = _context.Titulo
                 .Include(tp => tp.Pagador)
                 .Include(tr => tr.Recebedor);
               
            if (includeRecebedor && includePagador) {
                query = query
                  .Include(tp => tp.Pagador)
                 .Include(tr => tr.Recebedor);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Titulo[]> GetAllTitulosByNomeAsync(string nome, bool includeRecebedor = false, bool includePagador = false) {
            IQueryable<Titulo> query = _context.Titulo
                .Include(p => p.Pagador)
                .Include(p => p.Recebedor);
           

            if (includeRecebedor && includePagador) {
                query = query
                .Include(p => p.Pagador)
                .Include(p => p.Recebedor);


            }

            query = query.OrderBy(p => p.Id);

            query = query.OrderBy(p => p.Id)
                    .Where(p => p.Titulo_Descricao.ToLower().Contains(nome.ToLower()));


            return await query.ToArrayAsync();
        }

        public async Task<Titulo> GetTituloByIdAsync(int tituloId, bool includeRecebedor = false, bool includePagador = false) {

            IQueryable<Titulo> query = _context.Titulo
                .Include(p => p.Pagador)
                .Include(p => p.Recebedor);


            // Verificar a necessidade de colocar esse if.
            if (includeRecebedor && includePagador) {
                    query = query
                .Include(p => p.Pagador)
                .Include(p => p.Recebedor);


            }

            query = query.AsNoTracking().OrderBy(t => t.Id)
                    .Where(t => t.Id == tituloId);
            return await query.FirstOrDefaultAsync();
        }

    }
}
