using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrition.And.Exercise.Borders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Data.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
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
