using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrition.And.Exercise.Borders.Entities;

namespace Nutrition.And.Exercise.Data.ConfigurationMappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        /// EF Core - Fluent API
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            //builder.HasKey(x => x.Id);
            //builder.ToTable("Client");
            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
            builder.HasIndex(x => new { x.Nome });
        }
    }
}
