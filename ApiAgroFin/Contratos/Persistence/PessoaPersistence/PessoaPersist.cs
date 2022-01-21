using ApiAgroFin.Data;
using ApiAgroFin.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos.Persistence.PessoaPersistence {
    public class PessoaPersist : IPessoaPersist {

        private readonly AppDbContext _context;

        public PessoaPersist(AppDbContext context) {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Pessoa[]> GetAllPessoasAsync(bool includeEndereco = false) {

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.Enderecos);

            if (includeEndereco) {
                query = query.Include(p => p.Enderecos);
                //ThenInclude(pe => pe.Palestrante); caso tenha mais de um include;
            }

            query = query.AsNoTracking().OrderBy(p => p.Pessoa_Id);

            return await query.ToArrayAsync();
        }
        public async Task<Pessoa[]> GetAllPessoasByNomeAsync(string nome, bool includeEndereco = false) {

            IQueryable<Pessoa> query = _context.Pessoa.Include(p => p.Enderecos);
            query = query.OrderBy(p => p.Pessoa_Id);
            if (includeEndereco) {
                query = query.Include(p => p.Enderecos);
                //ThenInclude(pe => pe.Palestrante); caso tenha mais de um include;
            }

            query = query.OrderBy(p => p.Pessoa_Id)
                    .Where(p => p.Pessoa_Nome.ToLower().Contains(nome.ToLower()));


            return await query.ToArrayAsync();
        }
      
        public async Task<Pessoa> GetPessoaByIdAsync(int pessoa_Id, bool includeEndereco = false) {

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.Enderecos);

            //Verificar a necessidade de colocar esse if.
            if (includeEndereco) {
                query = query
                    .Include(p => p.Enderecos);
                //ThenInclude(pe => pe.Palestrante); caso tenha mais de um include;
            }

            query = query.AsNoTracking().OrderBy(p => p.Pessoa_Id)
                    .Where(p => p.Pessoa_Id == pessoa_Id);


            return await query.FirstOrDefaultAsync();
        }

        
    }
}
