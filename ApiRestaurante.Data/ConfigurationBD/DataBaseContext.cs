using ApiRestaurante.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestaurante.Data.ConfigurationBD;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.Property(e => e.Id).HasColumnName("idcustomers");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .HasColumnName("apellido");
            entity.Property(e => e.Celular)
                .HasMaxLength(45)
                .HasColumnName("celular");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orden");

            entity.HasIndex(e => e.CustomerId, "fk_customer_idx");

            entity.Property(e => e.Id).HasColumnName("id_orden");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Plato)
                .HasMaxLength(45)
                .HasColumnName("plato");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");

            entity.HasOne(d => d.Customer).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
