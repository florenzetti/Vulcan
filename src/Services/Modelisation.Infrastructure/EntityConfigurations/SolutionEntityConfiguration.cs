using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelisation.Domain.SolutionAggregate;

namespace Modelisation.Infrastructure.EntityConfigurations
{
    class SolutionEntityConfiguration : IEntityTypeConfiguration<Solution>
    {
        public void Configure(EntityTypeBuilder<Solution> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.Emplacements);
            builder.Metadata.FindNavigation(nameof(Solution.Emplacements)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
