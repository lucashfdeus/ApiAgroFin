using ApiAgroFin.Data;
using ApiAgroFin.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos.Persistence.EnderecoPersistence {

        public class EnderecoPersistence : IEnderecoPersist{

        private readonly AppDbContext _context;

        public EnderecoPersistence(AppDbContext context) {
            _context = context;
        }

        public async Task<Endereco[]> GetAllEnderecoByNomeAsync(string cep) {

            IQueryable<Endereco> query = _context.Endereco.Include(e => e.Endereco_Cep);
            query = query.OrderBy(e => e.Endereco_Id)
                     .Where(e => e.Endereco_Cep.ToLower().Contains(cep.ToLower()));

            return await query.ToArrayAsync();

        }

        public async Task<Endereco[]> GetAllEnderecoAsync(bool includeEndereco = false) {

            IQueryable<Endereco> query = _context.Endereco
                 .Include(e => e.Endereco_Id);

            return await query.ToArrayAsync();
        }

        public async Task<Endereco> GetAllEnderecoByIdAsync(int Endereco_Id) {

            IQueryable<Endereco> query = _context.Endereco
               .Include(e => e.Endereco_Id);

            query = query.OrderBy(e => e.Endereco_Id)
                 .Where(e => e.Endereco_Id == e.Endereco_Id);


            return await query.FirstOrDefaultAsync();
        }
    }
}
