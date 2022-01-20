using ApiAgroFin.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAgroFin.Data {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {


        }



        // Evento é Pessoa
        public DbSet<Pessoa> Pessoa { get; set; }
        //Lote é Endereco
        public DbSet<Endereco> Endereco { get; set; }

        //Relacionamento de (1-N)
        protected override void OnModelCreating(ModelBuilder builder) {

            //    //Relacionamento de (1-N)
            //    builder.Entity<Pessoa>()
            //        .HasOne(pessoa => pessoa.Enderecos)
            //        .WithMany(endereco => endereco.)
            //        .HasForeignKey(endereco => endereco.);
            //}
        } 
    }
}
