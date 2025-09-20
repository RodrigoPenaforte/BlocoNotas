using Microsoft.EntityFrameworkCore;
using Backend.Domain.Models.Usuarios;
using Backend.Domain.Models.BlocoDeNotas;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Backend.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<Usuario, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Notas> Notas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usuario>(entity =>
           {
               entity.Property(e => e.Nome)
                     .IsRequired()
                     .HasMaxLength(150);
           });

            builder.Entity<Notas>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titulo).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Conteudo).IsRequired().HasMaxLength(2000);

                entity.HasOne(e => e.Usuario)
                      .WithMany(e => e.Notas)
                      .HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}