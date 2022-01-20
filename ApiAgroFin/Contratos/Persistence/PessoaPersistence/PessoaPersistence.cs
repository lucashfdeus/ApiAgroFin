using ApiAgroFin.Data;
using ApiAgroFin.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos.Persistence.PessoaPersistence {
    public class PessoaPersistence : IPessoasPersist {

        private readonly AppDbContext _context;

        public PessoaPersistence(AppDbContext context) {
            _context = context;
        }

        public async Task<Pessoa[]> GetAllPessoasAsync(bool includeEndereco = false) {

            IQueryable<Pessoa> query = _context.Pessoa.Include(p => p.Enderecos);
            query = query.OrderBy(p => p.Pessoa_Id);

            if (includeEndereco) {
                query = query.Include(p => p.Enderecos);
                //ThenInclude(pe => pe.Palestrante); caso tenha mais de um include;
            }

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
        public async Task<Pessoa> GetPessoasByIdAsync(int Pessoa_Id, bool includeEndereco = false) {

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.Enderecos);

            if (includeEndereco) {
                query = query
                    .Include(p => p.Enderecos);
                //ThenInclude(pe => pe.Palestrante); caso tenha mais de um include;
            }

            query = query.OrderBy(p => p.Pessoa_Id)
                    .Where(p => p.Pessoa_Id == Pessoa_Id);


            return await query.FirstOrDefaultAsync();
        }

    }
}
