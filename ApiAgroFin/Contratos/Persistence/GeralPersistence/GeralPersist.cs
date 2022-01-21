using ApiAgroFin.Contratos.Persistence;
using ApiAgroFin.Data;
using System.Threading.Tasks;

namespace ApiAgroFin.Contratos.Persistence.GeralPersistence {
    public class GeralPersist : IGeralPersist {

        private readonly AppDbContext _context;

        public GeralPersist(AppDbContext context) {
            _context = context;
        }

        public void Add<T>(T entity) where T : class {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync() {
            
            return (await _context.SaveChangesAsync()) > 0;
        }
                
              
    }
}
