using EksiSozluk.API.Domain.Entities;
using EksiSozluk.API.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Persistence.EntityFramework.Contexts
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<EmailConfirmation> EmailConfirmations { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryComment> EntryComments { get; set; }
        public DbSet<EntryCommentFavorite> EntryCommentFavorites { get; set; }
        public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }
        public DbSet<EntryFavorite> EntryFavorites { get; set; }
        public DbSet<EntryVote> EntryVotes { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<RoleOperationClaim> RoleOperationClaims { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApplicationContext(IConfiguration configuration, DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ApplicationConnectionString"]);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }


        public override int SaveChanges()
        {
            this.SetAddedBaseEntities(this.GetAddedBaseEntities());
            this.SetUpdatedBaseEntities(this.GetUpdateBaseEntities());
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.SetAddedBaseEntities(this.GetAddedBaseEntities());
            this.SetUpdatedBaseEntities(this.GetUpdateBaseEntities());
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.SetAddedBaseEntities(this.GetAddedBaseEntities());
            this.SetUpdatedBaseEntities(this.GetUpdateBaseEntities());
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.SetAddedBaseEntities(this.GetAddedBaseEntities());
            this.SetUpdatedBaseEntities(this.GetUpdateBaseEntities());
            return base.SaveChangesAsync(cancellationToken);
        }

        private IEnumerable<BaseEntity> GetAddedBaseEntities()
        {
            return ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added).Select(e => (BaseEntity)e.Entity).ToList();
        }

        private void SetAddedBaseEntities(IEnumerable<BaseEntity> baseEntities)
        {
            foreach (var baseEntity in baseEntities)
            {
                if(baseEntity.CreateDate == DateTime.MinValue )
                {
                    baseEntity.Id = Guid.NewGuid();
                    baseEntity.CreateDate = DateTime.Now;
                    baseEntity.ModifyDate = DateTime.Now;
                    baseEntity.IsActive = true;
                }
            }
        }

        private IEnumerable<BaseEntity> GetUpdateBaseEntities()
        {
            return ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Modified).Select(e => (BaseEntity)e.Entity).ToList();
        }

        private void SetUpdatedBaseEntities(IEnumerable<BaseEntity> baseEntities)
        {
            foreach (var baseEntity in baseEntities)
            { 
                baseEntity.ModifyDate = DateTime.Now;
            }
        }
    }
}
