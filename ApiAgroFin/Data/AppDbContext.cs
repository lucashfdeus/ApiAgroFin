using ApiAgroFin.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAgroFin.Data {
    public class AppDbContext :DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        // Evento é Pessoa
        public DbSet<Pessoa> Pessoa { get; set; }
        //Lote é Endereco
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Titulo> Titulo { get; set; }
        public DbSet<Pagador> Pagador { get; set; }
        public DbSet<Recebedor> Recebedor { get; set; }





        //Relacionamento de (1-N)
        protected override void OnModelCreating(ModelBuilder builder) {

            builder.Entity<Pessoa>()
                .HasMany(p => p.Enderecos)
                .WithOne(p => p.pessoa)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Pagador>()
            //    .HasKey(pg => new { pg.Id, pg.Pessoa });

            //builder.Entity<Recebedor>()
            //   .HasKey(pgr => new { pgr.Id, pgr.Pessoa });


            builder.Entity<Titulo>()
                .HasOne(tp => tp.Pagador)
                .WithMany(t => t.ListaTilulosPagador);
            //.HasForeignKey(r => r.PagadorId);

            builder.Entity<Titulo>()
              .HasOne(tp => tp.Recebedor)
              .WithMany(t => t.ListaTilulosRecebedor);
             //.HasForeignKey(r => r.RecebedorId);


        }

    }
}
