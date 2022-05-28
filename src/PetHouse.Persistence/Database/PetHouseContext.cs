using Microsoft.EntityFrameworkCore;
using PetHouse.Domain.Usuarios;
using PetHouse.Persistence.Database.Mappers;

namespace PetHouse.Persistence.Database
{
    public sealed class PetHouseContext : DbContext
    {
        public PetHouseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        #region Save Methods
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new UsuarioTableMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
