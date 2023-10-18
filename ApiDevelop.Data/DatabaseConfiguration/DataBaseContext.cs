
using ApiDevelop.Domain.Domains;
using Microsoft.EntityFrameworkCore;

namespace ApiDevelop.Data.DatabaseConfiguration
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }

        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasOne(p => p.Categoria)
                    .WithMany(c => c.Producto)
                    .HasForeignKey(c => c.CategoriaId);
                    //.HasConstraintName("fk_id_categoria");
            });
        }

    }
}
