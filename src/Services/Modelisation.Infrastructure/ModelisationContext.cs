using Microsoft.EntityFrameworkCore;
using Modelisation.Domain.Base;
using Modelisation.Domain.SolutionAggregate;
using Modelisation.Infrastructure.EntityConfigurations;

namespace Modelisation.Infrastructure
{
    public class ModelisationContext : DbContext, IUnitOfWork
    {
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Emplacement> Emplacements { get; set; }
        public DbSet<Entite> Entites { get; set; }
        public DbSet<ElementDonnee> ElementDonnees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SolutionEntityConfiguration());
        }
    }
}